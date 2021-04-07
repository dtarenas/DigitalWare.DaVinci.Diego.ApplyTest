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
    /// Product Service BL Implementation
    /// </summary>
    /// <seealso cref="DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades.IProductServiceBL" />
    public class ProductServiceBL : IProductServiceBL
    {
        /// <summary>
        /// The product repo
        /// </summary>
        private readonly IBaseRepo<Product> _productRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductServiceBL"/> class.
        /// </summary>
        /// <param name="productRepo">The product repo.</param>
        public ProductServiceBL(IBaseRepo<Product> productRepo)
        {
            this._productRepo = productRepo;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="productDTO">The product dto.</param>
        /// <returns>
        /// Product DTO
        /// </returns>
        public async Task<WebApiResponseDTO<ProductDTO>> CreateAsync(ProductDTO productDTO)
        {
            var product = new Product(productDTO);
            await this._productRepo.AddAsync(product);
            await this._productRepo.SaveChangesAsync();
            productDTO.ProductId = product.ProductId;
            return new WebApiResponseDTO<ProductDTO>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = productDTO
            };
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Result DTO</returns>
        /// <exception cref="DigitalWare.DaVinci.Diego.ApplyTest.BL.Exceptions.BLException">Producto no encontrado</exception>
        public async Task<WebApiResponseDTO<object>> DeleteAsync(int productId)
        {
            var product = await this._productRepo.Get().FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                throw new BLException("Producto no encontrado");
            }

            await this._productRepo.DeleteAsync(productId);
            await this._productRepo.SaveChangesAsync();

            return new WebApiResponseDTO<object>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = null
            };
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns>
        /// List of Product DTO
        /// </returns>
        public async Task<WebApiResponseDTO<List<ProductDTO>>> GetAsync()
        {
            var products = await this._productRepo.Get().Select(x => new ProductDTO(x)).ToListAsync();
            return new WebApiResponseDTO<List<ProductDTO>>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = products
            };
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// Product DTO
        /// </returns>
        public async Task<WebApiResponseDTO<ProductDTO>> GetAsync(int productId)
        {
            var product = await this._productRepo.Get().FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                throw new BLException("Producto no encontrado");
            }

            return new WebApiResponseDTO<ProductDTO>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = new ProductDTO(product)
            };
        }

        /// <summary>
        /// Gets the by minimal stock.
        /// </summary>
        /// <param name="minStock">The minimum stock.</param>
        /// <returns>
        /// List of product DTO
        /// </returns>
        /// <exception cref="BLException">No hay productos disponibles</exception>
        public async Task<WebApiResponseDTO<List<ProductDTO>>> GetByMinimalStock(int? minStock = 5)
        {
            if (!await this._productRepo.Get().AnyAsync())
            {
                throw new BLException("No hay productos disponibles");
            }

            var products = await this._productRepo.Get().Where(x => x.Stock >= minStock).Select(x => new ProductDTO(x)).ToListAsync();
            return new WebApiResponseDTO<List<ProductDTO>>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = products
            };
        }

        /// <summary>
        /// Gets the prices asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// List of product prices
        /// </returns>
        /// <exception cref="BLException">No hay productos disponibles</exception>
        public async Task<WebApiResponseDTO<List<ProductPricesDTO>>> GetPricesAsync(int? id)
        {
            if (!await this._productRepo.Get().AnyAsync())
            {
                throw new BLException("No hay productos disponibles");
            }

            var productPricesDto = await this._productRepo.Get().Where(x => x.Stock >= 5 && x.ProductId == (id ?? x.ProductId)).Select(x => new ProductPricesDTO()
            {
                Name = x.Description,
                Price = x.SalesPrice,
                ProductId = x.ProductId
            }).ToListAsync();

            return new WebApiResponseDTO<List<ProductPricesDTO>>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = productPricesDto
            };
        }

        /// <summary>
        /// Gets the total amount sold asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="year">The year.</param>
        /// <returns>
        /// List of totals
        /// </returns>
        /// <exception cref="BLException">Año no permitido</exception>
        public async Task<WebApiResponseDTO<List<ProductTotalAmountSoldDTO>>> GetTotalAmountSoldAsync(int? productId, int? year = 2000)
        {
            if (year > DateTime.UtcNow.Year)
            {
                throw new BLException("Año no permitido");
            }

            ////Obtengo todos los productos
            var products = await this._productRepo.Get()
                .Include(x => x.InvoiceDetails)
                .ThenInclude(x => x.Invoice)
                .Where(x => x.ProductId == (productId ?? x.ProductId))
                .ToListAsync();

            if (products.Count == 0)
            {
                throw new BLException("Producto no existe");
            }

            ////Obtengo totales
            var totalSoldDto = products.SelectMany(x => x.InvoiceDetails).Where(x => x.Invoice.CreatedOn.Year == year).GroupBy(x => x.ProductId).Select(x => new ProductTotalAmountSoldDTO()
            {
               ProductId = x.Key,
               TotalAmountSold = x.Sum(x => x.ItemPrice * x.Quantity),
               Description = x.First().Product.Description
            }).ToList();

            return new WebApiResponseDTO<List<ProductTotalAmountSoldDTO>>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = totalSoldDto
            };
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productDTO">The product dto.</param>
        /// <returns>
        /// Product DTO
        /// </returns>
        /// <exception cref="DigitalWare.DaVinci.Diego.ApplyTest.BL.Exceptions.BLException">
        /// Producto no encontrado
        /// or
        /// Producto no encontrado
        /// </exception>
        public async Task<WebApiResponseDTO<ProductDTO>> UpdateAsync(int productId, ProductDTO productDTO)
        {
            if (productId != productDTO.ProductId)
            {
                throw new BLException("Producto no encontrado");
            }

            var product = await this._productRepo.Get().FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                throw new BLException("Producto no encontrado");
            }

            product.Description = productDTO.Description;
            product.PictureUrl = productDTO.PictureUrl;
            product.ProductId = productDTO.ProductId;
            product.SalesPrice = productDTO.SalesPrice;
            product.Status = product.Status;
            product.Stock = productDTO.Stock;

            this._productRepo.Update(product);
            await this._productRepo.SaveChangesAsync();

            return new WebApiResponseDTO<ProductDTO>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = productDTO
            };
        }
    }
}
