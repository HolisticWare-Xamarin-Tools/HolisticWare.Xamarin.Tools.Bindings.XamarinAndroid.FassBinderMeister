﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

using HolisticWare.Xamarin.Tools.GitHub;
using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator
{
    public class BinderatorConfigDownloader
    {
        public BinderatorConfigDownloader(HttpClient client)
        {
            HttpClient = client;

            return;
        }

        // HttpClient is intended to be instantiated once per application,
        // rather than per-use. See Remarks.
        public static HttpClient HttpClient
        {
            get;
            set;
        }

        public IEnumerable<QuickType.ConfigRoot> Configs
        {
            get;
            set;
        }

        public
            List
                <
                (
                    string GithubUserOrganization,
                    string RepositoryName,
                    string TagName
                )
                >
                           ConfigsNotFound
        {
            get;
            set;
        }

        public static List<string> GroupIdsNotFoundByMavenNet
        {
            get;
            set;
        }

        public async
            Task<Dictionary<string, IEnumerable<(Tag, List<ConfigRoot>)>>>
                                    DownloadAndExtendBinderatorConfigObjectsAsync
                                                            (
                                                                string user_org,
                                                                string repo,
                                                                string tag = null
                                                            )
        {
            Dictionary<string, IEnumerable<(Tag, List<ConfigRoot>)>> contents = null;

            contents = await DownloadBinderatorConfigObjectsAsync
                                                            (
                                                                user_org,
                                                                repo,
                                                                tag
                                                            );

            foreach (KeyValuePair<string, IEnumerable<(Tag tag, List<ConfigRoot>)>> c in contents)
            {
                string r = c.Key;
                List<(Tag tag, List<ConfigRoot> config_object)> tags_config_objects = new List<(Tag tag, List<ConfigRoot> config_object)>();
                foreach ((Tag tag, List<ConfigRoot> config_object) tag_content in c.Value)
                {
                    foreach (ConfigRoot cr in tag_content.config_object)
                    {
                        foreach (QuickType.Artifact a in cr.Artifacts)
                        {
                            string artifact_id = a.ArtifactId;
                            string artifact_id_version = a.Version;
                            string nuget_id = a.NugetId;
                            string nuget_version = a.NugetVersion;

                            List<IPackageSearchMetadata> package_metadata = null;
                            package_metadata = await a.GetPackageMetadataAsync()
                                                        .ConfigureAwait(false);
                        }
                    }
                }
            }

            return contents;
        }

        /// <summary>
        /// Download and deserialize BinderatorConfig objects from the repo of the user/organization
        /// and given tag list.
        /// </summary>
        /// <param name="user_org"></param>
        /// <param name="repo"></param>
        /// <param name="tag"></param>
        /// <returns>Dictionary of repo names with config objects for given tags</returns>
        public async
            Task<Dictionary<string, IEnumerable<(Tag, List<ConfigRoot>)>>>
                                    DownloadBinderatorConfigObjectsAsync
                                                            (
                                                                string user_org,
                                                                string repo,
                                                                string tag = null
                                                            )
        {
            Dictionary<string, IEnumerable<(Tag, string)>> contents = null;
            contents = await DownloadBinderatorConfigContentsAsync
                                                            (
                                                                user_org,
                                                                repo,
                                                                tag
                                                            );

            Dictionary<string, IEnumerable<(Tag, List<ConfigRoot>)>> config_objects = null;
            config_objects = new Dictionary<string, IEnumerable<(Tag, List<ConfigRoot>)>>();

            foreach (KeyValuePair<string, IEnumerable<(Tag tag, string content)>> c in contents)
            {
                string r = c.Key;
                List<(Tag tag, List<ConfigRoot> config_object)> tags_config_objects = null;
                tags_config_objects = new List<(Tag tag, List<ConfigRoot> config_object)>();

                foreach ((Tag tag, string content) tag_content in c.Value)
                {
                    FassBinderMeister.Binderator.QuickType.Artifact.HttpClient = HttpClient;
                    List<ConfigRoot> cr = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConfigRoot>>(tag_content.content);
                    tags_config_objects.Add((tag_content.tag, cr));
                }

                config_objects.Add(r, tags_config_objects);
            }

            return config_objects;
        }

        /// <summary>
        /// Download and deserialize BinderatorConfig objects from the repo of the
        /// user/organization and given tag list.
        /// </summary>
        /// <param name="user_org"></param>
        /// <param name="repo"></param>
        /// <param name="tag"></param>
        /// <returns>Dictionary of repo names with config objects for given tags</returns>
        public async
            Task<Dictionary<string, IEnumerable<(Tag, string)>>>
                                    DownloadBinderatorConfigContentsAsync
                                                            (
                                                                string user_org,
                                                                string repo,
                                                                string tag = null
                                                            )
        {
            if (string.IsNullOrEmpty(user_org))
            {
                return null;
            }

            List<string> repos = null;
            if (string.IsNullOrEmpty(repo))
            {
                repos = new List<string>
                {
                    "AndroidX",
                    "GooglePlayServiceComponents"
                };
            }

            Dictionary<string, IEnumerable<Tag>> tags_for_repo = null;
            ConfigsNotFound = new List
                                    <
                                    (
                                        string GithubUserOrganization,
                                        string RepositoryName,
                                        string TagName
                                    )
                                    >();

            tags_for_repo = new Dictionary<string, IEnumerable<Tag>>();
            Dictionary<string, IEnumerable<(Tag, string)>> tags_for_repo_content = null;
            GitHubClient gc = new GitHubClient(BinderatorConfigDownloader.HttpClient);

            if (string.IsNullOrEmpty(tag))
            {
                IEnumerable<Tag> tags = await gc.GetTagsAsync(user_org, repository: repo);

                tags_for_repo.Add(repo, tags);
            }
            else
            {
                IEnumerable<Tag> tags = await gc.GetTagsAsync(user_org, repository: repo, tag);

                tags_for_repo.Add(repo, tags);
            }

            tags_for_repo_content = new Dictionary<string, IEnumerable<(Tag, string)>>();

            foreach (string r in tags_for_repo.Keys)
            {
                List<(Tag, string)> list_tag_content = new List<(Tag, string)>();
                foreach (Tag t in tags_for_repo[r])
                {
                    string url_github = $"https://raw.githubusercontent.com/{user_org}/{r}/{t.Name}/config.json";

                    Trace.WriteLine($"Downloading tags: {url_github}"); 
                    System.Net.Http.HttpResponseMessage result = await HttpClient.GetAsync(url_github);
                    if(result.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // TODO: configs not found
                        ConfigsNotFound.Add
                            (
                                (
                                    GithubUserOrganization: user_org,
                                    RepositoryName: r,
                                    TagName: t.Name
                                )
                            );
                        continue;
                    }
                    string content = await result.Content
                                                    .ReadAsStringAsync()
                                                    .ConfigureAwait(false);
                    list_tag_content.Add((t, content));
                }

                tags_for_repo_content.Add(r, list_tag_content);
            }

            return tags_for_repo_content;
        }

    }
}
