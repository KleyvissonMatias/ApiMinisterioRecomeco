using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiMinisterioRecomeco.Models
{
    public class Endereco
    {
        [Column("id")]
        public Int64 Id { get; set; }
        
        [Column("rua")]
        public string? Rua { get; set; }

        [Column("numero")]
        public string? Numero { get; set; }

        [Column("bairro")]
        public string? Bairro { get; set; }

        [Column("complemento")]
        public string? Complemento { get; set; }

        [Column("cidade")]
        public string? Cidade { get; set; }

        [Column("uf")]
        public string? Uf { get; set; }

        [Column("cep")]
        public string? Cep { get; set; }

        [JsonIgnore]
        [Column("data_inclusao")]
        public DateTime DataInclusao { get; set; } = DateTime.Now;

        [JsonIgnore]
        [Column("data_alteracao")]
        public DateTime? DataAlteracao { get; set; }
    }
}
