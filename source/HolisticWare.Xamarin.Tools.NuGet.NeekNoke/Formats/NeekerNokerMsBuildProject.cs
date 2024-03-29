using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

using HolisticWare.Xamarin.Tools.NuGet.NeekNoke;
using HolisticWare.Xamarin.Tools.NuGet.ServerAPI;

namespace HolisticWare.Xamarin.Tools.NuGet.NeekNoke.Formats;

public partial class
										NeekerNokerMsBuildProject
										:
										NeekerNokerBase
{
    public
        void
										NeekNoke
											(
												string pattern,
												string[] files
											)
	{
		// initialize result, so Add does not crash (parallel) and no Concurrent Collections are needed
		foreach (string file in files)
		{
            this.NeekNoker
					.ResultsPerFormat["MSBuild (Project Files, Property/Target Files)"]
                        .ResultsPerFilePattern[pattern]
							.ResultsPerFile
								.Add
									(
										file,
										new ResultsPerFile()
										{
											File = file
										}
									);
			}

        Parallel.ForEach
					(
						files,
						(file) =>
						{
							string file_new = null;
							string content_original = System.IO.File.ReadAllText(file);
							string content_new = null;

							string nuget_id = null;
							string version = null;
							string text_snippet_original = null;
							string text_snippet_new = null;

							XmlReader xreader = null;
                            XDocument xdoc = null;
							try
							{
								xreader = XmlReader.Create(new StreamReader(file));
                                xdoc = XDocument.Load(xreader);
                            }
							catch (System.Exception exc)
							{
								throw;
							}
							//------------------------------------------------------------------------------------------------------
							// PackageReference

							/*
							 
							 */
							Dictionary
									<
										(
											string nuget_id,
											string version
										),
										(
											string snippet_original,
											string snippet_new
										)
									>
									packages_with_versions_found;

							packages_with_versions_found = new Dictionary
																<
																	(
																		string nuget_id,
																		string version
																	),
																	(
																		string snippet_original,
																		string snippet_new
																	)
																>
																	();

                            // namespace manager that knows of the namespaces used in xreader
                            XmlNamespaceManager namespace_manager = new XmlNamespaceManager(xreader.NameTable);
							// add an explicit prefix mapping for query
							string xml_namespace = "http://schemas.microsoft.com/developer/msbuild/2003";
                            namespace_manager.AddNamespace("ns", xml_namespace);

                            IEnumerable<XElement> xe_package_references = null;
							xe_package_references =
													xdoc.XPathSelectElements
																		(
																			"//ns:PackageReference",
																			namespace_manager
																		);

							IEnumerable<XElement> xe_package_references_include_attribute = null;
							xe_package_references_include_attribute =
													xdoc.XPathSelectElements
																		(
																			"//ns:PackageReference[@Include]",
																			namespace_manager
																		);

							if
							(
								xe_package_references_include_attribute == null
								||
								!xe_package_references_include_attribute.Any()
							)
							{
								// No PackageReferences;
								return;
							}

							foreach (XElement xe in xe_package_references_include_attribute)
							{
								nuget_id = xe.Attribute("Include").Value;
							}

							/*
							 
							 */
							IEnumerable<XElement> xe_package_references_version_attribute = null;
							xe_package_references_version_attribute =
														xdoc.XPathSelectElements
																			(
																				"//ns:PackageReference[@Version]",
																				namespace_manager
																			);

							/*
							 
							 */
							IEnumerable<XElement> xe_package_references_version_node = null;
							xe_package_references_version_node = xdoc.XPathSelectElements
																			(
																				"//ns:PackageReference/ns:Version",
																				namespace_manager
																			);

							if
							(
								xe_package_references_version_attribute != null
								&&
								xe_package_references_version_attribute.Any()
							)
							{
								// There are Version (Attributes)
								foreach (XElement xe in xe_package_references_version_attribute)
								{
									version = xe.Attribute("Version").Value;
									string nuget_id_version_attribute = xe.Attribute("Include").Value;

									if 
										(
											! packages_with_versions_found.ContainsKey
																				(
																					(
																						nuget_id: nuget_id_version_attribute,
																						version: version
																					)
																				)
										)
									{
										packages_with_versions_found.Add
																		(
																			(
																				nuget_id: nuget_id_version_attribute,
																				version: version
																			),
																			(
																				snippet_original: null,
																				snippet_new: null
																			)
																		);
									}

								}
							}

							if
							(
								xe_package_references_version_node != null
								&&
								xe_package_references_version_node.Any()
							)
							{
								// There are Version (Nodes)
								foreach (XElement xe in xe_package_references_version_node)
								{
									if (xe.Name == "Version")
									{
										version = xe.Value;
										string nuget_id_version_node = xe.Parent.Attribute("Include").Value;
										packages_with_versions_found.Add
																		(
																			(
																				nuget_id: nuget_id_version_node,
																				version: version
																			),
																			(
																				snippet_original: null,
																				snippet_new: null
																			)
																		);
									}
								}
							}

							// Version is null or empty => Central Package Management
							if
							(
                                xe_package_references_include_attribute != null
								&&
                                xe_package_references_include_attribute.Any()
								&&
								(
									xe_package_references_version_attribute == null
									||
									(
										//xe_package_references_version_attribute != null
										//&&
										! xe_package_references_version_attribute.Any()
									)
								)
								&&
								(
									xe_package_references_version_node == null
									||
									(
										//xe_package_references_version_node != null
										//&&
										! xe_package_references_version_node.Any()
									)
								)
							)
							{
								// Central Package Management
							}
							else
							{
								// No PackageReferences
								// TODO: check packages.config
							}

							foreach (XElement xe in xe_package_references_version_attribute)
							{
								if (xe.Attribute("Version") == null)
								{
									continue;
								}

								nuget_id = xe.Attribute("Include").Value;
								version = xe.Attribute("Version").Value;
								text_snippet_original = xe
                                                        .ToString()
                                                        .Replace
                                                            (
                                                                $"xmlns=\"{xml_namespace}\" ",
                                                                ""
                                                            );

								this.NeekNoker
									.ResultsPerFormat["MSBuild (Project Files, Property/Target Files)"]
										.ResultsPerFilePattern[pattern]
											.ResultsPerFile[file]
			                                    .PackageReferences
													.Add
														(
															(
																nuget_id: nuget_id,
																version_current: version,
																versions_upgradeable: null,
																text_snippet_original: text_snippet_original,
																text_snippet_new: text_snippet_new
															)
														);
                            }

                            foreach (XElement xe in xe_package_references_version_node)
							{
								nuget_id = xe.Parent.Attribute("Include").Value;
                                version = xe.Value; //.Select(n => { return true; });
                                text_snippet_original = xe.Parent
																	.ToString()
																	.Replace
																		(
																			$"xmlns=\"{xml_namespace}\"",
																			""
																		);

                                this.NeekNoker
										.ResultsPerFormat["MSBuild (Project Files, Property/Target Files)"]
											.ResultsPerFilePattern[pattern]
												.ResultsPerFile[file]
													.PackageReferences
														.Add
	                                                        (
	                                                            (
	                                                                nuget_id: nuget_id,
	                                                                version_current: version,
	                                                                versions_upgradeable: null,
	                                                                text_snippet_original: text_snippet_original,
	                                                                text_snippet_new: text_snippet_new
	                                                            )
	                                                        );
                            }

                            if (nuget_id == null)
							{
								string msg = "nuget_id is null";
							}
                            //------------------------------------------------------------------------------------------------------
                            //------------------------------------------------------------------------------------------------------
                            // PackageVersion

                            //------------------------------------------------------------------------------------------------------
                            this.NeekNoker
		                            .ResultsPerFormat["MSBuild (Project Files, Property/Target Files)"]
										.ResultsPerFilePattern[pattern]
											.ResultsPerFile[file]
												.Log
													.Add
											            (
												            (
													            file_backup: file_new,
													            content: content_original,
													            content_backup: content_new
												            )
											            );
                            
                            // Console.WriteLine($"nuget_id:		{Environment.NewLine}			{nuget_id}");
                            // Console.WriteLine($"	version:			{Environment.NewLine}	{version}");
                            // Console.WriteLine($"		outer_xml:		{Environment.NewLine}	{outer_xml}");
                            
                            return;
						}

					);

		return;
	}
}
