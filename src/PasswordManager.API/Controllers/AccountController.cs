using Microsoft.AspNetCore.Mvc;
using PasswordManager.Endpoints;
using PasswordManager.Repository;
using PasswordManager.Shared.Codes;
using PasswordManager.Shared.Lib;
using PasswordManager.Shared.Payloads;

namespace PasswordManager.API.Controllers;

[Route("/api/[Controller]")]
public class AccountController : ControllerBase, IAccountEndpoints
{
    private AccountRepository Accounts;

    public AccountController(AccountRepository accounts)
    {
        Accounts = accounts;
    }

    [HttpPost]
    public async Task<GenericResult> Register([FromBody]RegisterPayload payload)
    {
        if (!ModelState.IsValid)
            return (ErrorCode.BadRequest);

        GenericResult r = Accounts.TryCreateAccount(payload);

        if (r.IsError())
            return (r.GetError());

        await Accounts.SaveAsync();
        return (r.GetSuccess());
    }
}
