using Dirmod.API.Commons;
using Dirmod.API.Models.Response;
using Dirmod.Web.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dirmod.Web.Services.Implementation
{
    /// <summary>
    /// Quotation Service
    /// </summary>
    public class QuotationService : IQuotationService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<QuotationService> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public QuotationService(HttpClient httpClient, IConfiguration configuration, ILogger<QuotationService> logger)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _baseUrl = _configuration.GetValue<string>("ExternalApi:Url");
            _logger = logger;
        }

        /// <summary>
        /// Get Quotation By Currency
        /// </summary>
        /// <param name="currency">currency</param>
        /// <returns>Quotation Response</returns>
        public async Task<QuotationResponse> GetQuotationByCurrency(string currency)
        {
            try
            {
                var uri = ApiCalls.ApiQuotation.GetQuotationByName(_baseUrl, currency);
                var response = await _httpClient.GetStringAsync(uri);
                var objDes = JsonConvert.DeserializeObject<QuotationResponse>(response);

                return objDes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
