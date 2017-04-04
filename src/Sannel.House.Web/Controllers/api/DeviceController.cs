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
	[Route("api/[controller]")]
	public partial class DeviceController : Controller
	{
		private IDataContext context;
		private ILogger logger;
		public DeviceController(IDataContext context, ILogger<DeviceController> logger)
		{
			this.context = context;
			this.logger = logger;
		}

		[HttpGet("GetPaged")]
		[Authorize(Roles = "DeviceList")]
		public PagedResults<Device> GetPaged()
		{
			var use = User.Claims.FirstOrDefault(i => i.Type == JwtRegisteredClaimNames.Sub);
			return GetPaged(1, 25);
		}

		[HttpGet("GetPaged/{page}")]
		[Authorize(Roles = "DeviceList")]
		public PagedResults<Device> GetPaged(int page)
		{
			return GetPaged(page, 25);
		}

		[HttpGet("GetPaged/{page}/{pageSize}")]
		[Authorize(Roles = "DeviceList")]
		public PagedResults<Device> GetPaged(int page, int pageSize)
		{
			return internalGetPaged(page, pageSize);
		}

		[HttpGet("{id}")]
		[Authorize(Roles = "DeviceList")]
		public Result<Device> Get(int id)
		{
			return internalGet(id);
		}

		[HttpPost]
		public Result<Device> Post([FromBody]Device data)
		{
			return internalPost(data);
		}

		[HttpPut]
		public Result<Device> Put([FromBody]Device data)
		{
			return internalPut(data);
		}

		[HttpDelete("{id}")]
		public Result<Device> Delete(int id)
		{
			return internalDelete(id);
		}

		partial void putExtraVerification(Device data, Result<Device> result)
		{
			var item = context.Devices.FirstOrDefault(i => i.Id == data.Id);
			if(item != null && item.IsReadOnly)
			{
				result.Errors.Add($"Device {item.Id} is read only");
			}
		}

		partial void deleteExtraVerification(Device data, Result<Device> result)
		{
			if (data.IsReadOnly)
			{
				result.Errors.Add($"Device {data.Id} is read only");
			}
		}
	}
}