using Microsoft.AspNetCore.Mvc;
using PasswordManager.Core.Session;
using PasswordManager.Database.Models;
using PasswordManager.Endpoints;
using PasswordManager.Repository;
using PasswordManager.Shared.Codes;
using PasswordManager.Shared.Lib;
using PasswordManager.Shared.Payloads;

namespace PasswordManager.API.Controllers;

[Route("/api/[Controller]")]
public class AccountController : ControllerBase, IAccountEndpoints
{
    private readonly SessionService Session;
    private readonly AccountRepository Accounts;

    public AccountController(AccountRepository accounts, SessionService session)
    {
        Accounts = accounts;
        Session = session;
    }

    [HttpPost("authenticate")]
    public async Task<GenericResult> Authenticate([FromBody]AuthenticationPayload model)
    {
        OneOf<Account, ErrorCode> result = Accounts.TryAuthenticate(model);

        return GenericResult.FromOneOf(result.Match
        (
            account =>
            {
                Session.BindSession(account);
                return (SuccessCode.Success);
            },
            error => error
        ));
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
