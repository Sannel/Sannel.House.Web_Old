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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sannel.House.Web.Users.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sannel.House.Web.Users.Data.Sqlite;
using Sannel.House.Web.Users.Data.SqlServer;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Stores;
using IdentityModel;

namespace Sannel.House.Web.Users
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
			//services.Configure<CookiePolicyOptions>(options =>
			//{
			//	// This lambda determines whether user consent for non-essential cookies is needed for a given request.
			//	options.CheckConsentNeeded = context => true;
			//	options.MinimumSameSitePolicy = SameSiteMode.None;
			//});

			services.AddDbContext<ApplicationDbContext>(options => {
				switch (Configuration["Db:Provider"])
				{
					case "sqlserver":
					case "SqlServer":
						options.ConfigureSqlServer(Configuration["Db:ConnectionString"]);
						break;
					case "sqlite":
					default:
						options.ConfigureSqlite(Configuration["Db:ConnectionString"]);
						break;
				}
			});
			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddIdentityServer()
				.AddDeveloperSigningCredential()
				.AddConfigurationStore(options =>
				{
					options.ConfigureDbContext = o =>
					{
						switch (Configuration["Db:Provider"])
						{
							case "sqlserver":
							case "SqlServer":
								o.ConfigureSqlServer(Configuration["Db:ConnectionString"]);
								break;
							case "sqlite":
							default:
								o.ConfigureSqlite(Configuration["Db:ConnectionString"]);
								break;
						}
					};
				})
				.AddOperationalStore(options =>
				{
					options.ConfigureDbContext = o =>
					{
						switch (Configuration["Db:Provider"])
						{
							case "sqlserver":
							case "SqlServer":
								o.ConfigureSqlServer(Configuration["Db:ConnectionString"]);
								break;
							case "sqlite":
							default:
								o.ConfigureSqlite(Configuration["Db:ConnectionString"]);
								break;
						}
					};

					options.EnableTokenCleanup = true;
					options.TokenCleanupInterval = 3600;
				})
				.AddAspNetIdentity<IdentityUser>();

			services.AddScoped<DataSeeder>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
		{
			{
				var db = provider.GetService<ApplicationDbContext>();
				db.Database.Migrate();
			}
			{
				var db = provider.GetService<ConfigurationDbContext>();
				db.Database.Migrate();
			}
			{
				var db = provider.GetService<PersistedGrantDbContext>();
				db.Database.Migrate();
			}

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseIdentityServer();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			if (Configuration.GetValue<bool>("Db:SeedDb"))
			{
				var s = provider.GetService<DataSeeder>();
				s.SeedData();
			}

		}
	}
}
