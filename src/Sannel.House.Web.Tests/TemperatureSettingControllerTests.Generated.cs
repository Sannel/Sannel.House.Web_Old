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
					var1.Id = 39;
					var1.DayOfWeek = 82;
					var1.Month = 43;
					var1.IsTimeOnly = true;
					var1.StartTime = DateTimeOffset.MinValue;
					var1.EndTime = DateTimeOffset.MinValue;
					var1.HeatTemperatureC = 0.60184031566690666;
					var1.CoolTemperatureC = 0.070599200702551379;
					var1.DateCreated = DateTimeOffset.MinValue;
					var1.DateModified = DateTimeOffset.MinValue;
					// var2
					var2.Id = 58;
					var2.DayOfWeek = 91;
					var2.Month = 10;
					var2.IsTimeOnly = false;
					var2.StartTime = DateTimeOffset.MinValue;
					var2.EndTime = DateTimeOffset.MinValue;
					var2.HeatTemperatureC = 0.59789824839583516;
					var2.CoolTemperatureC = 0.16143120786241777;
					var2.DateCreated = DateTimeOffset.MinValue;
					var2.DateModified = DateTimeOffset.MinValue;
					// var3
					var3.Id = 78;
					var3.DayOfWeek = 2;
					var3.Month = 76;
					var3.IsTimeOnly = false;
					var3.StartTime = DateTimeOffset.MinValue;
					var3.EndTime = DateTimeOffset.MinValue;
					var3.HeatTemperatureC = 0.59395618112476367;
					var3.CoolTemperatureC = 0.25226321502228416;
					var3.DateCreated = DateTimeOffset.MinValue;
					var3.DateModified = DateTimeOffset.MinValue;
					// var4
					var4.Id = 50;
					var4.DayOfWeek = 41;
					var4.Month = 13;
					var4.IsTimeOnly = true;
					var4.StartTime = DateTimeOffset.MinValue;
					var4.EndTime = DateTimeOffset.MinValue;
					var4.HeatTemperatureC = 0.041499853619141436;
					var4.CoolTemperatureC = 0.21699302886472691;
					var4.DateCreated = DateTimeOffset.MinValue;
					var4.DateModified = DateTimeOffset.MinValue;
					// var5
					var5.Id = 69;
					var5.DayOfWeek = 50;
					var5.Month = 80;
					var5.IsTimeOnly = true;
					var5.StartTime = DateTimeOffset.MinValue;
					var5.EndTime = DateTimeOffset.MinValue;
					var5.HeatTemperatureC = 0.037557786348069916;
					var5.CoolTemperatureC = 0.30782503602459332;
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
						var1.Id = 69;
						var1.DayOfWeek = 49;
						var1.Month = 64;
						var1.IsTimeOnly = true;
						var1.StartTime = DateTimeOffset.MinValue;
						var1.EndTime = DateTimeOffset.MinValue;
						var1.HeatTemperatureC = 0.1246089609920089;
						var1.CoolTemperatureC = 0.640784452967711;
						var1.DateCreated = DateTimeOffset.MinValue;
						var1.DateModified = DateTimeOffset.MinValue;
						//var2
						var2.Id = 50;
						var2.DayOfWeek = 4;
						var2.Month = 68;
						var2.IsTimeOnly = true;
						var2.StartTime = DateTimeOffset.MinValue;
						var2.EndTime = DateTimeOffset.MinValue;
						var2.HeatTemperatureC = 0.7329402587995586;
						var2.CoolTemperatureC = 0.686366495995953;
						var2.DateCreated = DateTimeOffset.MinValue;
						var2.DateModified = DateTimeOffset.MinValue;
						//var3
						var3.Id = 80;
						var3.DayOfWeek = 31;
						var3.Month = 33;
						var3.IsTimeOnly = false;
						var3.StartTime = DateTimeOffset.MinValue;
						var3.EndTime = DateTimeOffset.MinValue;
						var3.HeatTemperatureC = 0.11726078675932287;
						var3.CoolTemperatureC = 0.59167817169412884;
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
					expected.Id = 88;
					expected.DayOfWeek = 60;
					expected.Month = 47;
					expected.IsTimeOnly = false;
					expected.StartTime = DateTimeOffset.MinValue;
					expected.EndTime = DateTimeOffset.MinValue;
					expected.HeatTemperatureC = 0.0336157190769984;
					expected.CoolTemperatureC = 0.39865704318445971;
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
					expected.Id = 9;
					expected.DayOfWeek = 69;
					expected.Month = 14;
					expected.IsTimeOnly = true;
					expected.StartTime = DateTimeOffset.MinValue;
					expected.EndTime = DateTimeOffset.MinValue;
					expected.HeatTemperatureC = 0.029673651805926883;
					expected.CoolTemperatureC = 0.4894890503443261;
					expected.DateCreated = DateTimeOffset.MinValue;
					expected.DateModified = DateTimeOffset.MinValue;
					putPreCall(expected, wrapper);
					context.TemperatureSettings.Add(expected);
					context.SaveChanges();
					// Reset props and call put
					expected.DayOfWeek = 80;
					expected.Month = 9;
					expected.IsTimeOnly = true;
					expected.StartTime = DateTimeOffset.MinValue;
					expected.EndTime = DateTimeOffset.MinValue;
					expected.HeatTemperatureC = 0.55239001081902073;
					expected.CoolTemperatureC = 0.47721732430030467;
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