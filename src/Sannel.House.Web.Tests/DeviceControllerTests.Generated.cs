/* Copyright 2018 Sannel Software, L.L.C.

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
	public partial class DeviceControllerTests : IContextWrapperTest
	{
		[Fact]
		public void GetPagedTest()
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
					var var4 = new Device();
					var var5 = new Device();
					// var1
					var1.Id = 81;
					var1.Name = "5$r8[F*/mnC9@j";
					var1.Description = "Q0^@o<:ELPWXy<`Z?kciuJ7D-ti";
					var1.DisplayOrder = 10;
					var1.DateCreated = DateTime.MinValue;
					var1.MacAddress = 21;
					var1.IsReadOnly = false;
					// var2
					var2.Id = 15;
					var2.Name = "|5.6ql(&6\\$`I4X5-Q)-%P/%0g2~}f!ar";
					var2.Description = ",9crz7tCCxk4_;K>yDm1o2]aNFh9fb_}W|]FgF0@D+F7T6^";
					var2.DisplayOrder = 50;
					var2.DateCreated = DateTime.MinValue;
					var2.MacAddress = 30;
					var2.IsReadOnly = false;
					// var3
					var3.Id = 99;
					var3.Name = ";'[|`s~q{vp]A3i0^!/8|]7};mQ";
					var3.Description = ".Z{;Ib3u`kn8g\\zC";
					var3.DisplayOrder = 42;
					var3.DateCreated = DateTime.MinValue;
					var3.MacAddress = 3;
					var3.IsReadOnly = false;
					// var4
					var4.Id = 31;
					var4.Name = "x8\\clx&J&W/8#]5|M5L6&xFac'lnmzN|}?KMVXHv]2H=";
					var4.Description = "vQjV.PoD*,?+>`<4n&QO\"y#x8H5&_/%{WG";
					var4.DisplayOrder = 99;
					var4.DateCreated = DateTime.MinValue;
					var4.MacAddress = 87;
					var4.IsReadOnly = false;
					// var5
					var5.Id = 56;
					var5.Name = ",7V#&B\"PhO$:'-c-xO(GFuy9$+#";
					var5.Description = "P%T\\g7T1'uG8S|*\"]KNcxe|W/{m+PG?B}6?+1|[f\\z";
					var5.DisplayOrder = 58;
					var5.DateCreated = DateTime.MinValue;
					var5.MacAddress = 21;
					var5.IsReadOnly = false;
					// Fix order
					var5.DisplayOrder = 1;
					var4.DisplayOrder = 2;
					var3.DisplayOrder = 3;
					var2.DisplayOrder = 4;
					var1.DisplayOrder = 5;
					// Add to database
					context.Devices.Add(var1);
					context.Devices.Add(var2);
					context.Devices.Add(var3);
					context.Devices.Add(var4);
					context.Devices.Add(var5);
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
					// var5
					var actual = list[0];
					// var5 -> actual
					Assert.Equal(var5.Id, actual.Id);
					Assert.Equal(var5.Name, actual.Name);
					Assert.Equal(var5.Description, actual.Description);
					Assert.Equal(var5.DisplayOrder, actual.DisplayOrder);
					Assert.Equal(var5.DateCreated, actual.DateCreated);
					Assert.Equal(var5.MacAddress, actual.MacAddress);
					Assert.Equal(var5.IsReadOnly, actual.IsReadOnly);
					// var4
					actual = list[1];
					// var4 -> actual
					Assert.Equal(var4.Id, actual.Id);
					Assert.Equal(var4.Name, actual.Name);
					Assert.Equal(var4.Description, actual.Description);
					Assert.Equal(var4.DisplayOrder, actual.DisplayOrder);
					Assert.Equal(var4.DateCreated, actual.DateCreated);
					Assert.Equal(var4.MacAddress, actual.MacAddress);
					Assert.Equal(var4.IsReadOnly, actual.IsReadOnly);
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
					Assert.Equal(var3.Name, actual.Name);
					Assert.Equal(var3.Description, actual.Description);
					Assert.Equal(var3.DisplayOrder, actual.DisplayOrder);
					Assert.Equal(var3.DateCreated, actual.DateCreated);
					Assert.Equal(var3.MacAddress, actual.MacAddress);
					Assert.Equal(var3.IsReadOnly, actual.IsReadOnly);
					// var2
					actual = list[1];
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.Name, actual.Name);
					Assert.Equal(var2.Description, actual.Description);
					Assert.Equal(var2.DisplayOrder, actual.DisplayOrder);
					Assert.Equal(var2.DateCreated, actual.DateCreated);
					Assert.Equal(var2.MacAddress, actual.MacAddress);
					Assert.Equal(var2.IsReadOnly, actual.IsReadOnly);
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
					// var1
					actual = list[0];
					// var1 -> actual
					Assert.Equal(var1.Id, actual.Id);
					Assert.Equal(var1.Name, actual.Name);
					Assert.Equal(var1.Description, actual.Description);
					Assert.Equal(var1.DisplayOrder, actual.DisplayOrder);
					Assert.Equal(var1.DateCreated, actual.DateCreated);
					Assert.Equal(var1.MacAddress, actual.MacAddress);
					Assert.Equal(var1.IsReadOnly, actual.IsReadOnly);
				}
			}
		}

		[Fact]
		public void GetWithIdTest()
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
					var1.Id = 15;
					var1.Name = "h|e!)(Cl\\6%p)v6tNA(I'S'JXn`QwlvLq:;4P2Ct/O";
					var1.Description = ",j)^[AnHH)A_8pjh,W&,e`%yl;fseD/W5bm";
					var1.DisplayOrder = 9;
					var1.DateCreated = DateTime.MinValue;
					var1.MacAddress = 22;
					var1.IsReadOnly = false;
					//var2
					var2.Id = 71;
					var2.Name = "-1r1i2F)idk_T&g)/*)^Xhy8p";
					var2.Description = "/+BrA&$y=vG/rZD~uMr,wCTLe@k2b8%jASHuPX";
					var2.DisplayOrder = 78;
					var2.DateCreated = DateTime.MinValue;
					var2.MacAddress = 78;
					var2.IsReadOnly = true;
					//var3
					var3.Id = 22;
					var3.Name = "1bCKC4Ho\\Gvv";
					var3.Description = "8FK%BOF0\\`ke9+>]{v7`nI!}3or\";5s]d9*GsI}~k482";
					var3.DisplayOrder = 11;
					var3.DateCreated = DateTime.MinValue;
					var3.MacAddress = 38;
					var3.IsReadOnly = true;
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
					var results = controller.Get(var1.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					var actual = results.Data;
					// var1 -> actual
					Assert.Equal(var1.Id, actual.Id);
					Assert.Equal(var1.Name, actual.Name);
					Assert.Equal(var1.Description, actual.Description);
					Assert.Equal(var1.DisplayOrder, actual.DisplayOrder);
					Assert.Equal(var1.DateCreated, actual.DateCreated);
					Assert.Equal(var1.MacAddress, actual.MacAddress);
					Assert.Equal(var1.IsReadOnly, actual.IsReadOnly);
					// verify var2
					results = controller.Get(var2.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.Name, actual.Name);
					Assert.Equal(var2.Description, actual.Description);
					Assert.Equal(var2.DisplayOrder, actual.DisplayOrder);
					Assert.Equal(var2.DateCreated, actual.DateCreated);
					Assert.Equal(var2.MacAddress, actual.MacAddress);
					Assert.Equal(var2.IsReadOnly, actual.IsReadOnly);
					// verify var3
					results = controller.Get(var3.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var3 -> actual
					Assert.Equal(var3.Id, actual.Id);
					Assert.Equal(var3.Name, actual.Name);
					Assert.Equal(var3.Description, actual.Description);
					Assert.Equal(var3.DisplayOrder, actual.DisplayOrder);
					Assert.Equal(var3.DateCreated, actual.DateCreated);
					Assert.Equal(var3.MacAddress, actual.MacAddress);
					Assert.Equal(var3.IsReadOnly, actual.IsReadOnly);
					// Failed Test
					results = controller.Get(0);
					Assert.NotNull(results);
					Assert.False(results.Success);
					Assert.Equal(1, results.Errors.Count);
					Assert.Equal($"Could not find Device with Id {0}", results.Errors[0]);
				}
			}
		}

		[Fact]
		public void PostTest()
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
					expected.Id = 17;
					expected.Description = "y.XxWu:G:d$WzeO9uFNc,";
					expected.DisplayOrder = 72;
					expected.DateCreated = DateTime.MinValue;
					expected.MacAddress = 20;
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
					expected.Id = 56;
					expected.Name = "G4_5i:DZc^#p-u`j`:e<V&Q%}T4*7?OE~f=}B5H;Z|yGo(tS1";
					expected.DisplayOrder = 63;
					expected.DateCreated = DateTime.MinValue;
					expected.MacAddress = 92;
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
					expected.Id = 39;
					expected.Name = "C>4lvE,Q*ZGu&2f<xlo";
					expected.Description = "&7O9]No:jCm#(q(CfOQ7G5&\"@";
					expected.DisplayOrder = 58;
					expected.DateCreated = DateTime.MinValue;
					expected.MacAddress = 95;
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
					Assert.Equal(first.MacAddress, resultData.MacAddress);
					Assert.Equal(first.IsReadOnly, resultData.IsReadOnly);
				}
			}
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void postPreCall(Device data, ContextWrapper wrapper);
		[Fact]
		public void PutTest()
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
					expected.Id = 46;
					expected.Description = "<D2FhHr_NiES)lG+c6(f1h";
					expected.DisplayOrder = 20;
					expected.DateCreated = DateTime.MinValue;
					expected.MacAddress = 51;
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
					expected.Id = 35;
					expected.Name = "y6<!&m9_jJ";
					expected.DisplayOrder = 33;
					expected.DateCreated = DateTime.MinValue;
					expected.MacAddress = 23;
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
					expected.Id = 24;
					expected.Name = "xj6'V7.K=mX+EPA_IB&`?;W`*gjx|0M!SAa,Ctd]2BbM'vHB";
					expected.Description = "axTy&M2G6esv671/}hXw~uihF>4BOf..zStz_GzG[";
					expected.DisplayOrder = 81;
					expected.DateCreated = DateTime.MinValue;
					expected.MacAddress = 85;
					expected.IsReadOnly = false;
					putPreCall(expected, wrapper);
					context.Devices.Add(expected);
					context.SaveChanges();
					// Reset props and call put
					expected.Name = "p3u5LJ(Bjuk%2E9PW&TD;k\"X:<ahy\\8s^b,wXtKIiCVm6`G";
					expected.Description = "rf1TPp]:~d$Z[}v6_6>\\4DHti>\\";
					expected.DisplayOrder = 61;
					expected.MacAddress = 58;
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
					Assert.Equal(first.MacAddress, resultData.MacAddress);
					Assert.Equal(first.IsReadOnly, resultData.IsReadOnly);
				}
			}
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void putPreCall(Device data, ContextWrapper wrapper);
	}
}