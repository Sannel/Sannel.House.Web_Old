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
					var1.DeviceId = 11;
					var1.Value = 0.033795803801061494;
					var1.Value2 = 0.65749209637636885;
					var1.Value3 = 0.79581199390618684;
					var1.Value4 = 0.93713564702176289;
					var1.Value5 = 0.3670834053154492;
					var1.Value6 = 0.24068577505680069;
					var1.Value7 = 0.45171670729840019;
					var1.Value8 = 0.32845770769215082;
					var1.Value9 = 0.56758832119758629;
					var1.DateCreated = DateTime.MinValue;
					// var2
					var2.Id = Guid.NewGuid();
					var2.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var2.DeviceId = 72;
					var2.Value = 0.04490888679628674;
					var2.Value2 = 0.94977506061539752;
					var2.Value3 = 0.331225770214212;
					var2.Value4 = 0.60476464014722253;
					var2.Value5 = 0.099965633871017784;
					var2.Value6 = 0.17136945955984734;
					var2.Value7 = 0.82088940908242458;
					var2.Value8 = 0.19734642896677668;
					var2.Value9 = 0.666547383492136;
					var2.DateCreated = DateTime.MinValue;
					// var3
					var3.Id = Guid.NewGuid();
					var3.SensorType = Sannel.House.Sensor.SensorTypes.Temperature;
					var3.DeviceId = 53;
					var3.Value = 0.661222890792984;
					var3.Value2 = 0.08067340081588989;
					var3.Value3 = 0.038234835508388854;
					var3.Value4 = 0.53429174913758959;
					var3.Value5 = 0.60169871365730587;
					var3.Value6 = 0.90644240002447851;
					var3.Value7 = 0.1658148188916104;
					var3.Value8 = 0.16088793667074663;
					var3.Value9 = 0.18096074749760366;
					var3.DateCreated = DateTime.MinValue;
					// var4
					var4.Id = Guid.NewGuid();
					var4.SensorType = Sannel.House.Sensor.SensorTypes.Temperature;
					var4.DeviceId = 45;
					var4.Value = 0.9927913700196852;
					var4.Value2 = 0.64435892163047515;
					var4.Value3 = 0.74436190852167172;
					var4.Value4 = 0.72403209084832676;
					var4.Value5 = 0.088820518501485007;
					var4.Value6 = 0.089644236066212982;
					var4.Value7 = 0.59435238530596368;
					var4.Value8 = 0.61730076867030037;
					var4.Value9 = 0.97544131240595189;
					var4.DateCreated = DateTime.MinValue;
					// var5
					var5.Id = Guid.NewGuid();
					var5.SensorType = Sannel.House.Sensor.SensorTypes.SoilMoisture;
					var5.DeviceId = 13;
					var5.Value = 0.54559395254850107;
					var5.Value2 = 0.50095087732232679;
					var5.Value3 = 0.37779852113583989;
					var5.Value4 = 0.52234300203730488;
					var5.Value5 = 0.5654458294461695;
					var5.Value6 = 0.39662615693948516;
					var5.Value7 = 0.11367586772594408;
					var5.Value8 = 0.71537384331010923;
					var5.Value9 = 0.93065835020069887;
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
					var1.SensorType = Sannel.House.Sensor.SensorTypes.SoilMoisture;
					var1.DeviceId = 96;
					var1.Value = 0.97492780861208583;
					var1.Value2 = 0.62227872694948627;
					var1.Value3 = 0.14863179165340579;
					var1.Value4 = 0.802427050099907;
					var1.Value5 = 0.052448070166841179;
					var1.Value6 = 0.44361876810138057;
					var1.Value7 = 0.39545268118169752;
					var1.Value8 = 0.16288608832419202;
					var1.Value9 = 0.91514397036058082;
					var1.DateCreated = DateTime.MinValue;
					//var2
					var2.Id = Guid.NewGuid();
					var2.SensorType = Sannel.House.Sensor.SensorTypes.SoilMoisture;
					var2.DeviceId = 75;
					var2.Value = 0.19862680006708336;
					var2.Value2 = 0.34414680923528357;
					var2.Value3 = 0.080112576056324214;
					var2.Value4 = 0.63712088793382093;
					var2.Value5 = 0.33362403993197903;
					var2.Value6 = 0.3361911179200705;
					var2.Value7 = 0.069178276261863431;
					var2.Value8 = 0.0924468730075503;
					var2.Value9 = 0.26158822060636627;
					var2.DateCreated = DateTime.MinValue;
					//var3
					var3.Id = Guid.NewGuid();
					var3.SensorType = Sannel.House.Sensor.SensorTypes.SoilMoisture;
					var3.DeviceId = 71;
					var3.Value = 0.978832910758831;
					var3.Value2 = 0.88998781977686459;
					var3.Value3 = 0.042620754820583737;
					var3.Value4 = 0.88423873245913476;
					var3.Value5 = 0.0057273567680862529;
					var3.Value6 = 0.36861208470939288;
					var3.Value7 = 0.23502050257987367;
					var3.Value8 = 0.29017057329889878;
					var3.Value9 = 0.92488525571529068;
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
					expected.SensorType = Sannel.House.Sensor.SensorTypes.WindSpeed;
					expected.DeviceId = 54;
					expected.Value = 0.92986878004384632;
					expected.Value2 = 0.650247782771591;
					expected.Value3 = 0.59869241462959555;
					expected.Value4 = 0.12849937385343918;
					expected.Value5 = 0.19939505178453171;
					expected.Value6 = 0.29895974523339408;
					expected.Value7 = 0.18201237226930092;
					expected.Value8 = 0.47740289311735096;
					expected.Value9 = 0.31922571375930014;
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