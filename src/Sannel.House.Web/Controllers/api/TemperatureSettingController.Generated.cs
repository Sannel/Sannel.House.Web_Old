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
	public partial class TemperatureSettingController : Controller
	{
		private PagedResults<TemperatureSetting> internalGetPaged(int page, int pageSize)
		{
			var results = new PagedResults<TemperatureSetting>();
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

			IQueryable<TemperatureSetting> query;
			query = context.TemperatureSettings.OrderByDescending(i => i.DateCreated);
			results.TotalResults = query.LongCount();
			results.PageSize = pageSize;
			query = query.Skip((page - 1) * results.PageSize).Take(results.PageSize);
			results.CurrentPage = page;
			results.Count = query.Count();
			results.Data = query.AsNoTracking();
			results.Success = true;
			return results;
		}

		private Result<TemperatureSetting> internalGet(Int64 id)
		{
			var results = new Result<TemperatureSetting>();
			var data = context.TemperatureSettings.FirstOrDefault(i => i.Id == id);
			if (data != null)
			{
				results.Success = true;
				results.Data = data;
				return results;
			}
			else
			{
				results.Success = false;
				results.Errors.Add($"Could not find TemperatureSetting with Id {id}");
				return results;
			}
		}

		private Result<TemperatureSetting> internalPost(TemperatureSetting data)
		{
			var result = new Result<TemperatureSetting>();
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

			postExtraReset(data);
			context.TemperatureSettings.Add(data);
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
					logger.LogError(LoggingIds.PostException, ex, "Error during TemperatureSetting Post");
				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void postExtraVerification(TemperatureSetting data, Result<TemperatureSetting> result);
		partial void postExtraReset(TemperatureSetting data);
		private Result<TemperatureSetting> internalPut(TemperatureSetting data)
		{
			var result = new Result<TemperatureSetting>();
			result.Data = data;
			result.Success = false;
			if (data == null)
			{
				result.Errors.Add($"{nameof(data)} cannot be null");
				return result;
			}

			putExtraVerification(data, result);
			if (result.Errors.Count > 0)
			{
				return result;
			}

			putExtraReset(data);
			var current = context.TemperatureSettings.FirstOrDefault((i) => i.Id == data.Id);
			if (current == null)
			{
				result.Errors.Add($"TemperatureSetting with Id {data.Id} was not found");
				return result;
			}

			current.DayOfWeek = data.DayOfWeek;
			current.Month = data.Month;
			current.IsTimeOnly = data.IsTimeOnly;
			current.StartTime = data.StartTime;
			current.EndTime = data.EndTime;
			current.HeatTemperatureC = data.HeatTemperatureC;
			current.CoolTemperatureC = data.CoolTemperatureC;
			current.DateCreated = data.DateCreated;
			current.DateModified = data.DateModified;
			try
			{
				context.SaveChanges();
				result.Data = current;
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
				{
					logger.LogError(LoggingIds.PutException, ex, "Error during TemperatureSetting Put");
				}

				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void putExtraVerification(TemperatureSetting data, Result<TemperatureSetting> result);
		partial void putExtraReset(TemperatureSetting data);
		private Result<TemperatureSetting> internalDelete(Int64 key)
		{
			var result = new Result<TemperatureSetting>();
			var data = context.TemperatureSettings.FirstOrDefault((i) => i.Id == key);
			if (data != null)
			{
				result.Data = data;
				deleteExtraVerification(data, result);
				if (result.Errors.Count > 0)
				{
					return result;
				}

				try
				{
					context.TemperatureSettings.Remove(data);
					context.SaveChanges();
					result.Success = true;
					return result;
				}
				catch (Exception ex)
				{
					if (logger.IsEnabled(LogLevel.Error))
					{
						logger.LogError(LoggingIds.DeleteException, ex, $"Exception deleting TemperatureSetting with Id{key}");
					}

					result.Errors.Add(ex.Message);
					return result;
				}
			}

			result.Errors.Add($"Device with ID {key} was not found");
			return result;
		}

		partial void deleteExtraVerification(TemperatureSetting data, Result<TemperatureSetting> result);
	}
}