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
					var1.DeviceId = 62;
					var1.Value = 0.95315415875667431;
					var1.Value2 = 0.19179980652024961;
					var1.Value3 = 0.78637543916067831;
					var1.Value4 = 0.79307154323583073;
					var1.Value5 = 0.39677762305213959;
					var1.Value6 = 0.42977996889025905;
					var1.Value7 = 0.40923903016803742;
					var1.Value8 = 0.26500739821466029;
					var1.Value9 = 0.73350931225973615;
					var1.DateCreated = DateTime.MinValue;
					// var2
					var2.Id = Guid.NewGuid();
					var2.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var2.DeviceId = 72;
					var2.Value = 0.62178186635569754;
					var2.Value2 = 0.808530654669055;
					var2.Value3 = 0.78243337188960671;
					var2.Value4 = 0.88390355039569712;
					var2.Value5 = 0.28653524829379062;
					var2.Value6 = 0.98199645615275788;
					var2.Value7 = 0.24445674300401321;
					var2.Value8 = 0.69629142419262391;
					var2.Value9 = 0.57215567844554582;
					var2.DateCreated = DateTime.MinValue;
					// var3
					var3.Id = Guid.NewGuid();
					var3.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var3.DeviceId = 11;
					var3.Value = 0.98939755884436775;
					var3.Value2 = 0.638704433403306;
					var3.Value3 = 0.22997704438398456;
					var3.Value4 = 0.84863336423813984;
					var3.Value5 = 0.624349571123882;
					var3.Value6 = 0.035897346230175972;
					var3.Value7 = 0.20339115625405271;
					var3.Value8 = 0.49632654967546769;
					var3.Value9 = 0.1475325725728332;
					var3.DateCreated = DateTime.MinValue;
					// var4
					var4.Id = Guid.NewGuid();
					var4.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var4.DeviceId = 21;
					var4.Value = 0.65802526364942326;
					var4.Value2 = 0.25543528155211137;
					var4.Value3 = 0.22603497711291304;
					var4.Value4 = 0.93946537139800623;
					var4.Value5 = 0.514107196365533;
					var4.Value6 = 0.58811383349267476;
					var4.Value7 = 0.038608869090028509;
					var4.Value8 = 0.92761057658475388;
					var4.Value9 = 0.98617893875864282;
					var4.DateCreated = DateTime.MinValue;
					// var5
					var5.Id = Guid.NewGuid();
					var5.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var5.DeviceId = 30;
					var5.Value = 0.32665296845447878;
					var5.Value2 = 0.87216612970091689;
					var5.Value3 = 0.22209290984184152;
					var5.Value4 = 0.030297378557872668;
					var5.Value5 = 0.40386482160718407;
					var5.Value6 = 0.1403303207551736;
					var5.Value7 = 0.87382658192600426;
					var5.Value8 = 0.35889460349404;
					var5.Value9 = 0.8248253049444525;
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
					var1.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var1.DeviceId = 87;
					var1.Value = 0.40386482160718407;
					var1.Value2 = 0.35889460349404;
					var1.Value3 = 0.8726855045522961;
					var1.Value4 = 0.44692904662663541;
					var1.Value5 = 0.76522378286590043;
					var1.Value6 = 0.0029024365371570163;
					var1.Value7 = 0.32382699489771716;
					var1.Value8 = 0.72905423619274712;
					var1.Value9 = 0.022918034821244906;
					var1.DateCreated = DateTime.MinValue;
					//var2
					var2.Id = Guid.NewGuid();
					var2.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var2.DeviceId = 22;
					var2.Value = 0.1403303207551736;
					var2.Value2 = 0.8248253049444525;
					var2.Value3 = 0.68074218355153793;
					var2.Value4 = 0.55453019056214492;
					var2.Value5 = 0.30207151514574493;
					var2.Value6 = 0.41224352708656503;
					var2.Value7 = 0.7526766288805179;
					var2.Value8 = 0.065997123283332737;
					var2.Value9 = 0.63060014258632446;
					var2.DateCreated = DateTime.MinValue;
					//var3
					var3.Id = Guid.NewGuid();
					var3.SensorType = Sannel.House.Sensor.SensorTypes.Test;
					var3.DeviceId = 3;
					var3.Value = 0.87382658192600426;
					var3.Value2 = 0.55131987647680558;
					var3.Value3 = 0.910806250716935;
					var3.Value4 = 0.71913947524462807;
					var3.Value5 = 0.93777988242813382;
					var3.Value6 = 0.31646683314650637;
					var3.Value7 = 0.37756169651521448;
					var3.Value8 = 0.27023143240727088;
					var3.Value9 = 0.14529181790784551;
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
					expected.DeviceId = 40;
					expected.Value = 0.995280676053502;
					expected.Value2 = 0.48889697784972236;
					expected.Value3 = 0.21815084257077;
					expected.Value4 = 0.12112938571773907;
					expected.Value5 = 0.29362244684883509;
					expected.Value6 = 0.69254680801767243;
					expected.Value7 = 0.70904429476198;
					expected.Value8 = 0.79017862947200357;
					expected.Value9 = 0.66347167113026217;
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