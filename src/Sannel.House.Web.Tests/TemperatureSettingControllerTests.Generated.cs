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
	public partial class TemperatureSettingControllerTests : IContextWrapperTest
	{
		[Fact]
		public void GetPagedTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<TemperatureSettingController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new TemperatureSettingController(context, logger))
				// Fix order
				{
					var var1 = new TemperatureSetting();
					var var2 = new TemperatureSetting();
					var var3 = new TemperatureSetting();
					var var4 = new TemperatureSetting();
					var var5 = new TemperatureSetting();
					// var1
					var1.Id = 34;
					var1.DayOfWeek = 61;
					var1.Month = 8;
					var1.IsTimeOnly = true;
					var1.StartTime = DateTime.MinValue;
					var1.EndTime = DateTime.MinValue;
					var1.HeatTemperatureC = 0.76308434073025566;
					var1.CoolTemperatureC = 0.42876661030052537;
					var1.DateCreated = DateTime.MinValue;
					var1.DateModified = DateTime.MinValue;
					// var2
					var2.Id = 43;
					var2.DayOfWeek = 77;
					var2.Month = 65;
					var2.IsTimeOnly = true;
					var2.StartTime = DateTime.MinValue;
					var2.EndTime = DateTime.MinValue;
					var2.HeatTemperatureC = 0.59356492832003394;
					var2.CoolTemperatureC = 0.2371304110796798;
					var2.DateCreated = DateTime.MinValue;
					var2.DateModified = DateTime.MinValue;
					// var3
					var3.Id = 90;
					var3.DayOfWeek = 47;
					var3.Month = 10;
					var3.IsTimeOnly = true;
					var3.StartTime = DateTime.MinValue;
					var3.EndTime = DateTime.MinValue;
					var3.HeatTemperatureC = 0.0092012165157130069;
					var3.CoolTemperatureC = 0.32668560292883103;
					var3.DateCreated = DateTime.MinValue;
					var3.DateModified = DateTime.MinValue;
					// var4
					var4.Id = 96;
					var4.DayOfWeek = 79;
					var4.Month = 72;
					var4.IsTimeOnly = false;
					var4.StartTime = DateTime.MinValue;
					var4.EndTime = DateTime.MinValue;
					var4.HeatTemperatureC = 0.9233269085750575;
					var4.CoolTemperatureC = 0.51299288659961562;
					var4.DateCreated = DateTime.MinValue;
					var4.DateModified = DateTime.MinValue;
					// var5
					var5.Id = 30;
					var5.DayOfWeek = 59;
					var5.Month = 79;
					var5.IsTimeOnly = true;
					var5.StartTime = DateTime.MinValue;
					var5.EndTime = DateTime.MinValue;
					var5.HeatTemperatureC = 0.93812142682174282;
					var5.CoolTemperatureC = 0.18464970317885732;
					var5.DateCreated = DateTime.MinValue;
					var5.DateModified = DateTime.MinValue;
					var order = DateTime.Now;
					var1.DateCreated = order;
					var2.DateCreated = order.AddDays(-1);
					var3.DateCreated = order.AddDays(-2);
					var4.DateCreated = order.AddDays(-3);
					var5.DateCreated = order.AddDays(-4);
					// Add to database
					context.TemperatureSettings.Add(var1);
					context.TemperatureSettings.Add(var2);
					context.TemperatureSettings.Add(var3);
					context.TemperatureSettings.Add(var4);
					context.TemperatureSettings.Add(var5);
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
					Assert.Equal(var1.DayOfWeek, actual.DayOfWeek);
					Assert.Equal(var1.Month, actual.Month);
					Assert.Equal(var1.IsTimeOnly, actual.IsTimeOnly);
					Assert.Equal(var1.StartTime, actual.StartTime);
					Assert.Equal(var1.EndTime, actual.EndTime);
					Assert.Equal(var1.HeatTemperatureC, actual.HeatTemperatureC);
					Assert.Equal(var1.CoolTemperatureC, actual.CoolTemperatureC);
					Assert.Equal(var1.DateCreated, actual.DateCreated);
					Assert.Equal(var1.DateModified, actual.DateModified);
					// var2
					actual = list[1];
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
					Assert.Equal(var3.DayOfWeek, actual.DayOfWeek);
					Assert.Equal(var3.Month, actual.Month);
					Assert.Equal(var3.IsTimeOnly, actual.IsTimeOnly);
					Assert.Equal(var3.StartTime, actual.StartTime);
					Assert.Equal(var3.EndTime, actual.EndTime);
					Assert.Equal(var3.HeatTemperatureC, actual.HeatTemperatureC);
					Assert.Equal(var3.CoolTemperatureC, actual.CoolTemperatureC);
					Assert.Equal(var3.DateCreated, actual.DateCreated);
					Assert.Equal(var3.DateModified, actual.DateModified);
					// var4
					actual = list[1];
					// var4 -> actual
					Assert.Equal(var4.Id, actual.Id);
					Assert.Equal(var4.DayOfWeek, actual.DayOfWeek);
					Assert.Equal(var4.Month, actual.Month);
					Assert.Equal(var4.IsTimeOnly, actual.IsTimeOnly);
					Assert.Equal(var4.StartTime, actual.StartTime);
					Assert.Equal(var4.EndTime, actual.EndTime);
					Assert.Equal(var4.HeatTemperatureC, actual.HeatTemperatureC);
					Assert.Equal(var4.CoolTemperatureC, actual.CoolTemperatureC);
					Assert.Equal(var4.DateCreated, actual.DateCreated);
					Assert.Equal(var4.DateModified, actual.DateModified);
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
					Assert.Equal(var5.DayOfWeek, actual.DayOfWeek);
					Assert.Equal(var5.Month, actual.Month);
					Assert.Equal(var5.IsTimeOnly, actual.IsTimeOnly);
					Assert.Equal(var5.StartTime, actual.StartTime);
					Assert.Equal(var5.EndTime, actual.EndTime);
					Assert.Equal(var5.HeatTemperatureC, actual.HeatTemperatureC);
					Assert.Equal(var5.CoolTemperatureC, actual.CoolTemperatureC);
					Assert.Equal(var5.DateCreated, actual.DateCreated);
					Assert.Equal(var5.DateModified, actual.DateModified);
				}
			}
		}

		[Fact]
		public void GetWithIdTest()
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
					var1.Id = 60;
					var1.DayOfWeek = 35;
					var1.Month = 18;
					var1.IsTimeOnly = true;
					var1.StartTime = DateTime.MinValue;
					var1.EndTime = DateTime.MinValue;
					var1.HeatTemperatureC = 0.84322124852017555;
					var1.CoolTemperatureC = 0.44218185797435317;
					var1.DateCreated = DateTime.MinValue;
					var1.DateModified = DateTime.MinValue;
					//var2
					var2.Id = 1;
					var2.DayOfWeek = 89;
					var2.Month = 71;
					var2.IsTimeOnly = true;
					var2.StartTime = DateTime.MinValue;
					var2.EndTime = DateTime.MinValue;
					var2.HeatTemperatureC = 0.053203741113284485;
					var2.CoolTemperatureC = 0.87306394561802225;
					var2.DateCreated = DateTime.MinValue;
					var2.DateModified = DateTime.MinValue;
					//var3
					var3.Id = 99;
					var3.DayOfWeek = 13;
					var3.Month = 11;
					var3.IsTimeOnly = true;
					var3.StartTime = DateTime.MinValue;
					var3.EndTime = DateTime.MinValue;
					var3.HeatTemperatureC = 0.22774305205221429;
					var3.CoolTemperatureC = 0.27752627864364826;
					var3.DateCreated = DateTime.MinValue;
					var3.DateModified = DateTime.MinValue;
					//Fix Order
					var order = DateTime.Now;
					var3.DateCreated = order;
					var2.DateCreated = order.AddDays(-1);
					var1.DateCreated = order.AddDays(-2);
					// Add and save entities
					context.TemperatureSettings.Add(var1);
					context.TemperatureSettings.Add(var2);
					context.TemperatureSettings.Add(var3);
					wrapper.SaveChanges();
					// verify
					var results = controller.Get(var1.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					var actual = results.Data;
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
					// verify var2
					results = controller.Get(var2.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
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
					// verify var3
					results = controller.Get(var3.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
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
					// Failed Test
					results = controller.Get(0);
					Assert.NotNull(results);
					Assert.False(results.Success);
					Assert.Equal(1, results.Errors.Count);
					Assert.Equal($"Could not find TemperatureSetting with Id {0}", results.Errors[0]);
				}
			}
		}

		[Fact]
		public void PostTest()
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
					// Success Test
					expected = new TemperatureSetting();
					expected.Id = 36;
					expected.DayOfWeek = 19;
					expected.Month = 48;
					expected.IsTimeOnly = false;
					expected.StartTime = DateTime.MinValue;
					expected.EndTime = DateTime.MinValue;
					expected.HeatTemperatureC = 0.98283934313004806;
					expected.CoolTemperatureC = 0.89687511925440055;
					expected.DateCreated = DateTime.MinValue;
					expected.DateModified = DateTime.MinValue;
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

		// used to make sure reference tables have data needed for a test to succeed
		partial void postPreCall(TemperatureSetting data, ContextWrapper wrapper);
		[Fact]
		public void PutTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<TemperatureSettingController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new TemperatureSettingController(context, logger))
				{
					var result = controller.Put(null);
					Assert.NotNull(result);
					Assert.False(result.Success);
					Assert.Equal(1, result.Errors.Count);
					Assert.Equal("data cannot be null", result.Errors[0]);
					Assert.Null(result.Data);
					var expected = new TemperatureSetting();
					// Success Test
					expected = new TemperatureSetting();
					expected.Id = 20;
					expected.DayOfWeek = 22;
					expected.Month = 60;
					expected.IsTimeOnly = true;
					expected.StartTime = DateTime.MinValue;
					expected.EndTime = DateTime.MinValue;
					expected.HeatTemperatureC = 0.87468572374185816;
					expected.CoolTemperatureC = 0.69003880894279057;
					expected.DateCreated = DateTime.MinValue;
					expected.DateModified = DateTime.MinValue;
					putPreCall(expected, wrapper);
					context.TemperatureSettings.Add(expected);
					context.SaveChanges();
					// Reset props and call put
					expected.DayOfWeek = 12;
					expected.Month = 22;
					expected.IsTimeOnly = false;
					expected.StartTime = DateTime.MinValue;
					expected.EndTime = DateTime.MinValue;
					expected.HeatTemperatureC = 0.15195280460266061;
					expected.CoolTemperatureC = 0.45162792524864337;
					expected.DateCreated = DateTime.MinValue;
					expected.DateModified = DateTime.MinValue;
					putPreCall(expected, wrapper);
					result = controller.Put(expected);
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

		// used to make sure reference tables have data needed for a test to succeed
		partial void putPreCall(TemperatureSetting data, ContextWrapper wrapper);
	}
}