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
					var1.Id = 41;
					var1.Name = "B4Ir7nHso7C`u4;0lsf&($yc2p6_f);:X@fSNB1c]kOC=";
					var1.Description = "Xeao^#$#,{T-qT;z>-z39#v{!vaZF";
					var1.DisplayOrder = 74;
					var1.DateCreated = DateTime.MinValue;
					var1.IsReadOnly = false;
					// var2
					var2.Id = 60;
					var2.Name = "nQT]<!Q:&+&=4[xtidvHh2plEb,*X\\?/Pk=C)'F$~15^E<B]2";
					var2.Description = "{j[Ahv+#PolaMDqc['_/6H.[";
					var2.DisplayOrder = 68;
					var2.DateCreated = DateTime.MinValue;
					var2.IsReadOnly = false;
					// var3
					var3.Id = 32;
					var3.Name = "<j~oe^mWD_&Sdp1@*JJWZ%l9";
					var3.Description = "\\g`OKLdXZ.O{Io7d.";
					var3.DisplayOrder = 93;
					var3.DateCreated = DateTime.MinValue;
					var3.IsReadOnly = false;
					// var4
					var4.Id = 51;
					var4.Name = ".0~f$|d9,f;C~}4p6JM+=2x3K,3<";
					var4.Description = "1r*P(rK4e#T$~+T0";
					var4.DisplayOrder = 96;
					var4.DateCreated = DateTime.MinValue;
					var4.IsReadOnly = false;
					// var5
					var5.Id = 71;
					var5.Name = "eP=x7rq;gQK3K07nXK7\"iLb<jJbBn#D1";
					var5.Description = "v`<uC<wV/m?Qs0HNO5.&G#d=!5(OuVq:";
					var5.DisplayOrder = 83;
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
					var1.Id = 27;
					var1.Name = "u,~Z9L9u!j}fJ}#4r\\e+%%XMcSMxT$<mB`]b5iG<";
					var1.Description = "BSBK%$][;f";
					var1.DisplayOrder = 65;
					var1.DateCreated = DateTime.MinValue;
					var1.IsReadOnly = false;
					//var2
					var2.Id = 35;
					var2.Name = "p/#I3]X^&,J2\"z~P#eeX'Q<l-l";
					var2.Description = "8I0C8_19:5Q1DjI(\"\"X4I/:V_";
					var2.DisplayOrder = 54;
					var2.DateCreated = DateTime.MinValue;
					var2.IsReadOnly = true;
					//var3
					var3.Id = 17;
					var3.Name = "yc?Mby:GzO(;o5ygz-v4d)::4j6LOEQvlvz.&W(E`{b";
					var3.Description = "&Ql_)44%fV0|~]?.PB_|~yjN;k,\\QaH#";
					var3.DisplayOrder = 6;
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
					expected.Id = 81;
					expected.Description = "1DcI%gC$P5fN/Gb";
					expected.DisplayOrder = 89;
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
					expected.Id = 2;
					expected.Name = "E]cD82},x)A6y@m0q(E";
					expected.DisplayOrder = 56;
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
					expected.Id = 21;
					expected.Name = "u2c\">cv5[d8%4;/t=(F!{u\"";
					expected.Description = "mjEx%_lC2y&q6hP.#e:o{Z";
					expected.DisplayOrder = 36;
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
					expected.Id = 92;
					expected.Description = "OL1Kr,'L>s8Ksl9@?.51~;2Z=rly1TpO%PP9zQ";
					expected.DisplayOrder = 30;
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
					expected.Id = 12;
					expected.Name = "pg1B^$oqG.[>~\"=pJ.#mpi5HS;8edLLj27]&L)9~&a";
					expected.DisplayOrder = 9;
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
					expected.Id = 32;
					expected.Name = "58139{^O/KI9J*@nW/w&m$9As{/+X3r+K\\8u@LZ|MNa!Oi";
					expected.Description = ":?[}c+8qL?*bu8BGmla)\\~GsF};)W|B";
					expected.DisplayOrder = 6;
					expected.DateCreated = DateTime.MinValue;
					expected.IsReadOnly = false;
					putPreCall(expected, wrapper);
					context.Devices.Add(expected);
					context.SaveChanges();
					// Reset props and call put
					expected.Name = "`PI`-?q4!j42*'b%Hl/]HL2=I8N^*y";
					expected.Description = "D5W|AggfToTdAd_Kc";
					expected.DisplayOrder = 97;
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