﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using System.IO;
using Scryber.Components;

namespace Scryber.Core.UnitTests.Configuration
{
    /// <summary>
    /// Tests the configuration with any appsettings.json
    /// </summary>
    [TestClass()]
    public class SetConfig_Test
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public void ConfigClassCleanup()
        {
            var config = ServiceProvider.GetService<IScryberConfigurationService>();
            config.Reset();

            ServiceProvider.Init(true); 

            var service = ServiceProvider.GetService<IConfiguration>();

            Assert.IsNull(service, "The config service was not removed");
        }


        public void ConfigClassInitialize()
        {
            var path = this.TestContext.TestRunDirectory;
            path = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, "../../../scrybersettings.json"));
            if (!File.Exists(path))
            {
                path = System.IO.Path.Combine(this.TestContext.DeploymentDirectory, "../../../scrybersettings.json");
                path = System.IO.Path.GetFullPath(path);

                if (!File.Exists(path))
                    throw new FileNotFoundException("Cannot find the location of the scrybersettings.json file to run the tests from");
            }

            var builder = new ConfigurationBuilder()
                                .AddJsonFile(path, optional: false, reloadOnChange: false);

            IConfiguration config = builder.Build();

            Assert.IsNotNull(config);

            //Create a dictionary services provider
            System.Collections.Generic.Dictionary<Type, object> configDict = new System.Collections.Generic.Dictionary<Type, object>();
            configDict.Add(typeof(IConfiguration), config);
            ServiceProvider.DictionaryServiceProvider services = new ServiceProvider.DictionaryServiceProvider(configDict);

            ServiceProvider.SetProvider(services);
            ServiceProvider.GetService<IScryberConfigurationService>().Reset();
            this.TestContext.WriteLine("Loaded the appsettings file and added it to the services with a reset");
        }

        [TestMethod()]
        [TestCategory("Config")]
        public void ParsingOptions_Test()
        {
            ConfigClassInitialize();

            var service = Scryber.ServiceProvider.GetService<IScryberConfigurationService>();
            Assert.IsNotNull(service, "The scryber config service is null");

            var parsing = service.ParsingOptions;
            Assert.IsNotNull(parsing, "The parsing options are null");

            Assert.AreEqual(ParserReferenceMissingAction.LogError, parsing.MissingReferenceAction, "The missing reference action is not set to LogError");

            //Namespace Mappings
            Assert.IsNotNull(parsing.Namespaces, "Namespace mappings is null");

            int expectedLength = 6;
            string expectedNs = "Scryber.Core.UnitTests.Generation.Fakes";
            string expectedAssm = "Scryber.UnitTests";
            string expectedSrc = "http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Fakes.xsd";

            Assert.AreEqual(expectedLength, parsing.Namespaces.Count, "Namespace mappings length is not 5");

            var xmlNs = parsing.GetXmlNamespaceForAssemblyNamespace(expectedNs, expectedAssm);
            Assert.AreEqual(expectedSrc, xmlNs, "The expected xml source was not matched");

            //Check defaults are there
            expectedNs = "Scryber.Components";
            expectedAssm = "Scryber.Components, Version=1.0.0.0, Culture=neutral, PublicKeyToken=872cbeb81db952fe";
            expectedSrc = "http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Components.xsd";

            xmlNs = parsing.GetXmlNamespaceForAssemblyNamespace(expectedNs, expectedAssm);
            Assert.AreEqual(expectedSrc, xmlNs, "The expected xml source was not matched");


            Assert.IsNotNull(parsing.Bindings, "Binding prefixes are null");

            expectedLength = 4;
            string expectedPrefix = "custom";

            expectedAssm = "Scryber.Generation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=872cbeb81db952fe";
            string expectedType = "Scryber.Binding.BindingXPathExpressionFactory";

            Assert.AreEqual(expectedLength, parsing.Bindings.Count, "Binding mappings length is not " + expectedLength);
            Assert.AreEqual(expectedPrefix, parsing.Bindings[expectedLength-1].Prefix);
            Assert.AreEqual(expectedAssm, parsing.Bindings[expectedLength - 1].FactoryAssembly);
            Assert.AreEqual(expectedType, parsing.Bindings[expectedLength - 1].FactoryType);

            ConfigClassCleanup();
        }


        [TestMethod()]
        [TestCategory("Config")]
        public void FontOptions_Test()
        {
            ConfigClassInitialize();

            var service = Scryber.ServiceProvider.GetService<IScryberConfigurationService>();
            Assert.IsNotNull(service, "The scryber config service is null");

            var font = service.FontOptions;
            Assert.IsNotNull(font, "The font options are null");

            Assert.IsTrue(font.UseSystemFonts, "Use System Foints is not false");
            Assert.IsTrue(font.FontSubstitution, "Use Font Substitution is not true");
            Assert.IsFalse(string.IsNullOrEmpty(font.DefaultDirectory), "The default font directory is not provided");
            Assert.AreEqual("Mocks/Fonts/Avenir", font.DefaultDirectory, "The default font directory is not '/Users/RichardHewitson/Library/Fonts'");
            Assert.AreEqual("Avenir Next Condensed", font.DefaultFont, "The default font is not 'Avenir Next Condensed'");

            //Should be 3 registered fonts
            Assert.IsNotNull(font.Register, "The font register should not be null");
            Assert.AreEqual(3, font.Register.Length, "There are not 3 registered fonts");

            var family = "Segoe UI";
            var style = System.Drawing.FontStyle.Regular;
            var fileStem = "Mocks/Fonts/";
            var fileExt = ".ttf";
            var fileName = "segoeui";

            //Segoe UI Regular
            var option = font.Register[0]; 
            Assert.AreEqual(family, option.Family);
            Assert.AreEqual(style, option.Style);
            Assert.AreEqual(fileStem + fileName + fileExt, option.File);

            // Segoe UI Bold
            option = font.Register[1]; 
            style = System.Drawing.FontStyle.Bold;

            Assert.AreEqual(family, option.Family);
            Assert.AreEqual(style, option.Style);
            Assert.AreEqual(fileStem + fileName + "b" + fileExt, option.File);

            // Segoe UI Bold
            option = font.Register[2];
            style = System.Drawing.FontStyle.Italic;

            Assert.AreEqual(family, option.Family);
            Assert.AreEqual(style, option.Style);
            Assert.AreEqual(fileStem + fileName + "i" + fileExt, option.File);

            ConfigClassCleanup();
        }


        [TestMethod()]
        [TestCategory("Config")]
        public void OutputOptions_Test()
        {
            ConfigClassInitialize();

            var service = Scryber.ServiceProvider.GetService<IScryberConfigurationService>();
            Assert.IsNotNull(service, "The scryber config service is null");

            var output = service.OutputOptions;
            Assert.IsNotNull(output, "The render options are null");

            Assert.AreEqual(OutputCompressionType.None, output.Compression, "Expected None output compression");
            Assert.AreEqual(OutputCompliance.None, output.Compliance, "Expected Other output compliance");
            Assert.AreEqual(OutputStringType.Text, output.StringType, "Expected Text output string type");
            Assert.AreEqual(ComponentNameOutput.All, output.NameOutput,  "Expected 'All' string type");
            Assert.AreEqual("1.4", output.PDFVersion, "Expected a PDF Version of 1.4");

            ConfigClassCleanup();
        }


        [TestMethod()]
        [TestCategory("Config")]
        public void ImagingOptions_Test()
        {
            ConfigClassInitialize();

            var service = Scryber.ServiceProvider.GetService<IScryberConfigurationService>();
            Assert.IsNotNull(service, "The scryber config service is null");

            var img = service.ImagingOptions;

            Assert.IsNotNull(img, "The imaging options are null");

            Assert.IsTrue(img.AllowMissingImages, "Missing images is not true");
            Assert.AreEqual(60, img.ImageCacheDuration, "The image cache duration is not 60");
            Assert.IsNotNull(img.Factories, "The image factories are null");

            Assert.AreEqual(1, img.Factories.Length);
            Assert.AreEqual(".*\\.dynamic", img.Factories[0].Match, "The img factory match path is incorrect");
            Assert.AreEqual("Scryber.UnitTests.Mocks.MockImageFactory", img.Factories[0].FactoryType, "The image factory type is not correct");
            Assert.AreEqual("Scryber.UnitTests", img.Factories[0].FactoryAssembly, "The image factory assembly is not correct");

            ConfigClassCleanup();
        }

        [TestMethod()]
        [TestCategory("Config")]
        public void TracingOptions_Test()
        {
            ConfigClassInitialize();

            var service = Scryber.ServiceProvider.GetService<IScryberConfigurationService>();
            Assert.IsNotNull(service, "The scryber config service is null");

            var trace = service.TracingOptions;
            Assert.IsNotNull(trace, "The tracing options are null");
            Assert.AreEqual(TraceRecordLevel.Warnings, trace.TraceLevel, "Trace level is not Debug");

            Assert.IsNotNull(trace.Loggers, "The tracing loggers is null");
            Assert.AreEqual(2, trace.Loggers.Length, "The length of the tracing loggers is not 1");

            Assert.AreEqual("Spoof", trace.Loggers[0].Name, "THe logger name is not Spoof");
            Assert.AreEqual("Scryber.UnitTests.Mocks.MockTraceLog", trace.Loggers[0].FactoryType, "The logger type does not match");
            Assert.AreEqual("Scryber.UnitTests", trace.Loggers[0].FactoryAssembly, "The loggers assembly does not match");
            Assert.IsFalse(trace.Loggers[0].Enabled, "The first logger is incorrectly enabled");

            Assert.AreEqual("Spoof2", trace.Loggers[1].Name, "The second logger name is not Spoof2");
            Assert.AreEqual("Scryber.UnitTests.Mocks.MockTraceLog2", trace.Loggers[1].FactoryType, "The second logger type does not match");
            Assert.AreEqual("Scryber.UnitTests", trace.Loggers[1].FactoryAssembly, "The second loggers assembly does not match");
            Assert.IsTrue(trace.Loggers[1].Enabled, "The default for a logger should be enabled");

            ConfigClassCleanup();
        }

        [TestMethod()]
        public void MissingImageException_Test()
        {
            ConfigClassInitialize();

            var pdfx = @"<?xml version='1.0' encoding='utf-8' ?>
<doc:Document xmlns:doc='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Components.xsd'
              xmlns:styles='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Styles.xsd'
              xmlns:data='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Data.xsd' >
  <Params>
    <doc:Object-Param id='MyImage' />
  </Params>
  <Pages>

    <doc:Page styles:margins='20pt'>
      <Content>
        <doc:Image id='LoadedImage' src='DoesNotExist.png' />
        
      </Content>
    </doc:Page>
  </Pages>
    
</doc:Document>";

            bool caught = false;

            try
            {
                Document doc;
                using (var reader = new System.IO.StringReader(pdfx))
                    doc = Document.ParseDocument(reader, ParseSourceType.DynamicContent);

                using (var stream = DocStreams.GetOutputStream("MissingImageTest.pdf"))
                    doc.SaveAsPDF(stream);
            }
            catch (Exception)
            {
                caught = true;
            }

            Assert.IsFalse(caught, "An Exception was raised for a missing image");

            ConfigClassCleanup();
        }


        /// <summary>
        /// Ensures that even though the default is to raise an
        /// excpetion the attribute value is honoured
        /// </summary>
        [TestMethod()]
        public void MissingImageExplicitException_Test()
        {
            ConfigClassInitialize();

            var pdfx = @"<?xml version='1.0' encoding='utf-8' ?>
<doc:Document xmlns:doc='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Components.xsd'
              xmlns:styles='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Styles.xsd'
              xmlns:data='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Data.xsd' >
  <Pages>

    <doc:Page styles:margins='20pt'>
      <Content>
        <doc:Image id='LoadedImage' src='DoesNotExist.png' allow-missing-images='false' />
        
      </Content>
    </doc:Page>
  </Pages>

</doc:Document>";

            bool caught = false;

            try
            {
                Document doc;
                using (var reader = new System.IO.StringReader(pdfx))
                    doc = Document.ParseDocument(reader, ParseSourceType.DynamicContent);

                using (var stream = DocStreams.GetOutputStream("MissingImagesExplicit.pdf"))
                    doc.SaveAsPDF(stream);
            }
            catch (Exception)
            {
                caught = true;
            }

            Assert.IsTrue(caught, "Exception was not raised for a missing image, that should not be allowed");

            ConfigClassCleanup();
        }


        [TestMethod()]
        public void DynamicImage_Test()
        {
            ConfigClassInitialize();

            var pdfx = @"<?xml version='1.0' encoding='utf-8' ?>
<doc:Document xmlns:doc='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Components.xsd'
              xmlns:styles='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Styles.xsd'
              xmlns:data='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Data.xsd' >
  <Pages>

    <doc:Page styles:margins='20pt'>
      <Content>
        <doc:Span>This is before the image</doc:Span>
        <doc:Image id='LoadedImage' src='This+is+an+image.dynamic' />
        <doc:Span>This is after the image</doc:Span>
      </Content>
    </doc:Page>
  </Pages>

</doc:Document>";

            var service = Scryber.ServiceProvider.GetService<IScryberConfigurationService>();
            Assert.IsNotNull(service, "The scryber config service is null");

            var imgsvc = service.ImagingOptions;

            Assert.IsNotNull(imgsvc, "The imaging options are null");

            Assert.AreEqual(1, imgsvc.Factories.Length);

            var factory = imgsvc.Factories[0];

            Assert.AreEqual(".*\\.dynamic", factory.Match, "Config not loaded for this test");
            Document doc;

            using (var reader = new System.IO.StringReader(pdfx))
            {
                doc = Document.ParseDocument(reader, ParseSourceType.DynamicContent);
                
                using (var stream = DocStreams.GetOutputStream("DynamicImage.pdf"))
                {
                    doc.SaveAsPDF(stream);

                    //Check that the image was loaded and used.
                    var img = doc.FindAComponentById("LoadedImage") as Image;
                    Assert.IsNotNull(img.XObject, "No Dynamic image was loaded as an XObject");
                    var key = img.XObject.ResourceKey;
                    var expected = "/This+is+an+image.dynamic";
                    Assert.IsTrue(key.EndsWith(expected), "The key '" + key + "' does not end with '" + expected + "'");
                    //Assert.IsTrue(doc.SharedResources.GetResource(Resources.PDFImageXObject.XObjectResourceType, img.Source))
                }
            }

            ConfigClassCleanup();
        }




    }
}
