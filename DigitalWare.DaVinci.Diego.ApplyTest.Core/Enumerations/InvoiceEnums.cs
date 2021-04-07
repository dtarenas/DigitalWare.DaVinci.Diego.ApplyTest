namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Invoice Status Enum
    /// </summary>
    public enum InvoiceStatus
    {
        /// <summary>
        /// The void
        /// </summary>
        [Description("Anulada")]
        [Display(Name = "Anulada")]
        Void = 0,

        /// <summary>
        /// The pending
        /// </summary>
        [Description("Pendiente de pago")]
        [Display(Name = "Pendiente de pago")]
        Pending = 1,

        /// <summary>
        /// The declined
        /// </summary>
        [Description("Rechazada")]
        [Display(Name = "Rechazada")]
        Declined = 2,

        /// <summary>
        /// The payed
        /// </summary>
        [Description("Pagada")]
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
        [Description("Tarjeta débito / crédito")]
        [Display(Name = "Tarjeta débito / crédito")]
        Card = 1,

        /// <summary>
        /// The pse
        /// </summary>
        [Description("PSE")]
        [Display(Name = "PSE")]
        PSE = 2,

        /// <summary>
        /// The cash
        /// </summary>
        [Description("Efectivo")]
        [Display(Name = "Efectivo")]
        Cash = 3
    }
}
