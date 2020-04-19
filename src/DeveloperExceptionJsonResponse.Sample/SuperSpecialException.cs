using System;
using System.Runtime.Serialization;

namespace DeveloperExceptionJsonResponse.Sample
{
    /// <summary>
    /// The super special exception raised by the sample application.
    /// </summary>
    public class SuperSpecialException : Exception
    {
        private const string DefaultExceptionMessage = "This is a super special exception";

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperSpecialException"/> class
        /// </summary>
        public SuperSpecialException() : this(DefaultExceptionMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperSpecialException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception</param>
        public SuperSpecialException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperSpecialException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception</param>
        /// <param name="innerException">The inner exception</param>
        public SuperSpecialException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperSpecialException"/> class
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/></param>
        /// <param name="context"><see cref="StreamingContext"/></param>
        private SuperSpecialException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
