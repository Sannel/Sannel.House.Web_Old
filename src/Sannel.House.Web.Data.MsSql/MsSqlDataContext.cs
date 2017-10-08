using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Sannel.House.Web.Data
{
	public class MsSqlDataContext : DataContext
	{
		public MsSqlDataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
	}
}
