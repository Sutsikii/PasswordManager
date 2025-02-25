using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Shared.Payloads;

public class RegisterPayload
{
    [Required, EmailAddress]
    public string Email { get; set; } = "";
    [Required, MinLength(8)]
    public string Password { get; set; } = "";
}
