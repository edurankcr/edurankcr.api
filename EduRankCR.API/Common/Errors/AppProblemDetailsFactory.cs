using System.Diagnostics;

using EduRankCR.Api.Common.Http;

using ErrorOr;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace EduRankCR.Api.Common.Errors;

public class AppProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly Action<ProblemDetailsContext>? _configure;
    private readonly ApiBehaviorOptions _options;

    public AppProblemDetailsFactory(
        IOptions<ApiBehaviorOptions>? options,
        IOptions<ProblemDetailsOptions>? problemDetailsOptions = null)
    {
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        _configure = problemDetailsOptions?.Value.CustomizeProblemDetails;
    }

    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        statusCode ??= 500;

        ProblemDetails problemDetails = new()
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance,
        };

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(
        HttpContext httpContext,
        ModelStateDictionary modelStateDictionary,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        ArgumentNullException.ThrowIfNull(modelStateDictionary);

        statusCode ??= 400;

        ValidationProblemDetails problemDetails = new(modelStateDictionary)
        {
            Status = statusCode, Type = type, Detail = detail, Instance = instance,
        };

        if (title != null)
        {
            problemDetails.Title = title;
        }

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;

        if (_options.ClientErrorMapping.TryGetValue(statusCode, out ClientErrorData? clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        string traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

        problemDetails.Extensions["traceId"] = traceId;

        if (httpContext.Items[HttpContextItemsKeys.Errors] is List<Error> errors)
        {
            problemDetails.Extensions["errorCodes"] = errors.Select(e => e.Code).ToArray();
        }

        _configure?.Invoke(new ProblemDetailsContext { HttpContext = httpContext, ProblemDetails = problemDetails });
    }
}