﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype
{
    public partial class Repository : Maven.Repository
    {
        public Repository() : base()
        {
            this.UrlRoot = Repositories.MavenCentralSonatype.Repository.UrlRootDefault;

            return;
        }

        static Repository()
        {
            // Maven Central Sonatype
            // root url
            url_root_default = new Uri($"https://repo1.maven.org/maven2");

            // Maven Central Sonatype
            // search url
            url_search_default = new Uri($"https://search.maven.org/solrsearch/select?q=_PLACEHOLDER_SEARCH_TERM_&start=0&rows=_PLACEHOLDER_SEARCH_RESULTS_");


            // Maven Central Sonatype
            // master index - must be built/implemented
            url_master_index_default = null;

            return;
        }

        public static Uri UrlRootDefault
        {
            get
            {
                return url_root_default;
            }
            set
            {
                url_root_default = value;

                return;
            }
        }

        public static new Uri UrlMasterIndexDefault
        {
            get
            {
                return url_master_index_default;
            }
            set
            {
                url_master_index_default = value;

                return;
            }
        }

        public static Uri UrlSearchDefault
        {
            get
            {
                return url_search_default;
            }
            set
            {
                url_search_default = value;

                return;
            }
        }

        public virtual async
            Task<SearchData>
                                            Search
                                                    (
                                                        string search_term,
                                                        int search_results_count = 20
                                                    )
        {
            SearchData result = null;

            // Discovery

            return result;
        }

    }
}
