#tool   nuget:?package=Cake.CoreCLR

#addin  nuget:?package=System.Text.Json&loaddependencies=true

#addin  nuget:?package=HolisticWare.Xamarin.Tools.NuGet&prerelease&loaddependencies=true

#addin  nuget:?package=HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI&loaddependencies=true
#addin  nuget:?package=HolisticWare.Xamarin.Tools.NuGet.Client.Core&prerelease&loaddependencies=true



// using NuGetClient = HolisticWare.Xamarin.Tools.NuGet.ServerAPI.NuGetClient;
// using VersionsData=HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.Versions.Root;
// using PackageRegistrationData=HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration.Root;
// using NuSpecData=HolisticWare.Xamarin.Tools.NuGet.NuSpec.Generated.Microsoft.package;

using System.Net;
using System.Net.Http;

using HolisticWare.Xamarin.Tools.NuGet.ServerAPI;


                HttpClientHandler handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };

                HolisticWare.Xamarin.Tools.NuGet.ServerAPI
                                                .NuGetClient.HttpClient = new HttpClient(handler);
                
string nuget_id = null;
NuGetPackage np = null;
string versions = null;


nuget_id = "Xamarin.AndroidX.Browser";

                np = 
                                    //await
                                    HolisticWare.Xamarin.Tools.NuGet.ServerAPI
                                                .NuGetPackage.Utilities
                                                            .GetNuGetPackageFromRegistrationAsync(nuget_id)
                                                            .Result
                                                            ;

                Console.WriteLine($"nuget_id:    {nuget_id}");
                versions = string.Join
                                    (
                                        $"\t{Environment.NewLine}\t\t",
                                        np.VersionsDates
                                            .Select(kv => kv.Key + "\t = \t " + kv.Value.ToString("yyyy-MM-dd hh:mm:ss"))
                                                .ToArray()
                                    );

                Console.WriteLine(versions);


nuget_id = "Xamarin.AndroidX.Activity";

                np = 
                                    //await
                                    HolisticWare.Xamarin.Tools.NuGet.ServerAPI
                                                .NuGetPackage.Utilities
                                                            .GetNuGetPackageFromRegistrationAsync(nuget_id)
                                                            .Result
                                                            ;

                Console.WriteLine($"nuget_id:    {nuget_id}");
                versions = string.Join
                                    (
                                        $"\t{Environment.NewLine}\t\t",
                                        np.VersionsDates
                                            .Select(kv => kv.Key + "\t = \t " + kv.Value.ToString("yyyy-MM-dd hh:mm:ss"))
                                                .ToArray()
                                    );

                Console.WriteLine(versions);

