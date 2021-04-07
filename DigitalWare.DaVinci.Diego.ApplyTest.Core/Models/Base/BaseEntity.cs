namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.Models.Base
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Base Entity
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [Column("status")]
        public Status Status { get; set; }
    }
}
