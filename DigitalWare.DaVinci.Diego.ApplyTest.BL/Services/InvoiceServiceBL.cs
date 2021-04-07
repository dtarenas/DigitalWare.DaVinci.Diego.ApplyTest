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
    /// Invoice Service BL Implementation
    /// </summary>
    /// <seealso cref="DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades.IInvoiceServiceBL" />
    public class InvoiceServiceBL : IInvoiceServiceBL
    {
        /// <summary>
        /// The invoice repo
        /// </summary>
        private readonly IBaseRepo<Invoice> _invoiceRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceServiceBL" /> class.
        /// </summary>
        /// <param name="invoiceRepo">The invoice repo.</param>
        public InvoiceServiceBL(IBaseRepo<Invoice> invoiceRepo)
        {
            this._invoiceRepo = invoiceRepo;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="invoiceDTO">The invoice dto.</param>
        /// <returns>
        /// Invoice DTO
        /// </returns>
        public async Task<WebApiResponseDTO<InvoiceDTO>> CreateAsync(InvoiceDTO invoiceDTO)
        {
            var invoice = new Invoice(invoiceDTO);
            await this._invoiceRepo.AddAsync(invoice);
            await this._invoiceRepo.SaveChangesAsync();
            invoiceDTO.InvoiceId = invoice.InvoiceId;
            return new WebApiResponseDTO<InvoiceDTO>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = invoiceDTO
            };
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="invoiceDTOs">The invoice dt os.</param>
        /// <returns>
        /// List of Invoice DTO
        /// </returns>
        public async Task<WebApiResponseDTO<List<InvoiceDTO>>> CreateAsync(List<InvoiceDTO> invoiceDTOs)
        {
            var invoices = invoiceDTOs.Select(x => new Invoice(x));
            await this._invoiceRepo.AddAsync(invoices);
            await this._invoiceRepo.SaveChangesAsync();
            return new WebApiResponseDTO<List<InvoiceDTO>>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = invoiceDTOs
            };
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns></returns>
        /// <exception cref="DigitalWare.DaVinci.Diego.ApplyTest.BL.Exceptions.BLException">Factura no encontrada</exception>
        public async Task<WebApiResponseDTO<object>> DeleteAsync(int invoiceId)
        {
            var invoice = await this._invoiceRepo.Get().FirstOrDefaultAsync(x => x.InvoiceId == invoiceId);
            if (invoice == null)
            {
                throw new BLException("Factura no encontrada");
            }

            await this._invoiceRepo.DeleteAsync(invoiceId);
            await this._invoiceRepo.SaveChangesAsync();

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
        /// List of Invoice DTO
        /// </returns>
        public async Task<WebApiResponseDTO<List<InvoiceDTO>>> GetAsync()
        {
            var invoices = await this._invoiceRepo.Get().Select(x => new InvoiceDTO(x)).ToListAsync();
            return new WebApiResponseDTO<List<InvoiceDTO>>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = invoices
            };
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns>
        /// Invoice DTO
        /// </returns>
        public async Task<WebApiResponseDTO<InvoiceDTO>> GetAsync(int invoiceId)
        {
            var invoice = await this._invoiceRepo.Get().FirstOrDefaultAsync(x => x.InvoiceId == invoiceId);
            if (invoice == null)
            {
                throw new BLException("Factura no encontrada");
            }

            return new WebApiResponseDTO<InvoiceDTO>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = new InvoiceDTO(invoice)
            };
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <param name="invoiceDTO">The invoice dto.</param>
        /// <returns>
        /// Invoice DTO
        /// </returns>
        /// <exception cref="DigitalWare.DaVinci.Diego.ApplyTest.BL.Exceptions.BLException">
        /// Factura no encontrada
        /// or
        /// Factura no encontrada
        /// </exception>
        public async Task<WebApiResponseDTO<InvoiceDTO>> UpdateAsync(int invoiceId, InvoiceDTO invoiceDTO)
        {
            if (invoiceId != invoiceDTO.InvoiceId)
            {
                throw new BLException("Factura no encontrada");
            }

            var invoice = await this._invoiceRepo.Get().FirstOrDefaultAsync(x => x.InvoiceId == invoiceId);
            if (invoice == null)
            {
                throw new BLException("Factura no encontrada");
            }

            SetNewValuesForInvoice(invoiceDTO, invoice);
            this._invoiceRepo.Update(invoice);
            await this._invoiceRepo.SaveChangesAsync();

            return new WebApiResponseDTO<InvoiceDTO>()
            {
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = Constants.OkMessage,
                ObjResult = invoiceDTO
            };
        }

        /// <summary>
        /// Sets the new values for invoice.
        /// </summary>
        /// <param name="invoiceDTO">The invoice dto.</param>
        /// <param name="invoice">The invoice.</param>
        private static void SetNewValuesForInvoice(InvoiceDTO invoiceDTO, Invoice invoice)
        {
            invoice.InvoiceId = invoiceDTO.InvoiceId;
            invoice.Consecutive = invoiceDTO.Consecutive;
            invoice.TotalAmount = invoiceDTO.TotalAmount;
            invoice.PaymentWay = invoiceDTO.PaymentWay;
            invoice.CreatedOn = invoiceDTO.CreatedOn;
            invoice.Notes = invoiceDTO.Notes;
            invoice.InvoiceStatus = invoiceDTO.InvoiceStatus;
            invoice.Seller = invoiceDTO.Seller;
            invoice.Status = invoiceDTO.Status;

            invoice.Customer.Email = invoiceDTO.Customer.Email;
            invoice.Customer.Phone = invoiceDTO.Customer.Phone;
            invoice.Customer.IdType = invoiceDTO.Customer.IDType;
            invoice.Customer.IdNumber = invoiceDTO.Customer.IDNumber;
            invoice.Customer.DateOfBirth = invoiceDTO.Customer.DateOfBirth;
            invoice.Customer.FirstName = invoiceDTO.Customer.FullName;

            invoice.InvoiceDetails = invoiceDTO.InvoiceDetails.ConvertAll(invoiceDTOInvoiceDetail => new InvoiceDetail
            {
                InvoiceDetailId = invoiceDTOInvoiceDetail.InvoiceDetailId,
                Quantity = invoiceDTOInvoiceDetail.Quantity,
                ItemPrice = invoiceDTOInvoiceDetail.ItemPrice,
                Notes = invoiceDTOInvoiceDetail.Notes
            });
        }
    }
}
