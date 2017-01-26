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
	public partial class DeviceControllerTests : IContextWrapperTest
	{
		[Fact]
		public void GetTest()
		{
			{
				var logFactory = new LoggerFactory();
				var logger = logFactory.CreateLogger<DeviceController>();
				using (var wrapper = new ContextWrapper(this))
				{
					var context = wrapper.Context;
					using (var controller = new DeviceController(context, logger))
					{
						var var1 = new Device();
						var var2 = new Device();
						var var3 = new Device();
						//var1
						var1.Id = 41;
						var1.Name = "*_2vh|/])Ig/^#A}xXT>b<*4wwjn";
						var1.Description = "|]sXx9)!zhV.e@m-9C11T[}Q?aaSjNedH/D<@`y_o";
						var1.DisplayOrder = 63;
						var1.DateCreated = DateTimeOffset.MinValue;
						var1.IsReadOnly = false;
						//var2
						var2.Id = 87;
						var2.Name = "1N{.f@BuC%+=#nS@)_A5d]j#)K_2>q#_3s(}P`{1Hp.I]K]i";
						var2.Description = "dbGPO_m[Qe4|8i/AX=Qf/n#gF/i/M9x{.JN!K_I@!8q?";
						var2.DisplayOrder = 43;
						var2.DateCreated = DateTimeOffset.MinValue;
						var2.IsReadOnly = true;
						//var3
						var3.Id = 24;
						var3.Name = ":32O'kbsxpnXCo,1`8{i2a(;|*5A";
						var3.Description = "5zaep8%bX%J]yC6Z<sx{w-)]jV";
						var3.DisplayOrder = 50;
						var3.DateCreated = DateTimeOffset.MinValue;
						var3.IsReadOnly = false;
						//Fix Order
						var3.DisplayOrder = 1;
						var2.DisplayOrder = 2;
						var1.DisplayOrder = 3;
						// Add and save entities
						context.Devices.Add(var1);
						context.Devices.Add(var2);
						context.Devices.Add(var3);
						wrapper.SaveChanges();
						//call get method
						var results = controller.Get();
						Assert.NotNull(results);
						var list = results.ToList();
						Assert.Equal(3, list.Count);
						var one = list[0];
						// var3 -> one
						Assert.Equal(var3.Id, one.Id);
						Assert.Equal(var3.Name, one.Name);
						Assert.Equal(var3.Description, one.Description);
						Assert.Equal(var3.DisplayOrder, one.DisplayOrder);
						Assert.Equal(var3.DateCreated, one.DateCreated);
						Assert.Equal(var3.IsReadOnly, one.IsReadOnly);
						var two = list[1];
						// var2 -> two
						Assert.Equal(var2.Id, two.Id);
						Assert.Equal(var2.Name, two.Name);
						Assert.Equal(var2.Description, two.Description);
						Assert.Equal(var2.DisplayOrder, two.DisplayOrder);
						Assert.Equal(var2.DateCreated, two.DateCreated);
						Assert.Equal(var2.IsReadOnly, two.IsReadOnly);
						var three = list[2];
						// var1 -> three
						Assert.Equal(var1.Id, three.Id);
						Assert.Equal(var1.Name, three.Name);
						Assert.Equal(var1.Description, three.Description);
						Assert.Equal(var1.DisplayOrder, three.DisplayOrder);
						Assert.Equal(var1.DateCreated, three.DateCreated);
						Assert.Equal(var1.IsReadOnly, three.IsReadOnly);
					}
				}
			}
		}

		[Fact]
		public void GetWithIdTest()
		{
			{
				var logFactory = new LoggerFactory();
				var logger = logFactory.CreateLogger<DeviceController>();
				using (var wrapper = new ContextWrapper(this))
				{
					var context = wrapper.Context;
					using (var controller = new DeviceController(context, logger))
					{
						var var1 = new Device();
						var var2 = new Device();
						var var3 = new Device();
						//var1
						var1.Id = 77;
						var1.Name = "d(%mfQsX)2W.B9%BEJ[x@)?MO#[H[\\;aZiC2.iu8x+43";
						var1.Description = "[g40?\\POhnm+j~[$KPhpXK<f<@/lCWr9ks4pFT?L+JP*";
						var1.DisplayOrder = 72;
						var1.DateCreated = DateTimeOffset.MinValue;
						var1.IsReadOnly = true;
						//var2
						var2.Id = 57;
						var2.Name = "o-?TOmB@KI%(*Z+_mjJh*}x$#wrgw`Z^M&y5]=E";
						var2.Description = ";'{xk3}CkNzkc~HA%DGqk|581p!{m060Pna,XM].c#`j";
						var2.DisplayOrder = 33;
						var2.DateCreated = DateTimeOffset.MinValue;
						var2.IsReadOnly = true;
						//var3
						var3.Id = 42;
						var3.Name = "b_4QOA[f6HNA^'jmxDk]wdLKF>q`z&KgF3Z<IZg[Z";
						var3.Description = ":&z!864CNy|g.z-:1wp:aAMI$:(o@";
						var3.DisplayOrder = 76;
						var3.DateCreated = DateTimeOffset.MinValue;
						var3.IsReadOnly = false;
						//Fix Order
						var3.DisplayOrder = 1;
						var2.DisplayOrder = 2;
						var1.DisplayOrder = 3;
						// Add and save entities
						context.Devices.Add(var1);
						context.Devices.Add(var2);
						context.Devices.Add(var3);
						wrapper.SaveChanges();
						// verify
						var actual = controller.Get(var1.Id);
						Assert.NotNull(actual.Id);
						// var1 -> actual
						Assert.Equal(var1.Id, actual.Id);
						Assert.Equal(var1.Name, actual.Name);
						Assert.Equal(var1.Description, actual.Description);
						Assert.Equal(var1.DisplayOrder, actual.DisplayOrder);
						Assert.Equal(var1.DateCreated, actual.DateCreated);
						Assert.Equal(var1.IsReadOnly, actual.IsReadOnly);
						// Verify var2
						actual = controller.Get(var2.Id);
						Assert.NotNull(actual.Id);
						// var2 -> actual
						Assert.Equal(var2.Id, actual.Id);
						Assert.Equal(var2.Name, actual.Name);
						Assert.Equal(var2.Description, actual.Description);
						Assert.Equal(var2.DisplayOrder, actual.DisplayOrder);
						Assert.Equal(var2.DateCreated, actual.DateCreated);
						Assert.Equal(var2.IsReadOnly, actual.IsReadOnly);
						// Verify var3
						actual = controller.Get(var3.Id);
						Assert.NotNull(actual.Id);
						// var3 -> actual
						Assert.Equal(var3.Id, actual.Id);
						Assert.Equal(var3.Name, actual.Name);
						Assert.Equal(var3.Description, actual.Description);
						Assert.Equal(var3.DisplayOrder, actual.DisplayOrder);
						Assert.Equal(var3.DateCreated, actual.DateCreated);
						Assert.Equal(var3.IsReadOnly, actual.IsReadOnly);
					}
				}
			}
		}

		[Fact]
		public void PostTest()
		{
			{
				var logFactory = new LoggerFactory();
				var logger = logFactory.CreateLogger<DeviceController>();
				using (var wrapper = new ContextWrapper(this))
				{
					var context = wrapper.Context;
					using (var controller = new DeviceController(context, logger))
					{
						var result = controller.Post(null);
						Assert.NotNull(result);
						Assert.False(result.Success);
						Assert.Equal(1, result.Errors.Count);
						Assert.Equal("data cannot be null", result.Errors[0]);
						Assert.Null(result.Data);
						var expected = new Device();
						// Name
						expected = new Device();
						expected.Id = 33;
						expected.Description = "+XWr)$+`6bxgc`T(g~Viy?Ah";
						expected.DisplayOrder = 41;
						expected.DateCreated = DateTimeOffset.MinValue;
						expected.IsReadOnly = false;
						expected.Name = "";
						postPreCall(expected, wrapper);
						result = controller.Post(expected);
						Assert.NotNull(result);
						Assert.False(result.Success);
						Assert.Equal(1, result.Errors.Count);
						Assert.Equal("Name must have a non empty value", result.Errors[0]);
						Assert.NotNull(result.Data);
						// Description
						expected = new Device();
						expected.Id = 52;
						expected.Name = "BlW]~}0aXD\"n_uOfe~4<cGFa5q)`";
						expected.DisplayOrder = 20;
						expected.DateCreated = DateTimeOffset.MinValue;
						expected.IsReadOnly = false;
						expected.Description = null;
						postPreCall(expected, wrapper);
						result = controller.Post(expected);
						Assert.NotNull(result);
						Assert.False(result.Success);
						Assert.Equal(1, result.Errors.Count);
						Assert.Equal("Description must not be null", result.Errors[0]);
						Assert.NotNull(result.Data);
						// Success Test
						expected = new Device();
						expected.Id = 71;
						expected.Name = "n=Wj3wNL}`${<O}E!~@cG/KiIjG<.'*~";
						expected.Description = "!$/cCr.Oa3_={oSD0XCs=PMqwD;g>&%|3";
						expected.DisplayOrder = 15;
						expected.DateCreated = DateTimeOffset.MinValue;
						expected.IsReadOnly = false;
						postPreCall(expected, wrapper);
						result = controller.Post(expected);
						Assert.NotNull(result);
						Assert.True(result.Success, "Success was not true");
						Assert.Equal(0, result.Errors.Count);
						Assert.NotNull(result.Data);
						Assert.True(result.Data.Id > 0, "Id not updated");
						var first = context.Devices.FirstOrDefault((i) => i.Id == result.Data.Id);
						Assert.NotNull(first);
						var resultData = result.Data;
						Assert.Equal(first.Id, resultData.Id);
						Assert.Equal(first.Name, resultData.Name);
						Assert.Equal(first.Description, resultData.Description);
						Assert.Equal(first.DisplayOrder, resultData.DisplayOrder);
						Assert.Equal(first.DateCreated, resultData.DateCreated);
						Assert.Equal(first.IsReadOnly, resultData.IsReadOnly);
					}
				}
			}
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void postPreCall(Device data, ContextWrapper wrapper);
		[Fact]
		public void PutTest()
		{
			{
				var logFactory = new LoggerFactory();
				var logger = logFactory.CreateLogger<DeviceController>();
				using (var wrapper = new ContextWrapper(this))
				{
					var context = wrapper.Context;
					using (var controller = new DeviceController(context, logger))
					{
						var result = controller.Put(null);
						Assert.NotNull(result);
						Assert.False(result.Success);
						Assert.Equal(1, result.Errors.Count);
						Assert.Equal("data cannot be null", result.Errors[0]);
						Assert.Null(result.Data);
						var expected = new Device();
						// Name
						expected = new Device();
						expected.Id = 27;
						expected.Description = "f@Zc8:|$oTj$:6kH\\y]9|6d";
						expected.DisplayOrder = 60;
						expected.DateCreated = DateTimeOffset.MinValue;
						expected.IsReadOnly = false;
						expected.Name = "";
						putPreCall(expected, wrapper);
						result = controller.Put(expected);
						Assert.NotNull(result);
						Assert.False(result.Success);
						Assert.Equal(1, result.Errors.Count);
						Assert.Equal("Name must have a non empty value", result.Errors[0]);
						Assert.NotNull(result.Data);
						// Description
						expected = new Device();
						expected.Id = 47;
						expected.Name = "=S\"Q>abm^ZGexa'4_u;O`Zj;AHi";
						expected.DisplayOrder = 79;
						expected.DateCreated = DateTimeOffset.MinValue;
						expected.IsReadOnly = false;
						expected.Description = null;
						putPreCall(expected, wrapper);
						result = controller.Put(expected);
						Assert.NotNull(result);
						Assert.False(result.Success);
						Assert.Equal(1, result.Errors.Count);
						Assert.Equal("Description must not be null", result.Errors[0]);
						Assert.NotNull(result.Data);
						// Success Test
						expected = new Device();
						expected.Id = 19;
						expected.Name = "jmt,rhz\\S\"FM<\\?\"={Sx]7,0+/%z(kfX`Vwm\\o|%/:3";
						expected.Description = "zf-rcTKtfm]\\>^y";
						expected.DisplayOrder = 67;
						expected.DateCreated = DateTimeOffset.MinValue;
						expected.IsReadOnly = false;
						putPreCall(expected, wrapper);
						context.Devices.Add(expected);
						context.SaveChanges();
						// Reset props and call put
						expected.Name = "C@*tO^3pK,7-8QA29<{X@/XQ5";
						expected.Description = "LAlTWBEH_>}P<xGppoa9N!]@Qo.W%__x+Sy_:!N~a)[D+o?";
						expected.DisplayOrder = 18;
						putPreCall(expected, wrapper);
						result = controller.Put(expected);
						Assert.NotNull(result);
						Assert.True(result.Success, "Success was not true");
						Assert.Equal(0, result.Errors.Count);
						Assert.NotNull(result.Data);
						Assert.True(result.Data.Id > 0, "Id not updated");
						var first = context.Devices.FirstOrDefault((i) => i.Id == result.Data.Id);
						Assert.NotNull(first);
						var resultData = result.Data;
						Assert.Equal(first.Id, resultData.Id);
						Assert.Equal(first.Name, resultData.Name);
						Assert.Equal(first.Description, resultData.Description);
						Assert.Equal(first.DisplayOrder, resultData.DisplayOrder);
						Assert.Equal(first.DateCreated, resultData.DateCreated);
						Assert.Equal(first.IsReadOnly, resultData.IsReadOnly);
					}
				}
			}
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void putPreCall(Device data, ContextWrapper wrapper);
	}
}