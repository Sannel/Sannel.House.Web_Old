using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sannel.House.Web.Data
{
	public class SqliteDesignTimeFactory : IDesignTimeDbContextFactory<SqliteDataContext>
	{
		public SqliteDataContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<DataContext>();

			builder.UseSqlite("Data Source=data/data.sqlite");
			return new SqliteDataContext(builder.Options);
		}
	}
}
