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

using Sannel.House.Web.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base.Models
{
	[Generation(DontGenerateMethods = new GenerationAttribute.ApiCalls[]
	{
		GenerationAttribute.ApiCalls.Delete,
		GenerationAttribute.ApiCalls.Put
	})]
	public class ApplicationLogEntry
	{
		[Key]
		public Guid Id
		{
			get;
			set;
		}

		public int? DeviceId
		{
			get;
			set;
		}

		[Required]
		[MaxLength(256)]
		[Generation(IsRequired = true)]
		public String ApplicationId
		{
			get;
			set;
		}

		[Required]
		[Generation(CheckForEmptyString = true)]
		public String Message
		{
			get;
			set;
		}

		public String Exception
		{
			get;
			set;
		}
		[Required]
		[Generation(IsNow = true)]
		public DateTimeOffset CreatedDate
		{
			get;
			set;
		}
	}
}
