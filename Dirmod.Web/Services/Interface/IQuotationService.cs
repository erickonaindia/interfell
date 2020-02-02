using Dirmod.API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.Web.Services.Interface
{
    public interface IQuotationService
    {
        Task<QuotationResponse> GetQuotationByCurrency(string currency);
    }
}
