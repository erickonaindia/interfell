using Dirmod.API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.API.Services.Interface
{
    /// <summary>
    /// Cotizacion Interface
    /// </summary>
    public interface IQuotationService
    {
        /// <summary>
        /// Get Cotizac
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        Task<QuotationResponse> GetQuotationByCurrency(string currency);
    }
}
