using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sannel.House.Web.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Sannel.House.Web.Mocks
{
	public class ContextWrapper : IDisposable
	{
		private DataContext context;
		private SqliteConnection connection;

		public DataContext Context
		{
			get
			{
				return context;
			}
		}

		public ContextWrapper()
		{
			connection = new SqliteConnection("DataSource=:memory:");
			connection.Open();
			var options = new DbContextOptionsBuilder<DataContext>()
					.UseSqlite(connection)
					.Options;
			context = new DataContext(options);
			context.Database.EnsureCreated();
		}

		public void Dispose()
		{
			context?.Dispose();
			connection?.Close();
			connection?.Dispose();
		}
	}
}
