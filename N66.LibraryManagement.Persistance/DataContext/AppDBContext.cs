using Microsoft.EntityFrameworkCore;
using N66.LibraryManagement.Domin.Entities.Models;

namespace N66.LibraryManagement.Persistance.DataContext;

public class AppDBContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();  
    public DbSet<Book> Books => Set<Book>();


    public AppDBContext(DbContextOptions<AppDBContext> optoins) : base(optoins)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
    }
}
