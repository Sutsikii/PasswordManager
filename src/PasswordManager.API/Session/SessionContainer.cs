using PasswordManager.Database.Models;

namespace PasswordManager.API.Session;

public class SessionContainer
{
    public Guid Id;
    public Account? Account { get; set; }

    public bool IsAuthenticated()
    {
        return (Account != null);
    }
}