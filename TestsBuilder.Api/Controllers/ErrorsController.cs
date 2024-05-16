using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestsBuilder.Application.Common.Errors;

namespace TestsBuilder.Api.Controllers
{
    public class ErrorsController:ControllerBase
    {
        [HttpGet("/error")]
        public IActionResult Error()
        {
            Exception? ex = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = ex switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured."),
            };

            return Problem(statusCode: statusCode,title:message);
        }
    }
}
