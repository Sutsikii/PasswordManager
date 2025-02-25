using PasswordManager.Endpoints;
using PasswordManager.Shared.Codes;
using PasswordManager.Shared.Lib;
using PasswordManager.Shared.Payloads;
using Refit;

namespace PasswordManager.Transport;

public partial interface IPasswordManagerClient : IAccountEndpoints
{
    [Post("/api/account")]
    new Task<OneOf<SuccessCode, ErrorCode>> Register(RegisterPayload payload);
}