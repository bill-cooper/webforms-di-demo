using System;

namespace di_demo.Tests.Server
{
    public class WebApplicationProxyException : ApplicationException
    {
        public WebApplicationProxyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
