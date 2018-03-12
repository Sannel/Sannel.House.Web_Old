using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Data;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Sannel.House.Web.Base.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;
using MySQL.Data.Entity.Extensions;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Swagger;
using Sannel.House.Web.Extensions;

namespace Sannel.House.Web
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{

			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"config/appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			var file = Configuration["RSAKeysFile"];
			TokenAuthOptions tokenOptions = null;

			//if (File.Exists(file))
			//{
				//var data = File.ReadAllText(file);
				var provider = new RSACryptoServiceProvider(2048);
				//provider.ImportParameters(JsonConvert.DeserializeObject<RSAParameters>(data));
				services.AddSingleton<RSA>(provider);

				var key = new RsaSecurityKey(provider.ExportParameters(true));

				services.AddSingleton(key);

				tokenOptions = new TokenAuthOptions
				{
					Audience = Configuration["Audience"],
					Issuer = Configuration["Issuer"],
					Credentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature)
				};

				services.AddSingleton(tokenOptions);

			//}

			var db = Configuration.GetSection("DB");

			switch (db["Provider"]?.ToLower())
			{
				//case "mysql":
					//services.AddMySQL();
					//services.AddDbContext<DataContext>(options => options.UseMySQL(Configuration["MySqlConnectionString"], b => b.MigrationsAssembly("AspNet5MultipleProject")));
					//break;
				case "sqlite":
					services.AddDbContext<SqliteDataContext>(options => options.UseSqlite(db["ConnectionString"]));
					services.AddScoped(typeof(DataContext), (prov) => prov.GetService<SqliteDataContext>());
					services.AddScoped(typeof(IDataContext), (prov) => prov.GetService<SqliteDataContext>());
					break;
				case "mssql":
				default:
					services.AddDbContext<SqlServerDataContext>(options => options.UseSqlServer(db["ConnectionString"]));
					services.AddScoped(typeof(DataContext), (prov) => prov.GetService<SqlServerDataContext>());
					services.AddScoped(typeof(IDataContext), (prov) => prov.GetService<SqlServerDataContext>());
					break;
			}

			services.AddMvc();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info()
				{
					Title = "Sannel House Api",
					Version = "v1",
					Description = "API to store and query Sannel.House info",
					TermsOfService = "None"
				});
			});
			services.AddMvcCore();
			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				//options.Cookies.ApplicationCookie.AuthenticationScheme = "ApplicationCookie";
				//options.Cookies.ApplicationCookie.CookieName = "Authz";
				//options.Cookies.ApplicationCookie.CookiePath = "/";
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 4;
			})
			.AddEntityFrameworkStores<DataContext>()
				.AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(option =>
			{
				option.Cookie.Name = "Authz";
				option.Cookie.Path = "/";
			});
			services.AddAuthorization(authz =>
			{
				authz.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
					.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
					.RequireAuthenticatedUser().Build());
			});
			var auth = services.AddAuthentication();
			auth.AddCookie();
			if (tokenOptions != null)
			{
				auth.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						IssuerSigningKey = tokenOptions.Credentials.Key,
						ValidAudience = tokenOptions.Audience,
						ValidIssuer = tokenOptions.Issuer,
						ValidateLifetime = true,
						ClockSkew = TimeSpan.FromMinutes(3)
					};
				});
			}
			services.AddAntiforgery();
			services.AddSingleton(Configuration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public async void Configure(IApplicationBuilder app,
			IHostingEnvironment env,
			ILoggerFactory loggerFactory,
			TokenAuthOptions tokenOptions)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();
			loggerFactory.AddLog4Net();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sannel House API");
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");

			}
			// For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
			try
			{
				using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
					.CreateScope())
				{
					serviceScope.ServiceProvider.GetService<DataContext>()
						 .Database.Migrate();
				}
			}
			catch(Exception ex)
			{
				var log = app.ApplicationServices.GetRequiredService<ILogger<Startup>>();
				log.LogDebug(ex, "Exception while migrating database");
			}
			app.UseAuthentication();

			app.UseStaticFiles();

			// To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			if (env.IsDevelopment())
			{
				var seeder = new DataSeeder(
					app.ApplicationServices.GetService<IDataContext>(),
					app.ApplicationServices.GetService<ILogger<DataSeeder>>(),
					app.ApplicationServices.GetService<UserManager<ApplicationUser>>(),
					app.ApplicationServices.GetService<RoleManager<IdentityRole>>());
				await seeder.SeedDataAsync();
			}
		}
	}
}
