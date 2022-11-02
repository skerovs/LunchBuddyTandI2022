using System;

namespace DfdsLunchBuddy.Domain.Exceptions
{
    /// <summary>
    /// The base class for all exceptions thrown in the domain layer.
    /// </summary>
    public abstract class DomainException : Exception
    {
        protected DomainException(bool isTransient, Exception innerException = null)
            : base(DefaultMessage(), innerException)
        {
            IsTransient = isTransient;
        }

        protected DomainException(bool isTransient, string message, Exception innerException = null)
            : base(message, innerException)
        {
            IsTransient = isTransient;
        }

        /// <summary>
        /// Gets a value indicating whether the exception is transient.
        /// </summary>
        public bool IsTransient { get; }

        public static string DefaultMessage() => "An error occurred in the domain layer.";

        public override string ToString()
        {
            var s = $"{GetType()}: {Message} ";
            s += $"{Environment.NewLine}IsTransient: {IsTransient}";
            if (InnerException != null)
                s += $" ---> {InnerException}";
            if (StackTrace != null)
                s += $"{Environment.NewLine}{StackTrace}";
            return s;
        }
    }
}
