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
					var1.Id = 88;
					var1.DayOfWeek = 57;
					var1.Month = 5;
					var1.IsTimeOnly = true;
					var1.StartTime = DateTime.MinValue;
					var1.EndTime = DateTime.MinValue;
					var1.HeatTemperatureC = 0.29968662527375234;
					var1.CoolTemperatureC = 0.70819396139504109;
					var1.DateCreated = DateTime.MinValue;
					var1.DateModified = DateTime.MinValue;
					// var2
					var2.Id = 8;
					var2.DayOfWeek = 67;
					var2.Month = 71;
					var2.IsTimeOnly = false;
					var2.StartTime = DateTime.MinValue;
					var2.EndTime = DateTime.MinValue;
					var2.HeatTemperatureC = 0.29574455800268079;
					var2.CoolTemperatureC = 0.79902596855490748;
					var2.DateCreated = DateTime.MinValue;
					var2.DateModified = DateTime.MinValue;
					// var3
					var3.Id = 27;
					var3.DayOfWeek = 76;
					var3.Month = 38;
					var3.IsTimeOnly = true;
					var3.StartTime = DateTime.MinValue;
					var3.EndTime = DateTime.MinValue;
					var3.HeatTemperatureC = 0.2918024907316093;
					var3.CoolTemperatureC = 0.88985797571477387;
					var3.DateCreated = DateTime.MinValue;
					var3.DateModified = DateTime.MinValue;
					// var4
					var4.Id = 46;
					var4.DayOfWeek = 86;
					var4.Month = 6;
					var4.IsTimeOnly = false;
					var4.StartTime = DateTime.MinValue;
					var4.EndTime = DateTime.MinValue;
					var4.HeatTemperatureC = 0.28786042346053775;
					var4.CoolTemperatureC = 0.98068998287464026;
					var4.DateCreated = DateTime.MinValue;
					var4.DateModified = DateTime.MinValue;
					// var5
					var5.Id = 19;
					var5.DayOfWeek = 25;
					var5.Month = 42;
					var5.IsTimeOnly = false;
					var5.StartTime = DateTime.MinValue;
					var5.EndTime = DateTime.MinValue;
					var5.HeatTemperatureC = 0.73540409595491552;
					var5.CoolTemperatureC = 0.945419796717083;
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
					var1.Id = 19;
					var1.DayOfWeek = 19;
					var1.Month = 75;
					var1.IsTimeOnly = true;
					var1.StartTime = DateTime.MinValue;
					var1.EndTime = DateTime.MinValue;
					var1.HeatTemperatureC = 0.45259206949388237;
					var1.CoolTemperatureC = 0.090002850205638849;
					var1.DateCreated = DateTime.MinValue;
					var1.DateModified = DateTime.MinValue;
					//var2
					var2.Id = 25;
					var2.DayOfWeek = 73;
					var2.Month = 53;
					var2.IsTimeOnly = true;
					var2.StartTime = DateTime.MinValue;
					var2.EndTime = DateTime.MinValue;
					var2.HeatTemperatureC = 0.049652504757816206;
					var2.CoolTemperatureC = 0.45677678680828621;
					var2.DateCreated = DateTime.MinValue;
					var2.DateModified = DateTime.MinValue;
					//var3
					var3.Id = 42;
					var3.DayOfWeek = 94;
					var3.Month = 67;
					var3.IsTimeOnly = false;
					var3.StartTime = DateTime.MinValue;
					var3.EndTime = DateTime.MinValue;
					var3.HeatTemperatureC = 0.084669785613506007;
					var3.CoolTemperatureC = 0.49748988379607439;
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
					expected.Id = 38;
					expected.DayOfWeek = 35;
					expected.Month = 9;
					expected.IsTimeOnly = true;
					expected.StartTime = DateTime.MinValue;
					expected.EndTime = DateTime.MinValue;
					expected.HeatTemperatureC = 0.731462028683844;
					expected.CoolTemperatureC = 0.03625180387694938;
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
					expected.Id = 57;
					expected.DayOfWeek = 44;
					expected.Month = 75;
					expected.IsTimeOnly = false;
					expected.StartTime = DateTime.MinValue;
					expected.EndTime = DateTime.MinValue;
					expected.HeatTemperatureC = 0.72751996141277253;
					expected.CoolTemperatureC = 0.12708381103681579;
					expected.DateCreated = DateTime.MinValue;
					expected.DateModified = DateTime.MinValue;
					putPreCall(expected, wrapper);
					context.TemperatureSettings.Add(expected);
					context.SaveChanges();
					// Reset props and call put
					expected.DayOfWeek = 76;
					expected.Month = 54;
					expected.IsTimeOnly = false;
					expected.StartTime = DateTime.MinValue;
					expected.EndTime = DateTime.MinValue;
					expected.HeatTemperatureC = 0.0361685357224981;
					expected.CoolTemperatureC = 0.723577894141701;
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