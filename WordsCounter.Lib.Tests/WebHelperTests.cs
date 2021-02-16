using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using System;

namespace WordsCounter.Lib.Tests
{
    [TestClass]
    public class WebHelperTests
    {
        WebHelper webHelper;
        [TestMethod]
        public void GetHtmlDocument_returnsNotNull_Test()
        {
            webHelper = new WebHelper(@"https://www.google.ru/");
            Assert.IsNotNull(webHelper.GetHtmlDocument());
        }
        [TestMethod]
        public void GetHtmlDocument_returnsTargetTypeInstance_Test()
        {
            webHelper = new WebHelper(@"https://www.google.ru/");
            Assert.IsInstanceOfType(webHelper.GetHtmlDocument(),typeof(HtmlDocument));
        }
    }
}
