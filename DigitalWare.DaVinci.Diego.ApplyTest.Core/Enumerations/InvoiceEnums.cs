namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Invoice Status Enum
    /// </summary>
    public enum InvoiceStatus
    {
        /// <summary>
        /// The void
        /// </summary>
        [Display(Name = "Anulada")]
        Void = 0,

        /// <summary>
        /// The pending
        /// </summary>
        [Display(Name = "Pendiente de pago")]
        Pending = 1,

        /// <summary>
        /// The declined
        /// </summary>
        [Display(Name = "Rechazada")]
        Declined = 2,

        /// <summary>
        /// The payed
        /// </summary>
        [Display(Name = "Pagada")]
        Payed = 3
    }

    /// <summary>
    /// Payment Ways
    /// </summary>
    public enum PaymentWays
    {
        /// <summary>
        /// The card
        /// </summary>
        [Display(Name = "Tarjeta débito / crédito")]
        Card = 1,

        /// <summary>
        /// The pse
        /// </summary>
        [Display(Name = "PSE")]
        PSE = 2,

        /// <summary>
        /// The cash
        /// </summary>
        [Display(Name = "Efectivo")]
        Cash = 3
    }
}
