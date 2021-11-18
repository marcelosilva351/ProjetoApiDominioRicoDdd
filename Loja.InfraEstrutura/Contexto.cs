using Loja.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace Loja.InfraEstrutura
{
    public class Contexto : DbContext
    {
        public DbSet<Client> Clientes { get; set; }
        public DbSet<Desconto> Descontos { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public Contexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasMany(p => p.Pedidos).WithOne(c => c.Cliente).HasForeignKey(c => c.ClienteId);
            modelBuilder.Entity<Desconto>().HasOne(p => p.Pedido).WithOne(d => d.Desconto).HasForeignKey<Pedido>(d => d.DescontoId);
            modelBuilder.Entity<Produto>().HasMany(i => i.Items).WithOne(p => p.Produto).HasForeignKey(p => p.ProdutoId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
