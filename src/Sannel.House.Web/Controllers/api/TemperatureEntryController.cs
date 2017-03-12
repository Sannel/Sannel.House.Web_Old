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

namespace Sannel.House.Web.Controllers.api
{
	[Route("api/[controller]")]
	public partial class TemperatureEntryController : Controller
	{
		private IDataContext context;
		private ILogger logger;
		public TemperatureEntryController(IDataContext context, ILogger<TemperatureEntryController> logger)
		{
			this.context = context;
			this.logger = logger;
		}

		[HttpGet]
		[Authorize(Roles = "TemperatureEntryList")]
		public PagedResults<TemperatureEntry> GetPaged()
		{
			return GetPaged(1);
		}

		[HttpGet]
		[Authorize(Roles = "TemperatureEntryList")]
		public PagedResults<TemperatureEntry> GetPaged(int page)
		{
			return GetPaged(page, 25);
		}

		[HttpGet]
		[Authorize(Roles = "TemperatureEntryList")]
		public PagedResults<TemperatureEntry> GetPaged(int page, int pageSize)
		{
			return internalGetPaged(page, pageSize);
		}

		[HttpGet("{id}")]
		[Authorize(Roles = "TemperatureEntryList")]
		public Result<TemperatureEntry> Get(Guid id)
		{
			return internalGet(id);
		}

		[HttpPost]
		[Authorize(Roles = "TemperatureEntryAdd")]
		public Result<TemperatureEntry> Post([FromBody]TemperatureEntry data)
		{
			return internalPost(data);
		}

		partial void postExtraReset(TemperatureEntry data)
		{
			var device = context.Devices.FirstOrDefault(i => i.Id == data.DeviceId);
			if(device == null)
			{
				if (logger.IsEnabled(LogLevel.Error))
				{
					logger.LogError(LoggingIds.DeviceNotFoundError, $"A device with id {data.DeviceId} was not found setting device to default");
				}
				data.DeviceId = SystemDeviceIds.DefaultId;
			}
		}
	}
}