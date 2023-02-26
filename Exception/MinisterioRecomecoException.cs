using System.Net;

namespace ApiMinisterioRecomeco.Exception
{
    public class MinisterioRecomecoException : HttpRequestException
    {
        HttpStatusCode _httpStatusCode;
        private readonly string _message;
        Object _data = new object();

        public MinisterioRecomecoException(HttpStatusCode status, string message) : base(message)
        {
            _httpStatusCode = status;
            _message = message;
        }

        public MinisterioRecomecoException(HttpStatusCode status, string message, Object obj)
        {
            _httpStatusCode = status;
            _message = message;
            _data = obj;
        }

        public MinisterioRecomecoException(string message)
        {
            _message = message;
        }
    }
}
