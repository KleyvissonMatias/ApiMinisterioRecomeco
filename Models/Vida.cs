using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiMinisterioRecomeco.Models
{
    public class Vida
    {
        [Column("id")]
        public Int64 Id { get; set; }

        [Column("nome_completo")]
        public string? NomeCompleto { get; set; }

        [Column("data_nascimento")]
        public string? DataNascimento { get; set; }

        [Column("sexo")]
        public string? Sexo { get; set; }

        [Column("estado_civil")]
        public string? EstadoCivil { get; set; }

        [Column("telefone_contato")]
        public string? Telefone { get; set; }

        [Column("telefone_outro_contato")]
        public string? TelefoneOutroContato { get; set; }

        [JsonIgnore]
        [ForeignKey("id_endereco")]
        [Column("id_endereco")]
        public Int64 EnderecoId { get; set; }

        public Endereco? Endereco { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("rede_social")]
        public string? RedeSocial { get; set; }

        [Column("possui_celula")]
        public string PossuiCelula { get; set; }

        [Column("nome_celula")]
        public string? NomeCelula { get; set; }

        [Column("tipo_conversao")]
        public string? TipoConversao { get; set; }

        [Column("campus")]
        public string? Campus { get; set; }

        [Column("culto")]
        public string? Culto { get; set; }

        [Column("horario_culto")]
        public string? HorarioCulto { get; set; }

        [Column("nome_voluntario")]
        public string? NomeVoluntario { get; set; }

        [Column("observacao")]
        public string? Observacao { get; set; }
        
        [JsonIgnore]
        [Column("data_inclusao")]
        public DateTime DataInclusao { get; set; } = DateTime.Now;

        [JsonIgnore]
        [Column("data_alteracao")]
        public DateTime? DataAlteracao { get; set; }
    }
}
