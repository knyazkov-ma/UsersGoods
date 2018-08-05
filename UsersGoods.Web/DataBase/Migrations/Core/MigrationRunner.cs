using System.Diagnostics;
using FluentMigrator.Runner;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace UsersGoods.Web.DataBase.Migrations.Core
{
	public class MigrationRunner : IMigrationRunner
    {
        private readonly string _connectionString;
               

        public MigrationRunner(string connectionString)
        {
            _connectionString = connectionString;
        }

        
        
        public void Update()
        {
			var serviceProvider = CreateServices();

			// Put the database update into a scope to ensure
			// that all resources will be disposed.
			using (var scope = serviceProvider.CreateScope())
			{
				UpdateDatabase(scope.ServiceProvider);
			}
		}

		/// <summary>
		/// Configure the dependency injection services
		/// </sumamry>
		private IServiceProvider CreateServices()
		{
			return new ServiceCollection()
				// Add common FluentMigrator services
				.AddFluentMigratorCore()
				.ConfigureRunner(rb => rb
					// Add SQLite support to FluentMigrator
					.AddPostgres()
					// Set the connection string
					.WithGlobalConnectionString(_connectionString)
					// Define the assembly containing the migrations
					.ScanIn(typeof(InitialDeployment).Assembly).For.Migrations())
				// Enable logging to console in the FluentMigrator way
				.AddLogging(lb => lb.AddFluentMigratorConsole())
				// Build the service provider
				.BuildServiceProvider(false);
		}

		/// <summary>
		/// Update the database
		/// </sumamry>
		private void UpdateDatabase(IServiceProvider serviceProvider)
		{
			// Instantiate the runner
			var runner = serviceProvider.GetRequiredService<FluentMigrator.Runner.IMigrationRunner>();
			var asm = typeof(InitialDeployment).Assembly;
			
			// Execute the migrations
			runner.MigrateUp();
		}
	}
}