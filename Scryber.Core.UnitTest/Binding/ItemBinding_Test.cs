﻿using System;
using System.Net.WebSockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scryber.Components;

namespace Scryber.Core.UnitTests.Binding
{
    /// <summary>
    /// Tests for the item binding expression
    /// </summary>
    [TestClass()]
    public class ItemBinding_Test
    {
        public TestContext TextContext
        {
            get;
            set;
        }


        [TestMethod()]
        [TestCategory("Binding")]
        public void BindLabelText()
        {
            var expected = "My Document Title";

            var src = @"<?xml version='1.0' encoding='utf-8' ?>
                        <pdf:Document xmlns:pdf = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Components.xsd'
                                    xmlns:styles = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Styles.xsd'
                                    xmlns:data = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Data.xsd'
                                     >
                        <Styles>

                        <styles:Style applied-class='blue-bg'>
                            <styles:Background color='blue' />
                        </styles:Style>
    
                        </Styles>
                        <Params>
                            <pdf:String-Param id='title' value='" + expected + @"' />
                        </Params>
                        <Pages>
    
                        <pdf:Section>
                            <Content>
                            <pdf:Label text='{@:title}'></pdf:Label>
                            </Content>
                        </pdf:Section>

                        </Pages>
                    </pdf:Document>";

            using (var reader = new System.IO.StringReader(src))
            {
                var doc = PDFDocument.ParseDocument(reader, ParseSourceType.DynamicContent);
                var sect = doc.Pages[0] as PDFSection;
                var label = sect.Contents[0] as PDFLabel;


                doc.InitializeAndLoad();
                doc.DataBind();

                Assert.AreEqual(expected, label.Text, "The document title does not match");
            }

            
        }

        

        [TestMethod()]
        [TestCategory("Binding")]
        public void BindAllTypes()
        {
            var expectedString = "My Document Title";
            var expectedInt = 125;
            var expectedGuid = "{1C978E2A-E3E1-43F9-AA07-97B976B57DAA}";
            var expectedDouble = 12.34;
            var expectedBool = true;
            var expectedDate = "2020-07-03 12:24:24";
            var expectedUnit = "34pt";
            var expectedColor = "#FF3300";
            var expectedThickness = "10pt 20pt 20pt 5pt";
            var expectedEnum = "Dash";
            
            var src = @"<?xml version='1.0' encoding='utf-8' ?>
                        <pdf:Document xmlns:pdf = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Components.xsd'
                                    xmlns:styles = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Styles.xsd'
                                    xmlns:data = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Data.xsd'
                                     >
                        <Params>
                            <pdf:String-Param id='title' value='" + expectedString + @"' />
                            <pdf:Int-Param id='int' value='" + expectedInt + @"' />
                            <pdf:Guid-Param id='guid' value='" + expectedGuid + @"' />
                            <pdf:Double-Param id='double' value='" + expectedDouble + @"' />
                            <pdf:Bool-Param id='bool' value='" + expectedBool + @"' />
                            <pdf:Date-Param id='date' value='" + expectedDate + @"' />
                            <pdf:Unit-Param id='unit' value='" + expectedUnit+ @"' />
                            <pdf:Color-Param id='color' value='" + expectedColor + @"' />
                            <pdf:Thickness-Param id='thick' value='" + expectedThickness + @"' />
                            <pdf:Enum-Param id='enum' type='Scryber.Drawing.LineStyle, Scryber.Drawing' value='" + expectedEnum + @"' />
                        </Params>

                        <Pages>
    
                        <pdf:Section>
                            <Content>
                                <pdf:Label styles:fill-color='{@:color}' styles:x='{@:unit}' styles:padding='{@:thick}'
                                           styles:border-style='{@:enum}' text='{@:title}'></pdf:Label>
                                <pdf:Date value='{@:date}' />
                                <pdf:Number value='{@:int}' styles:font-bold='{@:bool}' />
                                <pdf:Number value='{@:double}' />
                            </Content>
                        </pdf:Section>

                        </Pages>
                    </pdf:Document>";

            using (var reader = new System.IO.StringReader(src))
            {
                var doc = PDFDocument.ParseDocument(reader, ParseSourceType.DynamicContent);
                

                var sect = doc.Pages[0] as PDFSection;
                var label = sect.Contents[0] as PDFLabel;
                var date = sect.Contents[1] as PDFDate;
                var num1 = sect.Contents[2] as PDFNumber;
                var num2 = sect.Contents[3] as PDFNumber;

                doc.InitializeAndLoad();
                doc.DataBind();

                Assert.AreEqual(expectedString, label.Text, "The label text does not match");
                Assert.AreEqual(Scryber.Drawing.PDFColor.Parse(expectedColor), label.FillColor, "The Label fill colour does not match");
                Assert.AreEqual(Scryber.Drawing.PDFUnit.Parse(expectedUnit), label.X, "The label x offsets do not match");
                Assert.AreEqual(Scryber.Drawing.PDFThickness.Parse(expectedThickness), label.Padding, "The label paddings do not match");
                Assert.AreEqual(Scryber.Drawing.LineStyle.Dash, label.BorderStyle, "The label border styles do not match");
                Assert.AreEqual(DateTime.Parse(expectedDate), date.Value, "The date time values do not match");
                Assert.AreEqual(expectedInt, (int)num1.Value,"The integers do not match");
                Assert.AreEqual(expectedBool, num1.FontBold, "The bool values do not match");
                Assert.AreEqual(expectedDouble, num2.Value, "The double values do not match");


            }


        }

        /// <summary>
        /// Test for binding style values to parameters
        /// </summary>
        [TestMethod()]
        [TestCategory("Binding")]
        public void BindStyles()
        {
            var expectedString = "My Document Title";
            var expectedBool = true;
            var expectedUnit = "34pt";
            var expectedColor = "#FF3300";
            
            var src = @"<?xml version='1.0' encoding='utf-8' ?>
                        <pdf:Document xmlns:pdf = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Components.xsd'
                                    xmlns:styles = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Styles.xsd'
                                    xmlns:data = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Data.xsd'
                                     >
                        <Styles>

                        <styles:Style applied-class='blue'>
                            <styles:Background color='{@:color}' />
                            <styles:Padding top='{@:unit}' />
                            <styles:Font bold='{@:bool}' />
                        </styles:Style>
    
                        </Styles>
                        <Params>
                            <pdf:String-Param id='title' value='" + expectedString + @"' />
                            <pdf:Bool-Param id='bool' value='" + expectedBool + @"' />
                            <pdf:Unit-Param id='unit' value='" + expectedUnit + @"' />
                            <pdf:Color-Param id='color' value='" + expectedColor + @"' />
                        </Params>

                        <Pages>
    
                        <pdf:Section>
                            <Content>
                                <pdf:Label styles:class='blue' text='{@:title}'></pdf:Label>
                                
                            </Content>
                        </pdf:Section>

                        </Pages>
                    </pdf:Document>";

            using (var reader = new System.IO.StringReader(src))
            {
                var doc = PDFDocument.ParseDocument(reader, ParseSourceType.DynamicContent);
                

                var sect = doc.Pages[0] as PDFSection;
                var label = sect.Contents[0] as PDFLabel;
                var style = doc.Styles[0] as Scryber.Styles.PDFStyle;

                doc.InitializeAndLoad();
                doc.DataBind();

                Assert.AreEqual(expectedString, label.Text, "The label text does not match");

                Assert.IsTrue(style.IsValueDefined(Scryber.Styles.PDFStyleKeys.BgColorKey), "The background colour is not set");
                Assert.AreEqual(Scryber.Drawing.PDFColor.Parse(expectedColor), style.Background.Color, "The style color does not match");

                Assert.IsTrue(style.IsValueDefined(Scryber.Styles.PDFStyleKeys.FontBoldKey), "The font bold is not set");
                Assert.AreEqual(expectedBool, style.Font.FontBold, "The font bolds do not match");

                Assert.IsTrue(style.IsValueDefined(Scryber.Styles.PDFStyleKeys.PaddingTopKey), "The padding top is not set");
                Assert.AreEqual(Scryber.Drawing.PDFUnit.Parse(expectedUnit), style.Padding.Top, "The padding top values do not match");

            }


        }


        [TestMethod()]
        [TestCategory("Binding")]
        public void BindDynamicObject()
        {

            var src = @"<?xml version='1.0' encoding='utf-8' ?>
                        <pdf:Document xmlns:pdf = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Components.xsd'
                                    xmlns:styles = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Styles.xsd'
                                    xmlns:data = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Data.xsd'
                                     >
                        <Params>
                            <pdf:Object-Param id='dynamic' ></pdf:Object-Param>
                        </Params>

                        <Styles>

                        <styles:Style applied-class='blue'>
                            <styles:Background color='{@:dynamic.Color}' />
                        </styles:Style>
    
                        </Styles>

                        <Pages>
    
                        <pdf:Section>
                            <Content>

                                <data:ForEach value='{@:dynamic.List}' >
                                    <Template>
                                        <pdf:Label id='{@:.Id}' text='{@:.Name}' ></pdf:Label>
                                        <pdf:Br/>
                                    </Template>
                                </data:ForEach>

                            </Content>
                        </pdf:Section>

                        </Pages>
                    </pdf:Document>";

            using (var reader = new System.IO.StringReader(src))
            {
                var doc = PDFDocument.ParseDocument(reader, ParseSourceType.DynamicContent);
                doc.Params["dynamic"] = new
                {
                    Color = Scryber.Drawing.PDFColors.Aqua,
                    List = new[] {
                        new { Name = "First", Id = "FirstID"},
                        new { Name = "Second", Id = "SecondID" }
                    }
                };


                doc.InitializeAndLoad();
                doc.DataBind();

                //For the ForEach template with an object source.
                var first = doc.FindAComponentById("FirstID") as PDFLabel;
                Assert.IsNotNull(first, "Could not find the first label");
                Assert.AreEqual("First", first.Text, "The first label does not have the correct Name value");

                var second = doc.FindAComponentById("SecondID") as PDFLabel;
                Assert.IsNotNull(second, "Could not find the second label");
                Assert.AreEqual("Second", second.Text, "The second label does not have the correct Name value");

                var style = doc.Styles[0] as Scryber.Styles.PDFStyle;
                Assert.IsTrue(style.IsValueDefined(Scryber.Styles.PDFStyleKeys.BgColorKey), "The background color is not assigned");
                Assert.AreEqual(Scryber.Drawing.PDFColors.Aqua, style.Background.Color, "The background colors do not match");
            }


        }

        [TestMethod()]
        [TestCategory("Binding")]
        public void BindXmlAndTemplateObject()
        {
            var expectedXml = @"<node value='1' >
                                    <inner value='1' />
                                    <inner value='2' />
                                </node>";

            var expectedTemplate = @"<pdf:Div id='{xpath:concat(""xmlInnerDiv"",@value)}' >
                                        <pdf:Label id='{xpath:concat(""xmlLabel"",@value)}' text='{xpath:@value}' />
                                     </pdf:Div>";

            var src = @"<?xml version='1.0' encoding='utf-8' ?>
                        <pdf:Document xmlns:pdf = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Components.xsd'
                                    xmlns:styles = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Styles.xsd'
                                    xmlns:data = 'http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Data.xsd'
                                     >

                        <Params>
                            <pdf:Xml-Param id='xml' >" + expectedXml + @"</pdf:Xml-Param>
                            <pdf:Template-Param id='template' >" + expectedTemplate + @"</pdf:Template-Param>
                        </Params>

                        <Pages>
    
                        <pdf:Section>
                            <Content>
                                <data:ForEach id='Foreach2' value='{@:xml}' select='//node/inner' template='{@:template}' ></data:ForEach>
                            </Content>
                        </pdf:Section>

                        </Pages>
                    </pdf:Document>";

            using (var reader = new System.IO.StringReader(src))
            {
                var doc = PDFDocument.ParseDocument(reader, ParseSourceType.DynamicContent);

                doc.InitializeAndLoad();
                doc.DataBind();

                //For the ForEach template with an object source.
                var first = doc.FindAComponentById("xmlInnerDiv1") as PDFDiv;
                Assert.IsNotNull(first, "Could not find inner div");
                
                var second = doc.FindAComponentById("xmlLabel2") as PDFLabel;
                Assert.IsNotNull(second, "Could not find the second label");
                Assert.AreEqual("2", second.Text, "The second label does not have the correct text value");

            }
        }
    }
}