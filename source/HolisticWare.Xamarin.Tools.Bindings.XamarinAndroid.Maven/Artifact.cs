﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven.Models.GeneratedFromXML.Original;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    /// <summary>
    /// 
    /// </summary>
    /// https://dl.google.com/android/maven2/androidx/arch/core/core-common/2.0.0/artifact-metadata.json
    /// dl.google.com/android/maven2/ artifact-metadata.json
    public partial class Artifact
    {
        public Artifact()
        {
            return;
        }

        public Artifact(string id_group, string id_artifact)
        {
            this.GroupId = id_group;
            this.ArtifactId = id_artifact;

            return;
        }

        public Artifact(string id_fully_qualified)
        {
            int idx = id_fully_qualified.LastIndexOf('.');

            this.GroupId = id_fully_qualified.Substring(0, idx);
            this.ArtifactId = id_fully_qualified.Substring(idx + 1, id_fully_qualified.Length - (idx + 1));

            return;
        }

       
        public string GroupId
        {
            get;
            set;
        }

        public string ArtifactId
        {
            get;
            set;
        }

        public string IdFullyQualified
        {
            get
            {
                return string.Concat(this.GroupId, ".", this.ArtifactId);
            }
            set
            {
            }
        }

        public string VersionTextual
        {
            get;
            set;
        }

        public System.Version Version
        {
            get;
            set;
        }

        public GroupIndex GroupIndex
        {
            get;
            set;
        }

        public List<string> VersionsTextual
        {
            get;
            set;
        }

        public List<System.Version> Versions
        {
            get;
            set;
        }

        public string ProjectObjectModelTextual
        {
            get;
            set;
        }

        public ModelsFromOfficialXSD.ProjectObjectModel ProjectObjectModel
        {
            get;
            set;
        }

        public List<Artifact> Dependencies
        {
            get;
            set;
        }





        public async
            Task<List<string>>
                                        GetVersionsFromGroupIndexAsync
                                                (
                                                )
        {
            GroupIndex gi = new GroupIndex(this.GroupId);

            IEnumerable<(string name, string[] versions)> artifacts_and_versions = null;

            artifacts_and_versions = await gi.GetArtifactNamesAndVersionsAsync();

            IEnumerable<string[]> artifact_versions_filtered = null;

            artifact_versions_filtered = 
                                from (string name, string[] versions) av in artifacts_and_versions
                                    where av.name == this.ArtifactId 
                                    select av.versions
                                ;

            List<string> result = artifact_versions_filtered.FirstOrDefault().Reverse().ToList();

            this.VersionsTextual = result;

            return result;
        }


        public static
            IEnumerable<System.Version>
                                        GetVersions
                                                (
                                                    IEnumerable<string> versions_textual
                                                )
        {
            foreach(string vt in versions_textual)
            {
                System.Version v;
                bool parsed = System.Version.TryParse(vt, out v);

                yield return v;
            }
        }

        public static
            IEnumerable<System.Version>
                                    GetVersionsOfBindingsNuGetPackage
                                                (
                                                    IEnumerable<string> versions_textual
                                                )
        {
            foreach (string vt in versions_textual)
            {

                System.Version v;
                bool parsed = System.Version.TryParse(vt, out v);

                yield return v;
            }
        }

        public async
            Task<string>
                                    DownloadArtifactMetadata
                                            (
                                            )
        {
            string gid = this.IdFullyQualified.Replace(".", "/");
            string v = this.VersionTextual;
            string url = $"https://dl.google.com/android/maven2/{gid}/{v}/artifact-metadata.json";

            string response = null;

            try
            {
                response = await MavenClient.HttpClient.GetStringAsync(url);
            }
            catch(Exception exc)
            {
                response = exc.Message;
            }

            return response;
        }

        public async
            Task<string>
                                    DownloadProjectObjectModelPOM
                                            (
                                            )
        {
            string id = this.ArtifactId;
            string idfq = this.IdFullyQualified.Replace(".", "/");
            string v = this.VersionTextual;
            string url = $"https://dl.google.com/android/maven2/{idfq}/{v}/{id}-{v}.pom";

            string response = await MavenClient.HttpClient.GetStringAsync(url);

            return response;
        }

        public async
            Task<ProjectObjectModel.Project>
                                    DeserializeProjectObjectModelPOM
                                            (
                                            )
        {
            string content = await DownloadProjectObjectModelPOM();

            System.Xml.Serialization.XmlSerializer xs = null;
            xs = new System.Xml.Serialization.XmlSerializer(typeof(ProjectObjectModel.Project));
            ProjectObjectModel.Project result;

            string id_g = this.GroupId;
            string id_a = this.ArtifactId;
            System.IO.File.WriteAllText($"{id_g}.{id_a}-pom.xml", content);

            using (System.IO.TextReader tr = new System.IO.StringReader(content))
            {
                result = (ProjectObjectModel.Project) xs.Deserialize(tr);
            }

            return result;
        }
        
        public async
            Task<ModelsFromOfficialXSD.ProjectObjectModel>
                                    DeserializeProjectObjectModelPOMFromOfficialXSD
                                            (
                                            )
        {
            string content = await DownloadProjectObjectModelPOM();

            System.Xml.Serialization.XmlSerializer xs = null;
            xs = new System.Xml.Serialization.XmlSerializer(typeof(ModelsFromOfficialXSD.ProjectObjectModel));
            ModelsFromOfficialXSD.ProjectObjectModel result;

            using (System.IO.TextReader tr = new System.IO.StringReader(content))
            {
                result = (ModelsFromOfficialXSD.ProjectObjectModel)xs.Deserialize(tr);
            }

            this.ProjectObjectModelTextual = content;
            this.ProjectObjectModel = result;

            return result;
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
                    content = this.SerializeToJSON_Newtonsoft();
                    break;
            }

            string type_name = this.GetType().FullName;
            string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmmss.ff");
            string filename = $"{type_name}-{timestamp}.{format}";
            //System.IO.File.WriteAllText(filename, content);
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(filename))
            {
                await writer.WriteAsync(content);
            }

            return;
        }

    }
}