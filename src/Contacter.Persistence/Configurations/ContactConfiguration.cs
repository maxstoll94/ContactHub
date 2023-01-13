using Contacter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gatherly.Persistence.Configurations;

internal sealed class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(c => c.Name);
        builder.OwnsOne(c => c.Socials);

        builder.HasOne(c => c.Company)
            .WithMany()
            .HasForeignKey(c => c.CompanyId);
    }
}
