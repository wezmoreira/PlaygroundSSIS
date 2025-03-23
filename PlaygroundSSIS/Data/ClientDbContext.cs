using Microsoft.EntityFrameworkCore;
using PlaygroundSSIS.Entities;
using System;

namespace PlaygroundSSIS.Data
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }
        public DbSet<TurmaClient> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TurmaClient>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
        }
    }
}
