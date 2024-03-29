﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using global::NuGet.Protocol.Core.Types;
using HolisticWare.Xamarin.Tools.NuGet;
using NuGet.Packaging.Core;
using NuGet.Protocol;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuHolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BinderatorickType;
//
//    var config = Config.FromJson(jsonString);

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType
{
    public partial class Artifact
    {
        NuGet.ClientAPI.NuGetClient ngc = null;

        IEnumerable<IPackageSearchMetadata> package_metadata = null;

        [Newtonsoft.Json.JsonIgnore]
        public IEnumerable<IPackageSearchMetadata> NugetPackageMetadata
        {
            get
            {
                return package_metadata;
            }
            set
            {
                package_metadata = value;
            }
        }

        public async
            Task<List<IPackageSearchMetadata>>
                            GetPackageMetadataAsync
                                            (
                                            )
        {
            package_metadata = await ngc.GetPackageMetadataAsync(this.NugetId);

            List<string> nuget_versions = new List<string>();

            foreach (PackageSearchMetadataRegistration pmd in package_metadata)
            {
                global::NuGet.Versioning.NuGetVersion nv = pmd.Version;
                nuget_versions.Add(nv.OriginalVersion.ToString());

                List<(string TargetFramework, List<string> Packages)> list = null;
                list = new List<(string TargetFramework, List<string> Packages)>();

                foreach (global::NuGet.Packaging.PackageDependencyGroup dependency in pmd.DependencySets)
                {
                    list.Add
                        (
                            (
                                TargetFramework: dependency.TargetFramework.Framework,
                                Packages:
                                (
                                    from PackageDependency p in dependency.Packages
                                            select p.Id
                                )
                                .ToList()
                            )
                        );
                }

                this.NugetIdDependencies = list;
            }

            nuget_versions.Reverse();

            this.NugetVersions = nuget_versions;

            MavenNet.GoogleMavenRepository repo_google = MavenNet.MavenRepository.FromGoogle();
            try
            {
                await repo_google.Refresh(this.GroupId);
            }
            catch (System.Exception exc)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine($"Binderator.Artifact.GetPackageMetadataAsync Exception");
                sb.AppendLine($"    NugetId     : {this.NugetId}");
                sb.AppendLine($"    GroupId     : {this.GroupId}");
                sb.AppendLine($"    MavenNet    : Google");
                sb.AppendLine($"    Exception   : {exc.GetType()}");
                sb.AppendLine($"    Message     : {exc.Message}");

                System.Diagnostics.Trace.WriteLine(sb.ToString());

                if (this.GroupId == "com.xamarin.androidx")
                {
                    string msg1 = "com.xamarin.androidx";
                }

                if (BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet == null)
                {
                    BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet = new List<string>();
                }
                BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet.Add(this.GroupId);

                //throw;
            }

            MavenNet.MavenCentralRepository repo_central = MavenNet.MavenRepository.FromMavenCentral();
            try
            {
                await repo_central.Refresh(this.GroupId);
            }
            catch (System.Exception exc)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine($"Binderator.Artifact.GetPackageMetadataAsync Exception");
                sb.AppendLine($"    NugetId     : {this.NugetId}");
                sb.AppendLine($"    GroupId     : {this.GroupId}");
                sb.AppendLine($"    MavenNet    : Maven Central");
                sb.AppendLine($"    Exception   : {exc.GetType()}");
                sb.AppendLine($"    Message     : {exc.Message}");

                System.Diagnostics.Trace.WriteLine(sb.ToString());

                if (BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet == null)
                {
                    BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet = new List<string>();
                }

                BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet.Add(this.GroupId);

                //throw;
            }

            return this.package_metadata.ToList();

            /*
            // https://github.com/Redth/MavenNet/blob/master/MavenNet.Tests/Test.cs
            // no API?
            await repo.LoadMetadataAsync();

            // https://github.com/Redth/MavenNet#usage
            // No API?
            foreach (var item in repo.Metadata)
            {
                foreach (var version in item.AllVersions)
                {
                }
            }
            */

            try
            {
                MavenNet.Models.Project project = await repo_google.GetProjectAsync
                                                                        (
                                                                            this.GroupId,
                                                                            this.ArtifactId,
                                                                            this.Version
                                                                        )
                                                                        .ConfigureAwait(false);
            }
            catch (System.Exception exc)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine($"Binderator.Artifact.GetPackageMetadataAsync Exception");
                sb.AppendLine($"    NugetId     : {this.NugetId}");
                sb.AppendLine($"    GroupId     : {this.GroupId}");
                sb.AppendLine($"    MavenNet    : Google");
                sb.AppendLine($"    Exception   : {exc.GetType()}");
                sb.AppendLine($"    Message     : {exc.Message}");

                System.Diagnostics.Trace.WriteLine(sb.ToString());

                if (BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet == null)
                {
                    BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet = new List<string>();
                }

                BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet.Add(this.GroupId);

                return this.package_metadata.ToList();
            }

            try
            {
                MavenNet.Models.Project project = await repo_central.GetProjectAsync
                                                                        (
                                                                            this.GroupId,
                                                                            this.ArtifactId,
                                                                            this.Version
                                                                        )
                                                                        .ConfigureAwait(false);
            }
            catch (System.Exception exc)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine($"Binderator.Artifact.GetPackageMetadataAsync Exception");
                sb.AppendLine($"    NugetId     : {this.NugetId}");
                sb.AppendLine($"    GroupId     : {this.GroupId}");
                sb.AppendLine($"    MavenNet    : Maven Central");
                sb.AppendLine($"    Exception   : {exc.GetType()}");
                sb.AppendLine($"    Message     : {exc.Message}");

                System.Diagnostics.Trace.WriteLine(sb.ToString());

                if (BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet == null)
                {
                    BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet = new List<string>();
                }

                BinderatorConfigDownloader.GroupIdsNotFoundByMavenNet.Add(this.GroupId);

                return this.package_metadata.ToList();
            }

            return this.package_metadata.ToList();
        }

        public async
            Task<IEnumerable<IPackageSearchMetadata>>
                            GetNugetPackageMetadataAsync
                                            (
                                                string nuget_id
                                            )
        {
            package_metadata = await ngc.GetPackageMetadataAsync(nuget_id);

            return package_metadata;
        }
    }
}
