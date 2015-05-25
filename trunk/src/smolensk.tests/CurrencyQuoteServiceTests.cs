using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smolensk.Services;

namespace smolensk.tests
{
    [TestClass]
    public class CurrencyQuoteServiceTests
    {
        private CurrencyQuoteService service;

        [TestInitialize]
        public void SetUp()
        {
            this.service = new CurrencyQuoteService();
        }

        [TestMethod]
        public void TestGetQuote()
        {
            DateTime date = new DateTime(2013, 9, 12);

            CurrencyQuote usdQuote = service.GetQuote(Currency.Usd, date);
            AssertQuote(usdQuote, Currency.Usd, 32.9629m, -0.29m);

            CurrencyQuote eurQuote = service.GetQuote(Currency.Eur, date);
            AssertQuote(eurQuote, Currency.Eur, 43.6824m, -0.41m);
        }

        [TestMethod]
        public void TestGetQuoteOnSunday()
        {
            DateTime date = new DateTime(2013, 9, 29);

            CurrencyQuote usdQuote = service.GetQuote(Currency.Usd, date);
            AssertQuote(usdQuote, Currency.Usd, 32.3451m, 0m);

            CurrencyQuote eurQuote = service.GetQuote(Currency.Eur, date);
            AssertQuote(eurQuote, Currency.Eur, 43.6497m, 0m);
        }

        private void AssertQuote(CurrencyQuote actual, Currency currency, decimal price, decimal change)
        {
            Assert.AreEqual(price, actual.Price);
            Assert.AreEqual(currency, actual.Currency);
            Assert.AreEqual(change, actual.PercentChange);
        }
    }
}
