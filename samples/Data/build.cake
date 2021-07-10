// #tool "dotnet:?package=dotnet-xscgen"
// #tool "dotnet:?package=ddotnet-xdt"


// https://api.met.no/weatherapi/locationforecast/2.0/schema


FilePath input_path = null;
FilePath output_path = null;
int  exit_code = -1;

string ns_root = null;
string ns = ns_root = null;

EnsureDirectoryExists("./nuspec/");



input_path = "./nuspec/microsoft-nuget/nuspec.xsd";
output_path = "./nuspec/microsoft-nuget/";
EnsureDirectoryExists($"{output_path}");
ns_root = "HolisticWare.Tools.NuGet";
ns = ns_root 
        + "." +
        "Nuspec.Microsoft.Generated"
        ;
exit_code = StartProcess
                (
                    "xsd",
                    new ProcessSettings
                    {
                        Arguments =
                            $"{input_path}"
                            + " " +
                            "/classes"
                            + " " +
                            $"/namespace:{ns}"
                            + " " +
                            "/language:CS"
                            + " " +
                            $"/outputdir:{output_path}"
                    }
                );                
CopyFile
(
    input_path.ToString().Replace("xsd", "cs"),
    "../../source/HolisticWare.Xamarin.Tools.NuGet.Client.Core/Models/NuSpec/Microsoft/Generated/nuspec.cs"
);


input_path = "./nuspec/sharwell/nuspec.xsd";
output_path = "./nuspec/sharwell/";
EnsureDirectoryExists($"{output_path}");
ns = ns_root 
        + "." +
        "NuGet.Nuspec.Sharwell.Generated"
        ;
exit_code = StartProcess
                (
                    "xsd",
                    new ProcessSettings
                    {
                        Arguments =
                            $"{input_path}"
                            + " " +
                            "/classes"
                            + " " +
                            $"/namespace:{ns}"
                            + " " +
                            "/language:CS"
                            + " " +
                            $"/outputdir:{output_path}"
                    }
                );                
CopyFile
(
    input_path.ToString().Replace("xsd", "cs"),
    "../../source/HolisticWare.Xamarin.Tools.NuGet.Client.Core/Models/NuSpec/Sharwell/Generated/nuspec.cs"
);


input_path = "./nuspec/myget/nuspec.xsd";
output_path = "./nuspec/myget/";
EnsureDirectoryExists($"{output_path}");
ns = ns_root 
        + "." +
        "NuGet.Nuspec.MyGet.Generated"
        ;
exit_code = StartProcess
                (
                    "xsd",
                    new ProcessSettings
                    {
                        Arguments =
                            $"{input_path}"
                            + " " +
                            "/classes"
                            + " " +
                            $"/namespace:{ns}"
                            + " " +
                            "/language:CS"
                            + " " +
                            $"/outputdir:{output_path}"
                    }
                );                
CopyFile
(
    input_path.ToString().Replace("xsd", "cs"),
    "../../source/HolisticWare.Xamarin.Tools.NuGet.Client.Core/Models/NuSpec/MyGet/Generated/nuspec.cs"
);



input_path = "./pom/pom.xsd";
output_path = "./pom/";
EnsureDirectoryExists($"{output_path}");
ns_root = "HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven";
ns = ns_root 
        + "." +
        "Models.Repositories.Maven.ProjectObjectModel.POM.Generated"
        ;
exit_code = StartProcess
                (
                    "xsd",
                    new ProcessSettings
                    {
                        Arguments =
                            $"{input_path}"
                            + " " +
                            "/classes"
                            + " " +
                            $"/namespace:{ns}"
                            + " " +
                            "/language:CS"
                            + " " +
                            $"/outputdir:{output_path}"
                    }
                );                
CopyFile
(
    "./pom/pom.cs",
    "../../source/HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven/Models/Data/ProjectObjectModel.POM/Generated/pom.cs"
);


EnsureDirectoryExists("./maven-central/");
input_path = "./maven-central/artifact-id-fully-qualified/maven-central.xsd";
output_path = "./maven-central/artifact-id-fully-qualified/";
ns = ns_root 
        + "." +
        "Maven.Repositories.MavenCentral.Artifact.Generated"
        ;
exit_code = StartProcess
                (
                    "xsd",
                    new ProcessSettings
                    {
                        Arguments =
                            $"{input_path}"
                            + " " +
                            "/classes"
                            + " " +
                            $"/namespace:{ns}"
                            + " " +
                            "/language:CS"
                            + " " +
                            $"/outputdir:{output_path}"
                    }
                );                
CopyFile
(
    "./maven-central/artifact-id-fully-qualified/maven-central.cs",
    "../../source/HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven/Models/Repositories/MavenCentral/Generated/maven-central.cs"
);


EnsureDirectoryExists("./maven-google/");
