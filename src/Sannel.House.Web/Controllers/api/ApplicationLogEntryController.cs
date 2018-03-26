/* Copyright 2018 Sannel Software, L.L.C.

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
	[Route("api/v1/[controller]")]
	public partial class ApplicationLogEntryController : Controller
	{
		protected int PageSize => 20;
		private IDataContext context;
		private ILogger logger;
		public ApplicationLogEntryController(IDataContext context, ILogger<ApplicationLogEntryController> logger)
		{
			this.context = context;
			this.logger = logger;
		}

		[HttpGet("GetPaged")]
		[Authorize(Roles = "ApplicationLogList")]
		public PagedResults<ApplicationLogEntry> GetPaged()
		{
			return GetPaged(1, PageSize);
		}

		[HttpGet("GetPaged/{page}")]
		[Authorize(Roles = "ApplicationLogList")]
		public PagedResults<ApplicationLogEntry> GetPaged(int page)
		{
			return GetPaged(page, PageSize);
		}

		[HttpGet("GetPaged/{page}/{pageSize}")]
		[Authorize(Roles = "ApplicationLogList")]
		public PagedResults<ApplicationLogEntry> GetPaged(int page, int pageSize)
		{
			return internalGetPaged(page, pageSize);
		}

		[HttpGet("{id}")]
		[Authorize(Roles = "ApplicationLogList")]
		public Result<ApplicationLogEntry> Get(Guid id)
		{
			return internalGet(id);
		}

		[HttpPost]
		[Authorize(Roles = "ApplicationLogAdd")]
		public Result<ApplicationLogEntry> Post([FromBody]ApplicationLogEntry data)
		{
			return internalPost(data);
		}
	}
}