using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Application.Responses
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public T Data { get; }
        public object Errors { get; }

        [JsonConstructor]
        internal ApiResponse(bool success, string message, T data, object errors)
        {
            IsSuccess = success;
            Message = message;
            Data = data;
            Errors = errors ?? new List<string>();
        }
        public static ApiResponse<T> Success(T data, string message = "SUCCESS") =>
            new ApiResponse<T>(true, message, data, new List<string>());
        public static ApiResponse<T> Error(string message, params string[] errors) =>
            new ApiResponse<T>(false, message, default, errors.Length > 0 ? errors.ToList() : new List<string>());
        public static ApiResponse<T> Validation(string message, Dictionary<string, List<string>> errors) =>
            new ApiResponse<T>(false, message, default, errors ?? new Dictionary<string, List<string>>());
    }

    public static class ApiResponse
    {
        public static ApiResponse<EmptyResult> Empty(string message = "SUCCESS") =>
            new ApiResponse<EmptyResult>(true, message, default, new List<string>());
    }
}