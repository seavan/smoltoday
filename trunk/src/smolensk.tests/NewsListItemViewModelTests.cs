using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smolensk.ViewModels;

namespace smolensk.tests
{
    [TestClass]
    public class NewsListItemViewModelTests
    {
        private SingleNewsViewModel model;

        [TestInitialize]
        public void SetUp()
        {
            model = new SingleNewsViewModel(12);
        }

        [TestMethod]
        public void TestGetItemUri()
        {
            Uri uri = model.GetItemUri();

            Assert.AreEqual("/News/Single/12", uri.ToString());
        }
    }
}
