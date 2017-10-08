using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sannel.House.Web.Data
{
	public class MsSqlDesignTimeFactory : IDesignTimeDbContextFactory<MsSqlDataContext>
	{
		public MsSqlDataContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

			var builder = new DbContextOptionsBuilder<DataContext>();

			builder.UseSqlite(configuration["SqliteConnectionString"]);
			return new MsSqlDataContext(builder.Options);
		}
	}
}