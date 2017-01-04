﻿/* Copyright 2017 Sannel Software, L.L.C.

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

#if LOGGING_SERVICE || LOGGING_SDK
namespace Sannel.House.Logging.Models
#else
namespace Sannel.House.Web.Base.Models
#endif
{
	public class ApplicationLogEntry
	{
#if !LOGGING_SDK
		[Key]
		public Guid Id
		{
			get;
			set;
		}
#endif

		public int? DeviceId
		{
			get;
			set;
		}

		[Required]
		[MaxLength(256)]
		public String ApplicationId
		{
			get;
			set;
		}

		[Required]
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
#if !LOGGING_SDK
		[Required]
		public DateTimeOffset CreatedDate
		{
			get;
			set;
		}
#endif

#if LOGGING_SERVICE
		public bool Synced
		{
			get;
			set;
		} = false;
#endif
	}
}
