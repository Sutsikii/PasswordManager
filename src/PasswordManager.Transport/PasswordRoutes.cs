using PasswordManager.Endpoints;
using PasswordManager.Shared.Codes;
using PasswordManager.Shared.DTO;
using PasswordManager.Shared.Lib;
using PasswordManager.Shared.Payloads;
using Refit;

namespace PasswordManager.Transport;

public partial interface IPasswordManagerClient : IPasswordEndpoints
{
    [Get("/api/password")]
    new Task<OneOf<PasswordDTO[], ErrorCode>> GetPasswords();
}