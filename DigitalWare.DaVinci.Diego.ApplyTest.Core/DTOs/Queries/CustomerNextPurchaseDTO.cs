namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Queries
{
    using System;

    /// <summary>
    /// Customer Next Purchase DTO
    /// </summary>
    public class CustomerNextPurchaseDTO
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the purchase frecuency.
        /// </summary>
        /// <value>
        /// The purchase frecuency.
        /// </value>
        public int PurchaseFrecuency { get; set; }

        /// <summary>
        /// Gets or sets the next purchase date aprox.
        /// </summary>
        /// <value>
        /// The next purchase date aprox.
        /// </value>
        public DateTime NextPurchaseDateAprox { get; set; }

        /// <summary>
        /// Gets the next purchase date aprox local.
        /// </summary>
        /// <value>
        /// The next purchase date aprox local.
        /// </value>
        public DateTime NextPurchaseDateAproxLocal => this.NextPurchaseDateAprox.ToLocalTime();
    }
}
