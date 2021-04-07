#nullable disable

namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.Models
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Invoice Detail Class Entity
    /// </summary>
    [Table("invoice_details")]
    public partial class InvoiceDetail
    {
        /// <summary>
        /// Gets or sets the invoice detail identifier.
        /// </summary>
        /// <value>
        /// The invoice detail identifier.
        /// </value>
        [Key]
        [Column("invoice_detail_id")]
        public int InvoiceDetailId { get; set; }

        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        [Column("invoice_id")]
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        [Column("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [Column("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the item price.
        /// </summary>
        /// <value>
        /// The item price.
        /// </value>
        [Column("item_price", TypeName = "decimal(18, 2)")]
        public decimal ItemPrice { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        [Column("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [Column("status")]
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>
        /// The invoice.
        /// </value>
        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("InvoiceDetails")]
        public virtual Invoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("InvoiceDetails")]
        public virtual Product Product { get; set; }
    }
}
