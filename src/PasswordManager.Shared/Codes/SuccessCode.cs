namespace PasswordManager.Shared.Codes;

public class SuccessCode
{
    public static SuccessCode None => new(0);
    public static SuccessCode Success => new(200);
    public static SuccessCode Created => new(201);

    public int Value { get; set; }

    public SuccessCode() { }

    public SuccessCode(int code)
    {
        Value = code;
    }
}