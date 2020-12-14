﻿// /*
//    Copyright (c) 2017-12
//
//    moljac
//    Test.cs
//
//    Permission is hereby granted, free of charge, to any person
//    obtaining a copy of this software and associated documentation
//    files (the "Software"), to deal in the Software without
//    restriction, including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the
//    Software is furnished to do so, subject to the following
//    conditions:
//
//    The above copyright notice and this permission notice shall be
//    included in all copies or substantial portions of the Software.
//
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// */

#if XUNIT
using Xunit;
// NUnit aliases
using Test = Xunit.FactAttribute;
using OneTimeSetUp = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
// XUnit aliases
using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
using TestContext = HolisticWare.Core.Testing.UnitTests.TestContext;
#elif NUNIT
using NUnit.Framework;
// MSTest aliases
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestProperty = NUnit.Framework.PropertyAttribute;
using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
// XUnit aliases
using Fact = NUnit.Framework.TestAttribute;
#elif MSTEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
// NUnit aliases
using Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
using OneTimeSetUp = Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute;
// XUnit aliases
using Fact = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
#endif

#if BENCHMARKDOTNET
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Attributes.Jobs;
#else
using Benchmark = HolisticWare.Core.Testing.BenchmarkTests.Benchmark;
using ShortRunJob = HolisticWare.Core.Testing.BenchmarkTests.ShortRunJob;
#endif

using System.Threading.Tasks;
using System.Collections.Generic;

using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

using HolisticWare.Xamarin.Tools.NuGet;

namespace UnitTests.NuGet
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_NugetPackage
    {
        [Test]
        public void Test_NuGet_NugetPackage_GetPackageMetadataAsync()
        {
            NuGetPackage.NugetClient = new NuGetClient();

            NuGetPackage np = new NuGetPackage()
            {
                PackageId = "Xamarin.AndroidX.Activity",
                VersionTextual = "1.1.0.4",
            };

            IEnumerable<IPackageSearchMetadata> result = null;
            result = np.GetPackageSearchMetadataAsync()
                            .Result;

            System.IO.Directory.CreateDirectory
                                    (
                                        $"nuget-client-api/NugetPackage/"
                                    );

            string timestamp = System.DateTime.Now.ToString("yyyyMMdd-HHmmssff");
            string json = null;

            json = Newtonsoft.Json.JsonConvert.SerializeObject
                                                    (
                                                        result,
                                                        Newtonsoft.Json.Formatting.Indented
                                                    );
            System.IO.File.WriteAllText
                                (
                                    $"nuget-client-api/NugetPackage/PackageSearchMetadata-{timestamp}.json",
                                    json
                                );

            //#if MSTEST
            //Assert.IsNotNull(search);
            //#elif NUNIT
            //Assert.NotNull(search);
            //#elif XUNIT
            //Assert.NotNull(search);
            //#endif


            return;
        }

        [Test]
        public void Test_NuGet_NugetPackage_GetDependencyTreeHierarchyAsync_AndroidX_MultiDex()
        {
            NuGetPackage.NugetClient = new NuGetClient();

            NuGetPackage np = new NuGetPackage()
            {
                PackageId = "Xamarin.AndroidX.MultiDex",
                VersionTextual = "2.1.0.5",
            };

            List<NuGetPackage> result = null;
            result = np.GetDependencyTreeHierarchyAsync()
                            .Result;

            System.IO.Directory.CreateDirectory
                                    (
                                        $"nuget-client-api/NugetPackage/"
                                    );

            string timestamp = System.DateTime.Now.ToString("yyyyMMdd-HHmmssff");
            string json = null;

            json = Newtonsoft.Json.JsonConvert.SerializeObject
                                                    (
                                                        result,
                                                        Newtonsoft.Json.Formatting.Indented
                                                    );
            System.IO.File.WriteAllText
                                (
                                    $"nuget-client-api/NugetPackage/DependencyTreeHierarchy-{timestamp}.json",
                                    json
                                );

            //#if MSTEST
            //Assert.IsNotNull(search);
            //#elif NUNIT
            //Assert.NotNull(search);
            //#elif XUNIT
            //Assert.NotNull(search);
            //#endif


            return;
        }

        [Test]
        public void Test_NuGet_NugetPackage_GetDependencyTreeHierarchyAsync_AndroidX_Migration()
        {
            NuGetPackage.NugetClient = new NuGetClient();

            NuGetPackage np = new NuGetPackage()
            {
                PackageId = "Xamarin.AndroidX.Migration",
                VersionTextual = "1.0.8",
            };

            List<NuGetPackage> result = null;
            result = np.GetDependencyTreeHierarchyAsync()
                            .Result;

            System.IO.Directory.CreateDirectory
                                    (
                                        $"nuget-client-api/NugetPackage/"
                                    );

            string timestamp = System.DateTime.Now.ToString("yyyyMMdd-HHmmssff");
            string json = null;

            json = Newtonsoft.Json.JsonConvert.SerializeObject
                                                    (
                                                        result,
                                                        Newtonsoft.Json.Formatting.Indented
                                                    );
            System.IO.File.WriteAllText
                                (
                                    $"nuget-client-api/NugetPackage/DependencyTreeHierarchy-{timestamp}.json",
                                    json
                                );

            //#if MSTEST
            //Assert.IsNotNull(search);
            //#elif NUNIT
            //Assert.NotNull(search);
            //#elif XUNIT
            //Assert.NotNull(search);
            //#endif


            return;
        }

        [Test]
        public void Test_NuGet_NugetPackage_GetDependencyTreeHierarchyAsync_AndroidX_Core()
        {
            NuGetPackage.NugetClient = new NuGetClient();

            NuGetPackage np = new NuGetPackage()
            {
                PackageId = "Xamarin.AndroidX.Core",
                VersionTextual = "1.3.2",
            };

            List<NuGetPackage> result = null;
            result = np.GetDependencyTreeHierarchyAsync()
                            .Result;

            System.IO.Directory.CreateDirectory
                                    (
                                        $"nuget-client-api/NugetPackage/"
                                    );

            string timestamp = System.DateTime.Now.ToString("yyyyMMdd-HHmmssff");
            string json = null;

            json = Newtonsoft.Json.JsonConvert.SerializeObject
                                                    (
                                                        result,
                                                        Newtonsoft.Json.Formatting.Indented
                                                    );
            System.IO.File.WriteAllText
                                (
                                    $"nuget-client-api/NugetPackage/DependencyTreeHierarchy-{timestamp}.json",
                                    json
                                );

            //#if MSTEST
            //Assert.IsNotNull(search);
            //#elif NUNIT
            //Assert.NotNull(search);
            //#elif XUNIT
            //Assert.NotNull(search);
            //#endif


            return;
        }

        //[Test]
        public void Test_NuGet_NugetPackage_GetDependencyTreeHierarchyAsync_AndroidX_Activity()
        {
            NuGetPackage.NugetClient = new NuGetClient();

            NuGetPackage np = new NuGetPackage()
            {
                PackageId = "Xamarin.AndroidX.Activity",
                VersionTextual = "1.1.0.4",
            };

            List<NuGetPackage> result = null;
            result = np.GetDependencyTreeHierarchyAsync()
                            .Result;

            System.IO.Directory.CreateDirectory
                                    (
                                        $"nuget-client-api/NugetPackage/"
                                    );

            string timestamp = System.DateTime.Now.ToString("yyyyMMdd-HHmmssff");
            string json = null;

            json = Newtonsoft.Json.JsonConvert.SerializeObject
                                                    (
                                                        result,
                                                        Newtonsoft.Json.Formatting.Indented
                                                    );
            System.IO.File.WriteAllText
                                (
                                    $"nuget-client-api/NugetPackage/DependencyTreeHierarchy-{timestamp}.json",
                                    json
                                );

            //#if MSTEST
            //Assert.IsNotNull(search);
            //#elif NUNIT
            //Assert.NotNull(search);
            //#elif XUNIT
            //Assert.NotNull(search);
            //#endif


            return;
        }
    }
}