using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sannel.House.Web.Data;
using Xunit;
using Microsoft.Extensions.Logging;
using Sannel.House.Web.Controllers.api;
using Sannel.House.Web.Base;

namespace Sannel.House.Web.Tests
{
	public partial class TemperatureEntryControllerTests : IContextWrapperTest
	{
		[Fact]
		public void DeviceIdResetTest()
		{

			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<TemperatureEntryController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				context.Devices.Add(new Device()
				{
					Id = 1,
					Name = "Controller",
					Description = "",
					DateCreated = DateTime.Now,
					DisplayOrder = 0,
					IsReadOnly = true
				});
				context.Devices.Add(new Device()
				{
					Id = 2,
					Name = "Default",
					Description = "",
					DateCreated = DateTime.Now,
					DisplayOrder = 0,
					IsReadOnly = true
				});

				context.SaveChanges();

				using (var controller = new TemperatureEntryController(context, logger))
				{
					var temp = new TemperatureEntry();
					temp.TemperatureCelsius = 20;
					temp.DeviceId = 500;
					temp.DateCreated = DateTime.Now;
					var result = controller.Post(temp);
					Assert.True(result.Success);
					var d = result.Data;
					Assert.NotNull(d);
					Assert.Equal(SystemDeviceIds.DefaultId, d.DeviceId);
				}
			}
		}

		[Fact]
		public void GenerateDeviceFromMacAddressTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<TemperatureEntryController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new TemperatureEntryController(context, logger))
				{
					var result = controller.Post(null);
					Assert.NotNull(result);
					Assert.False(result.Success);
					Assert.Equal(1, result.Errors.Count);
					Assert.Equal("data cannot be null", result.Errors[0]);
					Assert.Null(result.Data);
					var expected = new TemperatureEntry();
					// Success Test
					expected = new TemperatureEntry
					{
						Id = Guid.NewGuid(),
						DeviceMacAddress = 4,
						TemperatureCelsius = 0.10897310595445946,
						Humidity = 0.54895940634839213,
						Pressure = 0.43393340633899596,
						DateCreated = DateTime.MinValue
					};
					postPreCall(expected, wrapper);
					result = controller.Post(expected);
					Assert.NotNull(result);
					Assert.True(result.Success, "Success was not true");
					Assert.Equal(0, result.Errors.Count);
					Assert.NotNull(result.Data);
					Assert.True(result.Data.Id != Guid.NewGuid());
					var first = context.TemperatureEntries.FirstOrDefault((i) => i.Id == result.Data.Id);
					Assert.NotNull(first);
					var resultData = result.Data;
					Assert.Equal(first.Id, resultData.Id);
					Assert.True(resultData.DeviceId > -1, "Device Id");
					Assert.Equal(first.DeviceMacAddress, resultData.DeviceMacAddress);
					Assert.Equal(first.TemperatureCelsius, resultData.TemperatureCelsius);
					Assert.Equal(first.Humidity, resultData.Humidity);
					Assert.Equal(first.Pressure, resultData.Pressure);
					Assert.Equal(first.DateCreated, resultData.DateCreated);
				}
			}
		}

		public void PreSaveChanges(ContextWrapper wrapper)
		{
			// Add any missing devices our database may have.
			foreach(var entry in wrapper.Context.ChangeTracker.Entries<TemperatureEntry>())
			{
				using(var newContext = wrapper.CreateSubContext())
				{
					var e = entry.Entity;
					var device = newContext.Devices.FirstOrDefault(i => i.Id == e.DeviceId);
					if(device == null)
					{
						newContext.Devices.Add(new Device()
						{
							Id = e.DeviceId,
							DateCreated = DateTime.Now,
							Description = "",
							DisplayOrder = 0,
							IsReadOnly = true,
							Name = "",
							MacAddress = e.DeviceMacAddress
						});
						newContext.SaveChanges();
					}
				}
			}
		}

		partial void postPreCall(TemperatureEntry data, ContextWrapper wrapper)
		{
			if(data == null)
			{
				return;
			}

			using (var context = wrapper.CreateSubContext())
			{
				var device = context.Devices.FirstOrDefault(i => i.Id == data.DeviceId);
				if(device == null)
				{
					context.Devices.Add(new Device()
						{
							Id = data.DeviceId,
							DateCreated = DateTime.Now,
							Description = "",
							DisplayOrder = 0,
							IsReadOnly = true,
							Name = "",
							MacAddress = data.DeviceMacAddress
						});
					context.SaveChanges();
				}
			}
		}
	}
}
