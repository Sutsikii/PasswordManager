using PasswordManager.Shared.Codes;
using PasswordManager.Shared.DTO;
using PasswordManager.Shared.Lib;
using PasswordManager.Shared.Payloads;

namespace PasswordManager.Endpoints;

public interface IPasswordEndpoints
{
    Task<GenericResult> AddPassword(CreatePasswordPayload model);
    Task<GenericResult> DeletePassword(Guid id);
    Task<OneOf<PasswordDTO[], ErrorCode>> GetPasswords();
}