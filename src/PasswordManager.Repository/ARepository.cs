using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Database;

namespace PasswordManager.Repository;


public abstract class ARepository
{
    protected PasswordManagerContext Context;

    protected ARepository(PasswordManagerContext context)
    {
        Context = context;
    }
}

public abstract class ARepository<T> : ARepository where T : class
{
    protected abstract DbSet<T> Set { get; }

    protected ARepository(PasswordManagerContext context) : base(context) { }

    public Task SaveAsync()
    {
        return (Context.SaveChangesAsync());
    }
}