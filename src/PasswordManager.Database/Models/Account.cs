using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PasswordManager.Database.Models;

public class Account : AModel<Account>
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    public override void ConfigureModel(EntityTypeBuilder<Account> builder)
    {
        builder.Property(i => i.Email);
        builder.Property(i => i.Password);
    }
}