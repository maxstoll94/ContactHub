using Contacter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacter.Persistence
{
    public class ContacterContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContacterContext() { }
        public ContacterContext(DbContextOptions<ContacterContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // mocked for migrations
                optionsBuilder.UseSqlServer("");
            }
        }
    }
}
