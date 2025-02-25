using System.Runtime.InteropServices.JavaScript;

namespace PasswordManager.Shared.Codes;

public class ErrorCode
{
    public static ErrorCode None => new (0);
    public static ErrorCode Forbidden => new (403);
    public static ErrorCode NotFound => new (404);
    public static ErrorCode BadRequest => new(405);
    public static ErrorCode Existing => new(409);

    public int Value { get; set; }

    public ErrorCode() { }

    public ErrorCode(int code)
    {
        Value = code;
    }


}