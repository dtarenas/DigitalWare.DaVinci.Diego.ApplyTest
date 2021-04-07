namespace DigitalWare.DaVinci.Diego.ApplyTest.Presentation.Controllers
{
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Queries;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Customers Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /// <summary>
        /// The customer service bl
        /// </summary>
        private readonly ICustomerServiceBL _customerServiceBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        /// <param name="customerServiceBL">The customer service bl.</param>
        public CustomersController(ICustomerServiceBL customerServiceBL)
        {
            this._customerServiceBL = customerServiceBL;
        }

        /// <summary>
        /// Gets the billed customers.
        /// </summary>
        /// <param name="purchaseFrom">The purchase from.</param>
        /// <param name="purchaseTo">The purchase to.</param>
        /// <param name="maxAge">The maximum age.</param>
        /// <returns>
        /// REsponse DTO
        /// </returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<List<CustomerDTO>>))]
        public async Task<IActionResult> GetBilledCustomers(DateTime purchaseFrom, DateTime purchaseTo, int maxAge = 35)
        {
            return this.Ok(await this._customerServiceBL.GetBilledCustomers(purchaseFrom, purchaseTo, maxAge));
        }

        /// <summary>
        /// Gets the next purchase.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Response DTO
        /// </returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<CustomerNextPurchaseDTO>))]
        public async Task<IActionResult> GetNextPurchase(int id)
        {
            return this.Ok(await this._customerServiceBL.TryToGetNextPurchase(id));
        }
    }
}
