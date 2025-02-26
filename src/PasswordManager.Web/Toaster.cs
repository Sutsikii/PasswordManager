using Blazored.Toast.Services;
using PasswordManager.Shared.Codes;

namespace PasswordManager.Web;

public class Toaster
{
    private IToastService Toast;
    private Dictionary<int, string> Messages = new ()
    {
        {SuccessCode.Created.Value, "Resource créée"},
        {ErrorCode.Forbidden.Value, "Authentication requise"},
        {ErrorCode.Existing.Value, "Resource déjà existante"}
    };


    public Toaster(IToastService toast)
    {
        Toast = toast;
    }

    public void Error(ErrorCode code)
    {
        string? value = "";

        if (!Messages.TryGetValue(code.Value, out value))
            value = $"Erreur {code.Value}";
        Error(value);
    }

    public void Error(string message)
    {
        Toast.ShowError(message);
    }

    public void Success(SuccessCode code)
    {
        string? value = "";

        if (!Messages.TryGetValue(code.Value, out value))
            value = $"Succès {code.Value}";
        Success(value);
    }

    public void Success(string message)
    {
        Toast.ShowSuccess(message);
    }
}
