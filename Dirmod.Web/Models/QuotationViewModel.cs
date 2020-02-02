using Dirmod.API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.Web.Models
{
    /// <summary>
    /// Quotation ViewModel
    /// </summary>
    public class QuotationViewModel
    {
        public IList<QuotationResponse> QuotationList { get; set; } = new List<QuotationResponse>();
    }
}
