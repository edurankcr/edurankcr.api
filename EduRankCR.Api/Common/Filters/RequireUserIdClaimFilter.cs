using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EduRankCR.Api.Common.Filters;

public class RequireUserIdClaimFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata
            .OfType<Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute>()
            .Any();

        if (allowAnonymous)
        {
            return;
        }

        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
        {
            context.Result = new ObjectResult(new
            {
                title = "Unauthorized",
            })
            {
                StatusCode = StatusCodes.Status401Unauthorized,
            };

            return;
        }

        context.HttpContext.Items["UserId"] = userId;
    }
}