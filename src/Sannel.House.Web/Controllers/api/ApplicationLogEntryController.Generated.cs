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
	public partial class ApplicationLogEntryController : Controller
	{
		private PagedResults<ApplicationLogEntry> internalGetPaged(int page, int pageSize)
		{
			var results = new PagedResults<ApplicationLogEntry>();
			if (page <= 0)
			{
				results.Success = false;
				results.Errors.Add("Page must be 1 or greater");
				return results;
			}

			if (pageSize <= 0)
			{
				results.Success = false;
				results.Errors.Add("PageSize must be 1 or greater");
				return results;
			}

			IQueryable<ApplicationLogEntry> query;
			query = context.ApplicationLogEntries.OrderByDescending(i => i.CreatedDate);
			results.TotalResults = query.LongCount();
			results.PageSize = pageSize;
			query = query.Skip((page - 1) * results.PageSize).Take(results.PageSize);
			results.CurrentPage = page;
			results.Data = query;
			results.Success = true;
			return results;
		}

		private ApplicationLogEntry internalGet(Guid id)
		{
			return context.ApplicationLogEntries.FirstOrDefault(i => i.Id == id);
		}

		private Result<ApplicationLogEntry> internalPost(ApplicationLogEntry data)
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
			if (data.ApplicationId == null)
			{
				result.Errors.Add($"{nameof(data.ApplicationId)} must not be null");
				return result;
			}

			if (String.IsNullOrWhiteSpace(data.Message))
			{
				result.Errors.Add($"{nameof(data.Message)} must have a non empty value");
				return result;
			}

			postExtraVerification(data, result);
			if (result.Errors.Count > 0)
			{
				return result;
			}

			data.CreatedDate = DateTimeOffset.Now;
			postExtraReset(data);
			context.ApplicationLogEntries.Add(data);
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
					logger.LogError(LoggingIds.PostException, ex, "Error during ApplicationLogEntry Post");
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