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
	public partial class DeviceIdsController : Controller
	{
		private PagedResults<AlternateDeviceId> internalGetPaged(int page, int pageSize)
		{
			var results = new PagedResults<AlternateDeviceId>();
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

			IQueryable<AlternateDeviceId> query;
			query = context.AlternateDeviceIds.Include(i => i.Device).OrderByDescending(i => i.DateCreated);
			results.TotalResults = query.LongCount();
			results.PageSize = pageSize;
			query = query.Skip((page - 1) * results.PageSize).Take(results.PageSize);
			results.CurrentPage = page;
			results.Count = query.Count();
			results.Data = query.AsNoTracking();
			results.Success = true;
			return results;
		}

		private Result<AlternateDeviceId> internalGet(Int32 id)
		{
			var results = new Result<AlternateDeviceId>();
			var data = context.AlternateDeviceIds.FirstOrDefault(i => i.Id == id);
			if (data != null)
			{
				results.Success = true;
				results.Data = data;
				return results;
			}
			else
			{
				results.Success = false;
				results.Errors.Add($"Could not find DeviceIds with Id {id}");
				return results;
			}
		}

		private Result<AlternateDeviceId> internalPost(AlternateDeviceId data)
		{
			var result = new Result<AlternateDeviceId>();
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

			data.DateCreated = DateTime.Now;
			postExtraReset(data);
			context.AlternateDeviceIds.Add(data);
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
					logger.LogError(LoggingIds.PostException, ex, "Error during DeviceIds Post");
				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void postExtraVerification(AlternateDeviceId data, Result<AlternateDeviceId> result);
		partial void postExtraReset(AlternateDeviceId data);
	}
}