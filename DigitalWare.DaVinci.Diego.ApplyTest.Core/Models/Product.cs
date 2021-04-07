#nullable disable

namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.Models
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Product Class Entity
    /// </summary>
    /// <seealso cref="DigitalWare.DaVinci.Diego.ApplyTest.Core.Models.Base.BaseEntity" />
    [Table("products")]
    public partial class Product : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productDTO">The product dto.</param>
        public Product(ProductDTO productDTO)
        {
            ProductId = productDTO.ProductId;
            Description = productDTO.Description;
            PictureUrl = productDTO.PictureUrl;
            Stock = productDTO.Stock;
            SalesPrice = productDTO.SalesPrice;
            Status = productDTO.Status;
        }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Column("description")]
        [StringLength(800)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the picture URL.
        /// </summary>
        /// <value>
        /// The picture URL.
        /// </value>
        [Column("picture_url")]
        [StringLength(500)]
        public string PictureUrl { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// </summary>
        /// <value>
        /// The stock.
        /// </value>
        [Column("stock")]
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the sales price.
        /// </summary>
        /// <value>
        /// The sales price.
        /// </value>
        [Column("sales_price", TypeName = "decimal(18, 2)")]
        public decimal SalesPrice { get; set; }

        /// <summary>
        /// Gets or sets the invoice details.
        /// </summary>
        /// <value>
        /// The invoice details.
        /// </value>
        [InverseProperty(nameof(InvoiceDetail.Product))]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
