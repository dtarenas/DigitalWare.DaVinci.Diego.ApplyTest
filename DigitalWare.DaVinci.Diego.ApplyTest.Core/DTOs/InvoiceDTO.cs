namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Invoice DTO
    /// </summary>
    public class InvoiceDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceDTO"/> class.
        /// </summary>
        public InvoiceDTO()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceDTO"/> class.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public InvoiceDTO(Invoice invoice)
        {
            InvoiceId = invoice.InvoiceId;
            Customer = new CustomerDTO
            {
                FullName = invoice.Customer.FullName,
                Email = invoice.Customer.Email,
                Phone = invoice.Customer.Phone,
                IDType = invoice.Customer.IdType,
                IDNumber = invoice.Customer.IdNumber,
                DateOfBirth = invoice.Customer.DateOfBirth
            };
            Consecutive = invoice.Consecutive;
            TotalAmount = invoice.TotalAmount;
            PaymentWay = invoice.PaymentWay;
            CreatedOn = invoice.CreatedOn;
            Notes = invoice.Notes;
            InvoiceStatus = invoice.InvoiceStatus;
            Seller = invoice.Seller;
            Status = invoice.Status;
            InvoiceDetails = invoice.InvoiceDetails.Select(invoiceInvoiceDetail => new InvoiceDetailsDTO
            {
                InvoiceDetailId = invoiceInvoiceDetail.InvoiceDetailId,
                ProductId = invoiceInvoiceDetail.ProductId,
                Quantity = invoiceInvoiceDetail.Quantity,
                ItemPrice = invoiceInvoiceDetail.ItemPrice,
                Notes = invoiceInvoiceDetail.Notes
            }).ToList();
        }

        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        [Display(Name = "Id")]
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        [Display(Name = "Customer")]
        public CustomerDTO Customer { get; set; }

        /// <summary>
        /// Gets or sets the consecutive.
        /// </summary>
        /// <value>
        /// The consecutive.
        /// </value>
        [Display(Name = "Consecutivo")]
        public Guid Consecutive { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        [Display(Name = "Monto Total")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} debe ser mayor a {1}")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the payment way.
        /// </summary>
        /// <value>
        /// The payment way.
        /// </value>
        [Display(Name = "Forma de pago")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public PaymentWays PaymentWay { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        [Display(Name = "Fecha de registro")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        [Display(Name = "Notas")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the invoice status.
        /// </summary>
        /// <value>
        /// The invoice status.
        /// </value>
        [Display(Name = "Estado de la factura")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public InvoiceStatus InvoiceStatus { get; set; } = InvoiceStatus.Payed;

        /// <summary>
        /// Gets or sets the seller.
        /// </summary>
        /// <value>
        /// The seller.
        /// </value>
        [Display(Name = "Vendedor")]
        [StringLength(100, ErrorMessage = "{0} no debe contener más de {1} carácters")]
        public string Seller { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [Display(Name = "Estado de registro")]
        public Status Status { get; set; } = Status.Enable;

        /// <summary>
        /// Gets or sets the invoice details.
        /// </summary>
        /// <value>
        /// The invoice details.
        /// </value>
        [Display(Name = "Detalle de factura")]
        public List<InvoiceDetailsDTO> InvoiceDetails { get; set; }
    }
}
