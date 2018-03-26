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
/* This is generated code so probably best not to edit it */

using System;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Controllers.api;
using Sannel.House.Web.Data;
using Sannel.House.Web.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Sannel.House.Web.Tests
{
	public partial class AlternateDeviceIdControllerTests : IContextWrapperTest
	{
		[Fact]
		public void GetPagedTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<AlternateDeviceIdController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new AlternateDeviceIdController(context, logger))
				// Fix order
				{
					var var1 = new AlternateDeviceId();
					var var2 = new AlternateDeviceId();
					var var3 = new AlternateDeviceId();
					var var4 = new AlternateDeviceId();
					var var5 = new AlternateDeviceId();
					// var1
					var1.Id = 92;
					var1.DeviceId = 96;
					var1.DateCreated = DateTime.MinValue;
					var1.Uuid = Guid.NewGuid();
					// var2
					var2.Id = 87;
					var2.DeviceId = 54;
					var2.DateCreated = DateTime.MinValue;
					var2.Uuid = Guid.NewGuid();
					// var3
					var3.Id = 34;
					var3.DeviceId = 60;
					var3.DateCreated = DateTime.MinValue;
					var3.Uuid = Guid.NewGuid();
					// var4
					var4.Id = 78;
					var4.DeviceId = 28;
					var4.DateCreated = DateTime.MinValue;
					var4.Uuid = Guid.NewGuid();
					// var5
					var5.Id = 60;
					var5.DeviceId = 11;
					var5.DateCreated = DateTime.MinValue;
					var5.Uuid = Guid.NewGuid();
					var order = DateTime.Now;
					var1.DateCreated = order;
					var2.DateCreated = order.AddDays(-1);
					var3.DateCreated = order.AddDays(-2);
					var4.DateCreated = order.AddDays(-3);
					var5.DateCreated = order.AddDays(-4);
					// Add to database
					context.AlternateDeviceIds.Add(var1);
					context.AlternateDeviceIds.Add(var2);
					context.AlternateDeviceIds.Add(var3);
					context.AlternateDeviceIds.Add(var4);
					context.AlternateDeviceIds.Add(var5);
					wrapper.SaveChanges();
					// Call with invalid page number
					var paged = controller.GetPaged(0, 2);
					Assert.NotNull(paged);
					Assert.False(paged.Success);
					Assert.Equal(1, paged.Errors.Count);
					Assert.Equal("Page must be 1 or greater", paged.Errors[0]);
					// Invalid PageSize
					paged = controller.GetPaged(1, 0);
					Assert.NotNull(paged);
					Assert.False(paged.Success);
					Assert.Equal(1, paged.Errors.Count);
					Assert.Equal("PageSize must be 1 or greater", paged.Errors[0]);
					// Success Tests
					paged = controller.GetPaged(1, 2);
					Assert.NotNull(paged);
					Assert.True(paged.Success);
					Assert.Equal(5, paged.TotalResults);
					Assert.Equal(2, paged.PageSize);
					Assert.Equal(1, paged.CurrentPage);
					Assert.NotNull(paged.Data);
					var list = paged.Data.ToList();
					Assert.Equal(2, list.Count);
					// var1
					var actual = list[0];
					// var1 -> actual
					Assert.Equal(var1.Id, actual.Id);
					Assert.Equal(var1.DeviceId, actual.DeviceId);
					Assert.Equal(var1.DateCreated, actual.DateCreated);
					Assert.Equal(var1.Uuid, actual.Uuid);
					// var2
					actual = list[1];
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.DeviceId, actual.DeviceId);
					Assert.Equal(var2.DateCreated, actual.DateCreated);
					Assert.Equal(var2.Uuid, actual.Uuid);
					// Success Tests
					paged = controller.GetPaged(2, 2);
					Assert.NotNull(paged);
					Assert.True(paged.Success);
					Assert.Equal(5, paged.TotalResults);
					Assert.Equal(2, paged.PageSize);
					Assert.Equal(2, paged.CurrentPage);
					Assert.NotNull(paged.Data);
					list = paged.Data.ToList();
					Assert.Equal(2, list.Count);
					// var3
					actual = list[0];
					// var3 -> actual
					Assert.Equal(var3.Id, actual.Id);
					Assert.Equal(var3.DeviceId, actual.DeviceId);
					Assert.Equal(var3.DateCreated, actual.DateCreated);
					Assert.Equal(var3.Uuid, actual.Uuid);
					// var4
					actual = list[1];
					// var4 -> actual
					Assert.Equal(var4.Id, actual.Id);
					Assert.Equal(var4.DeviceId, actual.DeviceId);
					Assert.Equal(var4.DateCreated, actual.DateCreated);
					Assert.Equal(var4.Uuid, actual.Uuid);
					// Success Tests
					paged = controller.GetPaged(3, 2);
					Assert.NotNull(paged);
					Assert.True(paged.Success);
					Assert.Equal(5, paged.TotalResults);
					Assert.Equal(2, paged.PageSize);
					Assert.Equal(3, paged.CurrentPage);
					Assert.NotNull(paged.Data);
					list = paged.Data.ToList();
					Assert.Equal(1, list.Count);
					// var5
					actual = list[0];
					// var5 -> actual
					Assert.Equal(var5.Id, actual.Id);
					Assert.Equal(var5.DeviceId, actual.DeviceId);
					Assert.Equal(var5.DateCreated, actual.DateCreated);
					Assert.Equal(var5.Uuid, actual.Uuid);
				}
			}
		}

		[Fact]
		public void GetWithIdTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<AlternateDeviceIdController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new AlternateDeviceIdController(context, logger))
				{
					var var1 = new AlternateDeviceId();
					var var2 = new AlternateDeviceId();
					var var3 = new AlternateDeviceId();
					//var1
					var1.Id = 31;
					var1.DeviceId = 37;
					var1.DateCreated = DateTime.MinValue;
					var1.Uuid = Guid.NewGuid();
					//var2
					var2.Id = 8;
					var2.DeviceId = 39;
					var2.DateCreated = DateTime.MinValue;
					var2.Uuid = Guid.NewGuid();
					//var3
					var3.Id = 92;
					var3.DeviceId = 81;
					var3.DateCreated = DateTime.MinValue;
					var3.Uuid = Guid.NewGuid();
					//Fix Order
					var order = DateTime.Now;
					var3.DateCreated = order;
					var2.DateCreated = order.AddDays(-1);
					var1.DateCreated = order.AddDays(-2);
					// Add and save entities
					context.AlternateDeviceIds.Add(var1);
					context.AlternateDeviceIds.Add(var2);
					context.AlternateDeviceIds.Add(var3);
					wrapper.SaveChanges();
					// verify
					var results = controller.Get(var1.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					var actual = results.Data;
					// var1 -> actual
					Assert.Equal(var1.Id, actual.Id);
					Assert.Equal(var1.DeviceId, actual.DeviceId);
					Assert.Equal(var1.DateCreated, actual.DateCreated);
					Assert.Equal(var1.Uuid, actual.Uuid);
					// verify var2
					results = controller.Get(var2.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.DeviceId, actual.DeviceId);
					Assert.Equal(var2.DateCreated, actual.DateCreated);
					Assert.Equal(var2.Uuid, actual.Uuid);
					// verify var3
					results = controller.Get(var3.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var3 -> actual
					Assert.Equal(var3.Id, actual.Id);
					Assert.Equal(var3.DeviceId, actual.DeviceId);
					Assert.Equal(var3.DateCreated, actual.DateCreated);
					Assert.Equal(var3.Uuid, actual.Uuid);
					// Failed Test
					results = controller.Get(0);
					Assert.NotNull(results);
					Assert.False(results.Success);
					Assert.Equal(1, results.Errors.Count);
					Assert.Equal($"Could not find AlternateDeviceId with Id {0}", results.Errors[0]);
				}
			}
		}

		[Fact]
		public void PostTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<AlternateDeviceIdController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new AlternateDeviceIdController(context, logger))
				{
					var result = controller.Post(null);
					Assert.NotNull(result);
					Assert.False(result.Success);
					Assert.Equal(1, result.Errors.Count);
					Assert.Equal("data cannot be null", result.Errors[0]);
					Assert.Null(result.Data);
					var expected = new AlternateDeviceId();
					// Success Test
					expected = new AlternateDeviceId();
					expected.Id = 50;
					expected.DeviceId = 89;
					expected.DateCreated = DateTime.MinValue;
					expected.Uuid = Guid.NewGuid();
					postPreCall(expected, wrapper);
					result = controller.Post(expected);
					Assert.NotNull(result);
					Assert.True(result.Success, "Success was not true");
					Assert.Equal(0, result.Errors.Count);
					Assert.NotNull(result.Data);
					Assert.True(result.Data.Id > 0, "Id not updated");
					var first = context.AlternateDeviceIds.FirstOrDefault((i) => i.Id == result.Data.Id);
					Assert.NotNull(first);
					var resultData = result.Data;
					Assert.Equal(first.Id, resultData.Id);
					Assert.Equal(first.DeviceId, resultData.DeviceId);
					Assert.Equal(first.DateCreated, resultData.DateCreated);
					Assert.Equal(first.Uuid, resultData.Uuid);
				}
			}
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void postPreCall(AlternateDeviceId data, ContextWrapper wrapper);
	}
}