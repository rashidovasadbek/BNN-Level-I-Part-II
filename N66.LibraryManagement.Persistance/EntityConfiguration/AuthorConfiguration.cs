using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N66.LibraryManagement.Domin.Entities.Models;

namespace N66.LibraryManagement.Persistance.EntityConfiguration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(author => author.FirstName).IsRequired().HasMaxLength(265);
        builder.Property(author => author.LastName).IsRequired().HasMaxLength(265);
    }
}
