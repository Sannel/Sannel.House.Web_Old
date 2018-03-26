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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base.Models
{
	public abstract class Result
	{
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Result{T}"/> is success.
		/// </summary>
		/// <value>
		///   <c>true</c> if success; otherwise, <c>false</c>.
		/// </value>
		[JsonProperty(nameof(Success))]
		public virtual bool Success { get; set; }

		/// <summary>
		/// Gets the errors.
		/// </summary>
		/// <value>
		/// The errors.
		/// </value>
		[JsonProperty(nameof(Errors))]
		public virtual List<string> Errors { get; } = new List<string>();
	}
	/// <summary>
	/// The results of an action to any of the api calls
	/// </summary>
	/// <typeparam name="T">Any type thats returned from an api call</typeparam>
	public class Result<T> : Result
    {

		/// <summary>
		/// Adds an Error to the errors list and returns this object
		/// </summary>
		/// <param name="error">The error.</param>
		/// <returns></returns>
		public virtual Result<T> AddError(string error)
		{
			Errors.Add(error);
			return this;
		}

		/// <summary>
		/// Gets or sets the data for the result
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		[JsonProperty(nameof(Data))]
		public virtual T Data { get; set; }
	}
}
