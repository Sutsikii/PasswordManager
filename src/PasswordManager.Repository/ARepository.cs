using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Database;
using PasswordManager.Database.Models;

namespace PasswordManager.Repository;


public abstract class ARepository
{
    protected PasswordManagerContext Context;

    protected ARepository(PasswordManagerContext context)
    {
        Context = context;
    }
}

public abstract class ARepository<T> : ARepository where T : AModel<T>
{
    protected abstract DbSet<T> Set { get; }

    protected ARepository(PasswordManagerContext context) : base(context) { }

    public IQueryable<T> WithId(Guid id)
    {
        return (Set
            .Where(i => i.Id == id)
            .Take(1));
    }

    public void Add(T model)
    {
        Set.Add(model);
    }

    public void Delete(T model)
    {
        Set.Remove(model);
    }

    public Task SaveAsync()
    {
        return (Context.SaveChangesAsync());
    }
}