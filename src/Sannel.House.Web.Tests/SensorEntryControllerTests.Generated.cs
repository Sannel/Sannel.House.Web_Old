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
					var1.DeviceId = 85;
					var1.DeviceMacAddress = 86;
					var1.Value = 0.6065838381678722;
					var1.Value2 = 0.083452647590754853;
					var1.Value3 = 0.49073299415909361;
					var1.Value4 = 0.97491774054938818;
					var1.Value5 = 0.026255818096108649;
					var1.Value6 = 0.88866385439814244;
					var1.Value7 = 0.21251143711270365;
					var1.Value8 = 0.05820414007557749;
					var1.Value9 = 0.38799520553461986;
					var1.Value10 = 0.19953585471936308;
					var1.DateCreated = DateTime.MinValue;
					// var2
					var2.Id = Guid.NewGuid();
					var2.SensorType = Sannel.House.Sensor.SensorTypes.WindDirection;
					var2.DeviceId = 77;
					var2.DeviceMacAddress = 1;
					var2.Value = 0.28563158413657525;
					var2.Value2 = 0.18760063740778743;
					var2.Value3 = 0.38435944513620784;
					var2.Value4 = 0.43009921416179242;
					var2.Value5 = 0.82758548661488363;
					var2.Value6 = 0.41486979202128471;
					var2.Value7 = 0.099227779125435178;
					var2.Value8 = 0.80113505888783143;
					var2.Value9 = 0.90829965095422216;
					var2.Value10 = 0.75977786246676826;
					var2.DateCreated = DateTime.MinValue;
					// var3
					var3.Id = Guid.NewGuid();
					var3.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var3.DeviceId = 43;
					var3.DeviceMacAddress = 6;
					var3.Value = 0.042731082552453073;
					var3.Value2 = 0.2806538517031138;
					var3.Value3 = 0.0761052924562736;
					var3.Value4 = 0.12079541670195545;
					var3.Value5 = 0.70325604253600171;
					var3.Value6 = 0.98664420982200851;
					var3.Value7 = 0.5419690779140075;
					var3.Value8 = 0.064088975109201377;
					var3.Value9 = 0.4617250158738927;
					var3.Value10 = 0.666016710766599;
					var3.DateCreated = DateTime.MinValue;
					// var4
					var4.Id = Guid.NewGuid();
					var4.SensorType = Sannel.House.Sensor.SensorTypes.Temperature;
					var4.DeviceId = 98;
					var4.DeviceMacAddress = 92;
					var4.Value = 0.053855266447111624;
					var4.Value2 = 0.48117253765518431;
					var4.Value3 = 0.286987073387479;
					var4.Value4 = 0.48807754390317831;
					var4.Value5 = 0.83876088626625056;
					var4.Value6 = 0.61158305062520457;
					var4.Value7 = 0.61486376850626612;
					var4.Value8 = 0.030225736568787014;
					var4.Value9 = 0.29597587571291994;
					var4.Value10 = 0.97097531378780277;
					var4.DateCreated = DateTime.MinValue;
					// var5
					var5.Id = Guid.NewGuid();
					var5.SensorType = Sannel.House.Sensor.SensorTypes.TemperatureHumidityPresure;
					var5.DeviceId = 12;
					var5.DeviceMacAddress = 61;
					var5.Value = 0.76905480901201018;
					var5.Value2 = 0.67157552050034308;
					var5.Value3 = 0.34286034356004574;
					var5.Value4 = 0.52896562569260863;
					var5.Value5 = 0.86773214622760753;
					var5.Value6 = 0.29365488527978534;
					var5.Value7 = 0.04553843571131045;
					var5.Value8 = 0.90702432669094968;
					var5.Value9 = 0.20106613785078103;
					var5.Value10 = 0.78183229676533128;
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
					Assert.Equal(var1.Value10, actual.Value10);
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
					Assert.Equal(var2.Value10, actual.Value10);
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
					Assert.Equal(var3.Value10, actual.Value10);
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
					Assert.Equal(var4.Value10, actual.Value10);
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
					Assert.Equal(var5.Value10, actual.Value10);
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
					var1.SensorType = Sannel.House.Sensor.SensorTypes.TemperatureHumidityPresure;
					var1.DeviceId = 86;
					var1.DeviceMacAddress = 63;
					var1.Value = 0.74224456387676507;
					var1.Value2 = 0.56125208016543282;
					var1.Value3 = 0.547429493883359;
					var1.Value4 = 0.43197985386102455;
					var1.Value5 = 0.73605522687363212;
					var1.Value6 = 0.17988797099324313;
					var1.Value7 = 0.65284767032267887;
					var1.Value8 = 0.61058029979960071;
					var1.Value9 = 0.47404862450158625;
					var1.Value10 = 0.249061654903489;
					var1.DateCreated = DateTime.MinValue;
					//var2
					var2.Id = Guid.NewGuid();
					var2.SensorType = Sannel.House.Sensor.SensorTypes.WindDirection;
					var2.DeviceId = 46;
					var2.DeviceMacAddress = 90;
					var2.Value = 0.5371014203583363;
					var2.Value2 = 0.93599803277105;
					var2.Value3 = 0.89222457487705376;
					var2.Value4 = 0.5937910506472881;
					var2.Value5 = 0.051724953601008726;
					var2.Value6 = 0.76534496655936579;
					var2.Value7 = 0.59352812105488406;
					var2.Value8 = 0.5629477470940667;
					var2.Value9 = 0.23988306300709167;
					var2.Value10 = 0.82869731300915461;
					var2.DateCreated = DateTime.MinValue;
					//var3
					var3.Id = Guid.NewGuid();
					var3.SensorType = Sannel.House.Sensor.SensorTypes.Temperature;
					var3.DeviceId = 34;
					var3.DeviceMacAddress = 46;
					var3.Value = 0.4478458889982877;
					var3.Value2 = 0.97777224424191389;
					var3.Value3 = 0.33353943346698744;
					var3.Value4 = 0.70111459014057864;
					var3.Value5 = 0.44690055793472594;
					var3.Value6 = 0.055126055169443626;
					var3.Value7 = 0.32897998733864164;
					var3.Value8 = 0.573051395161567;
					var3.Value9 = 0.2907642509279606;
					var3.Value10 = 0.48366417385808386;
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
					Assert.Equal(var1.Value10, actual.Value10);
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
					Assert.Equal(var2.Value10, actual.Value10);
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
					Assert.Equal(var3.Value10, actual.Value10);
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
					expected.DeviceId = 80;
					expected.DeviceMacAddress = 65;
					expected.Value = 0.19341359063676261;
					expected.Value2 = 0.026211004716442436;
					expected.Value3 = 0.98175323939963866;
					expected.Value4 = 0.92286767201631692;
					expected.Value5 = 0.89617202379562522;
					expected.Value6 = 0.37412025284679618;
					expected.Value7 = 0.80290673663975054;
					expected.Value8 = 0.52230591490972134;
					expected.Value9 = 0.48709855018514142;
					expected.Value10 = 0.41127838213521911;
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
					Assert.Equal(first.Value10, resultData.Value10);
					Assert.Equal(first.DateCreated, resultData.DateCreated);
				}
			}
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void postPreCall(SensorEntry data, ContextWrapper wrapper);
	}
}