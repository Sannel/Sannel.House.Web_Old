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
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base
{
	public static class LoggingIds
	{
		public static readonly EventId PostException = new EventId(1, "Post Exception");

		public static readonly EventId PutException = new EventId(2, "Put Exception");

		public static readonly EventId DeleteException = new EventId(3, "Delete Exception");

		public static readonly EventId DeviceNotFoundError = new EventId(4, "Device Not Found");
	}
}
