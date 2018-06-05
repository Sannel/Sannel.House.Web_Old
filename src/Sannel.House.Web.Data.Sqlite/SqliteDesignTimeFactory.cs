/* Copyright 2018 Sannel Software, L.L.C.
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at
	   http://www.apache.org/licenses/LICENSE-2.0
   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Web.Data.Sqlite
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
