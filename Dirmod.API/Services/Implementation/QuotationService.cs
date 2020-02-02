using Dirmod.API.Commons;
using Dirmod.API.Models.Response;
using Dirmod.API.Services.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dirmod.API.Services.Implementation
{
    /// <summary>
    /// Quotation Service
    /// </summary>
    public class QuotationService : IQuotationService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string _externalApiUri;

        public QuotationService(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _externalApiUri = _configuration.GetValue<string>("ExternalApi:Url");
            _httpClient = httpClient;
        }

        /// <summary>
        /// Get Quotation By Currency Service
        /// </summary>
        /// <param name="currency">currency</param>
        /// <returns>Quotation Response</returns>
        public async Task<QuotationResponse> GetQuotationByCurrency(string currency)
        {
            
            string uri = ApiCalls.ExternalQuotation.GetExternalQuotation(_externalApiUri)
                .Replace("{currency1}", currency)
                .Replace("{currency2}", _configuration.GetValue<string>("ExternalApi:DefaultCurrency"));

            var model = new QuotationResponse();
            try
            {
                var response = await _httpClient.GetStringAsync(uri);
                var desObj = JsonConvert.DeserializeObject<ExternalApiResponse>(response);

                model.Moneda = desObj.Result.Source;
                model.Precio = Math.Round(desObj.Result.Value, 2);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return model;
        }
    }
}
