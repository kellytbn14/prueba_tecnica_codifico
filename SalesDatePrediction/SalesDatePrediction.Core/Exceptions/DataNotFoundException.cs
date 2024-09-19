using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace SalesDatePrediction.Core.Exceptions
{
    [Serializable, ExcludeFromCodeCoverage]
    public class DataNotFoundException : Exception
    {
        public HttpResponseMessage HttpResponseMessage { get; }

        public DataNotFoundException() { }

        public DataNotFoundException(string message) : base(message) { }

        public DataNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public DataNotFoundException(HttpResponseMessage httpResponseMessage) { }

        public DataNotFoundException(string message, HttpResponseMessage httpResponseMessage) : base(message) { }

        public DataNotFoundException(string message, Exception innerException, HttpResponseMessage httpResponseMessage) : base(message, innerException) { }

        protected DataNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
