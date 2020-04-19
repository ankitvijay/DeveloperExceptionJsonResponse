using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperExceptionMiddleware
{
    public class Error
    {
        // Required to Deserialize
        private Error()
        {
        }

        public Error(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            ExceptionType = exception.GetType().ToString();
            Message = exception.Message;
            StackTrace = exception.StackTrace;
            Data = new Dictionary<string, string>();

            foreach (var data in exception.Data.Cast<DictionaryEntry>()
                .Where(data => data.Key is { } && data.Value is { }))
            {
                Data.Add(data.Key.ToString(), data.Value.ToString());
            }

        }

        public string ExceptionType { get; set; }

        public string Message { get; set; }

        public Dictionary<string,string> Data { get; set; }

        public string StackTrace { get; set; }
    }
}
