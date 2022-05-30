﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProvaTecnica3.Data;

#nullable disable

namespace ProvaTecnica3.Migrations
{
    [DbContext(typeof(ProvaTecnica3Context))]
    partial class ProvaTecnica3ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProvaTecnica3.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ProvaTecnica3.Models.Emprestimo", b =>
                {
                    b.Property<int>("EmprestimoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmprestimoId"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPago")
                        .HasColumnType("bit");

                    b.Property<double>("Juros")
                        .HasColumnType("float");

                    b.Property<double>("JurosPago")
                        .HasColumnType("float");

                    b.Property<int>("QtdParcelas")
                        .HasColumnType("int");

                    b.Property<double>("ValorEmprestimo")
                        .HasColumnType("float");

                    b.Property<double>("ValorParcela")
                        .HasColumnType("float");

                    b.HasKey("EmprestimoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Emprestimo");
                });

            modelBuilder.Entity("ProvaTecnica3.Models.Pagamento", b =>
                {
                    b.Property<int>("PagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagamentoId"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtPagamento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmprestimoId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPago")
                        .HasColumnType("bit");

                    b.Property<double>("ValorParcela")
                        .HasColumnType("float");

                    b.HasKey("PagamentoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EmprestimoId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("ProvaTecnica3.Models.Emprestimo", b =>
                {
                    b.HasOne("ProvaTecnica3.Models.Cliente", "Clientes")
                        .WithMany("Emprestimos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("ProvaTecnica3.Models.Pagamento", b =>
                {
                    b.HasOne("ProvaTecnica3.Models.Cliente", "Clientes")
                        .WithMany("Pagamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProvaTecnica3.Models.Emprestimo", "Emprestimos")
                        .WithMany("Pagamentos")
                        .HasForeignKey("EmprestimoId");

                    b.Navigation("Clientes");

                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("ProvaTecnica3.Models.Cliente", b =>
                {
                    b.Navigation("Emprestimos");

                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("ProvaTecnica3.Models.Emprestimo", b =>
                {
                    b.Navigation("Pagamentos");
                });
#pragma warning restore 612, 618
        }
    }
}