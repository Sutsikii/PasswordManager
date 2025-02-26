using PasswordManager.Database.Models;
using PasswordManager.Repository;

namespace PasswordManager.API.Session;

public class SessionService
{
    private readonly IHttpContextAccessor HttpContextAccessor;
    private AccountRepository Accounts;
    private SessionContainer? _SessionContainer;
    public SessionContainer SessionContainer => _SessionContainer ??= GenerateContainer();

    private static readonly string AccountIdKey = "AccountId";

    public SessionService(IHttpContextAccessor httpContextAccessor, AccountRepository accounts)
    {
        HttpContextAccessor = httpContextAccessor;
        Accounts = accounts;
    }

    public void BindSession(Account account)
    {
        HttpContextAccessor.HttpContext!.Session.SetString("AccountId", account.Id.ToString());
    }

    private SessionContainer GenerateContainer()
    {
        try
        {
            Guid id = Guid.Parse(HttpContextAccessor.HttpContext!.Session.GetString(AccountIdKey)!);

            return (new SessionContainer
            {
                Account = Accounts.WithId(id).First()
            });
        }
        catch
        {
            return (new SessionContainer());
        }
        
    }
}