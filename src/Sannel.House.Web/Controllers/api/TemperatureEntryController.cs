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
	[Route("api/v1/[controller]")]
	public partial class TemperatureEntryController : Controller
	{
		private IDataContext context;
		private ILogger logger;
		public TemperatureEntryController(IDataContext context, ILogger<TemperatureEntryController> logger)
		{
			this.context = context;
			this.logger = logger;
		}

		[HttpGet("GetPaged")]
		[Authorize(Roles = "TemperatureEntryList")]
		public PagedResults<TemperatureEntry> GetPaged()
			=> GetPaged(1);

		[HttpGet("GetPaged/{page}")]
		[Authorize(Roles = "TemperatureEntryList")]
		public PagedResults<TemperatureEntry> GetPaged(int page)
			=> GetPaged(page, 25);

		[HttpGet("GetPaged/{page}/{pageSize}")]
		[Authorize(Roles = "TemperatureEntryList")]
		public PagedResults<TemperatureEntry> GetPaged(int page, int pageSize)
			=> internalGetPaged(page, pageSize);

		[HttpGet("{id}")]
		[Authorize(Roles = "TemperatureEntryList")]
		public Result<TemperatureEntry> Get(Guid id)
			=> internalGet(id);

		[HttpPost]
		[Authorize(Roles = "TemperatureEntryAdd")]
		public Result<TemperatureEntry> Post([FromBody]TemperatureEntry data)
			=> internalPost(data);

		private Device checkMacAddress(TemperatureEntry data)
		{
			if (data.DeviceMacAddress != null) // No device id was passed but a mac address was. look for a device with that address if none are found add one.
			{
				var device = context.Devices.FirstOrDefault(i => i.MacAddress == data.DeviceMacAddress);
				if (device == null && data.DeviceMacAddress > 0)
				{
					device = new Device()
					{
						Name = $"Auto device {data.DeviceMacAddress}",
						Description = "Auto ",
						DateCreated = DateTime.Now,
						IsReadOnly = false,
						MacAddress = data.DeviceMacAddress,
						DisplayOrder = context.Devices.Count()
					};

					context.Devices.Add(device);
					context.SaveChanges();
					data.DeviceId = device.Id;
				}
				else if(device != null)
				{
					data.DeviceId = device.Id;
				}

				return device;
			}

			return null;
		}

		private void checkForDeviceNull(TemperatureEntry data, Device device)
		{
			if (device == null)
			{
				if (logger.IsEnabled(LogLevel.Error))
				{
					logger.LogError(LoggingIds.DeviceNotFoundError, $"A device with id {data.DeviceId} was not found setting device to default");
				}
				data.DeviceId = SystemDeviceIds.DefaultId;
			}
		}

		partial void postExtraReset(TemperatureEntry data)
		{
			if (data.DeviceId > default(int))
			{
				var device = context.Devices.FirstOrDefault(i => i.Id == data.DeviceId);
				if (device == null)
				{
					device = checkMacAddress(data);
				}

				checkForDeviceNull(data, device);
			}
			else
			{
				var device = checkMacAddress(data);

				checkForDeviceNull(data, device);
			}
		}
	}
}