using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smolensk.Domain;

namespace smolensk.tests
{
    [TestClass]
    public class FormatterTests
    {
        [TestMethod]
        public void TestFormatLongDateTime()
        {
            DateTime dateTime = new DateTime(2013, 04, 22, 13, 41, 54);
            Assert.AreEqual("22 апреля 2013, 13:41", Formatter.FormatLongDateTime(dateTime));
        }

        [TestMethod]
        public void TestFormatRecentDate()
        {
            DateTime dateTime = new DateTime(2013, 05, 26, 12, 23, 43);

            DateTime current = new DateTime(2013, 05, 26);
            Assert.AreEqual("12:23", Formatter.FormatRecentDate(dateTime, current));

            current = new DateTime(2013, 05, 27);
            Assert.AreEqual("Вчера в 12:23", Formatter.FormatRecentDate(dateTime, current));

            current = new DateTime(2013, 05, 29);
            Assert.AreEqual("26.05.2013", Formatter.FormatRecentDate(dateTime, current));
        }

    }
}
