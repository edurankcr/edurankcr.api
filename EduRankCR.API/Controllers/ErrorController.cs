using EduRankCR.Application.Common.Errors;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        (int statusCode, string message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (500, "An error occurred"),
        };

        return Problem(title: message, statusCode: statusCode);
    }
}