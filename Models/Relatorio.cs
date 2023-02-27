using System.Text.Json.Serialization;

namespace ApiMinisterioRecomeco.Models
{
    public class Relatorio
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("nome_voluntario")]
        public string NomeVoluntario { get; set; }

        [JsonPropertyName("nome_vida")]
        public string NomeVida { get; set; }

        [JsonPropertyName("retorno_contato")]
        public string RetornoContato { get; set; }

        [JsonPropertyName("data_inclusao")]
        public DateTime DataInclusao { get; set; } = DateTime.Now;

        [JsonPropertyName("data_alteracao")]
        public DateTime? DataAlteracao { get; set; }
    }
}
