namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Enumerations;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Customer DTO
    /// </summary>
    public class CustomerDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDTO"/> class.
        /// </summary>
        public CustomerDTO()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDTO"/> class.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public CustomerDTO(Customer customer)
        {
            FullName = customer.FullName;
            Email = customer.Email;
            Phone = customer.Phone;
            IDType = customer.IdType;
            IDNumber = customer.IdNumber;
            DateOfBirth = customer.DateOfBirth;
        }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        [Display(Name = "Nombre Completo")]
        [StringLength(100, ErrorMessage = "{0} no puede tener más de {1} carácteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage = "{0} no es válido")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the type of the identifier.
        /// </summary>
        /// <value>
        /// The type of the identifier.
        /// </value>
        [Display(Name = "Tipo de indentificación")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public IDTypes IDType { get; set; }

        /// <summary>
        /// Gets or sets the identifier number.
        /// </summary>
        /// <value>
        /// The identifier number.
        /// </value>
        [Display(Name = "Número de identificación")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string IDNumber { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets the date of birth local.
        /// </summary>
        /// <value>
        /// The date of birth local.
        /// </value>
        public DateTime DateOfBirthLocal => this.DateOfBirth.ToLocalTime();

        /// <summary>
        /// Gets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        [Display(Name = "Edad")]
        public int Age => DateTime.UtcNow.Year - DateOfBirth.Year;
    }
}
