using PasswordManager.Shared.Codes;
using PasswordManager.Shared.DTO;
using PasswordManager.Shared.Lib;

namespace PasswordManager.Endpoints;

public interface IPasswordEndpoints
{
    Task<OneOf<PasswordDTO[], ErrorCode>> GetPasswords();
}