#nullable disable

namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.Models
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Product Class Entity
    /// </summary>
    [Table("products")]
    public partial class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetail>();
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
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [Column("status")]
        public Status Status { get; set; }

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
