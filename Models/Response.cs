using System.Net;

namespace ApiMinisterioRecomeco.Models
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Data { get; set; }
    }
}
