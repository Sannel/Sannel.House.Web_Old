using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Sannel.House.Web.Data
{
	public abstract class DataContext : IdentityDbContext<ApplicationUser>, IDataContext
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

		/// <summary>
		/// Gets or sets the alternate device ids.
		/// </summary>
		/// <value>
		/// The device ids.
		/// </value>
		public DbSet<DeviceIds> DeviceIds
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the temperature settings.
		/// </summary>
		/// <value>
		/// The temperature settings.
		/// </value>
		public DbSet<TemperatureSetting> TemperatureSettings
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the application log entries.
		/// </summary>
		/// <value>
		/// The application log entries.
		/// </value>
		public DbSet<ApplicationLogEntry> ApplicationLogEntries
		{
			get;
			set;
		}

		public DbSet<TemperatureEntry> TemperatureEntries
		{
			get;
			set;
		}
		public DbSet<RefreshToken> RefreshTokens
		{
			get;
			set;
		}
		public DbSet<SensorEntry> SensorEntries { get; set; }

		public DataContext(DbContextOptions options) : base(options)
		{
		}
	}
}
