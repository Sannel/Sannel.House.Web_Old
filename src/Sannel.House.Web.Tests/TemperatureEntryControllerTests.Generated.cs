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
					var1.DeviceId = 21;
					var1.DeviceMacAddress = 19;
					var1.TemperatureCelsius = 0.84771622849987649;
					var1.Humidity = 0.52071471536565328;
					var1.Pressure = 0.43798061154688739;
					var1.DateCreated = DateTime.MinValue;
					// var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 41;
					var2.DeviceMacAddress = 29;
					var2.TemperatureCelsius = 0.51634393051096417;
					var2.Humidity = 0.13744556351445875;
					var2.Pressure = 0.43403854427581584;
					var2.DateCreated = DateTime.MinValue;
					// var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 13;
					var3.DeviceMacAddress = 67;
					var3.TemperatureCelsius = 0.88395962858756982;
					var3.Humidity = 0.9676193422487096;
					var3.Pressure = 0.88158221677019366;
					var3.DateCreated = DateTime.MinValue;
					// var4
					var4.Id = Guid.NewGuid();
					var4.DeviceId = 32;
					var4.DeviceMacAddress = 77;
					var4.TemperatureCelsius = 0.55258733059865761;
					var4.Humidity = 0.584350190397515;
					var4.Pressure = 0.87764014949912217;
					var4.DateCreated = DateTime.MinValue;
					// var5
					var5.Id = Guid.NewGuid();
					var5.DeviceId = 51;
					var5.DeviceMacAddress = 86;
					var5.TemperatureCelsius = 0.22121503819768085;
					var5.Humidity = 0.20108103854632053;
					var5.Pressure = 0.87369808222805057;
					var5.DateCreated = DateTime.MinValue;
					var order = DateTime.Now;
					var1.DateCreated = order;
					var2.DateCreated = order.AddDays(-1);
					var3.DateCreated = order.AddDays(-2);
					var4.DateCreated = order.AddDays(-3);
					var5.DateCreated = order.AddDays(-4);
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
					Assert.Equal(var1.DeviceMacAddress, actual.DeviceMacAddress);
					Assert.Equal(var1.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var1.Humidity, actual.Humidity);
					Assert.Equal(var1.Pressure, actual.Pressure);
					Assert.Equal(var1.DateCreated, actual.DateCreated);
					// var2
					actual = list[1];
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.DeviceId, actual.DeviceId);
					Assert.Equal(var2.DeviceMacAddress, actual.DeviceMacAddress);
					Assert.Equal(var2.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var2.Humidity, actual.Humidity);
					Assert.Equal(var2.Pressure, actual.Pressure);
					Assert.Equal(var2.DateCreated, actual.DateCreated);
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
					Assert.Equal(var3.DeviceMacAddress, actual.DeviceMacAddress);
					Assert.Equal(var3.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var3.Humidity, actual.Humidity);
					Assert.Equal(var3.Pressure, actual.Pressure);
					Assert.Equal(var3.DateCreated, actual.DateCreated);
					// var4
					actual = list[1];
					// var4 -> actual
					Assert.Equal(var4.Id, actual.Id);
					Assert.Equal(var4.DeviceId, actual.DeviceId);
					Assert.Equal(var4.DeviceMacAddress, actual.DeviceMacAddress);
					Assert.Equal(var4.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var4.Humidity, actual.Humidity);
					Assert.Equal(var4.Pressure, actual.Pressure);
					Assert.Equal(var4.DateCreated, actual.DateCreated);
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
					Assert.Equal(var5.DeviceMacAddress, actual.DeviceMacAddress);
					Assert.Equal(var5.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var5.Humidity, actual.Humidity);
					Assert.Equal(var5.Pressure, actual.Pressure);
					Assert.Equal(var5.DateCreated, actual.DateCreated);
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
					var1.DeviceId = 51;
					var1.DeviceMacAddress = 20;
					var1.TemperatureCelsius = 0.35937443206057623;
					var1.Humidity = 0.2153674239364301;
					var1.Pressure = 0.42525045081286245;
					var1.DateCreated = DateTime.MinValue;
					//var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 86;
					var2.DeviceMacAddress = 87;
					var2.TemperatureCelsius = 0.98226409218379485;
					var2.Humidity = 0.38112247706443186;
					var2.Pressure = 0.29256184319619177;
					var2.DateCreated = DateTime.MinValue;
					//var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 22;
					var3.DeviceMacAddress = 43;
					var3.TemperatureCelsius = 0.98831676598094254;
					var3.Humidity = 0.036352247947991009;
					var3.Pressure = 0.0050949924649181738;
					var3.DateCreated = DateTime.MinValue;
					//Fix Order
					var order = DateTime.Now;
					var3.DateCreated = order;
					var2.DateCreated = order.AddDays(-1);
					var1.DateCreated = order.AddDays(-2);
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
					Assert.Equal(var1.DeviceMacAddress, actual.DeviceMacAddress);
					Assert.Equal(var1.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var1.Humidity, actual.Humidity);
					Assert.Equal(var1.Pressure, actual.Pressure);
					Assert.Equal(var1.DateCreated, actual.DateCreated);
					// verify var2
					results = controller.Get(var2.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.DeviceId, actual.DeviceId);
					Assert.Equal(var2.DeviceMacAddress, actual.DeviceMacAddress);
					Assert.Equal(var2.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var2.Humidity, actual.Humidity);
					Assert.Equal(var2.Pressure, actual.Pressure);
					Assert.Equal(var2.DateCreated, actual.DateCreated);
					// verify var3
					results = controller.Get(var3.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var3 -> actual
					Assert.Equal(var3.Id, actual.Id);
					Assert.Equal(var3.DeviceId, actual.DeviceId);
					Assert.Equal(var3.DeviceMacAddress, actual.DeviceMacAddress);
					Assert.Equal(var3.TemperatureCelsius, actual.TemperatureCelsius);
					Assert.Equal(var3.Humidity, actual.Humidity);
					Assert.Equal(var3.Pressure, actual.Pressure);
					Assert.Equal(var3.DateCreated, actual.DateCreated);
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
					expected.DeviceId = 71;
					expected.DeviceMacAddress = 96;
					expected.TemperatureCelsius = 0.88984274020876863;
					expected.Humidity = 0.81781188669512606;
					expected.Pressure = 0.86975601495697907;
					expected.DateCreated = DateTime.MinValue;
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
					Assert.Equal(first.DeviceMacAddress, resultData.DeviceMacAddress);
					Assert.Equal(first.TemperatureCelsius, resultData.TemperatureCelsius);
					Assert.Equal(first.Humidity, resultData.Humidity);
					Assert.Equal(first.Pressure, resultData.Pressure);
					Assert.Equal(first.DateCreated, resultData.DateCreated);
				}
			}
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void postPreCall(TemperatureEntry data, ContextWrapper wrapper);
	}
}