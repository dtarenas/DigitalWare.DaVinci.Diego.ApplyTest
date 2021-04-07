namespace DigitalWare.DaVinci.Diego.ApplyTest.Presentation.Controllers
{
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Invoices Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        /// <summary>
        /// The product service bl
        /// </summary>
        private readonly IInvoiceServiceBL _invoiceServiceBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesController" /> class.
        /// </summary>
        /// <param name="invoiceServiceBL">The invoice service bl.</param>
        public InvoicesController(IInvoiceServiceBL invoiceServiceBL)
        {
            this._invoiceServiceBL = invoiceServiceBL;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>
        /// List of InvoiceDTO
        /// </returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<List<InvoiceDTO>>))]
        public async Task<IActionResult> Get()
        {
            return this.Ok(await this._invoiceServiceBL.GetAsync());
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Response DTO
        /// </returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<InvoiceDTO>))]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            return this.Ok(await this._invoiceServiceBL.GetAsync(id));
        }

        /// <summary>
        /// Creates the specified identifier.
        /// </summary>
        /// <param name="productDTO">The product dto.</param>
        /// <returns>Response DTO</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<InvoiceDTO>))]
        public async Task<IActionResult> Create([FromBody] InvoiceDTO productDTO)
        {
            return this.Ok(await this._invoiceServiceBL.CreateAsync(productDTO));
        }

        /// <summary>
        /// Deletes the specified product dto.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Response DTO
        /// </returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<object>))]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            return this.Ok(await this._invoiceServiceBL.DeleteAsync(id));
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="productDTO">The product dto.</param>
        /// <returns>Response DTO</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<InvoiceDTO>))]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] InvoiceDTO productDTO)
        {
            return this.Ok(await this._invoiceServiceBL.UpdateAsync(id, productDTO));
        }
    }
}
