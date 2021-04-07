namespace DigitalWare.DaVinci.Diego.ApplyTest.BL.Services
{
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Exceptions;
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades;
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Utils;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models;
    using DigitalWare.DaVinci.Diego.ApplyTest.DAL.Repositories;
    using Microsoft.EntityFrameworkCore;
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
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="productDTOs">The product dt os.</param>
        /// <returns>
        /// List of Product DTO
        /// </returns>
        public async Task<WebApiResponseDTO<List<ProductDTO>>> CreateAsync(List<ProductDTO> productDTOs)
        {
            var products = productDTOs.Select(x => new Product(x));
            await this._productRepo.AddAsync(products);
            await this._productRepo.SaveChangesAsync();
            return new WebApiResponseDTO<List<ProductDTO>>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = productDTOs
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
