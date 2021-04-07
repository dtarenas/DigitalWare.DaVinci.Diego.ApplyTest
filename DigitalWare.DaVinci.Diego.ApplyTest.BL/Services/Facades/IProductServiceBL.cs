namespace DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs;
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
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="productDTO">The product dto.</param>
        /// <returns>Product DTO</returns>
        Task<WebApiResponseDTO<ProductDTO>> CreateAsync(ProductDTO productDTO);

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="productDTOs">The product dt os.</param>
        /// <returns>List of Product DTO</returns>
        Task<WebApiResponseDTO<List<ProductDTO>>> CreateAsync(List<ProductDTO> productDTOs);

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
        /// <returns></returns>
        Task<WebApiResponseDTO<object>> DeleteAsync(int productId);
    }
}
