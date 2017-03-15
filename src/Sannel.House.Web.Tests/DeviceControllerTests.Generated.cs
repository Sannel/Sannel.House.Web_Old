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
					var1.Id = 41;
					var1.Name = "W^p9%#-':tG%/#zm(cFm0zx!WZi=niuJ#Z\\2";
					var1.Description = "A-5ZuxsJX>[0yvb9S'-.*awF>Bj";
					var1.DisplayOrder = 97;
					var1.DateCreated = DateTime.MinValue;
					var1.IsReadOnly = false;
					// var2
					var2.Id = 13;
					var2.Name = "44J6;*7yseG";
					var2.Description = "4!`d0<5glPI{$O^C\\D&.y+VJCBTN^>s,O]9,HAJ0k/le";
					var2.DisplayOrder = 34;
					var2.DateCreated = DateTime.MinValue;
					var2.IsReadOnly = false;
					// var3
					var3.Id = 32;
					var3.Name = "OQJ!\\SCAql->}l3";
					var3.Description = "N<#7}z{WJVA\":MT\\@,n<&'hxNhSV_Z=Pa{iaO";
					var3.DisplayOrder = 24;
					var3.DateCreated = DateTime.MinValue;
					var3.IsReadOnly = false;
					// var4
					var4.Id = 52;
					var4.Name = "o+H(et}^-Oa9s\"6XS>q";
					var4.Description = "?pSnh=tJe-!$?<q8;~q#E?-&Go@G3OX}VH*?j";
					var4.DisplayOrder = 22;
					var4.DateCreated = DateTime.MinValue;
					var4.IsReadOnly = false;
					// var5
					var5.Id = 71;
					var5.Name = "4ZHt%Zv.MV}*~(9-,>]q*^G";
					var5.Description = "~yZF|wm<GeM&J{8D\\kg;iL$C.Ea6=\\8H";
					var5.DisplayOrder = 8;
					var5.DateCreated = DateTime.MinValue;
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
					var1.Id = 43;
					var1.Name = "+w'Nzs'X{\"'&zMjiQ~.[M=/@{vcPhA?Tg2rC/EP";
					var1.Description = "]k4(\"qKv&f3X*I,s)#_+g|);q+ggpHf9:z:z<l)ulm{]Ak{@^";
					var1.DisplayOrder = 98;
					var1.DateCreated = DateTime.MinValue;
					var1.IsReadOnly = true;
					//var2
					var2.Id = 72;
					var2.Name = "yI(ir~u0Ev'+62A";
					var2.Description = "_deak/)lNbFo$p?V3WJ6g{";
					var2.DisplayOrder = 14;
					var2.DateCreated = DateTime.MinValue;
					var2.IsReadOnly = true;
					//var3
					var3.Id = 42;
					var3.Name = ".i^<:G]<\"J}l.cO";
					var3.Description = "X|K1K}S'e)7x`Ds4^wdx/z~ay]Kf5t~H;'[Q/.]|@5j09H";
					var3.DisplayOrder = 60;
					var3.DateCreated = DateTime.MinValue;
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
					expected.Id = 62;
					expected.Description = "8y_[ajp:o051(vv#toS}\"&?6eow'1ZMzG4~!,kdqf,";
					expected.DisplayOrder = 69;
					expected.DateCreated = DateTime.MinValue;
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
					expected.Id = 82;
					expected.Name = "}M_hr4&w^ei=NNm[@oXu-521MvLkd5\\r.pH+B0)X%~3eyt";
					expected.DisplayOrder = 38;
					expected.DateCreated = DateTime.MinValue;
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
					expected.Id = 2;
					expected.Name = "\\c_c^b5{5k";
					expected.Description = "_.e.m1o2Mu\"6NmD\\gX&Z9fPk](O4lB/onZH[s";
					expected.DisplayOrder = 17;
					expected.DateCreated = DateTime.MinValue;
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
					expected.Id = 57;
					expected.Description = "+nh/_#:6E%>O'Q[|+c_hwwW#2C]t)bS+\"Asaw]=cH";
					expected.DisplayOrder = 97;
					expected.DateCreated = DateTime.MinValue;
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
					expected.Id = 76;
					expected.Name = "N&g{!PIjl]wK(1a>-vp8'=O0W-<wT|)5I00xn`V$xgjwa";
					expected.DisplayOrder = 5;
					expected.DateCreated = DateTime.MinValue;
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
					expected.Id = 48;
					expected.Name = "e4VIjSQw8pwj.`\"G?<.NN";
					expected.Description = "KT$NF6k%-L\"j,i7#j7:9og";
					expected.DisplayOrder = 32;
					expected.DateCreated = DateTime.MinValue;
					expected.IsReadOnly = false;
					putPreCall(expected, wrapper);
					context.Devices.Add(expected);
					context.SaveChanges();
					// Reset props and call put
					expected.Name = "o>WVDptjPBbnmtiC3H>|z$~\".J!i3Miv.IJwj";
					expected.Description = "SwTnnOAL3#7'c})p-#JSqN&<f";
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