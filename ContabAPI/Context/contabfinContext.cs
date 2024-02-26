using System;
using System.Collections.Generic;
using ContabAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace ContabAPI.Context

{
    public partial class contabfinContext : DbContext
    {
        public contabfinContext()
        {
        }

        public contabfinContext(DbContextOptions<contabfinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DeclaracoesFinanceira> DeclaracoesFinanceiras { get; set; } = null!;
        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public virtual DbSet<Servico> Servicos { get; set; } = null!;
        public virtual DbSet<TransacoesFinanceira> TransacoesFinanceiras { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__677F38F50A8F7A9E");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.EnderecoCliente)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("endereco_cliente");

                entity.Property(e => e.NomeCliente)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome_cliente");

                entity.Property(e => e.TelefoneCliente).HasColumnName("telefone_cliente");

                entity.Property(e => e.TipoCliente)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tipo_cliente");
            });

            modelBuilder.Entity<DeclaracoesFinanceira>(entity =>
            {
                entity.HasKey(e => e.IdDeclaracao)
                    .HasName("PK__Declarac__1132B2610363BCFB");

                entity.Property(e => e.IdDeclaracao).HasColumnName("id_declaracao");

                entity.Property(e => e.ConteudoDeclaracao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("conteudo_declaracao");

                entity.Property(e => e.DataPreparacao).HasColumnName("data_preparacao");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.TipoDeclaracao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tipo_declaracao");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.DeclaracoesFinanceiras)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Declaraco__id_cl__3D5E1FD2");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PK__Funciona__6FBD69C40E10D141");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.CargoFuncionario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cargo_funcionario");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("departamento");

                entity.Property(e => e.NomeFuncionario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome_funcionario");

                entity.Property(e => e.TelefoneFuncionario).HasColumnName("telefone_funcionario");
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.HasKey(e => e.IdServico)
                    .HasName("PK__Servicos__D06FB5A2DCB7B0C9");

                entity.Property(e => e.IdServico).HasColumnName("id_servico");

                entity.Property(e => e.DescricaoServico)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descricao_servico");

                entity.Property(e => e.TaxaServico)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("taxa_servico");
            });

            modelBuilder.Entity<TransacoesFinanceira>(entity =>
            {
                entity.HasKey(e => e.IdTransacao)
                    .HasName("PK__Transaco__0FBBF7735B10FBDC");

                entity.Property(e => e.IdTransacao).HasColumnName("id_transacao");

                entity.Property(e => e.DataPreparacao).HasColumnName("data_preparacao");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.TipoTransacao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tipo_transacao");

                entity.Property(e => e.ValorTransicao)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor_transicao");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TransacoesFinanceiras)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Transacoe__id_cl__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
