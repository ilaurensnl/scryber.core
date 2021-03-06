﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Scryber {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Errors {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Errors() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Scryber.Errors", typeof(Errors).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDFDictionary could not be parsed. All Keys within hte dictionary must be Names (/Name)..
        /// </summary>
        internal static string AllDictionaryKeysMustBePDFNames {
            get {
                return ResourceManager.GetString("AllDictionaryKeysMustBePDFNames", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An indirect object with the referenced id of {0} could not be found in the original file..
        /// </summary>
        internal static string AnIndirectObjectWithReferenceCouldNotBeFound {
            get {
                return ResourceManager.GetString("AnIndirectObjectWithReferenceCouldNotBeFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDFArray could not be parsed as it does not end with the required &apos;]&apos; character..
        /// </summary>
        internal static string ArrayDoesNotEndWithRequiredChar {
            get {
                return ResourceManager.GetString("ArrayDoesNotEndWithRequiredChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDFArray could not be parsed as it does not start with the required &apos;[&apos; character..
        /// </summary>
        internal static string ArrayDoesNotStartWithRequiredChar {
            get {
                return ResourceManager.GetString("ArrayDoesNotStartWithRequiredChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified file could not be opened or does not exist at the specified path. See the inner exception for more details..
        /// </summary>
        internal static string CannotOpenTheFileAtThePath {
            get {
                return ResourceManager.GetString("CannotOpenTheFileAtThePath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot parse a nave value from a null or empty string..
        /// </summary>
        internal static string CannotParseNullString {
            get {
                return ResourceManager.GetString("CannotParseNullString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot parse a native value beyond the length of the provided string.
        /// </summary>
        internal static string CannotParsePastTheEndOfTheString {
            get {
                return ResourceManager.GetString("CannotParsePastTheEndOfTheString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The document ID&apos;s could nopt be parsed. The expected format is either a single Guid, or a pair of Guid values separated by a comma..
        /// </summary>
        internal static string CannotParseTheDocumentIDs {
            get {
                return ResourceManager.GetString("CannotParseTheDocumentIDs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Trace log messages cannot be recorded to a web tracing log without a current HttpContext. Ensure that there is a current web request or remove the PDFWebTraceLog from the trace..
        /// </summary>
        internal static string CannotRecordWebTraceWithoutWebContext {
            get {
                return ResourceManager.GetString("CannotRecordWebTraceWithoutWebContext", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The stream passed to the PDFWriter cannot be written to..
        /// </summary>
        internal static string CannotWriteToThisStream {
            get {
                return ResourceManager.GetString("CannotWriteToThisStream", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified stream filters could not be applied to the PDF object {0} : {1}.
        /// </summary>
        internal static string CouldNotApplyStreamFilters {
            get {
                return ResourceManager.GetString("CouldNotApplyStreamFilters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The compression of the stream failed, check the inner exception for more details..
        /// </summary>
        internal static string CouldNotCompressStreamFilter {
            get {
                return ResourceManager.GetString("CouldNotCompressStreamFilter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDFReader could not initialize based on the referenced file or stream. Check the validity of the file..
        /// </summary>
        internal static string CouldNotInitializeThePDFReader {
            get {
                return ResourceManager.GetString("CouldNotInitializeThePDFReader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The required boolean value could not be parsed from the string literal..
        /// </summary>
        internal static string CouldNotParseBooleanValue {
            get {
                return ResourceManager.GetString("CouldNotParseBooleanValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property &apos;{0}&apos; could not be found or accessed for binding. Please check the spelling..
        /// </summary>
        internal static string DatabindingPropertyNotFound {
            get {
                return ResourceManager.GetString("DatabindingPropertyNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The current databinding source is not an IXpathNavigable object..
        /// </summary>
        internal static string DatabindingSourceNotXPath {
            get {
                return ResourceManager.GetString("DatabindingSourceNotXPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDFDictionary could not be parsed as it does not end with the required &apos;&gt;&gt;&apos; marker..
        /// </summary>
        internal static string DictionaryDoesNotEndWithRequiredChar {
            get {
                return ResourceManager.GetString("DictionaryDoesNotEndWithRequiredChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDFDictionary could not be parsed as it does not start with the required &apos;&lt;&lt;&apos; marker..
        /// </summary>
        internal static string DictionaryDoesNotStartWithRequiredChar {
            get {
                return ResourceManager.GetString("DictionaryDoesNotStartWithRequiredChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more of the specified values for the document id were empty (or an empty Guid). The expected format is a pair of byte arrays (or Guids) .
        /// </summary>
        internal static string DocumentIDCannotBeEmpty {
            get {
                return ResourceManager.GetString("DocumentIDCannotBeEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no font file associated with the font definition &apos;{0}&apos;.
        /// </summary>
        internal static string FontDefinitionDoesNotHaveFile {
            get {
                return ResourceManager.GetString("FontDefinitionDoesNotHaveFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Indirect object could not be parsed.
        /// </summary>
        internal static string IndirectObjectCannotBeParsed {
            get {
                return ResourceManager.GetString("IndirectObjectCannotBeParsed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The use of high order characters in a stream is only supported with binary data writing. The character &apos;{0}&apos; could not be written..
        /// </summary>
        internal static string InvalidChararcterForStreamUseBytes {
            get {
                return ResourceManager.GetString("InvalidChararcterForStreamUseBytes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The binding indexer expression &apos;{0}&apos; could not be evaluated..
        /// </summary>
        internal static string InvalidIndexerExpression {
            get {
                return ResourceManager.GetString("InvalidIndexerExpression", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The string value was not recognised as the &apos;null&apos; string so could not be parsed..
        /// </summary>
        internal static string InvalidNullString {
            get {
                return ResourceManager.GetString("InvalidNullString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The string expression could not be converted to a valid object reference..
        /// </summary>
        internal static string InvalidObjectReferenceString {
            get {
                return ResourceManager.GetString("InvalidObjectReferenceString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDF Name &apos;{0}&apos; contains invalid characters. Please use Alpha numeric characters for names..
        /// </summary>
        internal static string InvalidPDFName {
            get {
                return ResourceManager.GetString("InvalidPDFName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parsed string does not conform to the PDF standards.
        /// </summary>
        internal static string InvalidPDFStringEscapeSequence {
            get {
                return ResourceManager.GetString("InvalidPDFStringEscapeSequence", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDF file marker &apos;{0}&apos; could not be found in the data file by the PDFReader. This marker is required in a PDFFile..
        /// </summary>
        internal static string MarkerNotFoundByReader {
            get {
                return ResourceManager.GetString("MarkerNotFoundByReader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no current data context to access.
        /// </summary>
        internal static string NoDataContextOnTheStack {
            get {
                return ResourceManager.GetString("NoDataContextOnTheStack", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The web application relative url could not be resolved as there is no current HttpContext.
        /// </summary>
        internal static string NoWebContextAvailableForRelativeUrl {
            get {
                return ResourceManager.GetString("NoWebContextAvailableForRelativeUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parsed value was not an itegral number..
        /// </summary>
        internal static string ParsedValueWasNotAnItegralNumber {
            get {
                return ResourceManager.GetString("ParsedValueWasNotAnItegralNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parsed value in the string was not convertable to a numeric value..
        /// </summary>
        internal static string ParsedValueWasNotANumericValue {
            get {
                return ResourceManager.GetString("ParsedValueWasNotANumericValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDF name does not start with the required &apos;/&apos; character..
        /// </summary>
        internal static string PDFNameDoesNotStartWithSlash {
            get {
                return ResourceManager.GetString("PDFNameDoesNotStartWithSlash", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDF String does not start with the required &apos;(&apos; character, nor is it a recognised hexadecimal sequence.
        /// </summary>
        internal static string PDFStringDoesNotStartWithRequiredCharacter {
            get {
                return ResourceManager.GetString("PDFStringDoesNotStartWithRequiredCharacter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parsed string does not have balanced unescpaed paranthese..
        /// </summary>
        internal static string PDFStringHasUnbalancedParenthese {
            get {
                return ResourceManager.GetString("PDFStringHasUnbalancedParenthese", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDFStream does not have any filters defined. If is invalid to ensure that the filters have been applied.
        /// </summary>
        internal static string StreamDoesNotHaveFiltersDefined {
            get {
                return ResourceManager.GetString("StreamDoesNotHaveFiltersDefined", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDFType can only be initialized with a ASCII string {1} characters long. The string &apos;{0}&apos; is not the correct length..
        /// </summary>
        internal static string TypeStringOnlyNChars {
            get {
                return ResourceManager.GetString("TypeStringOnlyNChars", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDFStream WriteTo method only supports MemoryStreams..
        /// </summary>
        internal static string WriteToOnlySupportedForMemoryStreams {
            get {
                return ResourceManager.GetString("WriteToOnlySupportedForMemoryStreams", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The XPath expression &apos;{0}&apos; could not be evaluated and returned an error..
        /// </summary>
        internal static string XPathExpressionCouldNotBeEvaluated {
            get {
                return ResourceManager.GetString("XPathExpressionCouldNotBeEvaluated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parsed XRefTable does not start with the required &apos;xref&apos; marker.
        /// </summary>
        internal static string XRefTableDoesNotStartWithXRef {
            get {
                return ResourceManager.GetString("XRefTableDoesNotStartWithXRef", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Each XRef table entry must consist of a 10 byte digit offset, a 5 byte generation number, and a single character state marker (f,n) with spaces in between and 2 whitespace characters at the end (to make 20 bytes)..
        /// </summary>
        internal static string XRefTableEntryMustBeInCorrectFormat {
            get {
                return ResourceManager.GetString("XRefTableEntryMustBeInCorrectFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Each XRefTable section must be a single line of 2 integer values separated by a space. And always have more than 1 entry..
        /// </summary>
        internal static string XRefTableSectionMustBe2Integers {
            get {
                return ResourceManager.GetString("XRefTableSectionMustBe2Integers", resourceCulture);
            }
        }
    }
}
