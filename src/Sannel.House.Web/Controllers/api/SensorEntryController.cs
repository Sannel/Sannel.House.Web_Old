using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sannel.House.Web.Base;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Controllers.api
{
	[Route("api/v1/[controller]")]
	public partial class SensorEntryController
	{
		private IDataContext context;
		private ILogger logger;
		public SensorEntryController(IDataContext context, ILogger<SensorEntryController> logger)
		{
			this.context = context;
			this.logger = logger;
		}

		[HttpGet("GetPaged")]
		[Authorize(Roles = "TemperatureEntryList")]
		public PagedResults<SensorEntry> GetPaged()
			=> GetPaged(1);

		[HttpGet("GetPaged/{page}")]
		[Authorize(Roles = "TemperatureEntryList")]
		public PagedResults<SensorEntry> GetPaged(int page)
			=> GetPaged(page, 25);

		[HttpGet("GetPaged/{page}/{pageSize}")]
		[Authorize(Roles = "TemperatureEntryList")]
		public PagedResults<SensorEntry> GetPaged(int page, int pageSize)
			=> internalGetPaged(page, pageSize);

		[HttpGet("{id}")]
		[Authorize(Roles = "TemperatureEntryList")]
		public Result<SensorEntry> Get(Guid id)
			=> internalGet(id);

		[HttpPost]
		[Authorize(Roles = "TemperatureEntryAdd")]
		public Result<SensorEntry> Post([FromBody]SensorEntry data)
			=> internalPost(data);

		private Device checkMacAddress(SensorEntry data)
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

		private void checkForDeviceNull(SensorEntry data, Device device)
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

		partial void postExtraReset(SensorEntry data)
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
