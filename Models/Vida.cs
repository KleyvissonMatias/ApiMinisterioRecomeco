using Newtonsoft.Json;

namespace ApiMinisterioRecomeco.Models
{
    public class Vida
    {
        [JsonProperty("id")]
        private long Id { get; set; }

        [JsonProperty("nome_completo")]
        private string NomeCompleto { get; set; }

        [JsonProperty("data_nascimento")]
        private string DataNascimento { get; set; }

        [JsonProperty("sexo")]
        private string Sexo { get; set; }

        [JsonProperty("estado_civil")]
        private string EstadoCivil { get; set; }

        [JsonProperty("telefone_contato")]
        private string Telefone { get; set; }

        [JsonProperty("telefone_outro_contato")]
        private string? TelefoneOutroContato { get; set; }

        [JsonProperty("endereco")]
        private Endereco Endereco { get; set; }

        [JsonProperty("email")]
        private string Email { get; set; }

        [JsonProperty("rede_social")]
        private string? RedeSocial { get; set; }

        [JsonProperty("possui_celula")]
        private string PossuiCelula { get; set; }

        [JsonProperty("nome_celula")]
        private string? NomeCelula { get; set; }

        [JsonProperty("tipo_conversao")]
        private string TipoConversao { get; set; }

        [JsonProperty("campus")]
        private string Campus { get; set; }

        [JsonProperty("culto")]
        private string Culto { get; set; }

        [JsonProperty("horario_culto")]
        private string HorarioCulto { get; set; }

        [JsonProperty("nome_voluntario")]
        private string NomeVoluntario { get; set; }

        [JsonProperty("observacao")]
        private string? Observacao { get; set; }
    }
}
