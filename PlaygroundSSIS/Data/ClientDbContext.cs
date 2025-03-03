using Microsoft.EntityFrameworkCore;
using PlaygroundSSIS.Entities;
using System;

namespace PlaygroundSSIS.Data
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }
        public DbSet<TurmaLyceum> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TurmaLyceum>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
        }
    }
}
