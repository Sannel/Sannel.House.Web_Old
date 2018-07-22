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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sannel.House.Web.Controllers;
using Sannel.House.Web.Controllers.v1;
using Sannel.House.Web.Interfaces;
using Sannel.House.Web.Models;
using Sannel.House.Web.Tests.RepositoryTests;
using Sannel.House.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sannel.House.Web.Tests.ControllerTests.v1
{
	public class AuthzControllerTests : BaseDataContextTests
	{
		protected override void AddServices(IServiceCollection services)
		{
			base.AddServices(services);
			services.AddTransient<AuthzController>();
		}

		[Fact]
		public async Task PostNullAsyncTest()
		{
			var controller = provider.GetService<AuthzController>();
			Assert.NotNull(controller);
			var result = await controller.Post(null);
			Assert.IsType<BadRequestResult>(result);
			var r = (BadRequestResult)result;
			Assert.Equal(400, r.StatusCode);
		}

		[Theory]
		[InlineData("Token")]
		[InlineData("UsernamePassword")]
		[InlineData("test")]
		public async Task PostNonPasswordGrantAsyncTest(string grantType)
		{
			var controller = provider.GetService<AuthzController>();
			Assert.NotNull(controller);
			var result = await controller.Post(new LoginRequest()
			{
				GrantType = grantType,
				Username = "username",
				Password = "password"
			});
			Assert.IsType<BadRequestObjectResult>(result);
			var r = (BadRequestObjectResult)result;
			Assert.Equal(400, r.StatusCode);
			Assert.Equal("Invalid Grant Type", r.Value);
		}

		[Theory]
		[InlineData("Admin","b")]
		[InlineData("user","c")]
		public async Task LoginInvalidUsernamePasswordAsyncTest(string username, string password)
		{
			await PrepareDatabaseAsync();
			var manager = provider.GetService<UserManager<ApplicationUser>>();
			await manager.CreateAsync(new ApplicationUser()
			{
				UserName = "Admin"
			}, "c");

			var controller = provider.GetService<AuthzController>();
			var result = await controller.Post(new LoginRequest()
			{
				GrantType = "password",
				Username = username,
				Password = password
			});
			Assert.IsType<BadRequestObjectResult>(result);
			var r = (BadRequestObjectResult)result;
			Assert.Equal(400, r.StatusCode);
			Assert.Equal("", r.Value);
		}
	}
}