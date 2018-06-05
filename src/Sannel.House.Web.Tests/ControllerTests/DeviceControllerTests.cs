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
using Microsoft.AspNetCore.Mvc;
using Sannel.House.Web.Controllers;
using Sannel.House.Web.Interfaces;
using Sannel.House.Web.Models;
using Sannel.House.Web.Tests.RepositoryTests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sannel.House.Web.Tests.ControllerTests
{
	public class DeviceControllerTests
	{
		[Fact]
		public async Task GetTest()
		{
			var dr = new DataRepositoryMock();
			var controller = new DeviceController(dr);

			var testId = 1;
			var called = false;

			dr.GetDeviceFunc = (id) => Task.Run(() =>
				{
					called = true;
					Assert.Equal(testId, id);
					return (Device)null;
				});

			var actual = await controller.Get(testId);

			Assert.IsType<NotFoundResult>(actual.Result);
			Assert.True(called);
			Assert.Null(actual.Value);

			called = false;

			var expected = new Device()
			{
				Id = testId,
				DateCreated = DateTime.Now,
				Description = "Description",
				Name = "Name",
				DisplayOrder = 50,
				IsReadOnly = true
			};

			dr.GetDeviceFunc = (id) => Task.Run(() =>
			{
				called = true;
				Assert.Equal(expected.Id, id);
				return expected;
			});

			actual = await controller.Get(expected.Id);

			Assert.IsType<OkObjectResult>(actual.Result);
			Assert.True(called);
			var oor = (OkObjectResult)actual.Result;
			Assert.NotNull(oor.Value);
			Assert.IsType<Device>(oor.Value);
			var d = (Device)oor.Value;
			Assert.Equal(expected.Id, d.Id);
			Assert.Equal(expected.DateCreated, d.DateCreated);
			Assert.Equal(expected.Description, d.Description);
			Assert.Equal(expected.Name, d.Name);
			Assert.Equal(expected.DisplayOrder, d.DisplayOrder);
			Assert.Equal(expected.IsReadOnly, d.IsReadOnly);
		}
	}
}
