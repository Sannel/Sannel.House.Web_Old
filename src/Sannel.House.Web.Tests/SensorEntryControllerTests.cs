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
	public partial class SensorEntryControllerTests : IContextWrapperTest
	{
		[Fact]
		public void PostEntryWithMacAddressTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<SensorEntryController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new SensorEntryController(context, logger))
				{
					var result = controller.Post(null);
					Assert.NotNull(result);
					Assert.False(result.Success);
					Assert.Equal(1, result.Errors.Count);
					Assert.Equal("data cannot be null", result.Errors[0]);
					Assert.Null(result.Data);
					var expected = new SensorEntry();
					// Success Test
					expected = new SensorEntry
					{
						Id = Guid.NewGuid(),
						SensorType = Sannel.House.Sensor.SensorTypes.Temperature,
						DeviceMacAddress = 84,
						Value = 0.479864743295994,
						Value2 = 0.33010231532626894,
						Value3 = 0.013223228516626743,
						Value4 = 0.35146865777274067,
						Value5 = 0.6768218738384647,
						Value6 = 0.46410197879378778,
						Value7 = 0.40449616564647117,
						Value8 = 0.58889869208862011,
						Value9 = 0.43174792147788588,
						DateCreated = DateTime.MinValue
					};
					postPreCall(expected, wrapper);
					result = controller.Post(expected);
					Assert.NotNull(result);
					Assert.True(result.Success, "Success was not true");
					Assert.Equal(0, result.Errors.Count);
					Assert.NotNull(result.Data);
					Assert.True(result.Data.Id != Guid.NewGuid());
					var first = context.SensorEntries.FirstOrDefault((i) => i.Id == result.Data.Id);
					Assert.NotNull(first);
					var resultData = result.Data;
					Assert.Equal(first.Id, resultData.Id);
					Assert.Equal(first.SensorType, resultData.SensorType);
					Assert.True(resultData.DeviceId > -1, "Device id");
					Assert.Equal(first.DeviceMacAddress, resultData.DeviceMacAddress);
					Assert.Equal(first.Value, resultData.Value);
					Assert.Equal(first.Value2, resultData.Value2);
					Assert.Equal(first.Value3, resultData.Value3);
					Assert.Equal(first.Value4, resultData.Value4);
					Assert.Equal(first.Value5, resultData.Value5);
					Assert.Equal(first.Value6, resultData.Value6);
					Assert.Equal(first.Value7, resultData.Value7);
					Assert.Equal(first.Value8, resultData.Value8);
					Assert.Equal(first.Value9, resultData.Value9);
					Assert.Equal(first.DateCreated, resultData.DateCreated);
				}
			}
		}

		public void PreSaveChanges(ContextWrapper wrapper)
		{
			// Add any missing devices our database may have.
			foreach(var entry in wrapper.Context.ChangeTracker.Entries<SensorEntry>())
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
							MacAddress = e.DeviceMacAddress,
							Name = ""
						});
						newContext.SaveChanges();
					}
				}
			}
		}

		partial void postPreCall(SensorEntry data, ContextWrapper wrapper)
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
