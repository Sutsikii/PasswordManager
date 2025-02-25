namespace PasswordManager.Shared.Codes;

public enum ErrorCode
{
    None,
    Forbidden = 403,
    NotFound = 404,
    BadRequest = 405,
    Existing = 409,
}