using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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

			services.AddIdentity<ApplicationUser, IdentityRole>(o => o.Stores.MaxLengthForKeys = 128)
				.AddEntityFrameworkStores<DataContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication();


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddAntiforgery();
			services.AddSingleton(Configuration);

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

			if(string.Compare(dataProvider, sensorProvider) == 0)
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
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseAuthentication();
		}
	}
}
