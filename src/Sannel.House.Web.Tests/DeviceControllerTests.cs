using Microsoft.Extensions.Logging;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Controllers.api;
using Sannel.House.Web.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sannel.House.Web.Tests
{
	public partial class DeviceControllerTests : IContextWrapperTest
	{
		public void PreSaveChanges(ContextWrapper wrapper)
		{
		}

		[Fact]
		public void PutReadonlyTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<DeviceController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new DeviceController(context, logger))
				{
					var expected = new Device();
					expected.DateCreated = DateTime.Now;
					expected.Description = "Test";
					expected.DisplayOrder = 3223;
					expected.Name = "Readonly";
					expected.IsReadOnly = true;
					context.Devices.Add(expected);
					context.SaveChanges();

					var result = controller.Put(expected);
					Assert.NotNull(result);
					Assert.False(result.Success, "Success should be false");
					Assert.Equal(1, result.Errors.Count);
					Assert.Equal($"Device {expected.Id} is read only", result.Errors[0]);
				}
			}
		}
	}
}
