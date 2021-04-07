namespace DigitalWare.DaVinci.Diego.ApplyTest.Presentation.Controllers
{
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Experimental Data Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ExperimentalDataController : ControllerBase
    {
        /// <summary>
        /// The random data service
        /// </summary>
        private readonly IRandomDataService _randomDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExperimentalDataController"/> class.
        /// </summary>
        /// <param name="randomDataService">The random data service.</param>
        public ExperimentalDataController(IRandomDataService randomDataService)
        {
            this._randomDataService = randomDataService;
        }

        /// <summary>
        /// Creates the random customers.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<List<Customer>>))]
        public async Task<IActionResult> CreateRandomCustomers([FromQuery] int quantity = 1)
        {
            return this.Ok(await this._randomDataService.CreateRandomCustomers(quantity));
        }

        /// <summary>
        /// Creates the random products.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<List<Product>>))]
        public async Task<IActionResult> CreateRandomProducts([FromQuery] int quantity = 1)
        {
            return this.Ok(await this._randomDataService.CreateRandomProducts(quantity));
        }

        /// <summary>
        /// Creates the random invoices.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<List<Invoice>>))]
        public async Task<IActionResult> CreateRandomInvoices(int quantity = 1)
        {
            return this.Ok(await this._randomDataService.CreateRandomInvoices(quantity));
        }
    }
}
