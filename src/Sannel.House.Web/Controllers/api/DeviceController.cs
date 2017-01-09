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

		partial void postExtraVerification(Device data, Result<Device> result);

		[HttpPost]
		public Result<Device> Post([FromBody]Device data)
		{
			var result = new Result<Device>();
			result.Data = data;
			result.Success = false;
			if (data == null)
			{
				result.Errors.Add($"{nameof(data)} cannot be null");
				return result;
			}

			data.Id = default(int);
			if (String.IsNullOrWhiteSpace(data.Name))
			{
				result.Errors.Add($"{nameof(data.Name)} must have a non empty value");
				return result;
			}

			postExtraVerification(data, result);
			if(result.Errors.Count > 0)
			{
				return result;
			}

			data.DateCreated = DateTimeOffset.Now;
			data.DisplayOrder = context.Devices.Count();

			context.Devices.Add(data);
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
	}
}