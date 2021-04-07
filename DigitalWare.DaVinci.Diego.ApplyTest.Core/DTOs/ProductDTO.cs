﻿namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Product DTO
    /// </summary>
    public class ProductDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDTO"/> class.
        /// </summary>
        public ProductDTO()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDTO"/> class.
        /// </summary>
        /// <param name="product">The product.</param>
        public ProductDTO(Product product)
        {
            ProductId = product.ProductId;
            Description = product.Description;
            PictureUrl = product.PictureUrl;
            Stock = product.Stock;
            SalesPrice = product.SalesPrice;
            Status = product.Status;
        }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        [Display(Name = "Id")]
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Display(Name = "Descripción")]
        [StringLength(800)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the picture URL.
        /// </summary>
        /// <value>
        /// The picture URL.
        /// </value>
        [StringLength(500)]
        [Display(Name = "Url Imagen")]
        public string PictureUrl { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// </summary>
        /// <value>
        /// The stock.
        /// </value>
        [Display(Name = "Cantidad disponible")]
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the sales price.
        /// </summary>
        /// <value>
        /// The sales price.
        /// </value>
        [Display(Name = "Precio de venta")]
        public decimal SalesPrice { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [Display(Name = "Estado del registro")]
        public Status Status { get; set; }
    }
}
