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
	public partial class ApplicationLogEntryControllerTests : IContextWrapperTest
	{
		[Fact]
		public void GetPagedTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<ApplicationLogEntryController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new ApplicationLogEntryController(context, logger))
				// Fix order
				{
					var var1 = new ApplicationLogEntry();
					var var2 = new ApplicationLogEntry();
					var var3 = new ApplicationLogEntry();
					var var4 = new ApplicationLogEntry();
					var var5 = new ApplicationLogEntry();
					// var1
					var1.Id = Guid.NewGuid();
					var1.DeviceId = 32;
					var1.ApplicationId = "w]9syrzy``n:o%";
					var1.Message = "M@5Hx;1.HO++M96dm\"OFqr]lI|&OT@2S_)..]J}v+A_P";
					var1.Exception = "3v(V'>>/px,|";
					var1.CreatedDate = DateTimeOffset.Now;
					// var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 4;
					var2.ApplicationId = "Q(']Wok~c>nlA#wD3d7]B%S]&90PCj";
					var2.Message = "\\49e9Fc8b6Kb:5lXh<6ZV(";
					var2.Exception = "cff=#c)A*6Q#fQ:%?dugt8nXuT%m|Jbp#s";
					var2.CreatedDate = DateTimeOffset.Now;
					// var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 23;
					var3.ApplicationId = "tL'jxVyc\\$C.g't1:d$2#2Gy\"eWTuQS%:d";
					var3.Message = "&0#Z^FuB@n1Bvc3a(d%aw3$m)(.^}[O|2z9XTx>^G8.{Lo8-e";
					var3.Exception = "'{W2E#Cz,M@=$A\"(X3f";
					var3.CreatedDate = DateTimeOffset.Now;
					// var4
					var4.Id = Guid.NewGuid();
					var4.DeviceId = 42;
					var4.ApplicationId = "`g'vdg#`)p*A#Xi*Ode,]LLq;l(QFJ)>TDWu\\S";
					var4.Message = "H'L+g~jME@1MxQDq~m(5B*l%\\=(6o*1GVAh7z";
					var4.Exception = "p=3zzhS:TeXk;P@O}v2/LtZavd!$2D@OP";
					var4.CreatedDate = DateTimeOffset.Now;
					// var5
					var5.Id = Guid.NewGuid();
					var5.DeviceId = 62;
					var5.ApplicationId = "W8;Ey21s8v'Z:_[dzda*/EZ&#PF,(`O|;=ugPohaq";
					var5.Message = ",AT>?SA>h::o~>%wjm&p$8:S";
					var5.Exception = "PCCP@<?N+5-;%{1L)kJ\"~?i+";
					var5.CreatedDate = DateTimeOffset.Now;
					var order = DateTimeOffset.Now;
					var1.CreatedDate = order;
					var2.CreatedDate = order.AddDays(-1);
					var3.CreatedDate = order.AddDays(-2);
					var4.CreatedDate = order.AddDays(-3);
					var5.CreatedDate = order.AddDays(-4);
					// Add to database
					context.ApplicationLogEntries.Add(var1);
					context.ApplicationLogEntries.Add(var2);
					context.ApplicationLogEntries.Add(var3);
					context.ApplicationLogEntries.Add(var4);
					context.ApplicationLogEntries.Add(var5);
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
					Assert.Equal(var1.DeviceId, actual.DeviceId);
					Assert.Equal(var1.ApplicationId, actual.ApplicationId);
					Assert.Equal(var1.Message, actual.Message);
					Assert.Equal(var1.Exception, actual.Exception);
					Assert.Equal(var1.CreatedDate, actual.CreatedDate);
					// var2
					actual = list[1];
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.DeviceId, actual.DeviceId);
					Assert.Equal(var2.ApplicationId, actual.ApplicationId);
					Assert.Equal(var2.Message, actual.Message);
					Assert.Equal(var2.Exception, actual.Exception);
					Assert.Equal(var2.CreatedDate, actual.CreatedDate);
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
					Assert.Equal(var3.DeviceId, actual.DeviceId);
					Assert.Equal(var3.ApplicationId, actual.ApplicationId);
					Assert.Equal(var3.Message, actual.Message);
					Assert.Equal(var3.Exception, actual.Exception);
					Assert.Equal(var3.CreatedDate, actual.CreatedDate);
					// var4
					actual = list[1];
					// var4 -> actual
					Assert.Equal(var4.Id, actual.Id);
					Assert.Equal(var4.DeviceId, actual.DeviceId);
					Assert.Equal(var4.ApplicationId, actual.ApplicationId);
					Assert.Equal(var4.Message, actual.Message);
					Assert.Equal(var4.Exception, actual.Exception);
					Assert.Equal(var4.CreatedDate, actual.CreatedDate);
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
					Assert.Equal(var5.DeviceId, actual.DeviceId);
					Assert.Equal(var5.ApplicationId, actual.ApplicationId);
					Assert.Equal(var5.Message, actual.Message);
					Assert.Equal(var5.Exception, actual.Exception);
					Assert.Equal(var5.CreatedDate, actual.CreatedDate);
				}
			}
		}

		[Fact]
		public void GetWithIdTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<ApplicationLogEntryController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new ApplicationLogEntryController(context, logger))
				{
					var var1 = new ApplicationLogEntry();
					var var2 = new ApplicationLogEntry();
					var var3 = new ApplicationLogEntry();
					//var1
					var1.Id = Guid.NewGuid();
					var1.DeviceId = 62;
					var1.ApplicationId = ";Ey21s8v'Z:_[";
					var1.Message = ")kJ\"~?i+\\\":^Z#;XCn):L)rX:aLC6Aq\"%;Vv2Z&{'.w+";
					var1.Exception = "0AWKcyb%MGA4!~Ceo4yh\"vNJrxS-LC*SwyWeO";
					var1.CreatedDate = DateTimeOffset.Now;
					//var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 79;
					var2.ApplicationId = "zda*/EZ&#PF,(`O|;=ugPohaqi,A";
					var2.Message = "S49l&mvg~?`$B1";
					var2.Exception = "Gkzjs*}:*BM%&47@D;HHl1zgy4v?}Ffnbf*JVp~I8drK!Q";
					var2.CreatedDate = DateTimeOffset.Now;
					//var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 67;
					var3.ApplicationId = ">?SA>h::o~>%wjm&p$8:SiPCCP@<?N+5-;%{1";
					var3.Message = "=s%.v>`i(N:1olr&N3D8p|pK!I[5;Cp7\"lb8a/";
					var3.Exception = "$I-'~h\"oFN7~p/}0\\gub|F*(]p0{6EIeEu[q,";
					var3.CreatedDate = DateTimeOffset.Now;
					//Fix Order
					var order = DateTimeOffset.Now;
					var3.CreatedDate = order;
					var2.CreatedDate = order.AddDays(-1);
					var1.CreatedDate = order.AddDays(-2);
					// Add and save entities
					context.ApplicationLogEntries.Add(var1);
					context.ApplicationLogEntries.Add(var2);
					context.ApplicationLogEntries.Add(var3);
					wrapper.SaveChanges();
					// verify
					var results = controller.Get(var1.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					var actual = results.Data;
					// var1 -> actual
					Assert.Equal(var1.Id, actual.Id);
					Assert.Equal(var1.DeviceId, actual.DeviceId);
					Assert.Equal(var1.ApplicationId, actual.ApplicationId);
					Assert.Equal(var1.Message, actual.Message);
					Assert.Equal(var1.Exception, actual.Exception);
					Assert.Equal(var1.CreatedDate, actual.CreatedDate);
					// verify var2
					results = controller.Get(var2.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var2 -> actual
					Assert.Equal(var2.Id, actual.Id);
					Assert.Equal(var2.DeviceId, actual.DeviceId);
					Assert.Equal(var2.ApplicationId, actual.ApplicationId);
					Assert.Equal(var2.Message, actual.Message);
					Assert.Equal(var2.Exception, actual.Exception);
					Assert.Equal(var2.CreatedDate, actual.CreatedDate);
					// verify var3
					results = controller.Get(var3.Id);
					Assert.NotNull(results);
					Assert.True(results.Success);
					actual = results.Data;
					Assert.NotNull(actual.Id);
					// var3 -> actual
					Assert.Equal(var3.Id, actual.Id);
					Assert.Equal(var3.DeviceId, actual.DeviceId);
					Assert.Equal(var3.ApplicationId, actual.ApplicationId);
					Assert.Equal(var3.Message, actual.Message);
					Assert.Equal(var3.Exception, actual.Exception);
					Assert.Equal(var3.CreatedDate, actual.CreatedDate);
					// Failed Test
					results = controller.Get(Guid.Empty);
					Assert.NotNull(results);
					Assert.False(results.Success);
					Assert.Equal(1, results.Errors.Count);
					Assert.Equal($"Could not find ApplicationLogEntry with Id {Guid.Empty}", results.Errors[0]);
				}
			}
		}

		[Fact]
		public void PostTest()
		{
			var logFactory = new LoggerFactory();
			var logger = logFactory.CreateLogger<ApplicationLogEntryController>();
			using (var wrapper = new ContextWrapper(this))
			{
				var context = wrapper.Context;
				using (var controller = new ApplicationLogEntryController(context, logger))
				{
					var result = controller.Post(null);
					Assert.NotNull(result);
					Assert.False(result.Success);
					Assert.Equal(1, result.Errors.Count);
					Assert.Equal("data cannot be null", result.Errors[0]);
					Assert.Null(result.Data);
					var expected = new ApplicationLogEntry();
					// ApplicationId
					expected = new ApplicationLogEntry();
					expected.Id = Guid.NewGuid();
					expected.DeviceId = 34;
					expected.Message = "3V>.E7<*Wc''_(Kw\\";
					expected.Exception = "E75:2FTz.[5avxTlLq^z4rb?jNvh01h]{[+(-@Z@N-sc";
					expected.CreatedDate = DateTimeOffset.Now;
					expected.ApplicationId = null;
					postPreCall(expected, wrapper);
					result = controller.Post(expected);
					Assert.NotNull(result);
					Assert.False(result.Success);
					Assert.Equal(1, result.Errors.Count);
					Assert.Equal("ApplicationId must not be null", result.Errors[0]);
					Assert.NotNull(result.Data);
					// Message
					expected = new ApplicationLogEntry();
					expected.Id = Guid.NewGuid();
					expected.DeviceId = 53;
					expected.ApplicationId = "I'>{c,FWkAKW<n\"l)KFEw";
					expected.Exception = "6}y|%ikb5tl:;]l!KBtjJ)=<~08o+IhJ>`f&p";
					expected.CreatedDate = DateTimeOffset.Now;
					expected.Message = "";
					postPreCall(expected, wrapper);
					result = controller.Post(expected);
					Assert.NotNull(result);
					Assert.False(result.Success);
					Assert.Equal(1, result.Errors.Count);
					Assert.Equal("Message must have a non empty value", result.Errors[0]);
					Assert.NotNull(result.Data);
					// Success Test
					expected = new ApplicationLogEntry();
					expected.Id = Guid.NewGuid();
					expected.DeviceId = 72;
					expected.ApplicationId = "o!<Hf$.9y>@FW<X{9LVq';9E`";
					expected.Message = "AtN|l0y^^'H}/z6`$zWd@^TyF2TaJK4qHh\\e~vd4dd}iXy%i";
					expected.Exception = ";tz`'Dz.bMh\\Coih'V!";
					expected.CreatedDate = DateTimeOffset.Now;
					postPreCall(expected, wrapper);
					result = controller.Post(expected);
					Assert.NotNull(result);
					Assert.True(result.Success, "Success was not true");
					Assert.Equal(0, result.Errors.Count);
					Assert.NotNull(result.Data);
					Assert.True(result.Data.Id != Guid.NewGuid());
					var first = context.ApplicationLogEntries.FirstOrDefault((i) => i.Id == result.Data.Id);
					Assert.NotNull(first);
					var resultData = result.Data;
					Assert.Equal(first.Id, resultData.Id);
					Assert.Equal(first.DeviceId, resultData.DeviceId);
					Assert.Equal(first.ApplicationId, resultData.ApplicationId);
					Assert.Equal(first.Message, resultData.Message);
					Assert.Equal(first.Exception, resultData.Exception);
					Assert.Equal(first.CreatedDate, resultData.CreatedDate);
				}
			}
		}

		// used to make sure reference tables have data needed for a test to succeed
		partial void postPreCall(ApplicationLogEntry data, ContextWrapper wrapper);
	}
}