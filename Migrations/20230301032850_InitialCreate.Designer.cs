﻿// <auto-generated />
using System;
using ApiMinisterioRecomeco.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiMinisterioRecomeco.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230301032850_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApiMinisterioRecomeco.Models.Celula", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_alteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_inclusao");

                    b.Property<string>("EmailLider")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email_lider");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("horario");

                    b.Property<string>("NomeCelula")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_celula");

                    b.Property<string>("NomeCoordenadores")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_coordenadores");

                    b.Property<string>("NomeLider")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_lider");

                    b.Property<string>("Rede")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("rede");

                    b.Property<string>("Reuniao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("reuniao");

                    b.Property<string>("TelefoneContato")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("telefone_contato");

                    b.Property<long>("id_endereco")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("id_endereco")
                        .IsUnique();

                    b.ToTable("Celulas");
                });

            modelBuilder.Entity("ApiMinisterioRecomeco.Models.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("cidade");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext")
                        .HasColumnName("complemento");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_alteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_inclusao");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("numero");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("rua");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("uf");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ApiMinisterioRecomeco.Models.Relatorio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_alteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_inclusao");

                    b.Property<string>("NomeVida")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_vida");

                    b.Property<string>("NomeVoluntario")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_voluntario");

                    b.Property<string>("RetornoContato")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("retorno_contato");

                    b.HasKey("Id");

                    b.ToTable("Relatorios");
                });

            modelBuilder.Entity("ApiMinisterioRecomeco.Models.Vida", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Campus")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("campus");

                    b.Property<string>("Culto")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("culto");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_alteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_inclusao");

                    b.Property<string>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("EstadoCivil")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("estado_civil");

                    b.Property<string>("HorarioCulto")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("horario_culto");

                    b.Property<string>("NomeCelula")
                        .HasColumnType("longtext")
                        .HasColumnName("nome_celula");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_completo");

                    b.Property<string>("NomeVoluntario")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_voluntario");

                    b.Property<string>("Observacao")
                        .HasColumnType("longtext")
                        .HasColumnName("observacao");

                    b.Property<string>("PossuiCelula")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("possui_celula");

                    b.Property<string>("RedeSocial")
                        .HasColumnType("longtext")
                        .HasColumnName("rede_social");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("sexo");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("telefone_contato");

                    b.Property<string>("TelefoneOutroContato")
                        .HasColumnType("longtext")
                        .HasColumnName("telefone_outro_contato");

                    b.Property<string>("TipoConversao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("tipo_conversao");

                    b.Property<long>("id_endereco")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("id_endereco")
                        .IsUnique();

                    b.ToTable("Vidas");
                });

            modelBuilder.Entity("ApiMinisterioRecomeco.Models.Voluntario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_alteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_inclusao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("LiderCelula")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("lider_celula");

                    b.Property<string>("LiderTreinamento")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("lider_treinamento");

                    b.Property<string>("NomeCelula")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_celula");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_completo");

                    b.Property<string>("NomeLider")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_lider");

                    b.Property<string>("TelefoneContato")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("telefone_contato");

                    b.HasKey("Id");

                    b.ToTable("Voluntarios");
                });

            modelBuilder.Entity("ApiMinisterioRecomeco.Models.Celula", b =>
                {
                    b.HasOne("ApiMinisterioRecomeco.Models.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("ApiMinisterioRecomeco.Models.Celula", "id_endereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ApiMinisterioRecomeco.Models.Vida", b =>
                {
                    b.HasOne("ApiMinisterioRecomeco.Models.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("ApiMinisterioRecomeco.Models.Vida", "id_endereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}