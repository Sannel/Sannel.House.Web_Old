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
	public class ApplicationLogEntryControllerTests
	{
		[Fact]
		public void GetTest()
		{
			using (var wrapper = new ContextWrapper())
			{
				var context = wrapper.Context;
				using (var controller = new ApplicationLogEntryController(context))
				{
					var var1 = new ApplicationLogEntry();
					var var2 = new ApplicationLogEntry();
					var var3 = new ApplicationLogEntry();
					//var1
					var1.Id = Guid.NewGuid();
					var1.DeviceId = 6;
					var1.ApplicationId = "wG-'d4ZGM-Gj+?\\}@oLBM~8,+m<48=};h6n1\"Xe+?/l,pCH\"";
					var1.Message = "P)7d+p/g%~CT";
					var1.Exception = "]B1~}a^1=7Bz~kcSD42Gg+v68a\"ot07L2SI>-tL~#S)J_ve/";
					var1.CreatedDate = DateTimeOffset.Now;
					//var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 67;
					var2.ApplicationId = "~BWF*>~Ph)H7KPGo+1%o]:_";
					var2.Message = "9X,jC+Qn^qWl_(Z3>-Sn";
					var2.Exception = "`:h\\Ih=yB4r";
					var2.CreatedDate = DateTimeOffset.Now;
					//var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 18;
					var3.ApplicationId = "vNe,d(iS8OB%";
					var3.Message = "'}0V=gmvpFpV%~d!bDQ;dl";
					var3.Exception = "HW1`6;uDvQd$:.T2}Dk0&ut(varwc,#+";
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
					context.SaveChanges();
					//call get method
					var results = controller.Get();
					Assert.NotNull(results);
					var list = results.ToList();
					Assert.Equal(3, list.Count);
					var one = list[0];
					// var3 -> one
					Assert.Equal(var3.Id, one.Id);
					Assert.Equal(var3.DeviceId, one.DeviceId);
					Assert.Equal(var3.ApplicationId, one.ApplicationId);
					Assert.Equal(var3.Message, one.Message);
					Assert.Equal(var3.Exception, one.Exception);
					Assert.Equal(var3.CreatedDate, one.CreatedDate);
					var two = list[1];
					// var2 -> two
					Assert.Equal(var2.Id, two.Id);
					Assert.Equal(var2.DeviceId, two.DeviceId);
					Assert.Equal(var2.ApplicationId, two.ApplicationId);
					Assert.Equal(var2.Message, two.Message);
					Assert.Equal(var2.Exception, two.Exception);
					Assert.Equal(var2.CreatedDate, two.CreatedDate);
					var three = list[2];
					// var1 -> three
					Assert.Equal(var1.Id, three.Id);
					Assert.Equal(var1.DeviceId, three.DeviceId);
					Assert.Equal(var1.ApplicationId, three.ApplicationId);
					Assert.Equal(var1.Message, three.Message);
					Assert.Equal(var1.Exception, three.Exception);
					Assert.Equal(var1.CreatedDate, three.CreatedDate);
				}
			}
		}

		[Fact]
		public void GetWithIdTest()
		{
			using (var wrapper = new ContextWrapper())
			{
				var context = wrapper.Context;
				using (var controller = new ApplicationLogEntryController(context))
				{
					var var1 = new ApplicationLogEntry();
					var var2 = new ApplicationLogEntry();
					var var3 = new ApplicationLogEntry();
					//var1
					var1.Id = Guid.NewGuid();
					var1.DeviceId = 6;
					var1.ApplicationId = "wG-'d4ZGM-Gj+?\\}@oLBM~8,+m<48=};h6n1\"Xe+?/l,pCH\"";
					var1.Message = "P)7d+p/g%~CT";
					var1.Exception = "]B1~}a^1=7Bz~kcSD42Gg+v68a\"ot07L2SI>-tL~#S)J_ve/";
					var1.CreatedDate = DateTimeOffset.Now;
					//var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 67;
					var2.ApplicationId = "~BWF*>~Ph)H7KPGo+1%o]:_";
					var2.Message = "9X,jC+Qn^qWl_(Z3>-Sn";
					var2.Exception = "`:h\\Ih=yB4r";
					var2.CreatedDate = DateTimeOffset.Now;
					//var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 18;
					var3.ApplicationId = "vNe,d(iS8OB%";
					var3.Message = "'}0V=gmvpFpV%~d!bDQ;dl";
					var3.Exception = "HW1`6;uDvQd$:.T2}Dk0&ut(varwc,#+";
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
					context.SaveChanges();
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
}