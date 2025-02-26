using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PasswordManager.Database.Models;

public class Password : AModel<Password>
{
    public Account Account { get; set; } = null!;
    public string Service { get; set; } = "";
    public string Login { get; set; } = "";
    public string PasswordContent { get; set; } = "";
    public string Description { get; set; } = "";

    public override void ConfigureModel(EntityTypeBuilder<Password> builder)
    {
        builder.HasOne(i => i.Account);
        builder.Property(i => i.Service);
        builder.Property(i => i.Login);
        builder.Property(i => i.PasswordContent);
        builder.Property(i => i.Description);
    }
}