namespace DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Queries;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Product Service BL
    /// </summary>
    public interface IProductServiceBL
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns>
        /// List of Product DTO
        /// </returns>
        Task<WebApiResponseDTO<List<ProductDTO>>> GetAsync();

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// Product DTO
        /// </returns>
        Task<WebApiResponseDTO<ProductDTO>> GetAsync(int productId);

        /// <summary>
        /// Gets the total amount sold asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="year">The year.</param>
        /// <returns>
        /// List of totals
        /// </returns>
        Task<WebApiResponseDTO<List<ProductTotalAmountSoldDTO>>> GetTotalAmountSoldAsync(int? productId, int? year);

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="productDTO">The product dto.</param>
        /// <returns>Product DTO</returns>
        Task<WebApiResponseDTO<ProductDTO>> CreateAsync(ProductDTO productDTO);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productDTO">The product dto.</param>
        /// <returns>
        /// Product DTO
        /// </returns>
        Task<WebApiResponseDTO<ProductDTO>> UpdateAsync(int productId, ProductDTO productDTO);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>N/A</returns>
        Task<WebApiResponseDTO<object>> DeleteAsync(int productId);

        /// <summary>
        /// Gets the prices asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// List of product prices
        /// </returns>
        Task<WebApiResponseDTO<List<ProductPricesDTO>>> GetPricesAsync(int? id);

        /// <summary>
        /// Gets the by minimal stock.
        /// </summary>
        /// <param name="minStock">The minimum stock.</param>
        /// <returns>
        /// List of product DTO
        /// </returns>
        Task<WebApiResponseDTO<List<ProductDTO>>> GetByMinimalStock(int? minStock = 5);
    }
}
