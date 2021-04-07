namespace DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Queries;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Customer Service BL Facade
    /// </summary>
    public interface ICustomerServiceBL
    {
        /// <summary>
        /// Gets the customers filtred.
        /// </summary>
        /// <param name="purchaseFrom">The purchase from.</param>
        /// <param name="purchaseTo">The purchase to.</param>
        /// <param name="maxAge">The minimum age.</param>
        /// <returns>
        /// List of customer
        /// </returns>
        Task<WebApiResponseDTO<List<CustomerDTO>>> GetBilledCustomers(DateTime purchaseFrom, DateTime purchaseTo, int maxAge = 35);

        /// <summary>
        /// Tries to get next purchase.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>Next Purchase</returns>
        Task<WebApiResponseDTO<CustomerNextPurchaseDTO>> TryToGetNextPurchase(int customerId);
    }
}
