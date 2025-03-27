using System;
using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.GitHub
{
    public partial class
                                        Commit
    {
        [JsonProperty("sha")]
        public string
                                        Sha
        {
            get;
            set;
        }

        [JsonProperty("url")]
        public Uri
                                        Url
        {
            get;
            set;
        }

        public
                                        Commit
                                        (
                                        )
        {
        }
    }

}
