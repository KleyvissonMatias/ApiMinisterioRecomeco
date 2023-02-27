using System.Text.Json.Serialization;

namespace ApiMinisterioRecomeco.Models
{
    public class Endereco
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        
        [JsonPropertyName("rua")]
        public string Rua { get; set; }

        [JsonPropertyName("numero")]
        public string Numero { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("complemento")]
        public string? Complemento { get; set; }

        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }

        [JsonPropertyName("uf")]
        public string Uf { get; set; }

        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("data_inclusao")]
        public DateTime DataInclusao { get; set; } = DateTime.Now;

        [JsonPropertyName("data_alteracao")]
        public DateTime? DataAlteracao { get; set; }
    }
}
