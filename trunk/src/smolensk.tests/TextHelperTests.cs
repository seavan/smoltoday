using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smolensk.Domain;

namespace smolensk.tests
{
    [TestClass]
    public class TextHelperTests
    {
        /*[TestMethod]
        public void TestExtractSeveralImageSources()
        {
            string text = "<subject>Жили были не тужили <img id=\"lala\" src='/content/vovka.jpg' alt='автор жжот &nbsp;'/> блаблабла <img src=\"picture.png\" class='sealed'>bad cow</img> </subject>";

            var imageSources = TextHelper.ExtractImageSources(text);
            Assert.AreEqual(2, imageSources.Count);
            AssertImage(imageSources[0], "/content/vovka.jpg", "автор жжот &nbsp;");
            AssertImage(imageSources[1], "picture.png", "");
        }

        [TestMethod]
        public void TestExtractSingleImageSource()
        {
            string text = "<subject>Супер-пупер новость! <img src='http://www.yandex.ru/coolchic.jpeg' alt=\"Йандекс\" /></subject>";

            var imageSources = TextHelper.ExtractImageSources(text);

            Assert.AreEqual(1, imageSources.Count);
            AssertImage(imageSources[0], "http://www.yandex.ru/coolchic.jpeg", "Йандекс");
        }

        [TestMethod]
        public void TestExtractImageNoSrc()
        {
            string text = "<subject>Супер-пупер новость! <img id=\"freak-on-a-leash\" /></subject>";

            var imageSources = TextHelper.ExtractImageSources(text);

            Assert.AreEqual(0, imageSources.Count);
        }

        [TestMethod]
        public void TestExtractImageSourceNoImage()
        {
            string text = "<subject>Текст. Тупо текст. <table></table><br/></subject>";

            var imageSources = TextHelper.ExtractImageSources(text);

            Assert.AreEqual(0, imageSources.Count);
        }

        [TestMethod]
        public void TestExtractImagesNoHtml()
        {
            string text = "Мама мыла раму";

            var images = TextHelper.ExtractImageSources(text);

            Assert.AreEqual(0, images.Count);
        }

        [TestMethod]
        public void TestExtractImagesEmptyString()
        {
            var images = TextHelper.ExtractImageSources(string.Empty);

            Assert.AreEqual(0, images.Count);
        }

        [TestMethod]
        public void TextExtractImageWithClosingTag()
        {
            string text = "<subject>Пишем новость ручки горят: <img src=\"milayovovich.png\" alt='Украина вперед!'></img></subject>";

            var images = TextHelper.ExtractImageSources(text);

            Assert.AreEqual(1, images.Count);
            AssertImage(images[0], "milayovovich.png", "Украина вперед!");
        }

        private static void AssertImage(HtmlImageInfo actual, string expectedUrl, string expectedAlt)
        {
            Assert.AreEqual(expectedUrl, actual.Uri);
            Assert.AreEqual(expectedAlt, actual.Alt);
        }*/
    }
}
