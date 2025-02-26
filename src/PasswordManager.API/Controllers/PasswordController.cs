using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordManager.API.Components.Pages;
using PasswordManager.API.Session;
using PasswordManager.Database.Models;
using PasswordManager.Endpoints;
using PasswordManager.Repository;
using PasswordManager.Shared.Codes;
using PasswordManager.Shared.DTO;
using PasswordManager.Shared.Lib;
using PasswordManager.Shared.Payloads;
using Refit;

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

    [HttpPost]
    public async Task<GenericResult> AddPassword([FromBody]CreatePasswordPayload model)
    {
        if (!Session.SessionContainer.IsAuthenticated())
            return (ErrorCode.Forbidden);

        if (!ModelState.IsValid)
            return (ErrorCode.BadRequest);

        Password password = PasswordRepository.ToModel(model, Session.SessionContainer.Account!);

        Passwords.Add(password);
        await Passwords.SaveAsync();

        return (SuccessCode.Created);
    }

    [HttpDelete("{id}")]
    public async Task<GenericResult> DeletePassword(Guid id)
    {
        if (!Session.SessionContainer.IsAuthenticated())
            return (ErrorCode.Forbidden);

        Password? p = Passwords.WithId(id)
            .Include(i => i.Account)
            .FirstOrDefault();

        if (p == null || p.Account.Id != Session.SessionContainer.Account!.Id)
            return (ErrorCode.NotFound);

        Passwords.Delete(p);
        await Passwords.SaveAsync();

        return (SuccessCode.Success);
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
