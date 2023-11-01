using Microsoft.EntityFrameworkCore;
using N66.LibraryManagement.Application.Services;
using N66.LibraryManagement.Domin.Entities.Models;
using N66.LibraryManagement.Persistance.DataContext;

namespace N66.LibraryManagement.Infrastucture.Services;

public class AutherService : IEntityBaseService<Auther>
{
    private readonly AppDBContext _appDBContext;

    public AutherService(AppDBContext appDBContext)
    {
        _appDBContext = appDBContext;
    }

    public async ValueTask<Auther> CreateAsync(Auther auther, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
       await _appDBContext.Authers.AddAsync(auther, cancellationToken);
       
      if(saveChanges) await _appDBContext.SaveChangesAsync();
        
       return auther;
    }

    public ValueTask<ICollection<Auther>> GetAsync(IEnumerable<Guid> Ids)
    {
        throw new NotImplementedException();
    }

    public  ValueTask<Auther> GetByIdAsync(Guid autherId, CancellationToken cancellationToken = default)
    {
        var auther =  _appDBContext.Authers.FirstOrDefault(auther => auther.Id == autherId);

        if (auther is null) throw new InvalidOperationException("Auther not found");

        return new ValueTask<Auther>(auther);
    }

    public async ValueTask<Auther> UpdateAsync(Auther auther, bool saveChance = true)
    {
        var foundAuther = await GetByIdAsync(auther.Id);

        foundAuther.FirstName = auther.FirstName;
        foundAuther.LastName = auther.LastName;

        _appDBContext.Authers.Update(foundAuther);  
        
       if(saveChance) await _appDBContext.SaveChangesAsync();
        
        return foundAuther;
    }

    public async ValueTask<Auther> DeleteAsync(Guid autherId, bool saveChanges = true)
    {
        var foundAuther  = await GetByIdAsync(autherId);

         _appDBContext.Authers.Remove(foundAuther);
        
       if(saveChanges) await _appDBContext.SaveChangesAsync();
       
        return foundAuther;
    }
}