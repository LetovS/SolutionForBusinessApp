using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Store.Migrations;

public class DbContextFactoryBase : IDesignTimeDbContextFactory<ResourceContext>
{
    public ResourceContext CreateDbContext(string[] args)
    {
        var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Resource;";//GetConnectionString();
        var optionsBuilder = CreateDbContextOptions(connectionString);
        return new ResourceContext(optionsBuilder.Options);
    }

    private DbContextOptionsBuilder<ResourceContext> CreateDbContextOptions(string connectionString)
        => new DbContextOptionsBuilder<ResourceContext>()
            .UseSqlServer(connectionString, b => b.MigrationsAssembly("Store.Migrations"));

    private string GetConnectionString()
        => new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build()
               .GetConnectionString(Constants.ConnectionStringName)
           ?? throw new InvalidOperationException($"Не удалось получить строку подключения {Constants.ConnectionStringName}");
}
