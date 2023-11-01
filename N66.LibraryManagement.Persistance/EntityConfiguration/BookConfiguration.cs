using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N66.LibraryManagement.Domin.Entities.Models;

namespace N66.LibraryManagement.Persistance.EntityConfiguration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(book =>  book.Title).IsRequired().HasMaxLength(265); 
        builder.Property(book =>  book.Description).IsRequired().HasMaxLength(265);
       
    }
}
