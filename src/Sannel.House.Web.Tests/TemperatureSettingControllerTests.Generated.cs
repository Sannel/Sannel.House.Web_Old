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
					var1.Id = 51;
					var1.DayOfWeek = 67;
					var1.Month = 88;
					var1.IsTimeOnly = false;
					var1.StartTime = DateTimeOffset.MinValue;
					var1.EndTime = DateTimeOffset.MinValue;
					var1.HeatTemperatureC = 0.23320340655427585;
					var1.CoolTemperatureC = 0.87897288700517862;
					var1.DateCreated = DateTimeOffset.MinValue;
					var1.DateModified = DateTimeOffset.MinValue;
					// var2
					var2.Id = 70;
					var2.DayOfWeek = 76;
					var2.Month = 55;
					var2.IsTimeOnly = false;
					var2.StartTime = DateTimeOffset.MinValue;
					var2.EndTime = DateTimeOffset.MinValue;
					var2.HeatTemperatureC = 0.22926133928320433;
					var2.CoolTemperatureC = 0.96980489416504512;
					var2.DateCreated = DateTimeOffset.MinValue;
					var2.DateModified = DateTimeOffset.MinValue;
					// var3
					var3.Id = 43;
					var3.DayOfWeek = 16;
					var3.Month = 92;
					var3.IsTimeOnly = true;
					var3.StartTime = DateTimeOffset.MinValue;
					var3.EndTime = DateTimeOffset.MinValue;
					var3.HeatTemperatureC = 0.67680501177758212;
					var3.CoolTemperatureC = 0.93453470800748784;
					var3.DateCreated = DateTimeOffset.MinValue;
					var3.DateModified = DateTimeOffset.MinValue;
					// var4
					var4.Id = 62;
					var4.DayOfWeek = 25;
					var4.Month = 59;
					var4.IsTimeOnly = true;
					var4.StartTime = DateTimeOffset.MinValue;
					var4.EndTime = DateTimeOffset.MinValue;
					var4.HeatTemperatureC = 0.67286294450651063;
					var4.CoolTemperatureC = 0.025366715167354194;
					var4.DateCreated = DateTimeOffset.MinValue;
					var4.DateModified = DateTimeOffset.MinValue;
					// var5
					var5.Id = 81;
					var5.DayOfWeek = 35;
					var5.Month = 26;
					var5.IsTimeOnly = false;
					var5.StartTime = DateTimeOffset.MinValue;
					var5.EndTime = DateTimeOffset.MinValue;
					var5.HeatTemperatureC = 0.66892087723543914;
					var5.CoolTemperatureC = 0.11619872232722059;
					var5.DateCreated = DateTimeOffset.MinValue;
					var5.DateModified = DateTimeOffset.MinValue;
					var order = DateTimeOffset.Now;
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
					var1.Id = 81;
					var1.DayOfWeek = 12;
					var1.Month = 45;
					var1.IsTimeOnly = true;
					var1.StartTime = DateTimeOffset.MinValue;
					var1.EndTime = DateTimeOffset.MinValue;
					var1.HeatTemperatureC = 0.3709666763297127;
					var1.CoolTemperatureC = 0.77532177827103144;
					var1.DateCreated = DateTimeOffset.MinValue;
					var1.DateModified = DateTimeOffset.MinValue;
					//var2
					var2.Id = 35;
					var2.DayOfWeek = 67;
					var2.Month = 6;
					var2.IsTimeOnly = false;
					var2.StartTime = DateTimeOffset.MinValue;
					var2.EndTime = DateTimeOffset.MinValue;
					var2.HeatTemperatureC = 0.70862184404797;
					var2.CoolTemperatureC = 0.27694722650430503;
					var2.DateCreated = DateTimeOffset.MinValue;
					var2.DateModified = DateTimeOffset.MinValue;
					//var3
					var3.Id = 26;
					var3.DayOfWeek = 12;
					var3.Month = 26;
					var3.IsTimeOnly = false;
					var3.StartTime = DateTimeOffset.MinValue;
					var3.EndTime = DateTimeOffset.MinValue;
					var3.HeatTemperatureC = 0.18321269107200797;
					var3.CoolTemperatureC = 0.24009345483039202;
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
					expected.Id = 1;
					expected.DayOfWeek = 44;
					expected.Month = 92;
					expected.IsTimeOnly = true;
					expected.StartTime = DateTimeOffset.MinValue;
					expected.EndTime = DateTimeOffset.MinValue;
					expected.HeatTemperatureC = 0.66497880996436753;
					expected.CoolTemperatureC = 0.20703072948708698;
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
					expected.Id = 73;
					expected.DayOfWeek = 83;
					expected.Month = 30;
					expected.IsTimeOnly = true;
					expected.StartTime = DateTimeOffset.MinValue;
					expected.EndTime = DateTimeOffset.MinValue;
					expected.HeatTemperatureC = 0.11252248245874535;
					expected.CoolTemperatureC = 0.17176054332952972;
					expected.DateCreated = DateTimeOffset.MinValue;
					expected.DateModified = DateTimeOffset.MinValue;
					putPreCall(expected, wrapper);
					context.TemperatureSettings.Add(expected);
					context.SaveChanges();
					// Reset props and call put
					expected.DayOfWeek = 92;
					expected.Month = 92;
					expected.IsTimeOnly = true;
					expected.StartTime = DateTimeOffset.MinValue;
					expected.EndTime = DateTimeOffset.MinValue;
					expected.HeatTemperatureC = 0.18157261199391103;
					expected.CoolTemperatureC = 0.10858041518767383;
					expected.DateCreated = DateTimeOffset.MinValue;
					expected.DateModified = DateTimeOffset.MinValue;
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