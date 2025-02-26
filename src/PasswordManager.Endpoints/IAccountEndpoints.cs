using PasswordManager.Shared.Codes;
using PasswordManager.Shared.Payloads;
using PasswordManager.Shared.Lib;

namespace PasswordManager.Endpoints;

public interface IAccountEndpoints
{
    Task<GenericResult> Authenticate(AuthenticationPayload model);
    Task<GenericResult> Register(RegisterPayload payload);
}
