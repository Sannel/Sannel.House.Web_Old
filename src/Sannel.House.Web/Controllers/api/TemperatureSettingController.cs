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
using Microsoft.AspNetCore.Authorization;

namespace Sannel.House.Web.Controllers.api
{
	[Authorize(Roles = "TemperatureSettingEdit")]
	public partial class TemperatureSettingController : Controller
	{
		private IDataContext context;
		private ILogger logger;
		public TemperatureSettingController(IDataContext context, ILogger<TemperatureSettingController> logger)
		{
			this.context = context;
			this.logger = logger;
		}

		[HttpGet]
		[Authorize(Roles = "TemperatureSettingList")]
		public IEnumerable<TemperatureSetting> Get()
		{
			return internalGet();
		}

		[HttpGet("{id}")]
		[Authorize(Roles = "TemperatureSettingList")]
		public TemperatureSetting Get(long id)
		{
			return internalGet(id);
		}

		[HttpPost]
		public Result<TemperatureSetting> Post([FromBody]TemperatureSetting data)
		{
			return internalPost(data);
		}

		[HttpPut]
		public Result<TemperatureSetting> Put([FromBody]TemperatureSetting data)
		{
			return internalPut(data);
		}

		[HttpDelete("{key}")]
		public Result<TemperatureSetting> Delete(long key)
		{
			return internalDelete(key);
		}
	}
}