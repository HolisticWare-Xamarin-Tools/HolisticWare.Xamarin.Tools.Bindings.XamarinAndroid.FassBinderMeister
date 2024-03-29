#tool nuget:?package=Cake.CoreCLR&loaddependencies=true&version=1.3.0

#addin nuget:?package=HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister&loaddependencies=true&version=0.0.1-alpha-202201162217
// #addin nuget:?package=HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven&loaddependencies=true&version=0.0.1-alpha-202201171924
// #addin nuget:?package=Newtonsoft.Json&loaddependencies=true&version=13.0.1
// #addin nuget:?package=Microsoft.AspNetCore.Mvc.Core&loaddependencies=true&version=2.2.5
// #addin nuget:?package=NuGet.Protocol&loaddependencies=true&version=6.0.0

using Newtonsoft.Json;

using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType;

var TARGET = Argument ("t", Argument ("target", "Default"));

Task("binderator-config-groups-new")
.Does
    (
        () =>
        {
            string path = "../../../data/binderator/**/config.json";
            FilePathCollection files_configs = GetFiles(path);
            foreach(FilePath f in files_configs)
            {
                string config_json = System.IO.File.ReadAllText(f.ToString());
                Information("------------------------------------------------------");
                Information($"File  = {f}");
                Information($"{config_json}");

                ConfigRoot cr = JsonConvert.DeserializeObject<ConfigRoot>(config_json);
            }
        }
    );


Task("Default")
.Does
    (
        () =>
        {
            RunTarget("binderator-config-groups-new");
        }
    );

RunTarget (TARGET);
