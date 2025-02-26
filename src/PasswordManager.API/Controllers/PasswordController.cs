using Microsoft.AspNetCore.Mvc;
using PasswordManager.API.Components.Pages;
using PasswordManager.Core.Session;
using PasswordManager.Endpoints;
using PasswordManager.Repository;
using PasswordManager.Shared.Codes;
using PasswordManager.Shared.DTO;
using PasswordManager.Shared.Lib;

namespace PasswordManager.API.Controllers;

[Route("api/[Controller]")]
public class PasswordController : ControllerBase, IPasswordEndpoints
{
    private PasswordRepository Passwords;
    private readonly SessionService Session;

    public PasswordController(PasswordRepository passwords, SessionService session)
    {
        Passwords = passwords;
        Session = session;
    }

    [HttpGet]
    public async Task<OneOf<PasswordDTO[], ErrorCode>> GetPasswords()
    {
        if (Session.SessionContainer.Account == null)
            return (ErrorCode.Forbidden);

        return (Passwords.ForAccount(Session.SessionContainer.Account)
            .Select(PasswordRepository.ToDTO)
            .ToArray());
    }
}
