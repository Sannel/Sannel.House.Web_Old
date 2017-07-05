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
		{
			return GetPaged(1);
		}

		[HttpGet("GetPaged/{page}")]
		[Authorize(Roles = "TemperatureEntryList")]
		public PagedResults<SensorEntry> GetPaged(int page)
		{
			return GetPaged(page, 25);
		}

		[HttpGet("GetPaged/{page}/{pageSize}")]
		[Authorize(Roles = "TemperatureEntryList")]
		public PagedResults<SensorEntry> GetPaged(int page, int pageSize)
		{
			return internalGetPaged(page, pageSize);
		}

		[HttpGet("{id}")]
		[Authorize(Roles = "TemperatureEntryList")]
		public Result<SensorEntry> Get(Guid id)
		{
			return internalGet(id);
		}

		[HttpPost]
		[Authorize(Roles = "TemperatureEntryAdd")]
		public Result<SensorEntry> Post([FromBody]SensorEntry data)
		{
			return internalPost(data);
		}

		partial void postExtraReset(SensorEntry data)
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
