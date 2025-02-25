using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PasswordManager.Database;

public class ContextConfigurator
{
    private readonly ModelBuilder Builder;

    private ContextConfigurator(ModelBuilder builder)
    {
        Builder = builder;
    }

    public static ContextConfigurator WithBuilder(ModelBuilder modelBuilder)
    {
        return (new ContextConfigurator(modelBuilder));
    }

    public ContextConfigurator Entity<T>() where T : AModel<T>, new()
    {
        T model = new T();
        EntityTypeBuilder<T> builder = Builder.Entity<T>();


        model.InnerConfigureModel(builder);
        return (this);
    }
}