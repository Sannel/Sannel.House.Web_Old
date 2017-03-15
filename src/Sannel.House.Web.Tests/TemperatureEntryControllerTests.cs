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
					temp.CreatedDateTime = DateTime.Now;
					var result = controller.Post(temp);
					Assert.True(result.Success);
					var d = result.Data;
					Assert.NotNull(d);
					Assert.Equal(SystemDeviceIds.DefaultId, d.DeviceId);
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
							Name = ""
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
							Name = ""
						});
					context.SaveChanges();
				}
			}
		}
	}
}
