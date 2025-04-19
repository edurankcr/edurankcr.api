using EduRankCR.Application.Common.Interfaces;

namespace EduRankCR.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}