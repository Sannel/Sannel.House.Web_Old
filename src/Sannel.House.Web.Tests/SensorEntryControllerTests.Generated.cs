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
	public partial class SensorEntryControllerTests : IContextWrapperTest
	{
		[Fact]
		public void GetPagedTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<SensorEntryController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new SensorEntryController(context, logger))
				// Fix order
				{
					var var1 = new SensorEntry();
					var var2 = new SensorEntry();
					var var3 = new SensorEntry();
					var var4 = new SensorEntry();
					var var5 = new SensorEntry();
					// var1
					var1.Id = Guid.NewGuid();
					var1.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var1.DeviceId = 38;
					var1.Value = 0.20863174563675735;
					var1.Value2 = 0.843805808966889;
					var1.Value3 = 0.038614440727333742;
					var1.Value4 = 0.74792930984307515;
					var1.Value5 = 0.66084721808361224;
					var1.Value6 = 0.21184027297973645;
					var1.Value7 = 0.89911828930448656;
					var1.Value8 = 0.17987423631356761;
					var1.Value9 = 0.96637155626265869;
					var1.DateCreated = DateTime.MinValue;
					// var2
					var2.Id = Guid.NewGuid();
					var2.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var2.DeviceId = 47;
					var2.Value = 0.87725945044181286;
					var2.Value2 = 0.46053665711569441;
					var2.Value3 = 0.034672373456262229;
					var2.Value4 = 0.83876131700294154;
					var2.Value5 = 0.55060484332526327;
					var2.Value6 = 0.76405676024223523;
					var2.Value7 = 0.73433600214046235;
					var2.Value8 = 0.61115826322285383;
					var2.Value9 = 0.80501792244846837;
					var2.DateCreated = DateTime.MinValue;
					// var3
					var3.Id = Guid.NewGuid();
					var3.SensorType = Sannel.House.Sensor.SensorTypes.Temperature;
					var3.DeviceId = 57;
					var3.Value = 0.54588715524686837;
					var3.Value2 = 0.077267505264499922;
					var3.Value3 = 0.030730306185190709;
					var3.Value4 = 0.92959332416280793;
					var3.Value5 = 0.4403624685669143;
					var3.Value6 = 0.31627324750473407;
					var3.Value7 = 0.56955371497643814;
					var3.Value8 = 0.042442290132139945;
					var3.Value9 = 0.643664288634278;
					var3.DateCreated = DateTime.MinValue;
					// var4
					var4.Id = Guid.NewGuid();
					var4.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var4.DeviceId = 95;
					var4.Value = 0.913502853323474;
					var4.Value2 = 0.90744128399875079;
					var4.Value3 = 0.4782739786795685;
					var4.Value4 = 0.89432313800525065;
					var4.Value5 = 0.77817679139700568;
					var4.Value6 = 0.37017413758215223;
					var4.Value7 = 0.52848812822647773;
					var4.Value8 = 0.84247741375233853;
					var4.Value9 = 0.2190411827615654;
					var4.DateCreated = DateTime.MinValue;
					// var5
					var5.Id = Guid.NewGuid();
					var5.SensorType = Sannel.House.Sensor.SensorTypes.Temperature;
					var5.DeviceId = 6;
					var5.Value = 0.58213055533456182;
					var5.Value2 = 0.5241721321475562;
					var5.Value3 = 0.47433191140849695;
					var5.Value4 = 0.985155145165117;
					var5.Value5 = 0.66793441663865671;
					var5.Value6 = 0.92239062484465106;
					var5.Value7 = 0.36370584106245352;
					var5.Value8 = 0.2737614415929473;
					var5.Value9 = 0.057687548947375059;
					var5.DateCreated = DateTime.MinValue;
					var order = DateTime.Now;
					var1.DateCreated = order;
					var2.DateCreated = order.AddDays(-1);
					var3.DateCreated = order.AddDays(-2);
					var4.DateCreated = order.AddDays(-3);
					var5.DateCreated = order.AddDays(-4);
					// Add to database
					context.SensorEntries.Add(var1);
					context.SensorEntries.Add(var2);
					context.SensorEntries.Add(var3);
					context.SensorEntries.Add(var4);
					context.SensorEntries.Add(var5);
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
					Assert.Equal(var1.SensorType, actual.SensorType);
					Assert.Equal(var1.DeviceId, actual.DeviceId);
					Assert.Equal(var1.Value, actual.Value);
					Assert.Equal(var1.Value2, actual.Value2);
					Assert.Equal(var1.Value3, actual.Value3);
					Assert.Equal(var1.Value4, actual.Value4);
					Assert.Equal(var1.Value5, actual.Value5);
					Assert.Equal(var1.Value6, actual.Value6);
					Assert.Equal(var1.Value7, actual.Value7);
					Assert.Equal(var1.Value8, actual.Value8);
					Assert.Equal(var1.Value9, actual.Value9);
					Assert.Equal(var1.DateCreated, actual.DateCreated);
					// var2
					actual = list[1];
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.SensorType, actual.SensorType);
					Assert.Equal(var2.DeviceId, actual.DeviceId);
					Assert.Equal(var2.Value, actual.Value);
					Assert.Equal(var2.Value2, actual.Value2);
					Assert.Equal(var2.Value3, actual.Value3);
					Assert.Equal(var2.Value4, actual.Value4);
					Assert.Equal(var2.Value5, actual.Value5);
					Assert.Equal(var2.Value6, actual.Value6);
					Assert.Equal(var2.Value7, actual.Value7);
					Assert.Equal(var2.Value8, actual.Value8);
					Assert.Equal(var2.Value9, actual.Value9);
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
					Assert.Equal(var3.SensorType, actual.SensorType);
					Assert.Equal(var3.DeviceId, actual.DeviceId);
					Assert.Equal(var3.Value, actual.Value);
					Assert.Equal(var3.Value2, actual.Value2);
					Assert.Equal(var3.Value3, actual.Value3);
					Assert.Equal(var3.Value4, actual.Value4);
					Assert.Equal(var3.Value5, actual.Value5);
					Assert.Equal(var3.Value6, actual.Value6);
					Assert.Equal(var3.Value7, actual.Value7);
					Assert.Equal(var3.Value8, actual.Value8);
					Assert.Equal(var3.Value9, actual.Value9);
					Assert.Equal(var3.DateCreated, actual.DateCreated);
					// var4
					actual = list[1];
					// var4 -> actual
					Assert.Equal(var4.Id, actual.Id);
					Assert.Equal(var4.SensorType, actual.SensorType);
					Assert.Equal(var4.DeviceId, actual.DeviceId);
					Assert.Equal(var4.Value, actual.Value);
					Assert.Equal(var4.Value2, actual.Value2);
					Assert.Equal(var4.Value3, actual.Value3);
					Assert.Equal(var4.Value4, actual.Value4);
					Assert.Equal(var4.Value5, actual.Value5);
					Assert.Equal(var4.Value6, actual.Value6);
					Assert.Equal(var4.Value7, actual.Value7);
					Assert.Equal(var4.Value8, actual.Value8);
					Assert.Equal(var4.Value9, actual.Value9);
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
					Assert.Equal(var5.SensorType, actual.SensorType);
					Assert.Equal(var5.DeviceId, actual.DeviceId);
					Assert.Equal(var5.Value, actual.Value);
					Assert.Equal(var5.Value2, actual.Value2);
					Assert.Equal(var5.Value3, actual.Value3);
					Assert.Equal(var5.Value4, actual.Value4);
					Assert.Equal(var5.Value5, actual.Value5);
					Assert.Equal(var5.Value6, actual.Value6);
					Assert.Equal(var5.Value7, actual.Value7);
					Assert.Equal(var5.Value8, actual.Value8);
					Assert.Equal(var5.Value9, actual.Value9);
					Assert.Equal(var5.DateCreated, actual.DateCreated);
				}
			}
		}

		[Fact]
		public void GetWithIdTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<SensorEntryController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new SensorEntryController(context, logger))
				{
					var var1 = new SensorEntry();
					var var2 = new SensorEntry();
					var var3 = new SensorEntry();
					//var1
					var1.Id = Guid.NewGuid();
					var1.SensorType = Sannel.House.Sensor.SensorTypes.Temperature;
					var1.DeviceId = 52;
					var1.Value = 0.66793441663865671;
					var1.Value2 = 0.2737614415929473;
					var1.Value3 = 0.489104320522912;
					var1.Value4 = 0.710598782035801;
					var1.Value5 = 0.71981219468629554;
					var1.Value6 = 0.570496284668565;
					var1.Value7 = 0.30992118842430466;
					var1.Value8 = 0.90642737639435911;
					var1.Value9 = 0.58927009282134013;
					var1.DateCreated = DateTime.MinValue;
					//var2
					var2.Id = Guid.NewGuid();
					var2.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var2.DeviceId = 47;
					var2.Value = 0.92239062484465106;
					var2.Value2 = 0.057687548947375059;
					var2.Value3 = 0.3052004814637827;
					var2.Value4 = 0.66744303268727057;
					var2.Value5 = 0.39368227794472233;
					var2.Value6 = 0.18900829143310352;
					var2.Value7 = 0.61164241685142851;
					var2.Value8 = 0.054800064794160455;
					var2.Value9 = 0.3647838366985246;
					var2.DateCreated = DateTime.MinValue;
					//var3
					var3.Id = Guid.NewGuid();
					var3.SensorType = Sannel.House.Sensor.SensorTypes.Temperature;
					var3.DeviceId = 98;
					var3.Value = 0.36370584106245352;
					var3.Value2 = 0.70008360394280567;
					var3.Value3 = 0.76973048447153092;
					var3.Value4 = 0.7171325496012031;
					var3.Value5 = 0.22612596034357602;
					var3.Value6 = 0.80861607510997735;
					var3.Value7 = 0.44858009994429543;
					var3.Value8 = 0.37715423357540473;
					var3.Value9 = 0.76964345749916674;
					var3.DateCreated = DateTime.MinValue;
					//Fix Order
					var order = DateTime.Now;
					var3.DateCreated = order;
					var2.DateCreated = order.AddDays(-1);
					var1.DateCreated = order.AddDays(-2);
					// Add and save entities
					context.SensorEntries.Add(var1);
					context.SensorEntries.Add(var2);
					context.SensorEntries.Add(var3);
					wrapper.SaveChanges();
					// verify
					var results = controller.Get(var1.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					var actual = results.Data;
					// var1 -> actual
					Assert.Equal(var1.Id, actual.Id);
					Assert.Equal(var1.SensorType, actual.SensorType);
					Assert.Equal(var1.DeviceId, actual.DeviceId);
					Assert.Equal(var1.Value, actual.Value);
					Assert.Equal(var1.Value2, actual.Value2);
					Assert.Equal(var1.Value3, actual.Value3);
					Assert.Equal(var1.Value4, actual.Value4);
					Assert.Equal(var1.Value5, actual.Value5);
					Assert.Equal(var1.Value6, actual.Value6);
					Assert.Equal(var1.Value7, actual.Value7);
					Assert.Equal(var1.Value8, actual.Value8);
					Assert.Equal(var1.Value9, actual.Value9);
					Assert.Equal(var1.DateCreated, actual.DateCreated);
					// verify var2
					results = controller.Get(var2.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.SensorType, actual.SensorType);
					Assert.Equal(var2.DeviceId, actual.DeviceId);
					Assert.Equal(var2.Value, actual.Value);
					Assert.Equal(var2.Value2, actual.Value2);
					Assert.Equal(var2.Value3, actual.Value3);
					Assert.Equal(var2.Value4, actual.Value4);
					Assert.Equal(var2.Value5, actual.Value5);
					Assert.Equal(var2.Value6, actual.Value6);
					Assert.Equal(var2.Value7, actual.Value7);
					Assert.Equal(var2.Value8, actual.Value8);
					Assert.Equal(var2.Value9, actual.Value9);
					Assert.Equal(var2.DateCreated, actual.DateCreated);
					// verify var3
					results = controller.Get(var3.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var3 -> actual
					Assert.Equal(var3.Id, actual.Id);
					Assert.Equal(var3.SensorType, actual.SensorType);
					Assert.Equal(var3.DeviceId, actual.DeviceId);
					Assert.Equal(var3.Value, actual.Value);
					Assert.Equal(var3.Value2, actual.Value2);
					Assert.Equal(var3.Value3, actual.Value3);
					Assert.Equal(var3.Value4, actual.Value4);
					Assert.Equal(var3.Value5, actual.Value5);
					Assert.Equal(var3.Value6, actual.Value6);
					Assert.Equal(var3.Value7, actual.Value7);
					Assert.Equal(var3.Value8, actual.Value8);
					Assert.Equal(var3.Value9, actual.Value9);
					Assert.Equal(var3.DateCreated, actual.DateCreated);
					// Failed Test
					results = controller.Get(Guid.Empty);
					Assert.NotNull(results);
					Assert.False(results.Success);
					Assert.Equal(1, results.Errors.Count);
					Assert.Equal($"Could not find SensorEntry with Id {Guid.Empty}", results.Errors[0]);
				}
			}
		}

		[Fact]
		public void PostTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<SensorEntryController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new SensorEntryController(context, logger))
				{
					var result = controller.Post(null);
					Assert.NotNull(result);
					Assert.False(result.Success);
					Assert.Equal(1, result.Errors.Count);
					Assert.Equal("data cannot be null", result.Errors[0]);
					Assert.Null(result.Data);
					var expected = new SensorEntry();
					// Success Test
					expected = new SensorEntry();
					expected.Id = Guid.NewGuid();
					expected.SensorType = Sannel.House.Sensor.SensorTypes.Temperature;
					expected.DeviceId = 15;
					expected.Value = 0.25075826013961727;
					expected.Value2 = 0.14090298029636172;
					expected.Value3 = 0.47038984413742546;
					expected.Value4 = 0.075987152324983459;
					expected.Value5 = 0.55769204188030774;
					expected.Value6 = 0.47460711210714984;
					expected.Value7 = 0.19892355389842928;
					expected.Value8 = 0.70504546850223349;
					expected.Value9 = 0.89633391513318472;
					expected.DateCreated = DateTime.MinValue;
					postPreCall(expected, wrapper);
					result = controller.Post(expected);
					Assert.NotNull(result);
					Assert.True(result.Success, "Success was not true");
					Assert.Equal(0, result.Errors.Count);
					Assert.NotNull(result.Data);
					Assert.True(result.Data.Id != Guid.NewGuid());
					var first = context.SensorEntries.FirstOrDefault((i) => i.Id == result.Data.Id);
					Assert.NotNull(first);
					var resultData = result.Data;
					Assert.Equal(first.Id, resultData.Id);
					Assert.Equal(first.SensorType, resultData.SensorType);
					Assert.Equal(first.DeviceId, resultData.DeviceId);
					Assert.Equal(first.Value, resultData.Value);
					Assert.Equal(first.Value2, resultData.Value2);
					Assert.Equal(first.Value3, resultData.Value3);
					Assert.Equal(first.Value4, resultData.Value4);
					Assert.Equal(first.Value5, resultData.Value5);
					Assert.Equal(first.Value6, resultData.Value6);
					Assert.Equal(first.Value7, resultData.Value7);
					Assert.Equal(first.Value8, resultData.Value8);
					Assert.Equal(first.Value9, resultData.Value9);
					Assert.Equal(first.DateCreated, resultData.DateCreated);
				}
			}
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void postPreCall(SensorEntry data, ContextWrapper wrapper);
	}
}