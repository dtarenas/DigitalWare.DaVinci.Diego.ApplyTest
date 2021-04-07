namespace DigitalWare.DaVinci.Diego.ApplyTest.BL.Exceptions
{
    using System;
    
    /// <summary>
    /// Bussines Logic Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class BLException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BLException"/> class.
        /// </summary>
        public BLException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BLException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BLException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BLException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> in Visual Basic) if no inner exception is specified.</param>
        public BLException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
