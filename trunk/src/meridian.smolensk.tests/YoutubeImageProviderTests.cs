using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using meridian.smolensk.impl.Video;
using System.IO;
using meridian.smolensk.impl.Images;

namespace meridian.smolensk.tests
{
    [TestClass]
    public class YoutubeImageProviderTests
    {
        private IVideoImageProvider provider;

        [TestInitialize]
        public void SetUp()
        {
            this.provider = new YoutubeImageProvider();
        }
        
        [TestMethod]
        public void TestGetExtension()
        {
            string expected = ".jpg";
            Assert.AreEqual(expected, provider.GetVideoImageExtension(new Uri("www.youtube.com/embed/ilqU0GStL7c", UriKind.RelativeOrAbsolute)));
            Assert.AreEqual(expected, provider.GetVideoImageExtension(new Uri("//www.youtube.com/embed/V5M0vXJtGS8", UriKind.RelativeOrAbsolute)));
        }

        [TestMethod]
        public void TestDownloadVideoImage()
        {
            string filename = "jack.jpg";
            Uri videoUri = new Uri("//www.youtube.com/embed/w2PzCRjJUeg");
            provider.DownloadVideoImage(videoUri, filename);

            var fileInfo = new FileInfo(filename);
            Assert.IsTrue(fileInfo.Exists);
            Assert.AreEqual(20259L, fileInfo.Length);
        }
    }
}
