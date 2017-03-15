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
					var1.DeviceId = 55;
					var1.TemperatureCelsius = 0.45889742181585053;
					var1.Humidity = 0.034340253581451367;
					var1.Pressure = 0.48840980347637541;
					var1.CreatedDateTime = DateTime.Now;
					// var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 74;
					var2.TemperatureCelsius = 0.55487456710770477;
					var2.Humidity = 0.70296795838650683;
					var2.Pressure = 0.10514065162518092;
					var2.CreatedDateTime = DateTime.Now;
					// var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 94;
					var3.TemperatureCelsius = 0.650851712399559;
					var3.Humidity = 0.37159566319156234;
					var3.Pressure = 0.72187149977398646;
					var3.CreatedDateTime = DateTime.Now;
					// var4
					var4.Id = Guid.NewGuid();
					var4.DeviceId = 14;
					var4.TemperatureCelsius = 0.74682885769141316;
					var4.Humidity = 0.040223367996617861;
					var4.Pressure = 0.33860234792279187;
					var4.CreatedDateTime = DateTime.Now;
					// var5
					var5.Id = Guid.NewGuid();
					var5.DeviceId = 85;
					var5.TemperatureCelsius = 0.13622462057332724;
					var5.Humidity = 0.40783906327925579;
					var5.Pressure = 0.16877612665704272;
					var5.CreatedDateTime = DateTime.Now;
					var order = DateTime.Now;
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
					var1.DeviceId = 85;
					var1.TemperatureCelsius = 0.16877612665704272;
					var1.Humidity = 0.60063508832856782;
					var1.Pressure = 0.19387192707223441;
					var1.CreatedDateTime = DateTime.Now;
					//var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 14;
					var2.TemperatureCelsius = 0.76373298827732583;
					var2.Humidity = 0.63024506421305471;
					var2.Pressure = 0.27180772054558977;
					var2.CreatedDateTime = DateTime.Now;
					//var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 41;
					var3.TemperatureCelsius = 0.20295659229297033;
					var3.Humidity = 0.26864240889839941;
					var3.Pressure = 0.62231230671625226;
					var3.CreatedDateTime = DateTime.Now;
					//Fix Order
					var order = DateTime.Now;
					var3.CreatedDateTime = order;
					var2.CreatedDateTime = order.AddDays(-1);
					var1.CreatedDateTime = order.AddDays(-2);
					// Add and save entities
					context.TemperatureEntries.Add(var1);
					context.TemperatureEntries.Add(var2);
					context.TemperatureEntries.Add(var3);
					wrapper.SaveChanges();
					// verify
					var results = controller.Get(var1.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					var actual = results.Data;
					// var1 -> actual
					Assert.Equal(var1.Id, actual.Id);
					Assert.Equal(var1.DeviceId, actual.DeviceId);
					Assert.Equal(var1.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var1.Humidity, actual.Humidity);
					Assert.Equal(var1.Pressure, actual.Pressure);
					Assert.Equal(var1.CreatedDateTime, actual.CreatedDateTime);
					// verify var2
					results = controller.Get(var2.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.DeviceId, actual.DeviceId);
					Assert.Equal(var2.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var2.Humidity, actual.Humidity);
					Assert.Equal(var2.Pressure, actual.Pressure);
					Assert.Equal(var2.CreatedDateTime, actual.CreatedDateTime);
					// verify var3
					results = controller.Get(var3.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var3 -> actual
					Assert.Equal(var3.Id, actual.Id);
					Assert.Equal(var3.DeviceId, actual.DeviceId);
					Assert.Equal(var3.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var3.Humidity, actual.Humidity);
					Assert.Equal(var3.Pressure, actual.Pressure);
					Assert.Equal(var3.CreatedDateTime, actual.CreatedDateTime);
					// Failed Test
					results = controller.Get(Guid.Empty);
					Assert.NotNull(results);
					Assert.False(results.Success);
					Assert.Equal(1, results.Errors.Count);
					Assert.Equal($"Could not find TemperatureEntry with Id {Guid.Empty}", results.Errors[0]);
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
					expected.DeviceId = 5;
					expected.TemperatureCelsius = 0.23220176586518146;
					expected.Humidity = 0.076466768084311285;
					expected.Pressure = 0.78550697480584819;
					expected.CreatedDateTime = DateTime.Now;
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