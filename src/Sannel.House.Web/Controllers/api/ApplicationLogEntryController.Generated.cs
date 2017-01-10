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
	[Route("api/[controller]")]
	public partial class ApplicationLogEntryController : Controller
	{
		public IEnumerable<ApplicationLogEntry> Get()
		{
			return context.ApplicationLogEntries.OrderByDescending(i => i.CreatedDate);
		}

		[HttpGet("{id}")]
		public ApplicationLogEntry Get(Guid id)
		{
			return context.ApplicationLogEntries.FirstOrDefault(i => i.Id == id);
		}

		[HttpPost]
		public Result<ApplicationLogEntry> Post([FromBody] ApplicationLogEntry data)
		{
			var result = new Result<ApplicationLogEntry>();
			result.Data = data;
			result.Success = false;
			if (data == null)
			{
				result.Errors.Add($"{nameof(data)} cannot be null");
				return result;
			}

			data.Id = Guid.NewGuid();
			postExtraVerification(data, result);
			if (result.Errors.Count > 0)
			{
				return result;
			}

			postExtraReset(data);
			context.ApplicationLogEntries.Add(data);
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void postExtraVerification(ApplicationLogEntry data, Result<ApplicationLogEntry> result);
		partial void postExtraReset(ApplicationLogEntry data);
	}
}