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
	public partial class DeviceController : Controller
	{
		private PagedResults<Device> internalGetPaged(int page, int pageSize)
		{
			var results = new PagedResults<Device>();
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

			IQueryable<Device> query;
			query = context.Devices.OrderBy(i => i.DisplayOrder);
			results.TotalResults = query.LongCount();
			results.PageSize = pageSize;
			query = query.Skip((page - 1) * results.PageSize).Take(results.PageSize);
			results.CurrentPage = page;
			results.Data = query;
			results.Success = true;
			return results;
		}

		private Result<Device> internalGet(Int32 id)
		{
			var results = new Result<Device>();
			var data = context.Devices.FirstOrDefault(i => i.Id == id);
			if (data != null)
			{
				results.Success = true;
				results.Data = data;
				return results;
			}
			else
			{
				results.Success = false;
				results.Errors.Add($"Could not find Device with Id {id}");
				return results;
			}
		}

		private Result<Device> internalPost(Device data)
		{
			var result = new Result<Device>();
			result.Data = data;
			result.Success = false;
			if (data == null)
			{
				result.Errors.Add($"{nameof(data)} cannot be null");
				return result;
			}

			data.Id = 0;
			if (String.IsNullOrWhiteSpace(data.Name))
			{
				result.Errors.Add($"{nameof(data.Name)} must have a non empty value");
				return result;
			}

			if (data.Description == null)
			{
				result.Errors.Add($"{nameof(data.Description)} must not be null");
				return result;
			}

			postExtraVerification(data, result);
			if (result.Errors.Count > 0)
			{
				return result;
			}

			data.DisplayOrder = context.Devices.Count();
			data.DateCreated = DateTimeOffset.Now;
			postExtraReset(data);
			context.Devices.Add(data);
			try
			{
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
					logger.LogError(LoggingIds.PostException, ex, "Error during Device Post");
				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void postExtraVerification(Device data, Result<Device> result);
		partial void postExtraReset(Device data);
		private Result<Device> internalPut(Device data)
		{
			var result = new Result<Device>();
			result.Data = data;
			result.Success = false;
			if (data == null)
			{
				result.Errors.Add($"{nameof(data)} cannot be null");
				return result;
			}

			if (String.IsNullOrWhiteSpace(data.Name))
			{
				result.Errors.Add($"{nameof(data.Name)} must have a non empty value");
				return result;
			}

			if (data.Description == null)
			{
				result.Errors.Add($"{nameof(data.Description)} must not be null");
				return result;
			}

			putExtraVerification(data, result);
			if (result.Errors.Count > 0)
			{
				return result;
			}

			putExtraReset(data);
			var current = context.Devices.FirstOrDefault((i) => i.Id == data.Id);
			if (current == null)
			{
				result.Errors.Add($"Device with Id {data.Id} was not found");
				return result;
			}

			current.Name = data.Name;
			current.Description = data.Description;
			current.DisplayOrder = data.DisplayOrder;
			try
			{
				context.SaveChanges();
				result.Data = current;
			}
			catch (Exception ex)
			{
				if (logger.IsEnabled(LogLevel.Error))
				{
					logger.LogError(LoggingIds.PutException, ex, "Error during Device Put");
				}

				result.Errors.Add(ex.Message);
				return result;
			}

			result.Success = true;
			return result;
		}

		partial void putExtraVerification(Device data, Result<Device> result);
		partial void putExtraReset(Device data);
		private Result<Device> internalDelete(Int32 key)
		{
			var result = new Result<Device>();
			var data = context.Devices.FirstOrDefault((i) => i.Id == key);
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
					context.Devices.Remove(data);
					context.SaveChanges();
					result.Success = true;
					return result;
				}
				catch (Exception ex)
				{
					if (logger.IsEnabled(LogLevel.Error))
					{
						logger.LogError(LoggingIds.DeleteException, ex, $"Exception deleting Device with Id{key}");
					}

					result.Errors.Add(ex.Message);
					return result;
				}
			}

			result.Errors.Add($"Device with ID {key} was not found");
			return result;
		}

		partial void deleteExtraVerification(Device data, Result<Device> result);
	}
}