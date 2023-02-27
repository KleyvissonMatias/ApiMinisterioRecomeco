using System.Text.Json.Serialization;

namespace ApiMinisterioRecomeco.Models
{
    public class Celula
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("nome_celula")]
        public string NomeCelula { get; set; }

        [JsonPropertyName("nome_lider")]
        public string NomeLider { get; set; }

        [JsonPropertyName("rede")]
        public string Rede { get; set; }

        [JsonPropertyName("nome_coordenadores")]
        public string NomeCoordenadores { get; set; }

        [JsonPropertyName("reuniao")]
        public string Reuniao { get; set; }

        [JsonPropertyName("horario")]
        public string Horario { get; set; }

        [JsonPropertyName("endereco")]
        public Endereco Endereco { get; set; }

        [JsonPropertyName("telefone_contato")]
        public string TelefoneContato { get; set; }

        [JsonPropertyName("email_lider")]
        public string EmailLider { get; set; }

        [JsonPropertyName("data_inclusao")]
        public DateTime DataInclusao { get; set; } = DateTime.Now;

        [JsonPropertyName("data_alteracao")]
        public DateTime? DataAlteracao { get; set; }
    }
}
