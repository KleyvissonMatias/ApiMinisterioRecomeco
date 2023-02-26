using Newtonsoft.Json;

namespace ApiMinisterioRecomeco.Models
{
    public class Endereco
    {
        [JsonProperty("id")]
        private long Id { get; set; }
        
        [JsonProperty("rua")]
        private string Rua { get; set; }

        [JsonProperty("numero")]
        private string Numero { get; set; }

        [JsonProperty("bairro")]
        private string Bairro { get; set; }

        [JsonProperty("complemento")]
        private string? Complemento { get; set; }

        [JsonProperty("cidade")]
        private string Cidade { get; set; }

        [JsonProperty("uf")]
        private string Estado { get; set; }

        [JsonProperty("cep")]
        private string Cep { get; set; }
    }
}
