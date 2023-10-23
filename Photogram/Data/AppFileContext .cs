using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileEntry;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using Photogram.Model;

namespace Photogram.Data
{
    public class AppFileContext : FileContext
    {
        public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));
        public AppFileContext(IFileContextOptions<IFileContext> fileContextOptions) : base(fileContextOptions)
        {
            OnSaveChanges += AddPrimaryKeys;
        }


        public ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSet)
        {
            foreach (var file in fileSet)
            {
                foreach(var entry in file.GetEntries()) 
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
}
