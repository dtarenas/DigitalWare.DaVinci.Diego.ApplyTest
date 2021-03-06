#nullable disable

namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.Models
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Invoice Class Entity
    /// </summary>
    /// <seealso cref="DigitalWare.DaVinci.Diego.ApplyTest.Core.Models.Base.BaseEntity" />
    [Table("invoices")]
    public partial class Invoice : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class.
        /// </summary>
        public Invoice()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class.
        /// </summary>
        /// <param name="invoiceDTO">The invoice dto.</param>
        public Invoice(InvoiceDTO invoiceDTO)
        {
            InvoiceId = invoiceDTO.InvoiceId;
            Consecutive = invoiceDTO.Consecutive ?? Guid.NewGuid();
            TotalAmount = invoiceDTO.TotalAmount;
            PaymentWay = invoiceDTO.PaymentWay;
            CreatedOn = invoiceDTO.CreatedOn;
            Notes = invoiceDTO.Notes;
            InvoiceStatus = invoiceDTO.InvoiceStatus;
            Seller = invoiceDTO.Seller;
            Customer = new Customer
            {
                Email = invoiceDTO.Customer.Email,
                Phone = invoiceDTO.Customer.Phone,
                IdType = invoiceDTO.Customer.IDType,
                IdNumber = invoiceDTO.Customer.IDNumber,
                DateOfBirth = invoiceDTO.Customer.DateOfBirth,
                FirstName = invoiceDTO.Customer.FullName,
                Status = Status.Enable
            };
            InvoiceDetails = invoiceDTO.InvoiceDetails.ConvertAll(invoiceDTOInvoiceDetail => new InvoiceDetail
            {
                InvoiceDetailId = invoiceDTOInvoiceDetail.InvoiceDetailId,
                ProductId = invoiceDTOInvoiceDetail.ProductId,
                Quantity = invoiceDTOInvoiceDetail.Quantity,
                ItemPrice = invoiceDTOInvoiceDetail.ItemPrice,
                Notes = invoiceDTOInvoiceDetail.Notes,
                Status = Status.Enable,
            });
            Status = invoiceDTO.Status;
        }

        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        [Key]
        [Column("invoice_id")]
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        [Column("customer_id")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the consecutive.
        /// </summary>
        /// <value>
        /// The consecutive.
        /// </value>
        [Column("consecutive")]
        public Guid Consecutive { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        [Column("total_amount", TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the payment way.
        /// </summary>
        /// <value>
        /// The payment way.
        /// </value>
        [Column("payment_way")]
        public PaymentWays PaymentWay { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        [Column("created_on", TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        [Required]
        [Column("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the invoice status.
        /// </summary>
        /// <value>
        /// The invoice status.
        /// </value>
        [Column("invoice_status")]
        public InvoiceStatus InvoiceStatus { get; set; }

        /// <summary>
        /// Gets or sets the seller.
        /// </summary>
        /// <value>
        /// The seller.
        /// </value>
        [Column("seller")]
        [StringLength(100)]
        public string Seller { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Invoices")]
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the invoice details.
        /// </summary>
        /// <value>
        /// The invoice details.
        /// </value>
        [InverseProperty(nameof(InvoiceDetail.Invoice))]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}