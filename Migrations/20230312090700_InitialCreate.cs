using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMinisterioRecomeco.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_voluntario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nome_vida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    retorno_contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Voluntarios",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_completo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nome_celula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lider_treinamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lider_celula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nome_lider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone_contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Celulas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_celula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nome_lider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rede = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nome_coordenadores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reuniao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_endereco = table.Column<long>(type: "bigint", nullable: false),
                    telefone_contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_lider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celulas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Celulas_Enderecos_id_endereco",
                        column: x => x.id_endereco,
                        principalTable: "Enderecos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vidas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_completo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_nascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado_civil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone_contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone_outro_contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_endereco = table.Column<long>(type: "bigint", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rede_social = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    possui_celula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_celula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo_conversao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    campus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    culto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    horario_culto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nome_voluntario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vidas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vidas_Enderecos_id_endereco",
                        column: x => x.id_endereco,
                        principalTable: "Enderecos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Celulas_id_endereco",
                table: "Celulas",
                column: "id_endereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vidas_id_endereco",
                table: "Vidas",
                column: "id_endereco",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Celulas");

            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropTable(
                name: "Vidas");

            migrationBuilder.DropTable(
                name: "Voluntarios");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
