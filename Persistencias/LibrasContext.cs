using Fiap.Challenge.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Challenge.Web.Persistencias
{
    public class LibrasContext : DbContext
    {
        // CONJUNTO DE PRODUTOS QUE ESTÃO NO BANCO DE DADOS //
        public DbSet<Produto> Produtos { get; set; }

        // CONJUNTO DE INVENTARIOS QUE ESTÃO NO BANCO DE DADOS //
        public DbSet<Inventario> Inventarios { get; set; }

        // CONJUNTO DE INVENTARIOS QUE ESTÃO NO BANCO DE DADOS //
        public DbSet<ItemProduto> ItensProdutos { get; set; }

        // CONTRUTOR QUE RECEBE AS OPTIONS E ENVIA PARA O PAI //
        public LibrasContext(DbContextOptions op) : base (op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a chave composta da tabela associativa
            modelBuilder.Entity<ItemProduto>().HasKey(i => new { i.ProdutoId, i.InventarioId });

            //Configurar o relacionamento da tabela associativa com o pedido
            modelBuilder.Entity<ItemProduto>()
                .HasOne(i => i.Inventario)
                .WithMany(i => i.ItensProdutos)
                .HasForeignKey(i => i.InventarioId);

            //Configurar o relacionamento da tabela associativa com o produto
            modelBuilder.Entity<ItemProduto>()
                .HasOne(i => i.Produto)
                .WithMany(i => i.ItensProdutos)
                .HasForeignKey(i => i.ProdutoId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
