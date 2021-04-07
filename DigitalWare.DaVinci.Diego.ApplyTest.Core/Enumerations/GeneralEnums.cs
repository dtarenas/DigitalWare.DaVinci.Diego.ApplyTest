namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations
{
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// Status Enum
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// The disable
        /// </summary>
        [Display(Name = "Desactivo")]
        Disable = 0,

        /// <summary>
        /// The enable
        /// </summary>
        [Display(Name = "Activo")]
        Enable = 1
    }
}
