using EduRankCR.Application.Common.Errors;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers.Common;

[ApiController]
[Route("/error")]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred"),
        };

        return Problem(statusCode: statusCode, title: message);
    }
}