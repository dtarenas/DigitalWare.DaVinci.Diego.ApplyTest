namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Invoice Details DTO
    /// </summary>
    public class InvoiceDetailsDTO
    {
        /// <summary>
        /// Gets or sets the invoice detail identifier.
        /// </summary>
        /// <value>
        /// The invoice detail identifier.
        /// </value>
        [Display(Name = "Id")]
        public int InvoiceDetailId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        [Display(Name = "Nombre producto")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        [Display(Name = "Id Producto")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the item price.
        /// </summary>
        /// <value>
        /// The item price.
        /// </value>
        [Display(Name = "Precio")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} no es válido")]
        public decimal ItemPrice { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        [Display(Name = "Notas adicionales")]
        [StringLength(800, ErrorMessage = "{0} no puede superar {1} carácteres")]
        public string Notes { get; set; }
    }
}
