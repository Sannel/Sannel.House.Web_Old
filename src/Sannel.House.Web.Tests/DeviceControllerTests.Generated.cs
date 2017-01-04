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
using Xunit;

namespace Sannel.House.Web.Tests
{
	public partial class DeviceControllerTests : IContextWrapperTest
	{
		[Fact]
		public void GetTest()
		{
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new DeviceController(context))
				{
					var var1 = new Device();
					var var2 = new Device();
					var var3 = new Device();
					//var1
					var1.Id = 89;
					var1.Name = "Sgm/s0B#b6[:Fp";
					var1.Description = "M5KGC$_{*CnkD";
					var1.DisplayOrder = 60;
					var1.DateCreated = DateTimeOffset.MinValue;
					var1.IsReadOnly = false;
					//var2
					var2.Id = 83;
					var2.Name = "DE*6<`sEI=VtKhOxNdKcOk1w)";
					var2.Description = ".iKGQA\"x=y*ONB@mawz]F2J5v(!^v";
					var2.DisplayOrder = 76;
					var2.DateCreated = DateTimeOffset.MinValue;
					var2.IsReadOnly = false;
					//var3
					var3.Id = 16;
					var3.Name = "6Pe9$JoD,X/|$9yDXkkA7T:js\\NGQqQBF(BOinN";
					var3.Description = "W!~rnxLzN@^[Vkc$*rcnhwNoWn;S&]mW<pQ7c,t";
					var3.DisplayOrder = 88;
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

		[Fact]
		public void GetWithIdTest()
		{
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new DeviceController(context))
				{
					var var1 = new Device();
					var var2 = new Device();
					var var3 = new Device();
					//var1
					var1.Id = 25;
					var1.Name = "`fSW\\1PWbpbL;eF?G!AxcPsmxG(6C-!";
					var1.Description = "'I~%Lg91Pf@5*<M&x?K[Z1L'*";
					var1.DisplayOrder = 96;
					var1.DateCreated = DateTimeOffset.MinValue;
					var1.IsReadOnly = false;
					//var2
					var2.Id = 52;
					var2.Name = "I}eFDfd6!!@xQeTv\\Z08}SM_2!0b|/}g*N!";
					var2.Description = "%5*t(EK')rmaho";
					var2.DisplayOrder = 76;
					var2.DateCreated = DateTimeOffset.MinValue;
					var2.IsReadOnly = true;
					//var3
					var3.Id = 34;
					var3.Name = "?`%yIT[]x:M(-/.216ZVD3A,yKwj[TrO~Cv]T|o4";
					var3.Description = "hW*!QCB,#-|l/g;Jn";
					var3.DisplayOrder = 27;
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
}