using System;
using System.Runtime;
using System.Text.Json;
using Newtonsoft.Json.Serialization;

namespace Core.Serialization.JSON
{
	public static partial class
									JSON<T>
	{
		static
									JSON
										(
										)
		{
            Deserialize = DeserializeUsingSystemTextJson;
            DeserializeCustom = DeserializeUsingSystemTextJson;

            return;
		}

        public static
            Func<string, T>
                                    Deserialize;


        public static
            Func<string, Settings, T>
                                    DeserializeCustom;


        public static
            T
                                    DeserializeUsingSystemTextJson
                                        (
                                            string json
                                        )
        {
            T retval = default(T);

            retval = System.Text.Json.JsonSerializer.Deserialize<T>
                                                            (
                                                                json
                                                            );

            return retval;
        }

        public static
            T
                                    DeserializeUsingSystemTextJson
                                        (
                                            string json,
                                            Settings settings
                                        )
        {
            T retval = default(T);

            if (settings == null)
            {
                retval = DeserializeUsingSystemTextJson(json);
            }
            else
            {
                SettingsSystemTextJson s = settings as SettingsSystemTextJson;

                System.Text.Json.JsonSerializerOptions jso = null;

                jso = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = s.Settings
                };

                retval = System.Text.Json.JsonSerializer.Deserialize<T>
                                                                (
                                                                    json,
                                                                    jso                                                                );
            }

            return retval;
        }

        public static
            T
                                    DeserializeUsingNewtonsoftJson
                                        (
                                            string json
                                        )
        {
            T retval = default(T);

            retval = Newtonsoft.Json.JsonConvert.DeserializeObject<T>
                                                            (
                                                                json
                                                            );

            return retval;
        }

        public static
            T
                                    DeserializeUsingNewtonsoftJson
                                        (
                                            string json,
                                            Settings settings = null
                                        )
        {
            T retval = default(T);

            if (settings == null)
            {
                DeserializeUsingNewtonsoftJson(json);            }
            else
            {
                SettingsNewtonsoftJson s = settings as SettingsNewtonsoftJson;

                Newtonsoft.Json.Serialization.DefaultContractResolver dcr = s.Settings;

                Newtonsoft.Json.JsonSerializerSettings jss = new Newtonsoft.Json.JsonSerializerSettings
                {
                    ContractResolver = dcr,
                };

                retval = Newtonsoft.Json.JsonConvert.DeserializeObject<T>
                                                                (
                                                                    json,
                                                                    jss
                                                                );
            }

            return retval;
        }

        public static
            T
                                    DeserializeUsingJil
                                        (
                                            string json
                                        )
        {
            T retval = default(T);

            retval = Jil.JSON.Deserialize<T>
                                        (
                                            json
                                        );

            return retval;
        }

        public static
            T
                                    DeserializeUsingJil
                                        (
                                            string json,
                                            Settings settings = null
                                        )
        {
            T retval = default(T);

            if (settings == null)
            {
                DeserializeUsingJil(json);
            }
            else
            {
                throw new NotImplementedException("TODO: Jil ");
            }

            return retval;
        }
    }
}

