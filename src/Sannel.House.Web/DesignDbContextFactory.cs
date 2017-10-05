using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sannel.House.Web.Data
{
	public class DesignDbContextFactory : IDesignTimeDbContextFactory<DataContext>
	{
		public DataContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

			var builder = new DbContextOptionsBuilder<DataContext>();

			var connectionString = configuration["SqliteConnectionString"];

			builder.UseSqlite(connectionString);
			return new DataContext(builder.Options);
		}
	}
}
