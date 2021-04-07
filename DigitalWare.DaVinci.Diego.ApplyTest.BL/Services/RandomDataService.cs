namespace DigitalWare.DaVinci.Diego.ApplyTest.BL.Services
{
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Exceptions;
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades;
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Utils;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models;
    using DigitalWare.DaVinci.Diego.ApplyTest.DAL.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Random Data Service
    /// </summary>
    /// <seealso cref="DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades.IRandomDataService" />
    public class RandomDataService : IRandomDataService
    {
        /// <summary>
        /// The product repo
        /// </summary>
        private readonly IBaseRepo<Product> _productRepo;

        /// <summary>
        /// The customer repo
        /// </summary>
        private readonly IBaseRepo<Customer> _customerRepo;

        /// <summary>
        /// The invoice repo
        /// </summary>
        private readonly IBaseRepo<Invoice> _invoiceRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomDataService" /> class.
        /// </summary>
        /// <param name="productRepo">The product repo.</param>
        /// <param name="customerRepo">The customer repo.</param>
        /// <param name="invoiceRepo">The invoice repo.</param>
        public RandomDataService(IBaseRepo<Product> productRepo, IBaseRepo<Customer> customerRepo, IBaseRepo<Invoice> invoiceRepo)
        {
            this._productRepo = productRepo;
            this._customerRepo = customerRepo;
            this._invoiceRepo = invoiceRepo;
        }

        /// <summary>
        /// Creates the random invoices.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>
        /// List of Invoice DTOs
        /// </returns>
        /// <exception cref="BLException">No hay productos disponibles</exception>
        public async Task<WebApiResponseDTO<List<Invoice>>> CreateRandomInvoices(int quantity = 1)
        {
            if (!await this._productRepo.Get().AnyAsync())
            {
                throw new BLException("No hay productos disponibles.");
            }

            if (!await this._customerRepo.Get().AnyAsync())
            {
                throw new BLException("No hay clientes disponibles.");
            }

            var products = await this._productRepo.Get().ToListAsync();
            var customers = await this._customerRepo.Get().ToListAsync();
            var invoices = Enumerable.Range(1, quantity).Select(x => new Invoice()
            {
                Consecutive = Guid.NewGuid(),
                CreatedOn = RandomDate(2000, 2, 1),
                InvoiceStatus = InvoiceStatus.Payed,
                Notes = $"Notas Notas {x}",
                PaymentWay = PaymentWays.Cash,
                Seller = $"Vendedor Ramdon {x}",
                InvoiceDetails = products.Select(x => new InvoiceDetail()
                {
                    ItemPrice = x.SalesPrice,
                    Notes = "Random",
                    Quantity = new Random().Next(1, 5),
                    Status = Status.Enable,
                    ProductId = x.ProductId,
                }).OrderBy(x => Guid.NewGuid()).Take(2).ToList(),
                TotalAmount = 10000,
                Status = Status.Enable,
                CustomerId = customers.OrderBy(x => Guid.NewGuid()).First().CustomerId
            }).ToList();

            var newInvoices = new List<Invoice>();
            foreach (var invoice in invoices)
            {
                invoice.TotalAmount = invoice.InvoiceDetails.Sum(x => x.ItemPrice * x.Quantity);
                newInvoices.Add(invoice);
            }

            newInvoices = (List<Invoice>)await this._invoiceRepo.AddAsync(newInvoices);
            await this._invoiceRepo.SaveChangesAsync();

            return new WebApiResponseDTO<List<Invoice>>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = newInvoices.ToList()
            };
        }

        /// <summary>
        /// Creates the random products.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        /// <exception cref="BLException">Cantidad a generar debe ser mayor a 1 y menor a 10</exception>
        public async Task<WebApiResponseDTO<List<Product>>> CreateRandomProducts(int quantity = 1)
        {
            if (quantity < 1 || quantity > 10)
            {
                throw new BLException("Cantidad a generar debe ser mayor a 1 y menor a 10");
            }

            var rdn = new Random();
            var products = Enumerable.Range(1, quantity).Select(x => new Product()
            {
                Description = $"Description Aleatorea {x}",
                PictureUrl = "https://dummyimage.com/640x360/fff/aaa",
                ProductId = 0,
                SalesPrice = rdn.Next(10000, 200000),
                Status = Status.Enable,
                Stock = rdn.Next(1, 200)
            });

            products = await this._productRepo.AddAsync(products);
            await this._productRepo.SaveChangesAsync();

            return new WebApiResponseDTO<List<Product>>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = products.ToList()
            };
        }

        /// <summary>
        /// Creates the random customers.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>Customer</returns>
        /// <exception cref="BLException">Cantidad a generar debe ser mayor a 1 y menor a 10</exception>
        public async Task<WebApiResponseDTO<List<Customer>>> CreateRandomCustomers(int quantity = 1)
        {
            if (quantity < 1 || quantity > 10)
            {
                throw new BLException("Cantidad a generar debe ser mayor a 1 y menor a 10");
            }

            var rdn = new Random();
            var customers = Enumerable.Range(1, quantity).Select(x => new Customer()
            {
                DateOfBirth = RandomDate(1974, 5, 1),
                Email = $"test{x}@test.com",
                FirstName = $"Nombre aleatoreo {x}",
                IdNumber = $"1234{x}",
                IdType = IDTypes.CC,
                LastName = $"Apellidos aleatorios {x}",
                Phone = $"321654{x}",
                Status = Status.Enable
            });

            customers = await this._customerRepo.AddAsync(customers);
            await this._customerRepo.SaveChangesAsync();

            return new WebApiResponseDTO<List<Customer>>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = customers.ToList()
            };
        }

        /// <summary>
        /// Randoms the day.
        /// </summary>
        /// <param name="startYear">The start year.</param>
        /// <param name="startMonth">The start month.</param>
        /// <param name="startDay">The start day.</param>
        /// <returns>
        /// Random Date
        /// </returns>
        private static DateTime RandomDate(int startYear = 2000, int startMonth = 1, int startDay = 1)
        {
            var random = new Random();
            var start = new DateTime(startYear, startMonth, startDay);
            return start.AddDays(random.Next(360));
        }
    }
}
