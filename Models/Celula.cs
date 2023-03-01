using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiMinisterioRecomeco.Models
{
    public class Celula
    {
        [Column("id")]
        public Int64 Id { get; set; }

        [Column("nome_celula")]
        public string NomeCelula { get; set; }

        [Column("nome_lider")]
        public string NomeLider { get; set; }

        [Column("rede")]
        public string Rede { get; set; }

        [Column("nome_coordenadores")]
        public string NomeCoordenadores { get; set; }

        [Column("reuniao")]
        public string Reuniao { get; set; }

        [Column("horario")]
        public string Horario { get; set; }

        [JsonIgnore]
        [ForeignKey("id_endereco")]
        [Column("id_endereco")]
        public Int64 EnderecoId { get; set; }

        public Endereco Endereco { get; set; }

        [Column("telefone_contato")]
        public string TelefoneContato { get; set; }

        [Column("email_lider")]
        public string EmailLider { get; set; }

        [Column("data_inclusao")]
        public DateTime DataInclusao { get; set; } = DateTime.Now;

        [JsonIgnore]
        [Column("data_alteracao")] 
        public DateTime? DataAlteracao { get; set; } 
    }
}
