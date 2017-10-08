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
		private DbContextOptions<DataContext> options;
		private IContextWrapperTest wrapperTest;

		public DataContext Context
		{
			get
			{
				return context;
			}
		}

		public ContextWrapper(IContextWrapperTest testClass)
		{
			wrapperTest = testClass;
			connection = new SqliteConnection("DataSource=:memory:");
			connection.Open();
			options = new DbContextOptionsBuilder<DataContext>()
					.UseSqlite(connection)
					.Options;
			context = new SqliteDataContext(options);
			context.Database.EnsureCreated();
		}

		public DataContext CreateSubContext()
		{
			return new SqliteDataContext(options);
		}

		public void SaveChanges()
		{
			wrapperTest.PreSaveChanges(this);
			context.SaveChanges();
		}

		public void Dispose()
		{
			context?.Dispose();
			connection?.Close();
			connection?.Dispose();
		}
	}
}
