using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Sannel.House.Web.Data
{
	public class SqliteDataContext : DataContext
	{
		public SqliteDataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public SqliteDataContext(DbContextOptions<SqliteDataContext> options) : base(options)
		{

		}
	}
}
