using EduRankCR.Application.Common.Interfaces.Services;

namespace EduRankCR.Infrastructure.Service;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}