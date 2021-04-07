namespace DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Invoice Service BL
    /// </summary>
    public interface IInvoiceServiceBL
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns>
        /// List of Product DTO
        /// </returns>
        Task<WebApiResponseDTO<List<InvoiceDTO>>> GetAsync();

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// Product DTO
        /// </returns>
        Task<WebApiResponseDTO<InvoiceDTO>> GetAsync(int productId);

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="productDTO">The product dto.</param>
        /// <returns>Product DTO</returns>
        Task<WebApiResponseDTO<InvoiceDTO>> CreateAsync(InvoiceDTO productDTO);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productDTO">The product dto.</param>
        /// <returns>
        /// Product DTO
        /// </returns>
        Task<WebApiResponseDTO<InvoiceDTO>> UpdateAsync(int productId, InvoiceDTO productDTO);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        Task<WebApiResponseDTO<object>> DeleteAsync(int productId);
    }
}
