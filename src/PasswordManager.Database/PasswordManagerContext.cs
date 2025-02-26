using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PasswordManager.Database.Models;

namespace PasswordManager.Database;

public class PasswordManagerContext : DbContext
{
    private readonly IConfiguration? Configuration;
    public static bool MigrationDone;

    public PasswordManagerContext() { }

    public PasswordManagerContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Password> Passwords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={Configuration?["DB:FileName"] ?? "PasswordManager.db"}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ContextConfigurator.WithBuilder(modelBuilder)
            .Entity<Account>()
            .Entity<Password>();
    }

    public PasswordManagerContext MigrateAndGet()
    {
        if (MigrationDone)
            return (this);

        Database.Migrate();
        MigrationDone = true;
        return (this);
    }
}
