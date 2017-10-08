using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sannel.House.Web.Data
{
	public class SqlServerDesignTimeFactory : IDesignTimeDbContextFactory<SqlServerDataContext>
	{
		public SqlServerDataContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

			var builder = new DbContextOptionsBuilder<DataContext>();

			builder.UseSqlServer(configuration["SqlServerConnectionString"]);
			return new SqlServerDataContext(builder.Options);
		}
	}
}
