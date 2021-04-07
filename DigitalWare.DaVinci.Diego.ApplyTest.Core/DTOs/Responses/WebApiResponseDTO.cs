namespace DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses
{
    using System.Net;

    /// <summary>
    /// WebApi Response DTO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses.GenericResponseDTO{T}" />
    public class WebApiResponseDTO<T> : GenericResponseDTO<T>
    {
        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        /// <value>
        /// The HTTP status code.
        /// </value>
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
