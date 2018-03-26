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
using Microsoft.AspNetCore.Mvc;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Base.Interfaces;
using Microsoft.Extensions.Logging;
using Sannel.House.Web.Base;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Sannel.House.Web.Controllers.api
{
	[Authorize()]
	[Route("api/v1/[controller]")]
	public partial class AlternateDeviceIdController : Controller
	{
		private IDataContext context;
		private ILogger logger;
		public AlternateDeviceIdController(IDataContext context, ILogger<AlternateDeviceIdController> logger)
		{
			this.context = context;
			this.logger = logger;
		}

		[HttpGet("GetPaged")]
		[Authorize(Roles = "DeviceList")]
		public PagedResults<AlternateDeviceId> GetPaged()
		{
			var use = User.Claims.FirstOrDefault(i => i.Type == JwtRegisteredClaimNames.Sub);
			return GetPaged(1, 25);
		}

		[HttpGet("GetPaged/{page}")]
		[Authorize(Roles = "DeviceList")]
		public PagedResults<AlternateDeviceId> GetPaged(int page)
		{
			return GetPaged(page, 25);
		}

		[HttpGet("GetPaged/{page}/{pageSize}")]
		[Authorize(Roles = "DeviceList")]
		public PagedResults<AlternateDeviceId> GetPaged(int page, int pageSize)
		{
			return internalGetPaged(page, pageSize);
		}

		[HttpGet("{id}")]
		[Authorize(Roles = "DeviceList")]
		public Result<AlternateDeviceId> Get(int id)
		{
			return internalGet(id);
		}

		[HttpGet("{id}")]
		public Result<AlternateDeviceId> GetFromSystemUuid(Guid uuid)
		{
			var results = new Result<AlternateDeviceId>();
			var ids = context.AlternateDeviceIds.FirstOrDefault(i => i.Uuid == uuid);

			if(ids == null)
			{
				results.Success = false;
				results.AddError($"No alternate id for {uuid}");
			}
			else
			{
				results.Success = true;
				results.Data = ids;
			}

			return results;
		}

		[HttpPost]
		public Result<AlternateDeviceId> Post([FromBody]AlternateDeviceId data)
		{
			return internalPost(data);
		}
	}
}