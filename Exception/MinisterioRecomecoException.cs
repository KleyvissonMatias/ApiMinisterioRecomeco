using System.Net;

namespace ApiMinisterioRecomeco.Exception
{
    public class MinisterioRecomecoException : HttpRequestException
    {
        public readonly HttpStatusCode? _httpStatusCode;
        public readonly string _message;
        public readonly Object? _data = new();

        public MinisterioRecomecoException(HttpStatusCode? status, string message) : base(message)
        {
            _httpStatusCode = status;
            _message = message;
        }

        public MinisterioRecomecoException(HttpStatusCode? status, string message, Object obj)
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
