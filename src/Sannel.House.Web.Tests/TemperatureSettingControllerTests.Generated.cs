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
	public partial class TemperatureSettingControllerTests : IContextWrapperTest
	{
		[Fact]
		public void GetTest()
		{
			{
				var logFactory = new LoggerFactory();
				var logger = logFactory.CreateLogger<TemperatureSettingController>();
				using (var wrapper = new ContextWrapper(this))
				{
					var context = wrapper.Context;
					using (var controller = new TemperatureSettingController(context, logger))
					{
						var var1 = new TemperatureSetting();
						var var2 = new TemperatureSetting();
						var var3 = new TemperatureSetting();
						//var1
						var1.Id = 58;
						var1.DayOfWeek = 73;
						var1.Month = 46;
						var1.IsTimeOnly = true;
						var1.StartTime = DateTimeOffset.MinValue;
						var1.EndTime = DateTimeOffset.MinValue;
						var1.HeatTemperatureC = 0.19375026793859446;
						var1.CoolTemperatureC = 0.6171414668751608;
						var1.DateCreated = DateTimeOffset.MinValue;
						var1.DateModified = DateTimeOffset.MinValue;
						//var2
						var2.Id = 66;
						var2.DayOfWeek = 28;
						var2.Month = 43;
						var2.IsTimeOnly = true;
						var2.StartTime = DateTimeOffset.MinValue;
						var2.EndTime = DateTimeOffset.MinValue;
						var2.HeatTemperatureC = 0.2823743267368406;
						var2.CoolTemperatureC = 0.13964135066589403;
						var2.DateCreated = DateTimeOffset.MinValue;
						var2.DateModified = DateTimeOffset.MinValue;
						//var3
						var3.Id = 15;
						var3.DayOfWeek = 12;
						var3.Month = 51;
						var3.IsTimeOnly = true;
						var3.StartTime = DateTimeOffset.MinValue;
						var3.EndTime = DateTimeOffset.MinValue;
						var3.HeatTemperatureC = 0.56154155757349988;
						var3.CoolTemperatureC = 0.76185700798493672;
						var3.DateCreated = DateTimeOffset.MinValue;
						var3.DateModified = DateTimeOffset.MinValue;
						//Fix Order
						var order = DateTimeOffset.Now;
						var3.DateCreated = order;
						var2.DateCreated = order.AddDays(-1);
						var1.DateCreated = order.AddDays(-2);
						// Add and save entities
						context.TemperatureSettings.Add(var1);
						context.TemperatureSettings.Add(var2);
						context.TemperatureSettings.Add(var3);
						wrapper.SaveChanges();
						//call get method
						var results = controller.Get();
						Assert.NotNull(results);
						var list = results.ToList();
						Assert.Equal(3, list.Count);
						var one = list[0];
						// var3 -> one
						Assert.Equal(var3.Id, one.Id);
						Assert.Equal(var3.DayOfWeek, one.DayOfWeek);
						Assert.Equal(var3.Month, one.Month);
						Assert.Equal(var3.IsTimeOnly, one.IsTimeOnly);
						Assert.Equal(var3.StartTime, one.StartTime);
						Assert.Equal(var3.EndTime, one.EndTime);
						Assert.Equal(var3.HeatTemperatureC, one.HeatTemperatureC);
						Assert.Equal(var3.CoolTemperatureC, one.CoolTemperatureC);
						Assert.Equal(var3.DateCreated, one.DateCreated);
						Assert.Equal(var3.DateModified, one.DateModified);
						var two = list[1];
						// var2 -> two
						Assert.Equal(var2.Id, two.Id);
						Assert.Equal(var2.DayOfWeek, two.DayOfWeek);
						Assert.Equal(var2.Month, two.Month);
						Assert.Equal(var2.IsTimeOnly, two.IsTimeOnly);
						Assert.Equal(var2.StartTime, two.StartTime);
						Assert.Equal(var2.EndTime, two.EndTime);
						Assert.Equal(var2.HeatTemperatureC, two.HeatTemperatureC);
						Assert.Equal(var2.CoolTemperatureC, two.CoolTemperatureC);
						Assert.Equal(var2.DateCreated, two.DateCreated);
						Assert.Equal(var2.DateModified, two.DateModified);
						var three = list[2];
						// var1 -> three
						Assert.Equal(var1.Id, three.Id);
						Assert.Equal(var1.DayOfWeek, three.DayOfWeek);
						Assert.Equal(var1.Month, three.Month);
						Assert.Equal(var1.IsTimeOnly, three.IsTimeOnly);
						Assert.Equal(var1.StartTime, three.StartTime);
						Assert.Equal(var1.EndTime, three.EndTime);
						Assert.Equal(var1.HeatTemperatureC, three.HeatTemperatureC);
						Assert.Equal(var1.CoolTemperatureC, three.CoolTemperatureC);
						Assert.Equal(var1.DateCreated, three.DateCreated);
						Assert.Equal(var1.DateModified, three.DateModified);
					}
				}
			}
		}

		[Fact]
		public void GetWithIdTest()
		{
			{
				var logFactory = new LoggerFactory();
				var logger = logFactory.CreateLogger<TemperatureSettingController>();
				using (var wrapper = new ContextWrapper(this))
				{
					var context = wrapper.Context;
					using (var controller = new TemperatureSettingController(context, logger))
					{
						var var1 = new TemperatureSetting();
						var var2 = new TemperatureSetting();
						var var3 = new TemperatureSetting();
						//var1
						var1.Id = 94;
						var1.DayOfWeek = 15;
						var1.Month = 62;
						var1.IsTimeOnly = true;
						var1.StartTime = DateTimeOffset.MinValue;
						var1.EndTime = DateTimeOffset.MinValue;
						var1.HeatTemperatureC = 0.19296720865786413;
						var1.CoolTemperatureC = 0.60947580757060826;
						var1.DateCreated = DateTimeOffset.MinValue;
						var1.DateModified = DateTimeOffset.MinValue;
						//var2
						var2.Id = 35;
						var2.DayOfWeek = 50;
						var2.Month = 46;
						var2.IsTimeOnly = true;
						var2.StartTime = DateTimeOffset.MinValue;
						var2.EndTime = DateTimeOffset.MinValue;
						var2.HeatTemperatureC = 0.60645863488617291;
						var2.CoolTemperatureC = 0.86538646922697615;
						var2.DateCreated = DateTimeOffset.MinValue;
						var2.DateModified = DateTimeOffset.MinValue;
						//var3
						var3.Id = 33;
						var3.DayOfWeek = 10;
						var3.Month = 49;
						var3.IsTimeOnly = false;
						var3.StartTime = DateTimeOffset.MinValue;
						var3.EndTime = DateTimeOffset.MinValue;
						var3.HeatTemperatureC = 0.76109140913984341;
						var3.CoolTemperatureC = 0.68184624085288781;
						var3.DateCreated = DateTimeOffset.MinValue;
						var3.DateModified = DateTimeOffset.MinValue;
						//Fix Order
						var order = DateTimeOffset.Now;
						var3.DateCreated = order;
						var2.DateCreated = order.AddDays(-1);
						var1.DateCreated = order.AddDays(-2);
						// Add and save entities
						context.TemperatureSettings.Add(var1);
						context.TemperatureSettings.Add(var2);
						context.TemperatureSettings.Add(var3);
						wrapper.SaveChanges();
						// verify
						var actual = controller.Get(var1.Id);
						Assert.NotNull(actual.Id);
						// var1 -> actual
						Assert.Equal(var1.Id, actual.Id);
						Assert.Equal(var1.DayOfWeek, actual.DayOfWeek);
						Assert.Equal(var1.Month, actual.Month);
						Assert.Equal(var1.IsTimeOnly, actual.IsTimeOnly);
						Assert.Equal(var1.StartTime, actual.StartTime);
						Assert.Equal(var1.EndTime, actual.EndTime);
						Assert.Equal(var1.HeatTemperatureC, actual.HeatTemperatureC);
						Assert.Equal(var1.CoolTemperatureC, actual.CoolTemperatureC);
						Assert.Equal(var1.DateCreated, actual.DateCreated);
						Assert.Equal(var1.DateModified, actual.DateModified);
						// Verify var2
						actual = controller.Get(var2.Id);
						Assert.NotNull(actual.Id);
						// var2 -> actual
						Assert.Equal(var2.Id, actual.Id);
						Assert.Equal(var2.DayOfWeek, actual.DayOfWeek);
						Assert.Equal(var2.Month, actual.Month);
						Assert.Equal(var2.IsTimeOnly, actual.IsTimeOnly);
						Assert.Equal(var2.StartTime, actual.StartTime);
						Assert.Equal(var2.EndTime, actual.EndTime);
						Assert.Equal(var2.HeatTemperatureC, actual.HeatTemperatureC);
						Assert.Equal(var2.CoolTemperatureC, actual.CoolTemperatureC);
						Assert.Equal(var2.DateCreated, actual.DateCreated);
						Assert.Equal(var2.DateModified, actual.DateModified);
						// Verify var3
						actual = controller.Get(var3.Id);
						Assert.NotNull(actual.Id);
						// var3 -> actual
						Assert.Equal(var3.Id, actual.Id);
						Assert.Equal(var3.DayOfWeek, actual.DayOfWeek);
						Assert.Equal(var3.Month, actual.Month);
						Assert.Equal(var3.IsTimeOnly, actual.IsTimeOnly);
						Assert.Equal(var3.StartTime, actual.StartTime);
						Assert.Equal(var3.EndTime, actual.EndTime);
						Assert.Equal(var3.HeatTemperatureC, actual.HeatTemperatureC);
						Assert.Equal(var3.CoolTemperatureC, actual.CoolTemperatureC);
						Assert.Equal(var3.DateCreated, actual.DateCreated);
						Assert.Equal(var3.DateModified, actual.DateModified);
					}
				}
			}
		}
	}
}