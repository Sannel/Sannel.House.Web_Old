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
using Microsoft.Extensions.DependencyInjection;
using Sannel.House.Web.Controllers;
using Sannel.House.Web.Controllers.v1;
using Sannel.House.Web.Interfaces;
using Sannel.House.Web.Models;
using Sannel.House.Web.Tests.RepositoryTests;
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
		}
	}
}