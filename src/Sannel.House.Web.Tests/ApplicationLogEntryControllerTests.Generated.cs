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
					var1.DeviceId = 98;
					var1.ApplicationId = "(Zx+ZGM38N_C|:P)>\\;e2KgyN=igNfZOqiJ%P0a";
					var1.Message = "v'}(e?VsGCoJvWI[\\^r|dg7m5'm[2;l:?OOg8*3M%C";
					var1.Exception = "384=m/aAkDQu0f-#|o;\\qpjJLN&w$#ix;G3l";
					var1.CreatedDate = DateTime.Now;
					// var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 43;
					var2.ApplicationId = "Aqqyrc~dC*gskI?&-nh>=Zm+{(8Q$D";
					var2.Message = "`T\"pqv=ekS?L/\"3E";
					var2.Exception = "z6jT0ao:Q1n6hg)-6g{mrT";
					var2.CreatedDate = DateTime.Now;
					// var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 22;
					var3.ApplicationId = ";K6utqN$PK%K,";
					var3.Message = "'xzbKQCF=KhWjf|ccZ-F,";
					var3.Exception = "@a!=H6M'\\#/<7ABnmx@OI";
					var3.CreatedDate = DateTime.Now;
					// var4
					var4.Id = Guid.NewGuid();
					var4.DeviceId = 87;
					var4.ApplicationId = "5nA^Bt22W\\Bci65.n?i>WNb%$6Ps|4js8/w:n";
					var4.Message = "5)6)q4<IgEm-[";
					var4.Exception = "KZ101c2Lnv),ChgOA#2";
					var4.CreatedDate = DateTime.Now;
					// var5
					var5.Id = Guid.NewGuid();
					var5.DeviceId = 15;
					var5.ApplicationId = "AjPh$65F+qK,Hv+<bGW21`x?e;v*";
					var5.Message = "HwE>]d:qc})&HtuFIovwaAjV0sABP#/hH1s?@/]=]";
					var5.Exception = "15\\F#Q%$n!`Vu4D|L<WVx[9A[G\"u.5MsZ}}ak";
					var5.CreatedDate = DateTime.Now;
					var order = DateTime.Now;
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
					var1.DeviceId = 92;
					var1.ApplicationId = "u*bXi_;\"lel]W`=6o9qW`BlFBQ.";
					var1.Message = ">IT|\\'?)_GN.3]BwVL:=.g+i2x(uqnD,Oj";
					var1.Exception = "}$aM|[C)Xg&(A";
					var1.CreatedDate = DateTime.Now;
					//var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 34;
					var2.ApplicationId = "gvlGlM]<5D/_~G:9,}vPDh:G48";
					var2.Message = "&9Bf!bZ{Akij|-0(e%|>katPKw";
					var2.Exception = "h7SG]Dw'\">28VaSSKcF/}/^0IH)9xNO_=L+-H4z=S%esVW";
					var2.CreatedDate = DateTime.Now;
					//var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 78;
					var3.ApplicationId = "]IS<Im0[BDI\"Iv!1vd1;#5\\##6X";
					var3.Message = "</2eV;`O%>[O'{{kK/6g*@ugaNkXS|%nLMV";
					var3.Exception = "gg-,/a0@HLW0c'%<B_}M5!/NF2W:";
					var3.CreatedDate = DateTime.Now;
					//Fix Order
					var order = DateTime.Now;
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
					expected.DeviceId = 89;
					expected.Message = "dV26tP(aB{*|X~CKOasFcjkk^I[jILL5yQ9[|^}$OMr'3||M0";
					expected.Exception = "wDs7\\N\\lK,r{O7:#\\*4l8kE)";
					expected.CreatedDate = DateTime.Now;
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
					expected.DeviceId = 35;
					expected.ApplicationId = "j|-~0s$[*o_/b$7b'!xn:W(`(_o@6F/xp^p";
					expected.Exception = "Ta8a>JD!+PKos;S2~}}Hl0ZK62taPI_oD";
					expected.CreatedDate = DateTime.Now;
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
					expected.DeviceId = 97;
					expected.ApplicationId = "a*7?etGqrh31z{j1vu)lcONjMi>Tw/%hO[";
					expected.Message = "9cAn4on<[WE^~%]_<'d2I+c2By->Wq'w~`[aG}^";
					expected.Exception = "M}zG+~Hh\"o*N)o3";
					expected.CreatedDate = DateTime.Now;
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