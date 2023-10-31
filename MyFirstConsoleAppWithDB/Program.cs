using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyFirstConsoleAppWithDB.Persistence.DataContext;
using N66_C.Domain.Entities;
using System;
using System.Text.Json;

var services = new ServiceCollection();

services.AddDbContext<AppDBContext>();

var serviceProvider = services.BuildServiceProvider();
var appDbContext = serviceProvider.GetRequiredService<AppDBContext>();

if (!appDbContext.Authors.Any())
{
    appDbContext.Authors.AddRange(new Author
    {
        FirstName = "John", 
        LastName = "Doe"
    },
        new Author
        {
            FirstName = "Jonibek",
            LastName = "Doniyorov"
        });

    var changedRowsCount = await appDbContext.SaveChangesAsync();
}

if (appDbContext.Authors.Any() && !appDbContext.Books.Any())
{
    appDbContext.Books.AddRange(new Book
    {
        Title = "Asp.NET Core in Action 2018",
        Description = "Programming",
        AuthorId = appDbContext.Authors.First().Id
    },
        new Book
        {
            Title = "Asp.NET Core in Action 2021",
            Description = "Programming",
            AuthorId = appDbContext.Authors.Skip(1).First().Id
        });

    var changedRowsCount = await appDbContext.SaveChangesAsync();
}

var allBooks = await appDbContext.Books
    .Include(book => book.Author)
    .ToListAsync();
Console.WriteLine(JsonSerializer.Serialize(allBooks));
