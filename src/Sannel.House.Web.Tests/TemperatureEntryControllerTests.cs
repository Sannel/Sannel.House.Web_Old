using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sannel.House.Web.Data;

namespace Sannel.House.Web.Tests
{
	public partial class TemperatureEntryControllerTests : IContextWrapperTest
	{
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
							DateCreated = DateTimeOffset.Now,
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
							DateCreated = DateTimeOffset.Now,
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
