using Microsoft.EntityFrameworkCore;
using N66.LibraryManagement.Domin.Entities.Models;

namespace N66.LibraryManagement.Persistance.DataContext;

public class AppDBContext : DbContext
{
    public DbSet<Auther> Authers => Set<Auther>();  
    public DbSet<Book> Books => Set<Book>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=LibraryManagement;Username=postgres;Password=725264");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().HasOne(book => book.Auther).WithMany();
    }
}
