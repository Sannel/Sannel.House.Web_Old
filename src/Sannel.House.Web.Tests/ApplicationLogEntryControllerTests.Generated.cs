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
					var1.DeviceId = 19;
					var1.ApplicationId = "JSf,'B,aI\"iZe6)eo2Nu";
					var1.Message = "0C>_\\bwAo&)LNud@c%T3;8yeKdEc_$v9H";
					var1.Exception = "OLgi-yrQrQ02uIF=DG(r51cQ]MCPj$.~3+,vE";
					var1.CreatedDate = DateTimeOffset.Now;
					// var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 39;
					var2.ApplicationId = "k[fPajf:'8W11\\q;^26<HNMV";
					var2.Message = "m@_^'T2Ew3cg#`eA4s.LthA@(OXe\\;xs'FFt$/?[.tIpO4";
					var2.Exception = "2}$Sje5v=p8";
					var2.CreatedDate = DateTimeOffset.Now;
					// var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 11;
					var3.ApplicationId = ":*CE|z\\Q06WQ]]{i7\\rG*-8kad`32<xHLE'pMyx%";
					var3.Message = "QeG}Jn`ZQ>\\O+";
					var3.Exception = "}=[)e'o.~kJFOLu]PK0{cF_}bJ?~i?";
					var3.CreatedDate = DateTimeOffset.Now;
					// var4
					var4.Id = Guid.NewGuid();
					var4.DeviceId = 30;
					var4.ApplicationId = "'KXS/9)9M+>D0AAvC\\a\\gN=s8Qx`g=2nE2&k_NiGG@/-";
					var4.Message = "r.9h.k{V:ovOfT?;)mG(o";
					var4.Exception = "7')r<4mnwq`~|1";
					var4.CreatedDate = DateTimeOffset.Now;
					// var5
					var5.Id = Guid.NewGuid();
					var5.DeviceId = 49;
					var5.ApplicationId = "^fX:'/8;DgwVF-FF|\\z2OS@o{:-<CehpkiX.cz@azE`\\JFQ%";
					var5.Message = "n35=f*aql-Wl-";
					var5.Exception = "h>X]a&@*%)-g3S{'V%V:e_a(4=gy5\\hXa6";
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
						var1.DeviceId = 49;
						var1.ApplicationId = "X:'/8;DgwVF-FF|\\z2OS@o{:-<Ce";
						var1.Message = "\\hXa6ksV[*<V";
						var1.Exception = "9x}CK$<]rj3";
						var1.CreatedDate = DateTimeOffset.Now;
						//var2
						var2.Id = Guid.NewGuid();
						var2.DeviceId = 95;
						var2.ApplicationId = "pkiX.cz@azE`\\JFQ%8n35=f*aql-W";
						var2.Message = "HD`?$/'>%gb(w&'/iq}G#SA&3";
						var2.Exception = "J{pmf9OszT'k/Z[k?LOvw78g_L83[H4#gVs,pq";
						var2.CreatedDate = DateTimeOffset.Now;
						//var3
						var3.Id = Guid.NewGuid();
						var3.DeviceId = 22;
						var3.ApplicationId = "-nh>X]a&@*%)-g3S{'V%V:e_a(4=gy";
						var3.Message = "_wn;<NNBa.(5NHD6^1w$AqZ+3B&9%42SN*o*oWk/qiSX]eyV";
						var3.Exception = "%,gg]1(_MSf]fAs\\|.Cyb1W4O.i2PsA-IClNHnEd1b-(B]c";
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
						var actual = controller.Get(var1.Id);
						Assert.NotNull(actual.Id);
						// var1 -> actual
						Assert.Equal(var1.Id, actual.Id);
						Assert.Equal(var1.DeviceId, actual.DeviceId);
						Assert.Equal(var1.ApplicationId, actual.ApplicationId);
						Assert.Equal(var1.Message, actual.Message);
						Assert.Equal(var1.Exception, actual.Exception);
						Assert.Equal(var1.CreatedDate, actual.CreatedDate);
						// Verify var2
						actual = controller.Get(var2.Id);
						Assert.NotNull(actual.Id);
						// var2 -> actual
						Assert.Equal(var2.Id, actual.Id);
						Assert.Equal(var2.DeviceId, actual.DeviceId);
						Assert.Equal(var2.ApplicationId, actual.ApplicationId);
						Assert.Equal(var2.Message, actual.Message);
						Assert.Equal(var2.Exception, actual.Exception);
						Assert.Equal(var2.CreatedDate, actual.CreatedDate);
						// Verify var3
						actual = controller.Get(var3.Id);
						Assert.NotNull(actual.Id);
						// var3 -> actual
						Assert.Equal(var3.Id, actual.Id);
						Assert.Equal(var3.DeviceId, actual.DeviceId);
						Assert.Equal(var3.ApplicationId, actual.ApplicationId);
						Assert.Equal(var3.Message, actual.Message);
						Assert.Equal(var3.Exception, actual.Exception);
						Assert.Equal(var3.CreatedDate, actual.CreatedDate);
					}
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
					expected.DeviceId = 69;
					expected.Message = "\"7XMa%VM,Wn";
					expected.Exception = "khJ2b\\W,Mn%r";
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
					expected.DeviceId = 41;
					expected.ApplicationId = "(CyVA)\"|^QnTXgq:fGVhiDyXXX;";
					expected.Exception = "#XHMk98cir;VbF^X+DG;]`GZ}C6dxs1:P#veH.";
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
					expected.DeviceId = 60;
					expected.ApplicationId = "C;y1QGO$4LCHnJr8wG48nmoJz08Wm6q";
					expected.Message = "tsATWVt'trx%H+K,1<u%MkVq~jdzO4x>x@h!6m]";
					expected.Exception = "hj}+5#1_)fQ.O8SGlgz@fAHq}";
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