using System.Text.Json.Serialization;

namespace ApiMinisterioRecomeco.Models
{
    public class Vida
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("nome_completo")]
        public string NomeCompleto { get; set; }

        [JsonPropertyName("data_nascimento")]
        public string DataNascimento { get; set; }

        [JsonPropertyName("sexo")]
        public string Sexo { get; set; }

        [JsonPropertyName("estado_civil")]
        public string EstadoCivil { get; set; }

        [JsonPropertyName("telefone_contato")]
        public string Telefone { get; set; }

        [JsonPropertyName("telefone_outro_contato")]
        public string? TelefoneOutroContato { get; set; }

        [JsonPropertyName("endereco")]
        public Endereco Endereco { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("rede_social")]
        public string? RedeSocial { get; set; }

        [JsonPropertyName("possui_celula")]
        public string PossuiCelula { get; set; }

        [JsonPropertyName("nome_celula")]
        public string? NomeCelula { get; set; }

        [JsonPropertyName("tipo_conversao")]
        public string TipoConversao { get; set; }

        [JsonPropertyName("campus")]
        public string Campus { get; set; }

        [JsonPropertyName("culto")]
        public string Culto { get; set; }

        [JsonPropertyName("horario_culto")]
        public string HorarioCulto { get; set; }

        [JsonPropertyName("nome_voluntario")]
        public string NomeVoluntario { get; set; }

        [JsonPropertyName("observacao")]
        public string? Observacao { get; set; }

        [JsonPropertyName("data_inclusao")]
        public DateTime DataInclusao { get; set; } = DateTime.Now;

        [JsonPropertyName("data_alteracao")]
        public DateTime? DataAlteracao { get; set; }
    }
}
