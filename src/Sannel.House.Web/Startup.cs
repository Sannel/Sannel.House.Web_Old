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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sannel.House.Web.Data;
using Sannel.House.Web.Data.Sqlite;
using Sannel.House.Web.Data.SqlServer;
using Sannel.House.Web.Interfaces;
using Sannel.House.Web.Models;

namespace Sannel.House.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var dSection = Configuration.GetSection("Database");
			configureDatabases(services, dSection);

			services.AddIdentity<ApplicationUser, IdentityRole>(o =>
			{
				o.Stores.MaxLengthForKeys = 128;
			})
				.AddEntityFrameworkStores<DataContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication(o =>
			{
				o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = Configuration["Jwt:Issuer"],
					ValidAudience = Configuration["Jwt:Issuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
				};
			});


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddTransient<DataSeeder>();
		}

		private void configureDatabases(IServiceCollection services, IConfigurationSection databaseSection)
		{
			var dataRepository = databaseSection.GetSection("DataRepository");
			var dataProvider = dataRepository["Provider"]?.ToLower();
			var dataConnectionString = dataRepository["ConnectionString"];
			switch (dataProvider)
			{
				case "sqlite":
					services.AddDbContextPool<SqliteDataContext>(o => o.UseSqlite(dataConnectionString));
					services.AddScoped<DataContext>(i => i.GetService<SqliteDataContext>());
					break;
				case "sqlserver":
					services.AddDbContextPool<SqlServerDataContext>(o => o.UseSqlServer(dataConnectionString));
					services.AddScoped<DataContext>(i => i.GetService<SqlServerDataContext>());
					break;
				case "mysql":
					throw new NotSupportedException("We currently do not support mysql");

				default:
					throw new NotSupportedException($"Provider {dataProvider} is not supported");
			}
			services.AddTransient<IDataRepository, EFDataRepository>();

			var sensorRepository = databaseSection.GetSection("SensorRepository");
			var sensorProvider = sensorRepository["Provider"]?.ToLower();
			var sensorConnectionString = sensorRepository["ConnectionString"];

			if (string.Compare(dataProvider, sensorProvider) == 0)
			{
				services.AddTransient<ISensorRepository, EFSensorRepository>();
			}
			else
			{
				switch (sensorProvider)
				{
					case "sqlite":
						services.AddDbContextPool<SqliteDataContext>(o => o.UseSqlite(sensorConnectionString));
						services.AddTransient<ISensorRepository, EFSensorRepository>(i => new EFSensorRepository(i.GetService<SqliteDataContext>()));
						break;
					case "sqlserver":
						services.AddDbContextPool<SqlServerDataContext>(o => o.UseSqlServer(sensorConnectionString));
						services.AddTransient<ISensorRepository, EFSensorRepository>(i => new EFSensorRepository(i.GetService<SqlServerDataContext>()));
						break;
					case "mongodb":
						throw new NotImplementedException("There is currently no Implementation for mongodb but it is planned");
					case "mysql":
						throw new NotSupportedException("We currently do not support mysql");

					default:
						throw new NotSupportedException($"Provider {sensorProvider} is not supported");
				}
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger, DataSeeder seeder)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseAuthentication();
			app.UseStaticFiles();
			app.UseHttpsRedirection();
			app.UseMvc();
			app.UseDefaultFiles();
			await seeder.SeedAsync();
		}
	}
}
