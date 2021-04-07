namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
  
    /// <summary>
    /// Status Enum
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// The disable
        /// </summary>
        [Description("Desactivo")]
        [Display(Name = "Desactivo")]
        Disable = 0,

        /// <summary>
        /// The enable
        /// </summary>
        [Description("Activo")]
        [Display(Name = "Activo")]
        Enable = 1
    }
}
