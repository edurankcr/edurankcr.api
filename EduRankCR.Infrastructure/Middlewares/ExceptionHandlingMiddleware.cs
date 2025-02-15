using System.Net;
using System.Text.Json;
using EduRankCR.Application.Responses;
using FluentValidation;
using EduRankCR.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

// ReSharper disable UnusedVariable
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        string clientIp = context.Request.Headers["CF-Connecting-IP"].FirstOrDefault() 
                          ?? context.Request.Headers["X-Forwarded-For"].FirstOrDefault()?.Split(',')[0].Trim() 
                          ?? context.Connection.RemoteIpAddress?.ToString() 
                          ?? "Unknown";
        
        bool isClientError = exception is ArgumentNullException or ValidationException or NotFoundException;

        if (isClientError)
        {
            _logger.LogWarning("Client {IP} error | HTTP {Method} {Path} | Message: {Message}",
                clientIp,
                context.Request.Method,
                context.Request.Path, 
                exception.Message);
        }
        else
        {
            _logger.LogError(exception, "An error occurred while processing the request.");
        }

        context.Response.ContentType = "application/json";

        var (statusCode, errorCode, errorResponse) = GenerateErrorResponse(exception);

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }

    private (int statusCode, string errorCode, ApiResponse<object> errorResponse) GenerateErrorResponse(Exception exception)
    {
        int statusCode = exception switch
        {
            NotFoundException => (int)HttpStatusCode.NotFound,
            SqlException => (int)HttpStatusCode.InternalServerError,
            ArgumentNullException => (int)HttpStatusCode.BadRequest,
            ValidationException => (int)HttpStatusCode.UnprocessableEntity,
            _ => (int)HttpStatusCode.InternalServerError
        };

        string errorCode = exception switch
        {
            NotFoundException => "EXCEPTION_NOT_FOUND",
            SqlException => "EXCEPTION_SQL",
            ArgumentNullException => "EXCEPTION_ARGUMENT_NULL",
            ValidationException => "EXCEPTION_VALIDATION",
            _ => "INTERNAL_SERVER_ERROR"
        };

        ApiResponse<object> errorResponse = exception switch
        {
            ValidationException validationException => ApiResponse<object>.Validation(
                "VALIDATION_ERROR",
                validationException.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToList())
            ),

            _ => ApiResponse<object>.Error(exception.Message, errorCode)
        };

        return (statusCode, errorCode, errorResponse);
    }
}
