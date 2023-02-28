using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiMinisterioRecomeco.Models
{
    public class Voluntario
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("nome_completo")]
        public string NomeCompleto { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("nome_celula")]
        public string NomeCelula { get; set; }

        [Column("lider_treinamento")]
        public string LiderTreinamento { get; set; }

        [Column("lider_celula")]
        public string LiderCelula { get; set; }

        [Column("nome_lider")]
        public string NomeLider { get; set; }

        [Column("telefone_contato")]
        public string TelefoneContato { get; set; }

        [Column("data_inclusao")]
        public DateTime DataInclusao { get; set; } = DateTime.Now;

        [Column("data_alteracao")]
        public DateTime? DataAlteracao { get; set; }
    }
}
