using Bravi.Domain.Repositories;
using Bravi.Infrastructure.Provider.Repositories;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Bravi.Infrastructure;

public static class Bootstrapper
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services.AddSingleton<IDbConnection>(_ =>
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = ":memory:",
                Mode = SqliteOpenMode.Memory,
                Cache = SqliteCacheMode.Shared,
            };

            var connection = new SqliteConnection(connectionStringBuilder.ToString());
            connection.Open();

            // Criar a tabela Person (se ela não existir)
            connection.Execute(@"
                CREATE TABLE IF NOT EXISTS Person (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    Nickname TEXT NULL
                );

                CREATE TABLE IF NOT EXISTS Contact (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PersonId INTEGER NOT NULL,
                    Value TEXT NOT NULL,
                    Type INTEGER NOT NULL,
                    IsMain INTEGER NOT NULL
                );
            ");

            return connection;
        });

        //Repositories
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
    }
}