using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.API.Commons
{
    /// <summary>
    /// Common Helper
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Currency Validator
        /// </summary>
        /// <param name="_currency">Currency</param>
        /// <returns>String</returns>
        public static string CurrencyValidator(string _currency)
        {
            Dictionary<string, string> currency = new Dictionary<string, string>();
            currency.Add("dolar", "USD");
            currency.Add("euro", "EUR");
            currency.Add("real", "BRL");

            return currency.Where(x => x.Key == _currency).Select(x => x.Value).FirstOrDefault();
        }
    }
}
