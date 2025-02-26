using PasswordManager.Endpoints;
using PasswordManager.Shared.Codes;
using PasswordManager.Shared.DTO;
using PasswordManager.Shared.Lib;
using PasswordManager.Shared.Payloads;
using Refit;

namespace PasswordManager.Transport;

public partial interface IPasswordManagerClient : IPasswordEndpoints
{
    [Post("/api/password")]
    new Task<GenericResult> AddPassword(CreatePasswordPayload model);
    [Delete("/api/password/{id}")]
    new Task<GenericResult> DeletePassword(Guid id);
    [Get("/api/password")]
    new Task<OneOf<PasswordDTO[], ErrorCode>> GetPasswords();


}