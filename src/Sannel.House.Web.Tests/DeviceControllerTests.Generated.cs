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
						var1.Id = 53;
						var1.Name = "V;nN\"NE`dS:(So7%_XmnHfv";
						var1.Description = "kC|6.$/+OnGBN>/\\k6-ywaKfA}~8u')&q'0lv";
						var1.DisplayOrder = 50;
						var1.DateCreated = DateTimeOffset.MinValue;
						var1.IsReadOnly = true;
						//var2
						var2.Id = 41;
						var2.Name = "S!E6`aaI<j~f|VSZF/w7A7^#n8|,DBlfNJ@O)n`2";
						var2.Description = "7mk\"So\"1zh)(";
						var2.DisplayOrder = 83;
						var2.DateCreated = DateTimeOffset.MinValue;
						var2.IsReadOnly = true;
						//var3
						var3.Id = 55;
						var3.Name = "@_+&msy0OF@!k?TNkfXQFC3>";
						var3.Description = "JC,p66qqZ4xC#uv.]:-Hd?";
						var3.DisplayOrder = 42;
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
						var1.Id = 73;
						var1.Name = "VmjkOol^ACcbFbV^pkLsL]*<u-=*f^)4/,d5z;l]~MKxF#G~";
						var1.Description = "1_|-&$g$<Iu>+)#Ern-6/%#nf5qaE)A\"VE<";
						var1.DisplayOrder = 64;
						var1.DateCreated = DateTimeOffset.MinValue;
						var1.IsReadOnly = true;
						//var2
						var2.Id = 51;
						var2.Name = "]<^.A8lpl!v(+{z";
						var2.Description = "q0G%[y<<Ep/XW;<q!!<F8~/@X3jIBf4bqup%DCWe&^V";
						var2.DisplayOrder = 30;
						var2.DateCreated = DateTimeOffset.MinValue;
						var2.IsReadOnly = false;
						//var3
						var3.Id = 22;
						var3.Name = "lN#=L/K?dwXzW@@e>95*3[:;BW3oV@L^qX+*";
						var3.Description = "[o}~qgPAI!{~f";
						var3.DisplayOrder = 36;
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
						// Name test
						expected = new Device();
						expected.Id = 57;
						expected.Description = "I@TP^3cXcC7O6<0Xt1o$[Et5=_j^W$jvjT7K2c6I995@MD";
						expected.DisplayOrder = 27;
						expected.DateCreated = DateTimeOffset.MinValue;
						expected.IsReadOnly = false;
						expected.Name = "";
						result = controller.Post(expected);
						Assert.NotNull(result);
						Assert.False(result.Success);
						Assert.Equal(1, result.Errors.Count);
						Assert.Equal("Name must have a non empty value", result.Errors[0]);
						Assert.Null(result.Data);
						// Description test
						expected = new Device();
						expected.Id = 57;
						expected.Name = "I@TP^3cXcC7O6<0Xt1o$[Et5=_j^W$jvjT7K2c6I995@MD";
						expected.DisplayOrder = 27;
						expected.DateCreated = DateTimeOffset.MinValue;
						expected.IsReadOnly = false;
						expected.Description = null;
						result = controller.Post(expected);
						Assert.NotNull(result);
						Assert.False(result.Success);
						Assert.Equal(1, result.Errors.Count);
						Assert.Equal("Description must not be null", result.Errors[0]);
						Assert.Null(result.Data);
						// Success Test test
						expected = new Device();
						expected.Id = 57;
						expected.Name = "I@TP^3cXcC7O6<0Xt1o$[Et5=_j^W$jvjT7K2c6I995@MD";
						expected.Description = "@zC3f<ik1H.bN'i*o\\j&";
						expected.DisplayOrder = 38;
						expected.DateCreated = DateTimeOffset.MinValue;
						expected.IsReadOnly = true;
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
	}
}