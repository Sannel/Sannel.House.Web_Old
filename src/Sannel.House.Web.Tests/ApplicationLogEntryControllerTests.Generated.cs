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
					var1.DeviceId = 57;
					var1.ApplicationId = "h}%=g6KrH]}G6~LGoFZ&=8-4Z@~Pv6";
					var1.Message = "iS7LDBB(cem7hIHADA1";
					var1.Exception = "[Xyo[m~(wC-P}#o3?q5:sxeXl`.t5puNc]Hd";
					var1.CreatedDate = DateTime.Now;
					// var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 76;
					var2.ApplicationId = "!i$*imE}Wn5NAk\"3&F`HiC@?'oIT3*E~n\\";
					var2.Message = "V)'3$4-\\S)eF\"o>$O0B*(%%E?X?OaCC";
					var2.Exception = "y<MSE|GA(hoP*cGr43<2W$q";
					var2.CreatedDate = DateTime.Now;
					// var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 48;
					var3.ApplicationId = ";%.%IW/z(b5b@jt\"7%)WS8wc5%zfKQzNSF4PPIn7u{w<~GV08";
					var3.Message = "d*lF^aZ6=j-#Ic30Gudn~ov#r3";
					var3.Exception = "t\\(+ais^r\\>bnJQx9M#3OV3`xQh)6.yg#,z.Z&EF_u";
					var3.CreatedDate = DateTime.Now;
					// var4
					var4.Id = Guid.NewGuid();
					var4.DeviceId = 68;
					var4.ApplicationId = "%G.qb&h?7DoO:";
					var4.Message = "i9V%oq1VykI]0aqH2Pn!OL3e[T8)._EwM^To>zPp6_g-";
					var4.Exception = "#04T(A.0O=k5nDE$|q6G]dZ{CKg?^7doC";
					var4.CreatedDate = DateTime.Now;
					// var5
					var5.Id = Guid.NewGuid();
					var5.DeviceId = 87;
					var5.ApplicationId = "La,ogAr\\V`EKx^[r|";
					var5.Message = "jZ)}osumW[{`hjaj[>";
					var5.Exception = "C%eH|>x*S>ewukLB>V04#1L9";
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
					var1.DeviceId = 87;
					var1.ApplicationId = ",ogAr\\V`EKx^[r|%jZ)}osumW[{";
					var1.Message = "mxscqV@Zy%C7555iCj\"o/L}Vat*<s";
					var1.Exception = "sp]<[cT%|S1,hH&k";
					var1.CreatedDate = DateTime.Now;
					//var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 19;
					var2.ApplicationId = "hjaj[>yC%e";
					var2.Message = "{Gwa\"n<jlhFMQ>=]I}~";
					var2.Exception = "bqn0DsuxDmjzk3,7cIGwZG\\-x4{=r%i&bbjh15.N5[nM";
					var2.CreatedDate = DateTime.Now;
					//var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 86;
					var3.ApplicationId = "|>x*S>ewukLB>V04#1L9CEVk#\\6G]<K`$5jAF^c,i9p";
					var3.Message = "OL&`H|Gl~NE$d0f9S,";
					var3.Exception = "/){o'X0]^<ALgz{I&";
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
					expected.DeviceId = 7;
					expected.Message = ";4,fir!K|%?>_ca'b^mjj";
					expected.Exception = "\\p1H*i#@M+)J70Qk`Cx_tLS_1]Zr3#~cS";
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
					expected.DeviceId = 78;
					expected.ApplicationId = "X\"7aIo0/t#?,Qx\"ofb:yX|z<l/7=?bH7a&vC";
					expected.Exception = "ExF\"Z%4WA=.m}wT";
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
					expected.DeviceId = 98;
					expected.ApplicationId = "cj6lbBN7#pw}iVCben?N~bvX#L.9s|qL)c_4sqi\\";
					expected.Message = "['y^)@{&OH1|2m<X@y{qJ.]8sjD/:~2*xt";
					expected.Exception = "4(ECTX\"OV+9&Nq=+B,-A}-(A}o7yxFA$E:V/g\\4";
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