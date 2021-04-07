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
    /// Products Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// The product service bl
        /// </summary>
        private readonly IProductServiceBL _productServiceBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController" /> class.
        /// </summary>
        /// <param name="productServiceBL">The product service bl.</param>
        public ProductsController(IProductServiceBL productServiceBL)
        {
            this._productServiceBL = productServiceBL;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>
        /// List of ProductDTO
        /// </returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<List<ProductDTO>>))]
        public async Task<IActionResult> Get()
        {
            return this.Ok(await this._productServiceBL.GetAsync());
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Response DTO
        /// </returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<ProductDTO>))]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            return this.Ok(await this._productServiceBL.GetAsync(id));
        }

        /// <summary>
        /// Creates the specified identifier.
        /// </summary>
        /// <param name="productDTO">The product dto.</param>
        /// <returns>Response DTO</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<ProductDTO>))]
        public async Task<IActionResult> Create([FromBody] ProductDTO productDTO)
        {
            return this.Ok(await this._productServiceBL.CreateAsync(productDTO));
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
            return this.Ok(await this._productServiceBL.DeleteAsync(id));
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="productDTO">The product dto.</param>
        /// <returns>Response DTO</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WebApiResponseDTO<ProductDTO>))]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] ProductDTO productDTO)
        {
            return this.Ok(await this._productServiceBL.UpdateAsync(id, productDTO));
        }
    }
}
