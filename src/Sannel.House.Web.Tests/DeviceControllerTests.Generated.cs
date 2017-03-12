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
					var1.Id = 37;
					var1.Name = "bIK^jWJ:!uATtW?e6m";
					var1.Description = "uJ9]bsIs+\"H,s>d9rPOat";
					var1.DisplayOrder = 92;
					var1.DateCreated = DateTimeOffset.MinValue;
					var1.IsReadOnly = false;
					// var2
					var2.Id = 92;
					var2.Name = "dP6qz)/%S4";
					var2.Description = "~*2}dyG'ZSl1H";
					var2.DisplayOrder = 85;
					var2.DateCreated = DateTimeOffset.MinValue;
					var2.IsReadOnly = false;
					// var3
					var3.Id = 13;
					var3.Name = "0u6osFh,m([+V";
					var3.Description = "SW#GQj2u5|k3>9Ei`[^HIh81e";
					var3.DisplayOrder = 1;
					var3.DateCreated = DateTimeOffset.MinValue;
					var3.IsReadOnly = false;
					// var4
					var4.Id = 32;
					var4.Name = "S<6ftir6fdI],}FZ2";
					var4.Description = "A9)#8I!(z6-;f#3#pn[n0mq?=K*FHM9iy`|^Vb:uw7G";
					var4.DisplayOrder = 26;
					var4.DateCreated = DateTimeOffset.MinValue;
					var4.IsReadOnly = false;
					// var5
					var5.Id = 4;
					var5.Name = "!DkaW\\qL3aI52P)P\"^2NQi*qW7pJB<t>^";
					var5.Description = "Z\\:SWkbm13-eM$GDbl@7XDx&}b2sV68O";
					var5.DisplayOrder = 84;
					var5.DateCreated = DateTimeOffset.MinValue;
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
					Assert.Equal(var5.IsReadOnly, actual.IsReadOnly);
					// var4
					actual = list[1];
					// var4 -> actual
					Assert.Equal(var4.Id, actual.Id);
					Assert.Equal(var4.Name, actual.Name);
					Assert.Equal(var4.Description, actual.Description);
					Assert.Equal(var4.DisplayOrder, actual.DisplayOrder);
					Assert.Equal(var4.DateCreated, actual.DateCreated);
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
					Assert.Equal(var3.IsReadOnly, actual.IsReadOnly);
					// var2
					actual = list[1];
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.Name, actual.Name);
					Assert.Equal(var2.Description, actual.Description);
					Assert.Equal(var2.DisplayOrder, actual.DisplayOrder);
					Assert.Equal(var2.DateCreated, actual.DateCreated);
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
					Assert.Equal(var1.IsReadOnly, actual.IsReadOnly);
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
						var1.Id = 23;
						var1.Name = "klx<-w:,1#P8qNP&~zX$_&r+NF";
						var1.Description = "^nj]/@AW`S";
						var1.DisplayOrder = 57;
						var1.DateCreated = DateTimeOffset.MinValue;
						var1.IsReadOnly = true;
						//var2
						var2.Id = 68;
						var2.Name = "=D|3Xc'$pg0t-utQD?q\\|-JiW";
						var2.Description = "ys>D%PQ>uVq{:";
						var2.DisplayOrder = 76;
						var2.DateCreated = DateTimeOffset.MinValue;
						var2.IsReadOnly = true;
						//var3
						var3.Id = 82;
						var3.Name = ",~+$+1eX{H)~Gl}|y{2&AJBz;qQpm`Mpi=B[X$%9";
						var3.Description = "AEcyL~'V%x&a~:-ZIm^:4C~~%@l^{7V:,':g%r=,'](\\";
						var3.DisplayOrder = 58;
						var3.DateCreated = DateTimeOffset.MinValue;
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
					expected.Id = 43;
					expected.Description = "h2kndlMPOJte\\dr@x&_!~2e!>hkAHw_'L()Wj>_P";
					expected.DisplayOrder = 8;
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
					expected.Id = 62;
					expected.Name = "!/jIy6D!z3.s-Gup[&p|pKy9,T7{+fPeEvVDFv6yF~4V";
					expected.DisplayOrder = 76;
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
					expected.Id = 34;
					expected.Name = ";gNQW-}M-2.8lDF*_m.m";
					expected.Description = "2hE~;Ck8Zb0L>sn+|.*0|C0/_@Iy=s>$Ofj?_l~^(";
					expected.DisplayOrder = 87;
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
					expected.Id = 89;
					expected.Description = "ok@{{Ixq}ON";
					expected.DisplayOrder = 54;
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
					expected.Id = 9;
					expected.Name = "4-@H,)[ObC)Q-kb";
					expected.DisplayOrder = 59;
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
					expected.Id = 28;
					expected.Name = "O{!VlF*!a0cDG:,F&G-";
					expected.Description = "^0@DL52qtnaKCIPZN/elg9o9";
					expected.DisplayOrder = 73;
					expected.DateCreated = DateTimeOffset.MinValue;
					expected.IsReadOnly = false;
					putPreCall(expected, wrapper);
					context.Devices.Add(expected);
					context.SaveChanges();
					// Reset props and call put
					expected.Name = "tpu!1]i6v_r\"Vl*/25H*MdB%Pk_v)";
					expected.Description = "AZ,{4]1)(0-^nP[+fK^n*$k&k\"s!\\j=AFFj\\)#gG.";
					expected.DisplayOrder = 77;
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

		// used to make sure reference tables have data needed for a test to succeed
		partial void putPreCall(Device data, ContextWrapper wrapper);
	}
}