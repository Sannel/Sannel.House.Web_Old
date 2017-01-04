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
		public void PostTest()
		{

			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new DeviceController(context))
				{
					var result = controller.Post(null);
					Assert.NotNull(result);
					Assert.False(result.Success);
					Assert.Equal(1, result.Errors.Count);
					Assert.Equal("device cannot be null", result.Errors[0]);
					Assert.Null(result.Data);

					var data = new Device();
					result = controller.Post(data);
					Assert.NotNull(result);
					Assert.False(result.Success);
					Assert.Equal(1, result.Errors.Count);
					Assert.Equal("Name must have a non empty value", result.Errors[0]);
					Assert.NotNull(result.Data);

					data = new Device();
					data.Name = "test";
					data.DisplayOrder = -1;
					data.DateCreated = DateTimeOffset.MinValue;
					data.IsReadOnly = true;
					result = controller.Post(data);
					Assert.NotNull(result);
					Assert.True(result.Success);
					Assert.Equal(0, result.Errors.Count);
					Assert.Null(result.Data);
					Assert.True(result.Data.Id != 0, "Id not updated");

					var first = context.Devices.FirstOrDefault(i => i.Id == result.Data.Id);
					Assert.NotNull(first);
					var resultData = result.Data;
					Assert.Equal(first.Id, resultData.Id);
					Assert.Equal(first.Name, resultData.Name);
					Assert.Equal(first.Description, resultData.Description);
					Assert.Equal(first.DisplayOrder, resultData.DisplayOrder);
					Assert.Equal(first.IsReadOnly, resultData.IsReadOnly);
					Assert.Equal(first.DateCreated, resultData.DateCreated);
				}

			}
		}
	}
}
