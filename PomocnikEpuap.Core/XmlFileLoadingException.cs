using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace PomocnikEpuap.Core
{

    [Serializable()]
    public class XmlFileLoadingException : Exception
    {

        protected XmlFileLoadingException() : base()
        {
        }

        public XmlFileLoadingException(string message) : base(message)
        {

        }

        public XmlFileLoadingException(string message, Exception innerException) : base(message, innerException)
        {

        }

        protected XmlFileLoadingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

