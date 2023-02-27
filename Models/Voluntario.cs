using System.Text.Json.Serialization;

namespace ApiMinisterioRecomeco.Models
{
    public class Voluntario
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("nome_completo")]
        public string NomeCompleto { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("nome_celula")]
        public string NomeCelula { get; set; }

        [JsonPropertyName("lider_treinamento")]
        public string LiderTreinamento { get; set; }

        [JsonPropertyName("lider_celula")]
        public string LiderCelula { get; set; }

        [JsonPropertyName("nome_lider")]
        public string NomeLider { get; set; }

        [JsonPropertyName("telefone_contato")]
        public string TelefoneContato { get; set; }

        [JsonPropertyName("data_inclusao")]
        public DateTime DataInclusao { get; set; } = DateTime.Now;

        [JsonPropertyName("data_alteracao")]
        public DateTime? DataAlteracao { get; set; }
    }
}
