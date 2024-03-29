﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
    public partial class GoogleMavenData
    {
        public GoogleMavenData()
        {
            //Repositories = new List<MavenNet.MavenRepository>();
            Projects = new List<MavenNet.Models.Project>();
            Dependencies = new List<MavenNet.Models.Dependency>();

            return;
        }

        public string Name
        {
            get;
            set;
        }


        public Configurator Configurator
        {
            get;
            set;
        }

        public List<string> RepositoryNames
        {
            get;
            set;
        }

        public List<MavenNet.Models.Repository> Repositories
        {
            get;
            protected set;
        }

        public List<MavenNet.Models.Project> Projects
        {
            get;
            set;
        }

        public List<MavenNet.Models.Dependency> Dependencies
        {
            get;
            set;
        }

        public void Initialize()
        {
            this.Configurator = Load();

            return;
        }

        public Binderator.BinderatorConfigDownloader BinderatorConfig
        {
            get;
            set;
        }

        protected static string filename = "GoogleMavenData.json";

        public Configurator Load()
        {
            Configurator data = null;

            if (!System.IO.File.Exists(filename))
            {
            }
            else
            {
                string content = System.IO.File.ReadAllText(filename);
                data = Newtonsoft.Json.JsonConvert.DeserializeObject<Configurator>(content);
            }

            return data;
        }

        public async
            Task
                            SaveAsync
                                        (
                                            string format = "json"
                                        )
        {
            string content = null;

            switch (format)
            {
                case "json":
                default:
                    content = GoogleMavenData.SerializeToJSON_Newtonsoft(this);
                    break;
            }

            string type_name = this.GetType().Name;
            string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmm");
            string filename = $"{type_name}-{timestamp}.{format}";
            //System.IO.File.WriteAllText(filename, content);
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(filename))
            {
                await writer.WriteAsync(content);
            }

            return;
        }

        public async
            void
                                LoadRemoteReposAsync
                                            (
                                            )
        {
            Trace.WriteLine($"downloading ...");
            this.Configurator = new Configurator();

            IEnumerable<Models.Repository> repositories = LoadMavenRepositories(RepositoryNames);

            await this.SaveAsync();

            return;
        }

        public IEnumerable<Models.Repository> LoadMavenRepositories(IEnumerable<string> repos)
        {
            MavenNet.MavenRepository mr = MavenNet.MavenRepository.FromGoogle();

            if (repos == null)
            {
                mr.Refresh();
                repos = new string[] { "Google Full Download" };
            }

            foreach (string r in repos)
            {
                Trace.WriteLine($"  repository = {r}");

                Task.WaitAll(mr.Refresh(r));

                Models.Repository repository = new Models.Repository()
                {
                    Id = r
                };

                foreach (MavenNet.Models.Group g in mr.Groups)
                {
                    Trace.WriteLine($"      group = {g}");
                    string g_id = g.Id;


                    Models.Group group = new Models.Group()
                    {
                        Id = g_id
                    };

                    foreach (MavenNet.Models.Artifact a in g.Artifacts)
                    {
                        string a_id = a.Id;

                        Trace.WriteLine($"          artifact = {a_id}");

                        if (!ArtifactsToBind.Exists(id => id == a_id))
                        {
                            Trace.WriteLine($"              skipped - not listed for bindings");
                            continue;
                        }

                        Models.Artifact artifact = new Models.Artifact()
                        {
                            Id = a_id
                        };

                        foreach (string v in a.Versions.OrderByDescending(i => i))
                        {
                            Trace.WriteLine($"              version = {v}");

                            Models.Version version = new Models.Version()
                            {
                                Value = v
                            };

                            try
                            {
                                MavenNet.Models.Project mp = mr.GetProjectAsync
                                                                            (
                                                                                g.Id,
                                                                                a.Id,
                                                                                v
                                                                            ).Result;

                                this.Projects.Add(mp);
                                (string ArtifactId, string Version) dependency;
                                foreach (var d in mp.Dependencies)
                                {
                                    dependency = (ArtifactId: d.ArtifactId, Version: d.Version);
                                    version.Dependencies.Add(dependency);

                                    Trace.WriteLine($"                  dependency = {d.ArtifactId}");
                                    Trace.WriteLine($"                      versoin = {d.Version}");

                                }
                            }
                            catch (Exception exc)
                            {
                                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                sb.AppendLine($"GoogleMavenData.LoadMavenRepositories Exception");
                                sb.AppendLine($"    Message : {exc.Message}");
                                sb.AppendLine($"    Not found {g.Id} {a.Id} {v}");

                                System.Diagnostics.Trace.WriteLine(sb.ToString());
                            }


                            artifact.Versions.Add(version);
                        }

                        group.Artifacts.Add(artifact);
                    }

                    repository.Groups.Add(group);
                }

                //Repositories.Add(mr);
                this.Configurator.Repositories.Add(repository);

                yield return repository;
            }
        }

        public List<string> ArtifactsToBind
        {
            get;
            set;
        }

        public static MavenNet.GoogleMavenRepository GoogleMavenRepositoryData
        {
            get;
            set;
        }

        protected static string filename_google_repo = null;
        protected static string content_json_google_repo = null;

        public static async Task LoadAsync(bool local = true)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmm");
            filename_google_repo = $"maven.google.com.{timestamp}.json";

            Trace.WriteLine($"Downloading data from maven.google.com to: {filename_google_repo}");

            if (File.Exists(filename_google_repo) && local == true)
            {
                content_json_google_repo = File.ReadAllText(filename_google_repo);
            }
            else
            {
                GoogleMavenRepositoryData = MavenNet.MavenRepository.FromGoogle();
                await GoogleMavenRepositoryData.Refresh();

                content_json_google_repo = JsonConvert.SerializeObject
                                                            (
                                                                GoogleMavenRepositoryData,
                                                                Formatting.Indented,
                                                                new JsonSerializerSettings()
                                                                {
                                                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                                }
                                                            );

                File.WriteAllText(filename_google_repo, content_json_google_repo);
            }

            Trace.WriteLine($"  Data saved: {filename_google_repo}");

            return;
        }
    }
}
