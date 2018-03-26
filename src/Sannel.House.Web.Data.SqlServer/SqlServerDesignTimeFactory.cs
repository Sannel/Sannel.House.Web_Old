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

			var builder = new DbContextOptionsBuilder<DataContext>();

			builder.UseSqlServer("Server=sql;Database=devHouse;uid=sa;password=@password1;MultipleActiveResultSets=True");
			return new SqlServerDataContext(builder.Options);
		}
	}
}
