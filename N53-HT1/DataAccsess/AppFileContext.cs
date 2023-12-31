﻿using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileEntry;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using N53_HT1.Model.Entities;

namespace N53_HT1.DataAccsess;

public class AppFileContext : FileContext
{
    public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));
    public IFileSet<Order, Guid> Orders => Set<Order, Guid>(nameof(Orders));
    public  IFileSet<Bonus, Guid> Bonuses =>  Set<Bonus, Guid>(nameof(Bonuses));
    public AppFileContext(IFileContextOptions<IFileContext> fileContextOptions) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
    }

    public ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileset in fileSets)
        {
            foreach(var entry in fileset.GetEntries())
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
