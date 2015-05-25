using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ru.cbr.www;

namespace smolensk.Services
{
    public class CurrencyQuoteService
    {
        private const string CurrencyPriceColumnName = "Vcurs";

        private DailyInfo dailyInfoService;

        public CurrencyQuoteService()
        {
            this.dailyInfoService = new DailyInfo();
        }

        public CurrencyQuote GetQuote(Currency currency, DateTime date)
        {
            var response = dailyInfoService.GetCursDynamic(date.AddDays(-1), date, currency.CentralBankCode);
            var table = response.Tables[0];

            if (table.Rows.Count == 0)
                return null;

            decimal todayPrice;
            decimal percentChange = 0m;

            // если курс не менялся (например, в нерабочий день), то в таблице будет 1 строка
            if (table.Rows.Count == 1)
            {
                todayPrice = Convert.ToDecimal(table.Rows[0][CurrencyPriceColumnName]);
            }
            // если курс менялся, то в таблице будет 2 строки
            else
            {
                decimal yesterdayPrice = Convert.ToDecimal(table.Rows[0][CurrencyPriceColumnName]);
                todayPrice = Convert.ToDecimal(table.Rows[1][CurrencyPriceColumnName]);
                percentChange = Math.Round((todayPrice - yesterdayPrice) / yesterdayPrice, 4) * 100m;
            }

            return new CurrencyQuote(currency, todayPrice, percentChange);
        }
    }
}