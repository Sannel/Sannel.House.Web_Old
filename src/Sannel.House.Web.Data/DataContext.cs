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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sannel.House.Sensor;
using Sannel.House.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Web.Data
{
	public class DataContext : IdentityDbContext<ApplicationUser>
	{
		/// <summary>
		/// Gets or sets the devices.
		/// </summary>
		/// <value>
		/// The devices.
		/// </value>
		public DbSet<Device> Devices
		{
			get;
			set;
		}

		public DbSet<AlternateDeviceId> AlternateDeviceIds
		{
			get;
			set;
		}

		public DbSet<SensorEntry> SensorEntries
		{
			get;
			set;
		}

		public DataContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<IdentityRole>()
				.HasData(
					new IdentityRole("DeviceList"),
					new IdentityRole("DeviceManager"),
					new IdentityRole("SensorEntryAdd"),
					new IdentityRole("SensorEntryList"),
					new IdentityRole("TemperatureSettingEdit"),
					new IdentityRole("TemperatureSettingList"),
					new IdentityRole("Admin")
				);

			builder.Entity<Device>()
				.HasData(
					new Device()
					{
						Id = 1,
						Name = "Controller",
						Description = "Central Control System",
						DisplayOrder = 0,
						IsReadOnly = true,
						DateCreated = DateTime.UtcNow
					}
				);

			builder.Entity<SensorEntry>(i =>
			{
				i.Property(j => j.Values)
				.HasConversion(
					j => JsonConvert.SerializeObject(j),
					j => JsonConvert.DeserializeObject<Dictionary<string, float>>(j)
				);
				i.Ignore(j => j.ExtraElements);
				i.Ignore(j => j.DeviceMacAddress);
				i.Ignore(j => j.DeviceUuid);
			});

		}
	}
}
