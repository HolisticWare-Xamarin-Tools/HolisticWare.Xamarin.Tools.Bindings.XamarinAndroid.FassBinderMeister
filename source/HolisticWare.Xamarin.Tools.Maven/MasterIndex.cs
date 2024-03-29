﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven
{
    /// <summary>
    /// MasterIndex - index of all group ids
    /// Google                  Maven Repository     -   available
    /// MavenCentralSonatype    Maven Repository     -   not available
    /// MavenCentralSonatype    Maven Repository     -   built from HTML
    /// </summary>
    public partial class MasterIndex
    {
        public Repository Repository
        {
            get;
            set;
        }

        public virtual string Content
        {
            get;
            set;
        }

        public virtual IEnumerable<string> GroupsTextual
        {
            get;
            set;
        }

        public virtual IEnumerable<Maven.Group> Groups
        {
            get;
            set;
        }

        public virtual string Url
        {
            get;
            set;
        }


        public virtual async
            Task<IEnumerable<string>>
                                                GetGroupsTextualAsync
                                                    (
                                                    )
        {
            List<string> result = new List<string>();

            return result;
        }

        public virtual async
            Task<IEnumerable<Maven.Group>>
                                                GetGroupsAsync
                                                    (
                                                    )
        {
            List<Maven.Group> groups = new List<Maven.Group>();

            return groups;
        }

    }
}
