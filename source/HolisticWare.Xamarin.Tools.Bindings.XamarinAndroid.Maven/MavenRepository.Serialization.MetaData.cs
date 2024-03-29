﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    // POCO class with Metadata for Buddy Class containing attributes
    //[
        //Microsoft.AspNetCore.Mvc.ModelMetadataType
        //System.ComponentModel.DataAnnotations.MetadataType
        //Core.Serialization.ModelMetadataType
        //(
            //typeof(Serialization.Formatters.MavenRepository)
            //typeof(MavenRepositorySerializationMetadata)
        //)
    //]
    public partial class MavenRepository
    {
        public partial class MavenRepositorySerializationMetadata
        {
            [Newtonsoft.Json.JsonProperty("master_index", Order = 1)]
            [System.Text.Json.Serialization.JsonPropertyName("master_index")]
            // System.Text.Json.Serialization.Json
            //  does not have Order Property
            // https://stackoverflow.com/questions/59134564/net-core-3-order-of-serialization-for-jsonpropertyname-system-text-json-seria
            [System.Xml.Serialization.XmlElement
                                            (
                                                ElementName = "master_index",
                                                Namespace = "http://holisticware.net"
                                            )
            ]
            public MasterIndex MasterIndex
            {
                get;
                set;
            }

        }
    }
}
