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
	public partial class TemperatureSettingController : Controller
	{
		public IEnumerable<TemperatureSetting> Get()
		{
			return context.TemperatureSettings.OrderByDescending(i => i.DateCreated);
		}

		[HttpGet("{id}")]
		public TemperatureSetting Get(Int64 id)
		{
			return context.TemperatureSettings.FirstOrDefault(i => i.Id == id);
		}

		[HttpPost]
		public Result<TemperatureSetting> Post([FromBody] TemperatureSetting data)
		{
			var result = new Result<TemperatureSetting>();
			result.Data = data;
			result.Success = false;
			if (data == null)
			{
				result.Errors.Add($"{nameof(data)} cannot be null");
				return result;
			}

			data.Id = 0;
			postExtraVerification(data, result);
			if (result.Errors.Count > 0)
			{
				return result;
			}

			postExtraReset(data);
			context.TemperatureSettings.Add(data);
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
					logger.LogError(LoggingIds.PostException, ex, "Error during TemperatureSetting Post");
				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void postExtraVerification(TemperatureSetting data, Result<TemperatureSetting> result);
		partial void postExtraReset(TemperatureSetting data);
		[HttpPut]
		public Result<TemperatureSetting> Put([FromBody] TemperatureSetting data)
		{
			var result = new Result<TemperatureSetting>();
			result.Data = data;
			result.Success = false;
			if (data == null)
			{
				result.Errors.Add($"{nameof(data)} cannot be null");
				return result;
			}

			putExtraVerification(data, result);
			if (result.Errors.Count > 0)
			{
				return result;
			}

			putExtraReset(data);
			var current = context.TemperatureSettings.FirstOrDefault((i) => i.Id == data.Id);
			if (current == null)
			{
				result.Errors.Add($"TemperatureSetting with Id {data.Id} was not found");
				return result;
			}

			current.DayOfWeek = data.DayOfWeek;
			current.Month = data.Month;
			current.IsTimeOnly = data.IsTimeOnly;
			current.StartTime = data.StartTime;
			current.EndTime = data.EndTime;
			current.HeatTemperatureC = data.HeatTemperatureC;
			current.CoolTemperatureC = data.CoolTemperatureC;
			current.DateCreated = data.DateCreated;
			current.DateModified = data.DateModified;
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
				{
					logger.LogError(LoggingIds.PutException, ex, "Error during TemperatureSetting Put");
				}

				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void putExtraVerification(TemperatureSetting data, Result<TemperatureSetting> result);
		partial void putExtraReset(TemperatureSetting data);
	}
}