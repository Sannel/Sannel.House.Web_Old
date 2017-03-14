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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base.Models
{
    public class PagedResults<T> : Result<IEnumerable<T>>
    {
		/// <summary>
		/// Gets or sets the total results.
		/// </summary>
		/// <value>
		/// The total results.
		/// </value>
		[JsonProperty(nameof(TotalResults))]
		public virtual long TotalResults
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the size of the page.
		/// </summary>
		/// <value>
		/// The size of the page.
		/// </value>
		[JsonProperty(nameof(PageSize))]
		public virtual int PageSize
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the current page
		/// </summary>
		/// <value>
		/// The current page
		/// </value>
		[JsonProperty(nameof(CurrentPage))]
		public virtual int CurrentPage
		{
			get;
			set;
		}
    }
}
