using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RevendooWebAPI.Models
{
    public partial class revendoodbContext : DbContext
    {
    
        public revendoodbContext(DbContextOptions<revendoodbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vendas> Vendas { get; set; }
        public virtual DbSet<VendasProdutos> VendasProdutos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("PK__Clientes__71ABD0A73F148FA0");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade).IsUnicode(false);

                entity.Property(e => e.Complemento).IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DataNasc).HasColumnType("date");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Endereco).IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .HasColumnName("RG")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefone).IsUnicode(false);
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(e => e.ProdutoId)
                    .HasName("PK__Produtos__9C8800C379622DA8");

                entity.Property(e => e.ProdutoId).HasColumnName("ProdutoID");

                entity.Property(e => e.CaminhoFoto).IsUnicode(false);

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Marca).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.PrecoCusto).HasColumnType("money");

                entity.Property(e => e.PrecoVenda).HasColumnType("money");

                entity.Property(e => e.Validade).HasColumnType("date");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC2185E5F5");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Cargo).IsUnicode(false);

                entity.Property(e => e.NomeCompleto).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<Vendas>(entity =>
            {
                entity.HasKey(e => e.VendaId)
                    .HasName("PK__Vendas__8020557BBABA12C2");

                entity.Property(e => e.VendaId).HasColumnName("VendaID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.DataEntrega).HasColumnType("date");

                entity.Property(e => e.DataPagamento).HasColumnType("date");

                entity.Property(e => e.Desconto).HasColumnType("money");

                entity.Property(e => e.FormaPagamento)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PrecoTotal).HasColumnType("money");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Vendas)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vendas__ClienteI__5535A963");
            });

            modelBuilder.Entity<VendasProdutos>(entity =>
            {
                entity.HasKey(e => new { e.VendaId, e.ProdutoId })
                    .HasName("PK__VendasPr__A9E8D577EB301969");

                entity.Property(e => e.VendaId).HasColumnName("VendaID");

                entity.Property(e => e.ProdutoId).HasColumnName("ProdutoID");

                entity.Property(e => e.PrecoParcial).HasColumnType("money");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.VendasProdutos)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VendasPro__Produ__59063A47");

                entity.HasOne(d => d.Venda)
                    .WithMany(p => p.VendasProdutos)
                    .HasForeignKey(d => d.VendaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VendasPro__Venda__5812160E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
