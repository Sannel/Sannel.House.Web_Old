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
					var1.DeviceId = 3;
					var1.ApplicationId = "klr/*rAc8]$6,6AZ?K`m|iG2%\"QrX./X<r4S7$>tS:F";
					var1.Message = "}}~tMa}Q!]7=T";
					var1.Exception = "dy/dWs}q9w2>FDLWH\"xO_";
					var1.CreatedDate = DateTime.Now;
					// var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 23;
					var2.ApplicationId = "#=r{-:n`Vnj%taF0HK-&`%KMK8*+yF-WDWOCpDSNlo~[w*#";
					var2.Message = "x]+<i`B<+uZ2.r/-hH]QIZO36#T";
					var2.Exception = "5dQnCDOBl~eDP},3Z}w$O2XgHlOWE(X$wr";
					var2.CreatedDate = DateTime.Now;
					// var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 42;
					var3.ApplicationId = "K}eJ1\\saAGG";
					var3.Message = "3DJtQK(H*2ZXjwD(S<vdm1[";
					var3.Exception = "Tpvz)ZhTKP%";
					var3.CreatedDate = DateTime.Now;
					// var4
					var4.Id = Guid.NewGuid();
					var4.DeviceId = 14;
					var4.ApplicationId = "^c|Fyg]*yDG>aSq@;(hW/^2h1-,";
					var4.Message = "b[d)D[XK#x";
					var4.Exception = "sxku:P&t|\"F6F>d";
					var4.CreatedDate = DateTime.Now;
					// var5
					var5.Id = Guid.NewGuid();
					var5.DeviceId = 33;
					var5.ApplicationId = "\"%|Z*2(Q#`-9-=rpo(n+\"36\\Wt$>4xC";
					var5.Message = "m{v<h@N5w1I";
					var5.Exception = "+IuLhAb-$4.J-t&XJ";
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
					var1.DeviceId = 17;
					var1.ApplicationId = ";`Mz8%*IaX,kmTS5nM\\+;6x,t";
					var1.Message = "/ZVtb(=1K9X,uZvyDZ";
					var1.Exception = "%Q$s8ec~]7F[:(5f%\\K6z5z\"A*Mit+54N,ZJapyqOl=-J";
					var1.CreatedDate = DateTime.Now;
					//var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 92;
					var2.ApplicationId = "vlN]K[1%5Ef&";
					var2.Message = "vG-D\\I|GlO$xT>F[yx83Kdi&b|";
					var2.Exception = "m`O*Q=+iy=9wWKu^";
					var2.CreatedDate = DateTime.Now;
					//var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 37;
					var3.ApplicationId = "OmppNHJ&;j#$%j7Ldat^2nI|24*h\\,8vo7IQ~EmFjJ41A";
					var3.Message = "rP^~3~m#[;8jmHanqQ'%.zh(SILz-s";
					var3.Exception = "-1}s*u^3F7xu3V\\4nnM/8mVAcq}{-OhBjI`07Io.j%";
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
					expected.DeviceId = 88;
					expected.Message = "P&>Mwn5?FTaz2h6;.sLGHd";
					expected.Exception = "/7d#J[NG^2Sl`'K20$thx_sN6NM|Tb6h+zr\"";
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
					expected.DeviceId = 9;
					expected.ApplicationId = "[K<5$!Za/Z{EPK9}hd<\\6qIbPQ";
					expected.Exception = "FJ0q?K-%=KdHPVKHLGB>@'Vq1FQy0=orl\\7v;n}";
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
					expected.DeviceId = 28;
					expected.ApplicationId = "6f<~7IPLh95G\\^=<rd82e0};p:wAq+";
					expected.Message = "AWf\")!5,yQu@@i\\`_~XGt1(%NIa|%]Nc%yq=Mt\"G";
					expected.Exception = "H}uNBc@ML3mpf\\}a_V'O";
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