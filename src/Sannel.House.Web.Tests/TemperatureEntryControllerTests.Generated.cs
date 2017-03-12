/* Copyright 2017 Sannel Software, L.L.C.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/

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
	public partial class TemperatureEntryControllerTests : IContextWrapperTest
	{
		[Fact]
		public void GetPagedTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<TemperatureEntryController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new TemperatureEntryController(context, logger))
				// Fix order
				{
					var var1 = new TemperatureEntry();
					var var2 = new TemperatureEntry();
					var var3 = new TemperatureEntry();
					var var4 = new TemperatureEntry();
					var var5 = new TemperatureEntry();
					// var1
					var1.Id = Guid.NewGuid();
					var1.DeviceId = 99;
					var1.TemperatureCelsius = 0.72412480447633421;
					var1.Humidity = 0.25625925569620878;
					var1.Pressure = 0.76331520162677169;
					var1.CreatedDateTime = DateTimeOffset.Now;
					// var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 71;
					var2.TemperatureCelsius = 0.1135205673582482;
					var2.Humidity = 0.623874948184879;
					var2.Pressure = 0.59348898036102249;
					var2.CreatedDateTime = DateTimeOffset.Now;
					// var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 90;
					var3.TemperatureCelsius = 0.20949771265010242;
					var3.Humidity = 0.2925026529899345;
					var3.Pressure = 0.21021982850982798;
					var3.CreatedDateTime = DateTimeOffset.Now;
					// var4
					var4.Id = Guid.NewGuid();
					var4.DeviceId = 10;
					var4.TemperatureCelsius = 0.30547485794195667;
					var4.Humidity = 0.96113035779499;
					var4.Pressure = 0.82695067665863353;
					var4.CreatedDateTime = DateTimeOffset.Now;
					// var5
					var5.Id = Guid.NewGuid();
					var5.DeviceId = 30;
					var5.TemperatureCelsius = 0.40145200323381086;
					var5.Humidity = 0.62975806260004552;
					var5.Pressure = 0.44368152480743894;
					var5.CreatedDateTime = DateTimeOffset.Now;
					var order = DateTimeOffset.Now;
					var1.CreatedDateTime = order;
					var2.CreatedDateTime = order.AddDays(-1);
					var3.CreatedDateTime = order.AddDays(-2);
					var4.CreatedDateTime = order.AddDays(-3);
					var5.CreatedDateTime = order.AddDays(-4);
					// Add to database
					context.TemperatureEntries.Add(var1);
					context.TemperatureEntries.Add(var2);
					context.TemperatureEntries.Add(var3);
					context.TemperatureEntries.Add(var4);
					context.TemperatureEntries.Add(var5);
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
					Assert.Equal(var1.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var1.Humidity, actual.Humidity);
					Assert.Equal(var1.Pressure, actual.Pressure);
					Assert.Equal(var1.CreatedDateTime, actual.CreatedDateTime);
					// var2
					actual = list[1];
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.DeviceId, actual.DeviceId);
					Assert.Equal(var2.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var2.Humidity, actual.Humidity);
					Assert.Equal(var2.Pressure, actual.Pressure);
					Assert.Equal(var2.CreatedDateTime, actual.CreatedDateTime);
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
					Assert.Equal(var3.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var3.Humidity, actual.Humidity);
					Assert.Equal(var3.Pressure, actual.Pressure);
					Assert.Equal(var3.CreatedDateTime, actual.CreatedDateTime);
					// var4
					actual = list[1];
					// var4 -> actual
					Assert.Equal(var4.Id, actual.Id);
					Assert.Equal(var4.DeviceId, actual.DeviceId);
					Assert.Equal(var4.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var4.Humidity, actual.Humidity);
					Assert.Equal(var4.Pressure, actual.Pressure);
					Assert.Equal(var4.CreatedDateTime, actual.CreatedDateTime);
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
					Assert.Equal(var5.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var5.Humidity, actual.Humidity);
					Assert.Equal(var5.Pressure, actual.Pressure);
					Assert.Equal(var5.CreatedDateTime, actual.CreatedDateTime);
				}
			}
		}

		[Fact]
		public void GetWithIdTest()
		{
			{
				var logFactory = new LoggerFactory();
				var logger = logFactory.CreateLogger<TemperatureEntryController>();
				using (var wrapper = new ContextWrapper(this))
				{
					var context = wrapper.Context;
					using (var controller = new TemperatureEntryController(context, logger))
					{
						var var1 = new TemperatureEntry();
						var var2 = new TemperatureEntry();
						var var3 = new TemperatureEntry();
						//var1
						var1.Id = Guid.NewGuid();
						var1.DeviceId = 65;
						var1.TemperatureCelsius = 0.8587684141745644;
						var1.Humidity = 0.61977153765958337;
						var1.Pressure = 0.049976541683998212;
						var1.CreatedDateTime = DateTimeOffset.Now;
						//var2
						var2.Id = Guid.NewGuid();
						var2.DeviceId = 10;
						var2.TemperatureCelsius = 0.99631537077776877;
						var2.Humidity = 0.6552691956308061;
						var2.Pressure = 0.607065523791623;
						var2.CreatedDateTime = DateTimeOffset.Now;
						//var3
						var3.Id = Guid.NewGuid();
						var3.DeviceId = 81;
						var3.TemperatureCelsius = 0.42075729855371513;
						var3.Humidity = 0.839637597948144;
						var3.Pressure = 0.35002632176039106;
						var3.CreatedDateTime = DateTimeOffset.Now;
						//Fix Order
						var order = DateTimeOffset.Now;
						var3.CreatedDateTime = order;
						var2.CreatedDateTime = order.AddDays(-1);
						var1.CreatedDateTime = order.AddDays(-2);
						// Add and save entities
						context.TemperatureEntries.Add(var1);
						context.TemperatureEntries.Add(var2);
						context.TemperatureEntries.Add(var3);
						wrapper.SaveChanges();
						// verify
						var actual = controller.Get(var1.Id);
						Assert.NotNull(actual.Id);
						// var1 -> actual
						Assert.Equal(var1.Id, actual.Id);
						Assert.Equal(var1.DeviceId, actual.DeviceId);
						Assert.Equal(var1.TemperatureCelsius, actual.TemperatureCelsius);
						Assert.Equal(var1.Humidity, actual.Humidity);
						Assert.Equal(var1.Pressure, actual.Pressure);
						Assert.Equal(var1.CreatedDateTime, actual.CreatedDateTime);
						// Verify var2
						actual = controller.Get(var2.Id);
						Assert.NotNull(actual.Id);
						// var2 -> actual
						Assert.Equal(var2.Id, actual.Id);
						Assert.Equal(var2.DeviceId, actual.DeviceId);
						Assert.Equal(var2.TemperatureCelsius, actual.TemperatureCelsius);
						Assert.Equal(var2.Humidity, actual.Humidity);
						Assert.Equal(var2.Pressure, actual.Pressure);
						Assert.Equal(var2.CreatedDateTime, actual.CreatedDateTime);
						// Verify var3
						actual = controller.Get(var3.Id);
						Assert.NotNull(actual.Id);
						// var3 -> actual
						Assert.Equal(var3.Id, actual.Id);
						Assert.Equal(var3.DeviceId, actual.DeviceId);
						Assert.Equal(var3.TemperatureCelsius, actual.TemperatureCelsius);
						Assert.Equal(var3.Humidity, actual.Humidity);
						Assert.Equal(var3.Pressure, actual.Pressure);
						Assert.Equal(var3.CreatedDateTime, actual.CreatedDateTime);
					}
				}
			}
		}

		[Fact]
		public void PostTest()
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
					expected = new TemperatureEntry();
					expected.Id = Guid.NewGuid();
					expected.DeviceId = 85;
					expected.TemperatureCelsius = 0.19212702996662215;
					expected.Humidity = 0.48219361504641994;
					expected.Pressure = 0.47549926232336986;
					expected.CreatedDateTime = DateTimeOffset.Now;
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
					Assert.Equal(first.DeviceId, resultData.DeviceId);
					Assert.Equal(first.TemperatureCelsius, resultData.TemperatureCelsius);
					Assert.Equal(first.Humidity, resultData.Humidity);
					Assert.Equal(first.Pressure, resultData.Pressure);
					Assert.Equal(first.CreatedDateTime, resultData.CreatedDateTime);
				}
			}
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void postPreCall(TemperatureEntry data, ContextWrapper wrapper);
	}
}