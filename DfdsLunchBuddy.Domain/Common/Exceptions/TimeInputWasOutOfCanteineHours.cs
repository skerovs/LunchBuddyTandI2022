
namespace DfdsLunchBuddy.Domain.Exceptions
{
    internal class TimeInputWasOutOfCanteineHours : DomainException
    {
        public TimeInputWasOutOfCanteineHours(string message) : base(true, message) { }
        public TimeInputWasOutOfCanteineHours(bool isTransient, Exception innerException = null) : base(isTransient, innerException) { }
    }
}
