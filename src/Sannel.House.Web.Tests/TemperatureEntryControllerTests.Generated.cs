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
						var1.DeviceId = 50;
						var1.TemperatureCelsius = 0.17491436292180529;
						var1.Humidity = 0.68454665163743622;
						var1.Pressure = 0.10284319571351781;
						var1.CreatedDateTime = DateTimeOffset.Now;
						//var2
						var2.Id = Guid.NewGuid();
						var2.DeviceId = 15;
						var2.TemperatureCelsius = 0.71690824614693793;
						var2.Humidity = 0.035434121282507725;
						var2.Pressure = 0.24452482594387831;
						var2.CreatedDateTime = DateTimeOffset.Now;
						//var3
						var3.Id = Guid.NewGuid();
						var3.DeviceId = 18;
						var3.TemperatureCelsius = 0.17296682771899125;
						var3.Humidity = 0.30090909930919718;
						var3.Pressure = 0.69809584957458815;
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
						var1.DeviceId = 50;
						var1.TemperatureCelsius = 0.17491436292180529;
						var1.Humidity = 0.68454665163743622;
						var1.Pressure = 0.10284319571351781;
						var1.CreatedDateTime = DateTimeOffset.Now;
						//var2
						var2.Id = Guid.NewGuid();
						var2.DeviceId = 15;
						var2.TemperatureCelsius = 0.71690824614693793;
						var2.Humidity = 0.035434121282507725;
						var2.Pressure = 0.24452482594387831;
						var2.CreatedDateTime = DateTimeOffset.Now;
						//var3
						var3.Id = Guid.NewGuid();
						var3.DeviceId = 18;
						var3.TemperatureCelsius = 0.17296682771899125;
						var3.Humidity = 0.30090909930919718;
						var3.Pressure = 0.69809584957458815;
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
	}
}