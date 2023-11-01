﻿using N66.LibraryManagement.Application.Services;
using N66.LibraryManagement.Domin.Entities.Models;
using N66.LibraryManagement.Persistance.DataContext;

namespace N66.LibraryManagement.Infrastucture.Services;

public class BookService : IEntityBaseService<Book>
{
    private readonly AppDBContext _appDBContext;

    public BookService(AppDBContext appDBContext)
    {
        _appDBContext = appDBContext;
    }
    public async ValueTask<Book> CreateAsync(Book book, bool saveChanges, CancellationToken cancellationToken = default)
    {
        await _appDBContext.AddAsync(book, cancellationToken);
        
       if(saveChanges) await _appDBContext.SaveChangesAsync();
        
        return book;
    }

    public  ValueTask<Book> GetByIdAsync(Guid bookId, CancellationToken cancellationToken = default)
    {
       var foundBook = _appDBContext.Books.FirstOrDefault(book =>  book.Id == bookId);

       if (foundBook is null) throw new InvalidOperationException("Books not found");

       return new ValueTask<Book>(foundBook);
    }

    public async ValueTask<Book> UpdateAsync(Book book, bool saveChanges = true)
    {
       var foundBook = await GetByIdAsync(book.Id);

       foundBook.Description = book.Description;
       foundBook.Title = book.Title;
       
       _appDBContext.Books.Update(foundBook);
       
      if(saveChanges) await _appDBContext.SaveChangesAsync();
       return book;
    }

    public async ValueTask<Book> DeleteAsync(Guid autherId, bool saveChanges = true)
    {
        var foundBook = await GetByIdAsync(autherId);

        _appDBContext.Books.Remove(foundBook);

       if(saveChanges) await _appDBContext.SaveChangesAsync();

        return foundBook;
    }

    public ValueTask<ICollection<Book>> GetAsync(IEnumerable<Guid> Ids)
    {
        throw new NotImplementedException();
    }

}