using System.Net;

namespace EduRankCR.Application.Common.Errors
{
    public class ServiceException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }

        public ServiceException(HttpStatusCode statusCode, string errorMessage)
            : base(errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}