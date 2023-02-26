using Newtonsoft.Json;

namespace ApiMinisterioRecomeco.Models
{
    public class Relatorio
    {
        [JsonProperty("id")]
        private long Id { get; set; }

        [JsonProperty("nome_voluntario")]
        private string NomeVoluntario { get; set; }

        [JsonProperty("nome_vida")]
        private string NomeVida { get; set; }

        [JsonProperty("retorno_contato")]
        private string RetornoContato { get; set; }
    }
}
