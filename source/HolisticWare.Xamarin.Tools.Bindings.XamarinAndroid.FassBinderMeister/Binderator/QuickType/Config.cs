﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuHolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BinderatorickType;
//
//    var config = Config.FromJson(jsonString);

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Config
    {
        [JsonProperty("mavenRepositoryType")]
        public string MavenRepositoryType { get; set; }

        [JsonProperty("slnFile")]
        public string SlnFile { get; set; }

        [JsonProperty("additionalProjects")]
        public string[] AdditionalProjects { get; set; }

        [JsonProperty("templates")]
        public Template[] Templates { get; set; }

        [JsonProperty("artifacts")]
        public Artifact[] Artifacts { get; set; }

        public static Config[] FromJson(string json)
            =>
            JsonConvert.DeserializeObject<Config[]>(json, Converter.Settings);
    }

}
