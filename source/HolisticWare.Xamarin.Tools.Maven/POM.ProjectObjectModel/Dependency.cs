﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel
{
	public partial class ProjectObjectModel
	{
		public partial class Dependency
		{
			public string GroupId
			{ get; set; }

			public string ArtifactId
			{ get; set; }

			public string Version
			{ get; set; }

			public string Scope
			{ get; set; }
		}
	}
}
