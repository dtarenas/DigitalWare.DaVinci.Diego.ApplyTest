namespace DigitalWare.DaVinci.Diego.ApplyTest.BL.Services
{
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Exceptions;
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades;
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Utils;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Queries;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models;
    using DigitalWare.DaVinci.Diego.ApplyTest.DAL.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Customer Service BL Implementation
    /// </summary>
    /// <seealso cref="DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades.ICustomerServiceBL" />
    public class CustomerServiceBL : ICustomerServiceBL
    {
        /// <summary>
        /// The invoice repo
        /// </summary>
        private readonly IBaseRepo<Customer> _customerRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerServiceBL" /> class.
        /// </summary>
        /// <param name="customerRepo">The invoice repo.</param>
        public CustomerServiceBL(IBaseRepo<Customer> customerRepo)
        {
            this._customerRepo = customerRepo;
        }

        /// <summary>
        /// Gets the customers filtred.
        /// </summary>
        /// <param name="purchaseFrom">The purchase from.</param>
        /// <param name="purchaseTo">The purchase to.</param>
        /// <param name="minAge">The minimum age.</param>
        /// <returns>
        /// List of customer
        /// </returns>
        /// <exception cref="BLException">Fecha minima de compra no es válida
        /// or
        /// Fecha minima de compra no es válida</exception>
        public async Task<WebApiResponseDTO<List<CustomerDTO>>> GetBilledCustomers(DateTime purchaseFrom, DateTime purchaseTo, int minAge = 35)
        {
            var purchaseDateFrom = purchaseFrom > purchaseTo ? purchaseTo : purchaseFrom;
            var purchaseDateTo = purchaseTo < purchaseFrom ? purchaseFrom : purchaseTo;

            if (purchaseDateFrom > DateTime.UtcNow)
            {
                throw new BLException("Fecha minima de compra no es válida");
            }

            if (purchaseDateTo > DateTime.UtcNow)
            {
                throw new BLException("Fecha máxima de compra no es válida");
            }

            if (minAge < 1)
            {
                throw new BLException("Edad no es válida");
            }

            var customersDto = await this._customerRepo.Get().Include(x => x.Invoices).Where(
                 x => x.Invoices.Count > 0  ///Que tengan facturas
                   && (DateTime.UtcNow.Year - x.DateOfBirth.Year) <= minAge //Que tengan menos de la edad mínima
                   && x.Invoices.Any(x => x.CreatedOn >= purchaseDateFrom.ToUniversalTime() && x.CreatedOn <= purchaseDateTo.ToUniversalTime()) // Filtro por el rango de fechas
                )
                .Select(x => new CustomerDTO(x))
                .ToListAsync();

            return new WebApiResponseDTO<List<CustomerDTO>>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = customersDto
            };
        }

        /// <summary>
        /// Tries to get next purchase.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>
        /// Next Purchase
        /// </returns>
        /// <exception cref="BLException">Cliente no existe</exception>
        public async Task<WebApiResponseDTO<CustomerNextPurchaseDTO>> TryToGetNextPurchase(int customerId)
        {
            var customer = await this._customerRepo.Get()
                .Include(x => x.Invoices)
                .FirstOrDefaultAsync(x => x.CustomerId == customerId);

            if (customer == null)
            {
                throw new BLException("Cliente no existe");
            }

            var nextPurchaseDTO = customer.Invoices.GroupBy(x => x.CustomerId).Select(x => new CustomerNextPurchaseDTO()
            {
                Name = x.First().Customer.FullName,
                PurchaseFrecuency = (x.Max(x => x.CreatedOn) - x.Min(x => x.CreatedOn)).Days / x.Count(),
                NextPurchaseDateAprox = DateTime.UtcNow.AddDays((x.Max(x => x.CreatedOn) - x.Min(x => x.CreatedOn)).Days / x.Count())
            }).FirstOrDefault();

            return new WebApiResponseDTO<CustomerNextPurchaseDTO>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = nextPurchaseDTO
            };
        }
    }
}
