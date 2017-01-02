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
	public class DeviceControllerTests
	{
		[Fact]
		public void GetTest()
		{
			using (var wrapper = new ContextWrapper())
			{
				var context = wrapper.Context;
				using (var controller = new DeviceController(context))
				{
					var var1 = new Device();
					var var2 = new Device();
					var var3 = new Device();
					//var1
					var1.Id = 67;
					var1.Name = "e.yaS$&]t:\\S^z}}B@p+\"_S&!E7O!v8K=G?FqE";
					var1.Description = "P*J3N5nE#F6[b>wKv";
					var1.DisplayOrder = 92;
					var1.DateCreated = DateTimeOffset.MinValue;
					var1.IsReadOnly = false;
					//var2
					var2.Id = 48;
					var2.Name = ")w4\\QrO,B+llj8zH3K-+89j)}Ax/[xBf)r->JJ-Za5~";
					var2.Description = "@3@*=uHA9vD\\D??|&CzI%{#>IN?HAy}]v>[N1h9g%#N2\"}`7]";
					var2.DisplayOrder = 12;
					var2.DateCreated = DateTimeOffset.MinValue;
					var2.IsReadOnly = false;
					//var3
					var3.Id = 84;
					var3.Name = ".5b|c?MN![{!FDW\"|6*ot4_@Mc?";
					var3.Description = "|pq:AaL#l#u``}JoJGv4}PG6j1D!8MBC\\Bvu-I^<8H<";
					var3.DisplayOrder = 21;
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
					context.SaveChanges();
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
			using (var wrapper = new ContextWrapper())
			{
				var context = wrapper.Context;
				using (var controller = new DeviceController(context))
				{
					var var1 = new Device();
					var var2 = new Device();
					var var3 = new Device();
					//var1
					var1.Id = 50;
					var1.Name = "7}6M.O_-/WC~lK!zVJVluCEkwAmW$Mtjz4xrFK\\M^);ZDI";
					var1.Description = "'}g[)($zLnrJzo0Z[yGs*>hfA+J5f@9e(Q:J?";
					var1.DisplayOrder = 60;
					var1.DateCreated = DateTimeOffset.MinValue;
					var1.IsReadOnly = true;
					//var2
					var2.Id = 88;
					var2.Name = "T#cl/MFx!5zQ:8bVEy\\vgqH}";
					var2.Description = "xkZ:9TA'&ygjl~D?sz)1,>]-7Ek`vZj+ZkAwzu\"DE&4hv";
					var2.DisplayOrder = 92;
					var2.DateCreated = DateTimeOffset.MinValue;
					var2.IsReadOnly = true;
					//var3
					var3.Id = 33;
					var3.Name = "\\<e8pSOb[Vhma";
					var3.Description = "/Mk)^rc>)v9|D\\$|MtK%n`iha8Wfr]VC'03'jtW#TC)$%Szd";
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
					context.SaveChanges();
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