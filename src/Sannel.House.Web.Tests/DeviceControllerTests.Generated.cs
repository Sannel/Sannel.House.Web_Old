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
					var1.Id = 58;
					var1.Name = "o|zx}\\3*h!h}!P3Dl!*i'w)|u[";
					var1.Description = "2S('sDl|H,c+}=oOBKo2(v0T*&^L7jS^uA1s";
					var1.DisplayOrder = 25;
					var1.DateCreated = DateTime.MinValue;
					var1.MacAddress = 61;
					var1.IsReadOnly = false;
					// var2
					var2.Id = 80;
					var2.Name = "NqCiIN)xOts`S|6o_8s.yX=g6X;oFMM$8eX|pC1";
					var2.Description = "J5(4j$&C7mlj7@o";
					var2.DisplayOrder = 5;
					var2.DateCreated = DateTime.MinValue;
					var2.MacAddress = 15;
					var2.IsReadOnly = false;
					// var3
					var3.Id = 89;
					var3.Name = "ZvD?wibMOVbGw,f'P4cCDoji_";
					var3.Description = "!m?oXlK7Ae'*](K08=tl:}";
					var3.DisplayOrder = 15;
					var3.DateCreated = DateTime.MinValue;
					var3.MacAddress = 79;
					var3.IsReadOnly = false;
					// var4
					var4.Id = 72;
					var4.Name = "hsJ|'zdj^t.2!=3/|ErFP1!j7zNnh`b/s4X";
					var4.Description = "_ilxyJNh6$;ip.uoBCXf+yE?nJ`^P>v0&s";
					var4.DisplayOrder = 39;
					var4.DateCreated = DateTime.MinValue;
					var4.MacAddress = 40;
					var4.IsReadOnly = false;
					// var5
					var5.Id = 28;
					var5.Name = "hTi9^.9.O=.+\"CGgX?OB]vwiO;=r`IQq>l";
					var5.Description = ">[&5@8oWJcvA/tik\\^t%Zp`oWk";
					var5.DisplayOrder = 78;
					var5.DateCreated = DateTime.MinValue;
					var5.MacAddress = 64;
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
					var1.Id = 98;
					var1.Name = "hd'pQd{G7@|kTequ|vF!%6mOo.%l}jC6jH";
					var1.Description = "y)GJ9m-u9v}B";
					var1.DisplayOrder = 71;
					var1.DateCreated = DateTime.MinValue;
					var1.MacAddress = 5;
					var1.IsReadOnly = true;
					//var2
					var2.Id = 12;
					var2.Name = "GoLN'D!CbPf*6QSj[ea[]JH12)^5v)T1:";
					var2.Description = "szj\\3T>SMGENd2S/~[PO`7C!I}w~^?{v8jVSTpz75_pa-Z.";
					var2.DisplayOrder = 81;
					var2.DateCreated = DateTime.MinValue;
					var2.MacAddress = 56;
					var2.IsReadOnly = true;
					//var3
					var3.Id = 59;
					var3.Name = "g>Z,_i4!2>X[-KM`k|6a@<zKV+c8tt3diy$FbA3";
					var3.Description = "tTN#1&Bu,tOqpHc<79KN9?M|K//PEg2G9";
					var3.DisplayOrder = 51;
					var3.DateCreated = DateTime.MinValue;
					var3.MacAddress = 57;
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
					expected.Id = 79;
					expected.Description = ".QHgN(n5@L,_Hw2wP[h>0s;Dv-Dq;";
					expected.DisplayOrder = 31;
					expected.DateCreated = DateTime.MinValue;
					expected.MacAddress = 6;
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
					expected.Id = 45;
					expected.Name = ":CClu9n3Dn$8.;7@&z/8#?i>jefvk.\"e%9S`N%*T\"O`l";
					expected.DisplayOrder = 51;
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
					expected.Id = 95;
					expected.Name = ")'Ma(9Va,)L0$rPM0&1n![|vdzq^_H*8";
					expected.Description = "h}xeG2,^+s#!nc;";
					expected.DisplayOrder = 47;
					expected.DateCreated = DateTime.MinValue;
					expected.MacAddress = 57;
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
					expected.Id = 60;
					expected.Description = "/o<!%))D.gME@wC@yi6;H}Bo)C";
					expected.DisplayOrder = 57;
					expected.DateCreated = DateTime.MinValue;
					expected.MacAddress = 97;
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
					expected.Id = 32;
					expected.Name = "HP<n!2$9^blmA1]E@s=T";
					expected.DisplayOrder = 65;
					expected.DateCreated = DateTime.MinValue;
					expected.MacAddress = 60;
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
					expected.Id = 82;
					expected.Name = "rg!fX\\%l.vn%EhI,u)]+MZ;ltSHMzCmyJ9oMqu^-_p/D[";
					expected.Description = "EL`P(_['C\\B,=-b*<PM_uc9}y`4q`x*{0m8MMG";
					expected.DisplayOrder = 67;
					expected.DateCreated = DateTime.MinValue;
					expected.MacAddress = 36;
					expected.IsReadOnly = false;
					putPreCall(expected, wrapper);
					context.Devices.Add(expected);
					context.SaveChanges();
					// Reset props and call put
					expected.Name = "u>vAIx25>;DOoavJN`0GCS^b";
					expected.Description = "tDNmd-06CVotP9Lvancav}XhBNqk)axA>\"i|7s;]E/dk%";
					expected.DisplayOrder = 51;
					expected.MacAddress = 22;
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