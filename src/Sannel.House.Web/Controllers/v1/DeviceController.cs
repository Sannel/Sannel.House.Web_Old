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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sannel.House.Web.Data;
using Sannel.House.Web.Interfaces;
using Sannel.House.Web.Models;
using Sannel.House.Web.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sannel.House.Web.Controllers.v1
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class DeviceController : BaseController
	{
		private IDataRepository dataRepo;
		/// <summary>
		/// Initializes a new instance of the <see cref="DeviceController"/> class.
		/// </summary>
		/// <param name="dataRepo">The data repo.</param>
		/// <exception cref="System.ArgumentNullException">dataRepo</exception>
		public DeviceController(IDataRepository dataRepo)
		{
			this.dataRepo = dataRepo ?? throw new ArgumentNullException(nameof(dataRepo));
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		[Authorize(Roles = RoleNames.GetDevice + "," + RoleNames.Administrators)]
		public async Task<ActionResult<Device>> Get(int id)
		{
			var d = await dataRepo.GetDeviceAsync(id);

			if(d == null)
			{
				return NotFound();
			}

			return Ok(d);
		}

	}
}
