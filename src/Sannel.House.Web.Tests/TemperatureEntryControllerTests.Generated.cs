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
		public void GetTest()
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
						var1.DeviceId = 48;
						var1.TemperatureCelsius = 0.093544082759667233;
						var1.Humidity = 0.81781536658192766;
						var1.Pressure = 0.86056559200424965;
						var1.CreatedDateTime = DateTimeOffset.Now;
						//var2
						var2.Id = Guid.NewGuid();
						var2.DeviceId = 85;
						var2.TemperatureCelsius = 0.22400316001102474;
						var2.Humidity = 0.88102902606177569;
						var2.Pressure = 0.63801939256397044;
						var2.CreatedDateTime = DateTimeOffset.Now;
						//var3
						var3.Id = Guid.NewGuid();
						var3.DeviceId = 55;
						var3.TemperatureCelsius = 0.16821098987395455;
						var3.Humidity = 0.86343549651253759;
						var3.Pressure = 0.51693051798126222;
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
						//call get method
						var results = controller.Get();
						Assert.NotNull(results);
						var list = results.ToList();
						Assert.Equal(3, list.Count);
						var one = list[0];
						// var3 -> one
						Assert.Equal(var3.Id, one.Id);
						Assert.Equal(var3.DeviceId, one.DeviceId);
						Assert.Equal(var3.TemperatureCelsius, one.TemperatureCelsius);
						Assert.Equal(var3.Humidity, one.Humidity);
						Assert.Equal(var3.Pressure, one.Pressure);
						Assert.Equal(var3.CreatedDateTime, one.CreatedDateTime);
						var two = list[1];
						// var2 -> two
						Assert.Equal(var2.Id, two.Id);
						Assert.Equal(var2.DeviceId, two.DeviceId);
						Assert.Equal(var2.TemperatureCelsius, two.TemperatureCelsius);
						Assert.Equal(var2.Humidity, two.Humidity);
						Assert.Equal(var2.Pressure, two.Pressure);
						Assert.Equal(var2.CreatedDateTime, two.CreatedDateTime);
						var three = list[2];
						// var1 -> three
						Assert.Equal(var1.Id, three.Id);
						Assert.Equal(var1.DeviceId, three.DeviceId);
						Assert.Equal(var1.TemperatureCelsius, three.TemperatureCelsius);
						Assert.Equal(var1.Humidity, three.Humidity);
						Assert.Equal(var1.Pressure, three.Pressure);
						Assert.Equal(var1.CreatedDateTime, three.CreatedDateTime);
					}
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
						var1.DeviceId = 48;
						var1.TemperatureCelsius = 0.093544082759667233;
						var1.Humidity = 0.81781536658192766;
						var1.Pressure = 0.86056559200424965;
						var1.CreatedDateTime = DateTimeOffset.Now;
						//var2
						var2.Id = Guid.NewGuid();
						var2.DeviceId = 85;
						var2.TemperatureCelsius = 0.22400316001102474;
						var2.Humidity = 0.88102902606177569;
						var2.Pressure = 0.63801939256397044;
						var2.CreatedDateTime = DateTimeOffset.Now;
						//var3
						var3.Id = Guid.NewGuid();
						var3.DeviceId = 55;
						var3.TemperatureCelsius = 0.16821098987395455;
						var3.Humidity = 0.86343549651253759;
						var3.Pressure = 0.51693051798126222;
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
						// Success Test test
						expected = new TemperatureEntry();
						expected.Id = Guid.NewGuid();
						expected.DeviceId = 48;
						expected.TemperatureCelsius = 0.85465780452576368;
						expected.Humidity = 0.54606472400299488;
						expected.Pressure = 0.093544082759667233;
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
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void postPreCall(TemperatureEntry data, ContextWrapper wrapper);
	}
}