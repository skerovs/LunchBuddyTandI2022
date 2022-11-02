using DfdsLunchBuddy.Application.Common.Interfaces.Services;

namespace DfdsLunchBuddy.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}