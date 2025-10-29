using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia.Core.Exceptions;
using System.Net;

namespace SocialMedia.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BussinesException bussinesEx)
            {
                // Error controlado (por ti)
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = bussinesEx.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                // Error general (por ejemplo, Dapper, null reference, etc.)
                var error = new
                {
                    Status = 500,
                    Title = "Internal Server Error",
                    Detail = context.Exception.Message
                };

                var json = new
                {
                    errors = new[] { error }
                };

                context.Result = new ObjectResult(json)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

            context.ExceptionHandled = true;
        }
    }
}