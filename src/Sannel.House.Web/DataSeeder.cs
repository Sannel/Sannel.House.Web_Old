using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web
{
	public class DataSeeder
	{
		protected readonly IDataContext context;
		protected readonly ILogger<DataSeeder> logger;
		protected readonly UserManager<ApplicationUser> userManager;
		protected readonly RoleManager<IdentityRole> roleManager;

		public DataSeeder(IDataContext context,
			ILogger<DataSeeder> logger,
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager)
		{
			this.context = context;
			this.logger = logger;
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

		protected virtual String[] Roles
		{
			get
			{
				return new String[]
				{
					"ApplicationLogList",
					"ApplicationLogAdd",
					"DeviceManager",
					"DeviceList",
					"SensorEntryList",
					"SensorEntryAdd",
					"TemperatureSettingEdit",
					"TemperatureSettingList"
				};
			}
		}

		public virtual async Task SeedDataAsync()
		{
			((DataContext)context).Database.EnsureCreated();
			await addRolesAsync();
			await addUsersAsync();

			var thermostat = context.Devices.FirstOrDefault();
			if (thermostat == null)
			{
				logger.LogInformation("Thermostat does not exist adding it");
				thermostat = new Device();
				thermostat.IsReadOnly = true;
				thermostat.DateCreated = DateTime.Now;
				thermostat.DisplayOrder = 0;
				thermostat.Name = "Thermostat";
				thermostat.Description = "The thermostat and central relay for all devices";
				context.Devices.Add(thermostat);
				await context.SaveChangesAsync();
			}
		}

		protected virtual async Task addUsersAsync()
		{
			var user = await checkAndCreateUserAsync("admin@asp.net", "P@ssword1", "Admin");
			if (!await userManager.IsInRoleAsync(user, Roles[Roles.Length - 1]))
			{
				await userManager.AddToRolesAsync(user, Roles);
			}
		}

		protected virtual async Task<ApplicationUser> checkAndCreateUserAsync(String email, String password, String name)
		{
			var user = await userManager.FindByEmailAsync(email);
			if (user == null)
			{
				var results = await userManager.CreateAsync(new ApplicationUser()
				{
					UserName = email,
					Email = email,
					Name = name
				}, password);
				if (results.Succeeded)
				{
					logger.LogInformation($"Username {email} created");
					user = await userManager.FindByEmailAsync(email);
					return user;
				}
				else
				{
					logger.LogInformation($"Unable to create user with username {email}");
					return null;
				}
			}
			else
			{
				logger.LogInformation($"User with name {email} already exists");
				return user;
			}
		}

		protected virtual async Task addRolesAsync()
		{
			foreach (var role in Roles)
			{
				await checkAndCreateRoleAsync(role);
			}
		}

		protected virtual async Task checkAndCreateRoleAsync(String roleName)
		{
			var role = await roleManager.FindByNameAsync(roleName);
			if (role == null)
			{
				var result = await roleManager.CreateAsync(new IdentityRole(roleName));
				if (!result.Succeeded)
				{
					logger.LogError($"Unable to add Role {roleName}");
				}
				else
				{
					logger.LogInformation($"Role {roleName} added");
				}
			}
			else
			{
				logger.LogInformation($"Role {roleName} already exists with id {role.Id}");
			}
		}
	}
}
