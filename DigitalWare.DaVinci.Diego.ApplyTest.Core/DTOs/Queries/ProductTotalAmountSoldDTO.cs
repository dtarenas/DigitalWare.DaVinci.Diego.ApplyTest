namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Queries
{
    /// <summary>
    /// Product Total Amount Sol dTO
    /// </summary>
    public class ProductTotalAmountSoldDTO
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the total amount sold.
        /// </summary>
        /// <value>
        /// The total amount sold.
        /// </value>
        public decimal TotalAmountSold { get; set; }

        /// <summary>
        /// Gets the total amount sold string.
        /// </summary>
        /// <value>
        /// The total amount sold string.
        /// </value>
        public string TotalAmountSoldStr => this.TotalAmountSold.ToString("C");
    }
}
