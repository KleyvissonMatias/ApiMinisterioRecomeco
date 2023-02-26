using Newtonsoft.Json;

namespace ApiMinisterioRecomeco.Models
{
    public class Celula
    {
        [JsonProperty("id")]
        private long Id { get; set; }

        [JsonProperty("nome_celula")]
        private string NomeCelula { get; set; }

        [JsonProperty("nome_lider")]
        private string NomeLider { get; set; }

        [JsonProperty("rede")]
        private string Rede { get; set; }

        [JsonProperty("nome_coordenadores")]
        private string NomeCoordenadores { get; set; }

        [JsonProperty("reuniao")]
        private string Reuniao { get; set; }

        [JsonProperty("horario")]
        private string Horario { get; set; }

        [JsonProperty("endereco")]
        private Endereco Endereco { get; set; }

        [JsonProperty("telefone_contato")]
        private string TelefoneContato { get; set; }

        [JsonProperty("email_lider")]
        private string EmailLider { get; set; }
    }
}
