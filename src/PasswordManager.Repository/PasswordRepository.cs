using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Database;
using PasswordManager.Database.Models;
using PasswordManager.Shared.DTO;

namespace PasswordManager.Repository;

public class PasswordRepository : ARepository<Password>
{
    public PasswordRepository(PasswordManagerContext context) : base(context) { }
    protected override DbSet<Password> Set => Context.Passwords;

    public IQueryable<Password> ForAccount(Account account)
    {
        return (Set
            .Include(i => i.Account)
            .Where(i => i.Account.Id == account.Id));
    }

    public static PasswordDTO ToDTO(Password p)
    {
        return (new PasswordDTO
        {
            Id = p.Id,
            Account = p.Account.Id,
            Login = p.Login,
            Password = p.PasswordContent,
            Description = p.Description
        });
    }
}