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
						var1.Id = 92;
						var1.DayOfWeek = 7;
						var1.Month = 76;
						var1.IsTimeOnly = true;
						var1.StartTime = DateTimeOffset.MinValue;
						var1.EndTime = DateTimeOffset.MinValue;
						var1.HeatTemperatureC = 0.54319769867844769;
						var1.CoolTemperatureC = 0.9665230875678934;
						var1.DateCreated = DateTimeOffset.MinValue;
						var1.DateModified = DateTimeOffset.MinValue;
						//var2
						var2.Id = 7;
						var2.DayOfWeek = 1;
						var2.Month = 30;
						var2.IsTimeOnly = false;
						var2.StartTime = DateTimeOffset.MinValue;
						var2.EndTime = DateTimeOffset.MinValue;
						var2.HeatTemperatureC = 0.52661180800134866;
						var2.CoolTemperatureC = 0.032094962909861913;
						var2.DateCreated = DateTimeOffset.MinValue;
						var2.DateModified = DateTimeOffset.MinValue;
						//var3
						var3.Id = 69;
						var3.DayOfWeek = 10;
						var3.Month = 5;
						var3.IsTimeOnly = true;
						var3.StartTime = DateTimeOffset.MinValue;
						var3.EndTime = DateTimeOffset.MinValue;
						var3.HeatTemperatureC = 0.63643362402749881;
						var3.CoolTemperatureC = 0.99906104057983547;
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
						var1.Id = 92;
						var1.DayOfWeek = 7;
						var1.Month = 76;
						var1.IsTimeOnly = true;
						var1.StartTime = DateTimeOffset.MinValue;
						var1.EndTime = DateTimeOffset.MinValue;
						var1.HeatTemperatureC = 0.54319769867844769;
						var1.CoolTemperatureC = 0.9665230875678934;
						var1.DateCreated = DateTimeOffset.MinValue;
						var1.DateModified = DateTimeOffset.MinValue;
						//var2
						var2.Id = 7;
						var2.DayOfWeek = 1;
						var2.Month = 30;
						var2.IsTimeOnly = false;
						var2.StartTime = DateTimeOffset.MinValue;
						var2.EndTime = DateTimeOffset.MinValue;
						var2.HeatTemperatureC = 0.52661180800134866;
						var2.CoolTemperatureC = 0.032094962909861913;
						var2.DateCreated = DateTimeOffset.MinValue;
						var2.DateModified = DateTimeOffset.MinValue;
						//var3
						var3.Id = 69;
						var3.DayOfWeek = 10;
						var3.Month = 5;
						var3.IsTimeOnly = true;
						var3.StartTime = DateTimeOffset.MinValue;
						var3.EndTime = DateTimeOffset.MinValue;
						var3.HeatTemperatureC = 0.63643362402749881;
						var3.CoolTemperatureC = 0.99906104057983547;
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

		[Fact]
		public void PostTest()
		{
			{
				var logFactory = new LoggerFactory();
				var logger = logFactory.CreateLogger<TemperatureSettingController>();
				using (var wrapper = new ContextWrapper(this))
				{
					var context = wrapper.Context;
					using (var controller = new TemperatureSettingController(context, logger))
					{
						var result = controller.Post(null);
						Assert.NotNull(result);
						Assert.False(result.Success);
						Assert.Equal(1, result.Errors.Count);
						Assert.Equal("data cannot be null", result.Errors[0]);
						Assert.Null(result.Data);
						var expected = new TemperatureSetting();
						// Success Test test
						expected = new TemperatureSetting();
						expected.Id = 92;
						expected.DayOfWeek = 7;
						expected.Month = 69;
						expected.IsTimeOnly = false;
						expected.StartTime = DateTimeOffset.MinValue;
						expected.EndTime = DateTimeOffset.MinValue;
						expected.HeatTemperatureC = 0.0041733910349073776;
						expected.CoolTemperatureC = 0.09501407579286679;
						expected.DateCreated = DateTimeOffset.MinValue;
						expected.DateModified = DateTimeOffset.MinValue;
						postPreCall(expected, wrapper);
						result = controller.Post(expected);
						Assert.NotNull(result);
						Assert.True(result.Success, "Success was not true");
						Assert.Equal(0, result.Errors.Count);
						Assert.NotNull(result.Data);
						Assert.True(result.Data.Id > 0, "Id not updated");
						var first = context.TemperatureSettings.FirstOrDefault((i) => i.Id == result.Data.Id);
						Assert.NotNull(first);
						var resultData = result.Data;
						Assert.Equal(first.Id, resultData.Id);
						Assert.Equal(first.DayOfWeek, resultData.DayOfWeek);
						Assert.Equal(first.Month, resultData.Month);
						Assert.Equal(first.IsTimeOnly, resultData.IsTimeOnly);
						Assert.Equal(first.StartTime, resultData.StartTime);
						Assert.Equal(first.EndTime, resultData.EndTime);
						Assert.Equal(first.HeatTemperatureC, resultData.HeatTemperatureC);
						Assert.Equal(first.CoolTemperatureC, resultData.CoolTemperatureC);
						Assert.Equal(first.DateCreated, resultData.DateCreated);
						Assert.Equal(first.DateModified, resultData.DateModified);
					}
				}
			}
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void postPreCall(TemperatureSetting data, ContextWrapper wrapper);
	}
}