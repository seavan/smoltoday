using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Services
{
    public class Currency
    {
        public static readonly Currency Usd = new Currency("R01235");
        public static readonly Currency Eur = new Currency("R01239");
        
        private Currency(string centralBankCode)
        {
            this.CentralBankCode = centralBankCode;
        }

        /// <summary>
        /// Внутренний код валюты ЦБ
        /// </summary>
        public string CentralBankCode { get; private set; }
    }
}