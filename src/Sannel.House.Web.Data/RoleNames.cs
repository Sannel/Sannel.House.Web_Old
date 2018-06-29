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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Data
{
	public static class RoleNames
	{
		public const string GetDevice = "GetDevice";
		public const string EditDevice = "EditDevice";
		public const string Administrators = "Administrators";

		public static IEnumerable<string> AllRoles()
		{
			var t = typeof(RoleNames);
			return t.GetFields().Select(i => i.GetValue(null) as string);
		}
	}
}
