using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace WordsCounter.Lib.Tests
{
    [TestClass]
    public class ParserTests
    {
        
        string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
        string[] wordsArray = { "Lorem","ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit" };
        
        Parser parser;
        public ParserTests()
        {
            this.parser = new Parser();
        }
        [TestMethod]
        public void ConvertToWordsArray_returnsStringArray()
        {
            var stringArray= parser.ConvertToWordsArray(text);
            Assert.IsInstanceOfType(stringArray,typeof(string[]));
        }
        [TestMethod]
        public void ConvertToWordsArray_IsNotNull()
        {
            var stringArray = parser.ConvertToWordsArray(text);
            Assert.IsNotNull(stringArray);
        }
        [TestMethod]
        public void CountingWords_returnsDictionaryTypeInstance()
        {
            var wordsStatistic= Parser.CountingWords(wordsArray);
            var targetType = typeof(Dictionary<string,int>);
            Assert.IsInstanceOfType(wordsStatistic, targetType);
        }
        [TestMethod]
        public void CountingWords_IsNotNull()
        {
            var wordsStatistic = Parser.CountingWords(wordsArray);
            var targetType = typeof(Dictionary<string, int>);
            Assert.IsNotNull(wordsStatistic);
        }
        [TestMethod]
        public void ExtractViewableText_isNotNullOrEmpty()
        {
            var htmlNodeText = File.ReadAllText(@"../../HtmlTextContent.txt");
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlNodeText);
            string text = parser.ExtractViewableText(htmlDoc.DocumentNode);
            
            Assert.IsFalse(string.IsNullOrEmpty(text));
        }
    }
}
