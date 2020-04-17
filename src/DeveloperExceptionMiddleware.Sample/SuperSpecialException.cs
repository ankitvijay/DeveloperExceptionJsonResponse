using System;
using System.Runtime.Serialization;

namespace DeveloperExceptionMiddleware.Sample
{
    /// <summary>
    /// The super special exception raised by the sample application.
    /// </summary>
    [Serializable]
    public class SuperSpecialException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperSpecialException"/> class
        /// </summary>
        public SuperSpecialException() : this("This is a super special exception")
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
        protected SuperSpecialException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
