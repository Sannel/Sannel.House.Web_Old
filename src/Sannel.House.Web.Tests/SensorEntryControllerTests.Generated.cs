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
					var1.SensorType = Sannel.House.Sensor.SensorTypes.SoilMoisture;
					var1.DeviceId = 21;
					var1.DeviceMacAddress = 77;
					var1.Value = 0.8062565526022839;
					var1.Value2 = 0.43291554340762811;
					var1.Value3 = 0.3337823237915441;
					var1.Value4 = 0.44395940305849507;
					var1.Value5 = 0.26817989175588819;
					var1.Value6 = 0.46119017268586449;
					var1.Value7 = 0.15553971200973712;
					var1.Value8 = 0.70959759722910709;
					var1.Value9 = 0.62143615708753286;
					var1.DateCreated = DateTime.MinValue;
					// var2
					var2.Id = Guid.NewGuid();
					var2.SensorType = Sannel.House.Sensor.SensorTypes.Temperature;
					var2.DeviceId = 75;
					var2.DeviceMacAddress = 75;
					var2.Value = 0.050939587434259984;
					var2.Value2 = 0.78044324032051637;
					var2.Value3 = 0.34748915831907146;
					var2.Value4 = 0.98397561907022058;
					var2.Value5 = 0.87100499582989377;
					var2.Value6 = 0.78924960353842455;
					var2.Value7 = 0.4754204044469727;
					var2.Value8 = 0.33120616540834596;
					var2.Value9 = 0.90095144505656855;
					var2.DateCreated = DateTime.MinValue;
					// var3
					var3.Id = Guid.NewGuid();
					var3.SensorType = Sannel.House.Sensor.SensorTypes.TemperatureHumidityPresure;
					var3.DeviceId = 91;
					var3.DeviceMacAddress = 27;
					var3.Value = 0.535098039328632;
					var3.Value2 = 0.69756514704672856;
					var3.Value3 = 0.0635400354226772;
					var3.Value4 = 0.0099909929605158949;
					var3.Value5 = 0.15375550005294172;
					var3.Value6 = 0.064809080243487416;
					var3.Value7 = 0.95228106060637208;
					var3.Value8 = 0.78977903993324328;
					var3.Value9 = 0.89172687236765724;
					var3.DateCreated = DateTime.MinValue;
					// var4
					var4.Id = Guid.NewGuid();
					var4.SensorType = Sannel.House.Sensor.SensorTypes.SoilMoisture;
					var4.DeviceId = 5;
					var4.DeviceMacAddress = 52;
					var4.Value = 0.88256355974942613;
					var4.Value2 = 0.91127380957420623;
					var4.Value3 = 0.72935932629246236;
					var4.Value4 = 0.83519331032186439;
					var4.Value5 = 0.47003140927759529;
					var4.Value6 = 0.1490138215706748;
					var4.Value7 = 0.82028984083807555;
					var4.Value8 = 0.67874734088720168;
					var4.Value9 = 0.69060759185376;
					var4.DateCreated = DateTime.MinValue;
					// var5
					var5.Id = Guid.NewGuid();
					var5.SensorType = Sannel.House.Sensor.SensorTypes.Temperature;
					var5.DeviceId = 71;
					var5.DeviceMacAddress = 46;
					var5.Value = 0.16608035339325683;
					var5.Value2 = 0.663293947774588;
					var5.Value3 = 0.96342500390644414;
					var5.Value4 = 0.34373279676946478;
					var5.Value5 = 0.90145495855317215;
					var5.Value6 = 0.0830547740138391;
					var5.Value7 = 0.08718899874351406;
					var5.Value8 = 0.6972103485358927;
					var5.Value9 = 0.85041157708056814;
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
					Assert.Equal(var1.DeviceMacAddress, actual.DeviceMacAddress);
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
					Assert.Equal(var2.DeviceMacAddress, actual.DeviceMacAddress);
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
					Assert.Equal(var3.DeviceMacAddress, actual.DeviceMacAddress);
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
					Assert.Equal(var4.DeviceMacAddress, actual.DeviceMacAddress);
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
					Assert.Equal(var5.DeviceMacAddress, actual.DeviceMacAddress);
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
					var1.DeviceId = 64;
					var1.DeviceMacAddress = 31;
					var1.Value = 0.13641606324185435;
					var1.Value2 = 0.89734474983874;
					var1.Value3 = 0.28848672205977455;
					var1.Value4 = 0.972823541598778;
					var1.Value5 = 0.4031172713279339;
					var1.Value6 = 0.035094466076742145;
					var1.Value7 = 0.93598287922143142;
					var1.Value8 = 0.41350306496652917;
					var1.Value9 = 0.958114845658706;
					var1.DateCreated = DateTime.MinValue;
					//var2
					var2.Id = Guid.NewGuid();
					var2.SensorType = Sannel.House.Sensor.SensorTypes.WindSpeed;
					var2.DeviceId = 80;
					var2.DeviceMacAddress = 84;
					var2.Value = 0.78326112766902012;
					var2.Value2 = 0.53084091261534061;
					var2.Value3 = 0.74023984313953661;
					var2.Value4 = 0.72099023811565255;
					var2.Value5 = 0.12317471398188487;
					var2.Value6 = 0.91296990723953109;
					var2.Value7 = 0.47522827446238525;
					var2.Value8 = 0.7019188086045528;
					var2.Value9 = 0.14157566434777141;
					var2.DateCreated = DateTime.MinValue;
					//var3
					var3.Id = Guid.NewGuid();
					var3.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var3.DeviceId = 58;
					var3.DeviceMacAddress = 60;
					var3.Value = 0.076114820351877638;
					var3.Value2 = 0.73101359034469982;
					var3.Value3 = 0.47298617357061534;
					var3.Value4 = 0.31385069541346777;
					var3.Value5 = 0.90383301996804444;
					var3.Value6 = 0.97566549944489522;
					var3.Value7 = 0.45612516508257256;
					var3.Value8 = 0.738482941285932;
					var3.Value9 = 0.98543473192743714;
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
					Assert.Equal(var1.DeviceMacAddress, actual.DeviceMacAddress);
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
					Assert.Equal(var2.DeviceMacAddress, actual.DeviceMacAddress);
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
					Assert.Equal(var3.DeviceMacAddress, actual.DeviceMacAddress);
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
					expected.DeviceId = 71;
					expected.DeviceMacAddress = 84;
					expected.Value = 0.479864743295994;
					expected.Value2 = 0.33010231532626894;
					expected.Value3 = 0.013223228516626743;
					expected.Value4 = 0.35146865777274067;
					expected.Value5 = 0.6768218738384647;
					expected.Value6 = 0.46410197879378778;
					expected.Value7 = 0.40449616564647117;
					expected.Value8 = 0.58889869208862011;
					expected.Value9 = 0.43174792147788588;
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
					Assert.Equal(first.DeviceMacAddress, resultData.DeviceMacAddress);
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