using Clientes.D1.Dados.Entidades.InfosClientes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.D1.Dados
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Enderecos> Enderecos { get; set; }
        public DbSet<RedesSociais> RedesSociais { get; set; }
        public DbSet<Telefones> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Enderecos>().ToTable("Enderecos");
            modelBuilder.Entity<RedesSociais>().ToTable("RedesSociais");
            modelBuilder.Entity<Telefones>().ToTable("Telefones");
        }
    }
}
