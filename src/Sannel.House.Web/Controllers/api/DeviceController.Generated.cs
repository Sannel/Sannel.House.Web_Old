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
	public partial class DeviceController : Controller
	{
		public IEnumerable<Device> Get()
		{
			return context.Devices.OrderBy(i => i.DisplayOrder);
		}

		[HttpGet("{id}")]
		public Device Get(Int32 id)
		{
			return context.Devices.FirstOrDefault(i => i.Id == id);
		}

		[HttpPost]
		public Result<Device> Post([FromBody] Device data)
		{
			var result = new Result<Device>();
			result.Data = data;
			result.Success = false;
			if (data == null)
			{
				result.Errors.Add($"{nameof(data)} cannot be null");
				return result;
			}

			data.Id = 0;
			if (String.IsNullOrWhiteSpace(data.Name))
			{
				result.Errors.Add($"{nameof(data.Name)} must have a non empty value");
				return result;
			}

			if (data.Description == null)
			{
				result.Errors.Add($"{nameof(data.Description)} must not be null");
				return result;
			}

			postExtraVerification(data, result);
			if (result.Errors.Count > 0)
			{
				return result;
			}

			data.DisplayOrder = context.Devices.Count();
			data.DateCreated = DateTimeOffset.Now;
			postExtraReset(data);
			context.Devices.Add(data);
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
					logger.LogError(LoggingIds.PostException, ex, "Error during Device Post");
				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void postExtraVerification(Device data, Result<Device> result);
		partial void postExtraReset(Device data);
		[HttpPut]
		public Result<Device> Put([FromBody] Device data)
		{
			var result = new Result<Device>();
			result.Data = data;
			result.Success = false;
			if (data == null)
			{
				result.Errors.Add($"{nameof(data)} cannot be null");
				return result;
			}

			data.Id = 0;
			if (String.IsNullOrWhiteSpace(data.Name))
			{
				result.Errors.Add($"{nameof(data.Name)} must have a non empty value");
				return result;
			}

			if (data.Description == null)
			{
				result.Errors.Add($"{nameof(data.Description)} must not be null");
				return result;
			}

			putExtraVerification(data, result);
			if (result.Errors.Count > 0)
			{
				return result;
			}

			putExtraReset(data);
			var current = context.Devices.FirstOrDefault((i) => i.Id == data.Id);
			if (current == null)
			{
				result.Errors.Add($"Device with Id {data.Id} was not found");
				return result;
			}

			current.Name = data.Name;
			current.Description = data.Description;
			current.DisplayOrder = data.DisplayOrder;
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
				{
					logger.LogError(LoggingIds.PutException, ex, "Error during Device Put");
				}

				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void putExtraVerification(Device data, Result<Device> result);
		partial void putExtraReset(Device data);
	}
}