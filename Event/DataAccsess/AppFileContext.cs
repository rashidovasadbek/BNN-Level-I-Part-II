using Event.Models.Entities;
using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileEntry;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;

namespace Event.DataAccsess;

public class AppFileContext : FileContext
{
    public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));
    public IFileSet<UserPreference, Guid> UserPreferences => Set<UserPreference, Guid>(nameof(UserPreferences));
    public IFileSet<BlogPost, Guid> BlogPosts => Set<BlogPost, Guid>(nameof(BlogPosts));
    public AppFileContext(IFileContextOptions<IFileContext> fileContextOptions) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
    }

    public ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
    {
        foreach(var fileSet in fileSets)
        {
            foreach(var entry in fileSet.GetEntries())
            {
                if (entry is not IFileEntityEntry<IEntity> entityEntry) continue;

                if(entityEntry.State == FileEntityState.Added)
                    entityEntry.Entity.Id = Guid.NewGuid();

                if (entry is not IFileEntityEntry<IFileSetEntity<Guid>> fileSetEntry) continue;
            }
        }
        return new ValueTask(Task.CompletedTask);
    }



}
