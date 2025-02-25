using PasswordManager.Shared.Codes;
using PasswordManager.Shared.Payloads;
using PasswordManager.Shared.Lib;

namespace PasswordManager.Endpoints;

public interface IAccountEndpoints
{
    Task<OneOf<SuccessCode, ErrorCode>> Register(RegisterPayload payload);
}
