using Microsoft.AspNetCore.Identity;

namespace PasswordManager.Repository;

public static class AuthenticationChecker
{
    private static PasswordHasher<object> _passwordHasher = new();

    public static string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(null!, password);
    }

    public static bool VerifyPassword(string hashedPassword, string inputPassword)
    {
        PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(null!, hashedPassword, inputPassword);
        return result == PasswordVerificationResult.Success;
    }
}