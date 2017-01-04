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

namespace Sannel.House.Web.Controllers.api
{
	public partial class DeviceController : Controller
	{
		[HttpPost]
		public Result<Device> Post(Device device)
		{
			var result = new Result<Device>();
			result.Data = device;
			result.Success = false;
			if (device == null)
			{
				result.Errors.Add($"{nameof(device)} cannot be null");
				return result;
			}

			device.Id = default(int);
			if (String.IsNullOrWhiteSpace(device.Name))
			{
				result.Errors.Add($"{nameof(device.Name)} must have a non empty value");
				return result;
			}

			if (postExtraVerification(device, result))
			{
				return result;
			}

			device.DateCreated = DateTimeOffset.Now;
			device.DisplayOrder = context.Devices.Count();

			context.Devices.Add(device);
			try
			{
				context.SaveChanges();
			}
			catch(Exception ex)
			{
				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		private bool postExtraVerification(Device device, Result<Device> result)
		{
			return false;
		}
	}
}