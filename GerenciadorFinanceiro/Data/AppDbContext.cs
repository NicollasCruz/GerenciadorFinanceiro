﻿using GerenciadorFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorFinanceiro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
