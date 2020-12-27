using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FluentMigrator.Runner;
using Infra.Data.Migrations;

namespace Infra.Data
{
    public static class InMemoryDatabase
    {
        #region properties
        private static readonly OrmLiteConnectionFactory dbFactory =
            new OrmLiteConnectionFactory(BuildConnectionString(), SqliteOrmLiteDialectProvider.Instance);
        public static IDbConnection Connection => dbFactory.OpenDbConnection();

        public static IMigrationRunner Runner;
        #endregion

        #region actions
        public static void CreateTable()
        {
            var provider = CreateServiceProvider();
            Runner = provider.CreateScope().ServiceProvider.GetRequiredService<IMigrationRunner>();
            Runner.MigrateUp();
        }

        private static string BuildConnectionString()
        {
            var builder = new SqliteConnectionStringBuilder
            {
                DataSource = "file:UnitTestDb",
                Cache = SqliteCacheMode.Shared,
                Mode = SqliteOpenMode.Memory
            };
            return builder.ConnectionString;
        }

        private static ServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                  .AddFluentMigratorCore()
                  .ConfigureRunner(builder => builder
                                             .AddSQLite()
                                             .WithGlobalConnectionString(BuildConnectionString())
                                             .WithMigrationsIn(typeof(CreateTablesMigration).Assembly))
                  .BuildServiceProvider();
        }
        #endregion
    }
}
