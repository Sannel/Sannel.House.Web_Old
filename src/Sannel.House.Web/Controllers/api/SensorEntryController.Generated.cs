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
/* This is generated code so probably best not to edit it */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sannel.House.Web.Base;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Base.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Sannel.House.Web.Controllers.api
{
	public partial class SensorEntryController : Controller
	{
		private PagedResults<SensorEntry> internalGetPaged(int page, int pageSize)
		{
			var results = new PagedResults<SensorEntry>();
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

			IQueryable<SensorEntry> query;
			query = context.SensorEntries.OrderByDescending(i => i.DateCreated);
			results.TotalResults = query.LongCount();
			results.PageSize = pageSize;
			query = query.Skip((page - 1) * results.PageSize).Take(results.PageSize);
			results.CurrentPage = page;
			results.Count = query.Count();
			results.Data = query.AsNoTracking();
			results.Success = true;
			return results;
		}

		private Result<SensorEntry> internalGet(Guid id)
		{
			var results = new Result<SensorEntry>();
			var data = context.SensorEntries.FirstOrDefault(i => i.Id == id);
			if (data != null)
			{
				results.Success = true;
				results.Data = data;
				return results;
			}
			else
			{
				results.Success = false;
				results.Errors.Add($"Could not find SensorEntry with Id {id}");
				return results;
			}
		}

		private Result<SensorEntry> internalPost(SensorEntry data)
		{
			var result = new Result<SensorEntry>();
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
			context.SensorEntries.Add(data);
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
					logger.LogError(LoggingIds.PostException, ex, "Error during SensorEntry Post");
				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void postExtraVerification(SensorEntry data, Result<SensorEntry> result);
		partial void postExtraReset(SensorEntry data);
	}
}