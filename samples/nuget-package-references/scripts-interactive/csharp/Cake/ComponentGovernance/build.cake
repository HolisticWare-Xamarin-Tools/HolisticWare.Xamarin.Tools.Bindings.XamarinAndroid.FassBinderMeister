//  Cake.CoreCLR add to ./tools/ folder for debugging
#tool nuget:?package=Cake.CoreCLR

#addin nuget:?package=Newtonsoft.Json&version=12.0.3

#addin nuget:?package=HolisticWare.Xamarin.Tools.ComponentGovernance&version=0.0.1.1
#addin nuget:?package=HolisticWare.Core.Net.HTTP&version=0.0.1
#addin nuget:?package=HolisticWare.Core.IO&version=0.0.1

using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using HolisticWare.Xamarin.Tools.ComponentGovernance;

var TARGET = Argument ("t", Argument ("target", "Default"));

JArray binderator_json_array = null;

List<(string, string, string, string)> mappings_artifact_nuget = new List<(string, string, string, string)>();
Dictionary<string, string> Licenses = new Dictionary<string, string>();


// modifying default method for licenses
Manifest.Defaults.VersionBasedOnFullyQualifiedArtifactIdDelegate = delegate(string s)
{
    if 
        (
            fully_qualified_artifact_id.StartsWith("androidx")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.android.material")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.firebase")
            ||
            fully_qualified_artifact_id.StartsWith("org.jetbrains.kotlin")
            ||
            fully_qualified_artifact_id.StartsWith("org.jetbrains.kotlinx")
            ||
            fully_qualified_artifact_id.StartsWith("com.squareup")
            ||
            fully_qualified_artifact_id.StartsWith("io.grpc")
        )
    {
        const string l = "The Apache Software License, Version 2.0";
        const string u = "https://www.apache.org/licenses/LICENSE-2.0.txt";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if 
        (
            fully_qualified_artifact_id.StartsWith("com.google.android.gms")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.android.odml")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.android.ump")
        )
    {
        const string l = "Android Software Development Kit License";
        const string u = "https://developer.android.com/studio/terms";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if 
        (
            fully_qualified_artifact_id.StartsWith("org.chromium.net")
        )
    {
        const string l = "Chromium and built-in dependencies";
        const string u = "https://storage.cloud.google.com/chromium-cronet/android/72.0.3626.96/Release/cronet/LICENSE";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if 
        (
            fully_qualified_artifact_id.StartsWith("com.google.mlkit")
        )
    {
        const string l = "ML Kit Terms of Service";
        const string u = "https://developers.google.com/ml-kit/terms";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if
        (
            fully_qualified_artifact_id.StartsWith("com.google.android.play")
        )
    {
        const string l = "Play Core Software Development Kit Terms of Service";
        const string u = "https://developer.android.com/guide/playcore#license";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if 
        (
            fully_qualified_artifact_id.StartsWith("com.google.android.play")
        )
    {
        const string l = "Play Core Software Development Kit Terms of Service";
        const string u = "https://developer.android.com/guide/playcore#license";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }
    
    if 
        (
            fully_qualified_artifact_id.StartsWith("com.google.android.play")
        )
    {
        const string l = "Play Core Software Development Kit Terms of Service";
        const string u = "https://developer.android.com/guide/playcore#license";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if 
        (
            fully_qualified_artifact_id.StartsWith("com.google.protobuf")
        )
    {
        const string l = "BSD 2/3 Clause";
        const string u = "https://opensource.org/licenses/BSD-3-Clause";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }
    
        
    return null;
};


Task ("mappings-artifact-nuget")
    .Does
    (
        () =>
        {
            using (StreamReader reader = System.IO.File.OpenText(@"./config.json"))
            {
                JsonTextReader jtr = new JsonTextReader(reader);
                binderator_json_array = (JArray)JToken.ReadFrom(jtr);
            }

            foreach(JObject jo in binderator_json_array[0]["artifacts"])
            {
                bool? dependency_only = (bool?) jo["dependencyOnly"];
                if ( dependency_only == true)
                {
                    continue;
                }

                string group_id  	= (string) jo["groupId"];
                string artifact_id  = (string) jo["artifactId"];
                string artifact_v   = (string) jo["version"];
                string nuget_id  	= (string) jo["nugetId"];
                string nuget_v  	= (string) jo["nugetVersion"];

                mappings_artifact_nuget.Add
                (
                    (
                        $"{group_id}:{artifact_id}",
                        $"{artifact_v}",
                        $"{nuget_id}",
                        $"{nuget_v}"
                    )
                );
            }

            // dump for C# tuple initialization
            string dump = string.Join($",{Environment.NewLine}", mappings_artifact_nuget);
            dump = dump.Replace("(","(\"");
            dump = dump.Replace(")","\")");
            dump = dump.Replace(", ","\", \"");
            EnsureDirectoryExists("./output/");
			System.IO.File.WriteAllText($"./output/mappings-artifact-nuget.md", dump);


            Manifest manifest = new Manifest();

            manifest.MappingMavenArtifact2NuGetPackage = mappings_artifact_nuget;

            Console.WriteLine($"Saving ComponetGovernanceManifest cgmanifest.json...");
            manifest.Save("./cgmanifest.json");

            return;
        }
    );

Task ("Default")
    .IsDependentOn ("mappings-artifact-nuget")
    ;

RunTarget (TARGET);
