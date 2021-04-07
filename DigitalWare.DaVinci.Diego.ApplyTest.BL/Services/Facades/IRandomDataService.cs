namespace DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Random Data Service
    /// </summary>
    public interface IRandomDataService
    {
        /// <summary>
        /// Creates the random customers.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        Task<WebApiResponseDTO<List<Customer>>> CreateRandomCustomers(int quantity = 1);

        /// <summary>
        /// Creates the random products.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>List of Product DTOs</returns>
        Task<WebApiResponseDTO<List<Product>>> CreateRandomProducts(int quantity = 1);

        /// <summary>
        /// Creates the random invoices.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>
        /// List of Invoice DTOs
        /// </returns>
        Task<WebApiResponseDTO<List<Invoice>>> CreateRandomInvoices(int quantity = 1);
    }
}
