using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Sannel.House.Web.Data
{
	public class SqlServerDataContext : DataContext
	{
		public SqlServerDataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public SqlServerDataContext(DbContextOptions<SqlServerDataContext> options) : base(options)
		{

		}
	}
}
