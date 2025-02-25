using Microsoft.AspNetCore.Components.Forms;

namespace PasswordManager.Shared.Lib;

public class FormHelper
{
    private ValidationMessageStore Store = null!;
    private EditContext Context = null!;

    public static FormHelper From(EditContext ctx)
    {
        FormHelper helper = new FormHelper
        {
            Store = new ValidationMessageStore(ctx),
            Context = ctx
        };

        return (helper);
    }

    public FormHelper Append(string message)
    {
        Store.Add(Context.Field(""), message);

        return (this);
    }

    public FormHelper Append(string field, string message)
    {
        Store.Add(Context.Field(field), message);

        return (this);
    }

    public void Notify()
    {
        Context.NotifyValidationStateChanged();
    }
}
