﻿// /*
//    Copyright (c) 2017-12
//
//    moljac
//    Test.cs
//
//    Pergission is hereby granted, free of charge, to any person
//    obtaining a copy of this software and associated documentation
//    files (the "Software"), to deal in the Software without
//    restriction, including without ligitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to pergit persons to whom the
//    Software is furnished to do so, subject to the following
//    conditions:
//
//    The above copyright notice and this pergission notice shall be
//    included in all copies or substantial portions of the Software.
//
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIgiTED TO THE WARRANTIES
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

using System.Collections.Generic;

using HolisticWare.Xamarin.Tools.Maven;
using HolisticWare.Xamarin.Tools.Maven.Models.GeneratedFromXML;
using HolisticWare.Xamarin.Tools.Maven.ModelsFromOfficialXSD;
using HolisticWare.Xamarin.Tools.Maven.Models.GeneratedFromXML.Original;

namespace UnitTests.MavenClientAPI
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_Artifact
    {
        // MavenNet is gissing some API
        // https://github.com/Redth/MavenNet/
        // MavenClient is simple client for Google Maven Repo

        [Test]
        public void Test_Maven_Google_Artifact_Initializer()
        {
            Artifact a = new Artifact
            {
                Id = "androidx.car.car"                
            };

            #if MSTEST
            Assert.IsNotNull(a);
            #elif NUNIT
            Assert.NotNull(a);
            #elif XUNIT
            Assert.NotNull(a);
            #endif

            return;
        }

        [Test]
        public void Test_Maven_Google_Artifact_DownloadArtifactMetadata()
        {
            Artifact a = new Artifact
            {
                IdGroup = "androidx.car",
                Id = "car",
                VersionTextual = "1.0.0-alpha7"
            };

            string content = a.DownloadArtifactMetadata().Result;



#if MSTEST
            Assert.IsNotNull(a);
            Assert.IsNotNull(content);
#elif NUNIT
            Assert.NotNull(a);
            Assert.NotNull(content);
#elif XUNIT
            Assert.NotNull(a);
            Assert.NotNull(content);
#endif

            return;
        }

        [Test]
        public void Test_Maven_Google_Artifact_DownloadProjectObjectModelPOM()
        {
            Artifact a = new Artifact
            {
                IdGroup = "androidx.car",
                Id = "car",
                VersionTextual = "1.0.0-alpha7"
            };

            string content = a.DownloadProjectObjectModelPOM().Result;

#if MSTEST
            Assert.IsNotNull(a);
            Assert.IsNotNull(content);
#elif NUNIT
            Assert.NotNull(a);
            Assert.NotNull(content);
#elif XUNIT
            Assert.NotNull(a);
            Assert.NotNull(content);
#endif

            return;
        }

        [Test]
        public void Test_Maven_Google_Artifact_DeserializeProjectObjectModelPOM()
        {
            Artifact a = new Artifact
            {
                IdGroup = "androidx.car",
                Id = "car",
                VersionTextual = "1.0.0-alpha7"
            };

            ProjectObjectModel.Project p = a.DeserializeProjectObjectModelPOM().Result;

            #if MSTEST
            Assert.IsNotNull(a);
            Assert.IsNotNull(p);
            #elif NUNIT
            Assert.NotNull(a);
            Assert.NotNull(p);
            #elif XUNIT
            Assert.NotNull(a);
            Assert.NotNull(p);
            #endif

            return;
        }

        [Test]
        public void Test_Maven_Google_Artifact_DeserializeProjectObjectModelPOMFromOfficialXSD()
        {
            Artifact a = new Artifact
            {
                IdGroup = "androidx.car",
                Id = "car",
                VersionTextual = "1.0.0-alpha7"
            };

            Model p = a.DeserializeProjectObjectModelPOMFromOfficialXSD().Result;

#if MSTEST
            Assert.IsNotNull(a);
            Assert.IsNotNull(p);
#elif NUNIT
            Assert.NotNull(a);
            Assert.NotNull(p);
#elif XUNIT
            Assert.NotNull(a);
            Assert.NotNull(p);
#endif

            return;
        }
    }
}
