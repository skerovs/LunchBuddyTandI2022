
namespace DfdsLunchBuddy.Domain.Exceptions
{
    internal class CouldNotRegisterUserException : DomainException
    {
        public CouldNotRegisterUserException(string message) : base(true, message) { }
        public CouldNotRegisterUserException(bool isTransient, Exception innerException = null) : base(isTransient, innerException) { }
    }
}
