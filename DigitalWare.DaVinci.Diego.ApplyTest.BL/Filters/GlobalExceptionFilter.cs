namespace DigitalWare.DaVinci.Diego.ApplyTest.BL.Filters
{
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Exceptions;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text.Json;

    /// <summary>
    /// Global Exception Filter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter" />
    public class GlobalExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Called after an action has thrown an <see cref="T:System.Exception" />.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" />.</param>
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BLException))
            {
                var exception = (BLException)context.Exception;
                var apiResponse = new WebApiResponseDTO<string>()
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    Message = exception.Message,
                    ObjResult = exception?.InnerException?.Message
                };

                context.Result = new BadRequestObjectResult(apiResponse);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
            else
            {
                var exception = context.Exception;
                var apiResponse = new WebApiResponseDTO<string>()
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    Message = exception.Message,
                    ObjResult = exception?.InnerException?.Message
                };

                context.Result = new BadRequestObjectResult(apiResponse);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = false;
            }
        }
    }
}
