using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PasswordManager.Database;

public abstract class AModel<T> where T : AModel<T>
{
    public Guid Id { get; set; } = Guid.NewGuid();

    internal void InnerConfigureModel(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(i => i.Id);

        ConfigureModel(builder);
    }

    public abstract void ConfigureModel(EntityTypeBuilder<T> builder);
}