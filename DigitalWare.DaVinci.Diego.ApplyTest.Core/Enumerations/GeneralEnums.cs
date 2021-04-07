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

    /// <summary>
    /// ID Types
    /// </summary>
    public enum IDTypes
    {
        /// <summary>
        /// The cc
        /// </summary>
        [Description("C.C")]
        [Display(Name = "C.C")]
        CC = 1,

        /// <summary>
        /// The ce
        /// </summary>
        [Description("C.E")]
        [Display(Name = "C.E")]
        CE = 2,

        /// <summary>
        /// The passport
        /// </summary>
        [Description("Pasaporte")]
        [Display(Name = "Pasaporte")]
        Passport = 3
    }
}
