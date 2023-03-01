using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiMinisterioRecomeco.Models
{
    public class Relatorio
    {
        [Column("id")]
        public Int64 Id { get; set; }

        [Column("nome_voluntario")]
        public string NomeVoluntario { get; set; }

        [Column("nome_vida")]
        public string NomeVida { get; set; }

        [Column("retorno_contato")]
        public string RetornoContato { get; set; }

        [Column("data_inclusao")]
        public DateTime DataInclusao { get; set; } = DateTime.Now;

        [JsonIgnore]
        [Column("data_alteracao")]
        public DateTime? DataAlteracao { get; set; }
    }
}
