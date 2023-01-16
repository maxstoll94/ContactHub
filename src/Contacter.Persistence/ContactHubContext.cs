using ContactHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactHub.Persistence
{
    public class ContactHubContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactHubContext() { }
        public ContactHubContext(DbContextOptions<ContactHubContext> options) : base(options) { }

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
