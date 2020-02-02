using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dirmod.API.Commons;
using Dirmod.API.Models.Response;
using Dirmod.API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dirmod.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private readonly ILogger<CotizacionController> _logger;
        private readonly IQuotationService _cotizacionService;
       
        public CotizacionController(ILogger<CotizacionController> logger,
            IQuotationService cotizacionService)
        {
            _logger = logger;
            _cotizacionService = cotizacionService;
        }

        /// <summary>
        /// Get Cotizaciones
        /// </summary>
        /// <param name="currency">moneda</param>
        /// <returns>Cotizaciones Responbse</returns>
        [HttpGet("{currency}", Name = "Get")]
        [ProducesResponseType(200, Type = typeof(QuotationResponse))]
        public async Task<IActionResult> GetCotizacion([FromRoute]string currency)
        {
            try
            {
                string _currency = Helper.CurrencyValidator(currency);

                if (string.IsNullOrEmpty(_currency))
                    return BadRequest("Currency is not supported.");

                var response = await _cotizacionService.GetQuotationByCurrency(_currency);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        
    }
}
