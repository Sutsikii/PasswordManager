using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Shared.Payloads;

public class AuthenticationPayload
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}
