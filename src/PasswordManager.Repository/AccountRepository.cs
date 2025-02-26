using Microsoft.EntityFrameworkCore;
using PasswordManager.Database;
using PasswordManager.Database.Models;
using PasswordManager.Shared.Codes;
using PasswordManager.Shared.Lib;
using PasswordManager.Shared.Payloads;

namespace PasswordManager.Repository;

public class AccountRepository : ARepository<Account>
{
    public AccountRepository(PasswordManagerContext context) : base(context)
    {
    }

    protected override DbSet<Account> Set => Context.Accounts;

    public GenericResult TryCreateAccount(RegisterPayload payload)
    {
        Account? found = Set.FirstOrDefault(i => i.Email == payload.Email);

        if (found != null)
            return (ErrorCode.Existing);

        found = new Account
        {
            Email = payload.Email,
            Password = AuthenticationChecker.HashPassword(payload.Password)
        };

        Set.Add(found);
        return (SuccessCode.Created);
    }

    public OneOf<Account, ErrorCode> TryAuthenticate(AuthenticationPayload model)
    {
        Account? found = Set.FirstOrDefault(i => i.Email == model.Email);

        if (found == null)
            return (ErrorCode.Forbidden);

        if (!AuthenticationChecker.VerifyPassword(found.Password, model.Password))
            return (ErrorCode.Forbidden);

        return (found);
    }
}
