﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    public partial class GroupIndexGoogle : GroupIndex
    {
        public GroupIndexGoogle(string group_id) : base (group_id)
        {
            this.Name = group_id;

            this.UrlGroupIndex = MavenRepository.UrlGroupIndexDefault.Replace("GROUP_ID", group_id);

            return;
        }

        public string Name
        {
            get;
            set;
        }

        public override string UrlGroupIndex
        {
            get
            {
                string gid = this.Name.Replace(".", "/");
                string url = MavenRepository.UrlGroupIndexDefault.Replace("GROUP_ID", gid);

                return url;
            }
            set
            {

            }
        }

        public async
            Task<IEnumerable<(string name, string[] versions)>>
                                                GetArtifactNamesAndVersionsAsync
                                                    (
                                                    )
        {
            string response_string_xml = null;

            try
            {
                /*
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string response_body = await response.Content.ReadAsStringAsync();
                */
                // new helper method below
                response_string_xml = await MavenClient.HttpClient.GetStringAsync(this.UrlGroupIndex);
                this.Content = response_string_xml;
            }
            catch (HttpRequestException exc)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine($"GroupIndexGoogle.GetArtifactNamesAndVersionsAsync HttpRequestException");
                sb.AppendLine($"    Message : {exc.Message}");
                sb.AppendLine($"    UrlGroupIndex : {this.UrlGroupIndex}");

                System.Diagnostics.Trace.WriteLine(sb.ToString());

                throw;
            }

            IEnumerable<(string name, string[] versions)> result = null;
            result = ParseArtifactNamesAndVersionsFromXML(response_string_xml);

            return result;
        }

        public
            IEnumerable<(string name, string[] versions)>
                                                ParseArtifactNamesAndVersionsFromXML
                                                    (
                                                        string xml
                                                    )
        {
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            System.Xml.XmlNamespaceManager ns = new System.Xml.XmlNamespaceManager(xmldoc.NameTable);

            System.Xml.XmlNodeList node_list = xmldoc.SelectNodes($"/{this.Name}/*", ns);
            foreach (System.Xml.XmlNode xn in node_list)
            {
                string n = xn.Name;
                string[] vs = xn.Attributes["versions"].InnerXml.Split
                                                            (
                                                                new string[] { "," },
                                                                StringSplitOptions.RemoveEmptyEntries
                                                            );
                yield return (name: n, versions: vs);
            }
        }

        public 
            IEnumerable<Artifact>
                                                GetArtifacts
                                                    (
                                                        IEnumerable<(string name, string[] versions)> artifacts_textual
                                                    )
        {
            foreach((string name, string[] versions) at in artifacts_textual)
            {
                Artifact a = new Artifact
                                    {
                                        ArtifactId = at.name,
                                        VersionsTextual = (at.versions).ToList(),
                                        Versions = Artifact.GetVersions(at.versions)
                                                                .ToList()
                                                                //.OrderByDescending()
                                    };

                yield return a;
            }
        }

    }
}
