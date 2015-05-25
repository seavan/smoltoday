using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using meridian.smolensk.impl.Images;

namespace meridian.smolensk.tests
{
    [TestClass]
    public class HtmlMarkupHelperTests
    {
        [TestMethod]
        public void TestCreateAbsoluteUri()
        {
            Assert.AreEqual("http://www.youtube.com/embed/V5M0vXJtGS8", HtmlMarkupHelper.CreateAbsoluteUri("//www.youtube.com/embed/V5M0vXJtGS8").ToString());
            Assert.AreEqual("http://www.youtube.com/embed/V5M0vXJtGS8", HtmlMarkupHelper.CreateAbsoluteUri("www.youtube.com/embed/V5M0vXJtGS8").ToString());
            Assert.AreEqual("http://host/path1/path2?v=1&e=0", HtmlMarkupHelper.CreateAbsoluteUri("host/path1/path2?v=1&e=0").ToString());
        }
    }
}
