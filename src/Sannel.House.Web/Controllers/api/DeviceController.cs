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

namespace Sannel.House.Web.Controllers.api
{
	public partial class DeviceController : Controller
	{
		private IDataContext context;
		private ILogger logger;
		public DeviceController(IDataContext context, ILogger<DeviceController> logger)
		{
			this.context = context;
			this.logger = logger;
		}

		partial void putExtraVerification(Device data, Result<Device> result)
		{
			var item = context.Devices.FirstOrDefault(i => i.Id == data.Id);
			if(item != null && item.IsReadOnly)
			{
				result.Errors.Add($"Device {item.Id} is read only");
			}
		}

		[HttpDelete]
		public Result<Device> Delete(int key)
		{
			var result = new Result<Device>();
			result.Success = false;

			var data = context.Devices.FirstOrDefault(i => i.Id == key);

			if (data != null)
			{
				result.Data = data;
				try
				{
					context.Devices.Remove(data);
					context.SaveChanges();
					result.Success = true;
					return result;
				}
				catch(Exception ex)
				{
					if (logger.IsEnabled(LogLevel.Error))
					{
						logger.LogError(LoggingIds.DeleteException, ex, $"Exception deleting Device with Id {key}");
					}
					result.Errors.Add(ex.Message);
					return result;
				}
			}

			result.Errors.Add($"Device with Id {key} was not found");
			return result;
		}
	}
}