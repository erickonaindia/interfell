using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dirmod.Web.Models;
using Dirmod.API.Models.Response;
using Dirmod.Web.Services.Interface;

namespace Dirmod.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IQuotationService _quotationService;

        public HomeController(ILogger<HomeController> logger, IQuotationService quotationService)
        {
            _logger = logger;
            _quotationService = quotationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Get data from API
        /// </summary>
        /// <returns>Partial View</returns>
        public async Task<IActionResult> GetDataAPI()
        {
            var model = new QuotationViewModel();
            var dataUsd = await _quotationService.GetQuotationByCurrency("dolar");
            var dataReal = await _quotationService.GetQuotationByCurrency("real");
            var dataEuro = await _quotationService.GetQuotationByCurrency("euro");

            model.QuotationList.Add(dataUsd);
            model.QuotationList.Add(dataReal);
            model.QuotationList.Add(dataEuro);

            return PartialView("_Quotation", model);
        }
    }
}
