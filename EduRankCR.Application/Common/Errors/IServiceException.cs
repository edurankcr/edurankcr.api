using System.Net;

namespace EduRankCR.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}