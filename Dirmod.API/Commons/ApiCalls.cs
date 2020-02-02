using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.API.Commons
{
    /// <summary>
    /// Api Calls
    /// </summary>
    public class ApiCalls
    {
        /// <summary>
        /// External Quotation Endpoints
        /// </summary>
        public static class ExternalQuotation
        {
            public static string GetExternalQuotation(string baseUrl) => $"{baseUrl}";
        }

        /// <summary>
        /// Api Quotation Endpoints
        /// </summary>
        public static class ApiQuotation
        {
            public static string GetQuotationByName(string baseUrl, string currency) => $"{baseUrl}/cotizacion/{currency}";
        }
    }
}
