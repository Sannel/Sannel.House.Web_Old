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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sannel.House.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Web.Data
{
	/// <summary>
	/// Class to seed data where migration seeding becomes harder
	/// </summary>
	public class DataSeeder
	{
		private UserManager<ApplicationUser> userManager;
		private RoleManager<IdentityRole> roleManager;
		private DataContext context;
		private ILogger log;

		public DataSeeder(UserManager<ApplicationUser> userManager, 
			RoleManager<IdentityRole> roleManager,
			ILogger<DataSeeder> log, DataContext context)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.log = log;
			this.context = context;
		}


		public async Task SeedAsync()
		{
			log.LogInformation("Migrating DB");
			context.Database.Migrate();

			foreach(var r in RoleNames.AllRoles())
			{
				await CheckAndCreateRoleAsync(r);
			}

			var user = await CheckAndCreateUserAsync("admin@asp.net", "@Password1", "Admin User");
			if(user != null && !await userManager.IsInRoleAsync(user, RoleNames.Administrators))
			{
				log.LogInformation("User not in admin group adding them to it");
				await userManager.AddToRoleAsync(user, RoleNames.Administrators);
			}
		}

		protected virtual async Task<ApplicationUser> CheckAndCreateUserAsync(string email, string password, string name)
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
					log.LogInformation($"Username {email} created");
					user = await userManager.FindByEmailAsync(email);
					return user;
				}
				else
				{
					log.LogInformation($"Unable to create user with username {email}");
					return null;
				}
			}
			else
			{
				log.LogInformation($"User with name {email} already exists");
				return user;
			}
		}

		protected virtual async Task CheckAndCreateRoleAsync(string roleName)
		{
			var role = await roleManager.FindByNameAsync(roleName);
			if (role == null)
			{
				var result = await roleManager.CreateAsync(new IdentityRole(roleName));
				if (!result.Succeeded)
				{
					log.LogError($"Unable to add Role {roleName}");
				}
				else
				{
					log.LogInformation($"Role {roleName} added");
				}
			}
			else
			{
				log.LogInformation($"Role {roleName} already exists with id {role.Id}");
			}
		}
	}
}
