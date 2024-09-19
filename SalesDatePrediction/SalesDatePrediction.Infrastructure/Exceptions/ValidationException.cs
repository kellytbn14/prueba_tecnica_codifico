using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace SalesDatePrediction.Infrastructure.Exceptions
{

    [Serializable]
    [ExcludeFromCodeCoverage]
    public class ValidationException : Exception
    {
        public HttpResponseMessage HttpResponseMessage { get; }

        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ValidationException(HttpResponseMessage httpResponseMessage)
        {
            HttpResponseMessage = httpResponseMessage;
        }

        public ValidationException(string message, HttpResponseMessage httpResponseMessage) : base(message)
        {
            HttpResponseMessage = httpResponseMessage;
        }

        public ValidationException(string message, Exception innerException, HttpResponseMessage httpResponseMessage) : base(message, innerException)
        {
            HttpResponseMessage = httpResponseMessage;
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
