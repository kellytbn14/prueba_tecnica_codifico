using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace SalesDatePrediction.Core.Exceptions
{
    [Serializable, ExcludeFromCodeCoverage]
    public class BadRequestException : Exception
    {
        public HttpResponseMessage HttpResponseMessage { get; }

        public BadRequestException() { }

        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }

        public BadRequestException(HttpResponseMessage httpResponseMessage) { }

        public BadRequestException(string message, HttpResponseMessage httpResponseMessage) : base(message) { }

        public BadRequestException(string message, Exception innerException, HttpResponseMessage httpResponseMessage) : base(message, innerException) { }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
