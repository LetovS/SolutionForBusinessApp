namespace Store.Migrations;

internal static class Constants
{
    public const string ConnectionStringName = "Resources";

    public const string DataMigrationsHistoryTable = "__DataMigrationsHistory";

    public static readonly string MigrationAssemblyName = typeof(DbContextFactoryBase).Assembly.GetName().Name;
}
