using Newtonsoft.Json;

namespace ApiMinisterioRecomeco.Models
{
    public class Voluntario
    {
        [JsonProperty("id")]
        private long Id { get; set; }

        [JsonProperty("nome_completo")]
        private string NomeCompleto { get; set; }

        [JsonProperty("email")]
        private string Email { get; set; }

        [JsonProperty("nome_celula")]
        private string NomeCelula { get; set; }

        [JsonProperty("lider_treinamento")]
        private string LiderTreinamento { get; set; }

        [JsonProperty("lider_celula")]
        private string LiderCelula { get; set; }

        [JsonProperty("nome_lider")]
        private string NomeLider { get; set; }

        [JsonProperty("telefone_contato")]
        private string TelefoneContato { get; set; }
    }
}
