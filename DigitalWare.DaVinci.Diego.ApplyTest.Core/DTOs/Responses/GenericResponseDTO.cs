namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses
{
    /// <summary>
    /// Generic Response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericResponseDTO<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the object result.
        /// </summary>
        /// <value>
        /// The object result.
        /// </value>
        public T ObjResult { get; set; }
    }
}
