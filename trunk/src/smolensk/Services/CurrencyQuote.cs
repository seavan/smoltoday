using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Services
{
    public class CurrencyQuote
    {
        public CurrencyQuote(Currency currency, decimal price, decimal percentChange)
        {
            this.Currency = currency;
            this.Price = price;
            this.PercentChange = percentChange;
        }

        public Currency Currency { get; private set; }
        public decimal Price { get; private set; }
        public decimal PercentChange { get; private set; }
    }
}