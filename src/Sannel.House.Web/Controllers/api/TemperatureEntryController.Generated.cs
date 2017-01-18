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
using Sannel.House.Web.Base;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Base.Interfaces;
using Microsoft.Extensions.Logging;

namespace Sannel.House.Web.Controllers.api
{
	[Route("api/[controller]")]
	public partial class TemperatureEntryController : Controller
	{
		public IEnumerable<TemperatureEntry> Get()
		{
			return context.TemperatureEntries.OrderByDescending(i => i.CreatedDateTime);
		}

		[HttpGet("{id}")]
		public TemperatureEntry Get(Guid id)
		{
			return context.TemperatureEntries.FirstOrDefault(i => i.Id == id);
		}

		[HttpPost]
		public Result<TemperatureEntry> Post([FromBody] TemperatureEntry data)
		{
			var result = new Result<TemperatureEntry>();
			result.Data = data;
			result.Success = false;
			if (data == null)
			{
				result.Errors.Add($"{nameof(data)} cannot be null");
				return result;
			}

			data.Id = Guid.NewGuid();
			if (data.DeviceId <= 0)
			{
				result.Errors.Add($"{nameof(data.DeviceId)} must be greater then 0");
				return result;
			}

			postExtraVerification(data, result);
			if (result.Errors.Count > 0)
			{
				return result;
			}

			postExtraReset(data);
			context.TemperatureEntries.Add(data);
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
					logger.LogError(LoggingIds.PostException, ex, "Error during TemperatureEntry Post");
				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void postExtraVerification(TemperatureEntry data, Result<TemperatureEntry> result);
		partial void postExtraReset(TemperatureEntry data);
	}
}