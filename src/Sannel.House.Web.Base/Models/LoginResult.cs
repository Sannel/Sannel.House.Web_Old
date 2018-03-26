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
using System.Text;

namespace Sannel.House.Web.Base.Models
{
    public class LoginResult : Result<String>
    {
		/// <summary>
		/// Gets the roles for the logged in user
		/// </summary>
		/// <value>
		/// The roles.
		/// </value>
		public virtual List<String> Roles
		{
			get;
		} = new List<string>();

		/// <summary>
		/// Adds the role to Roles
		/// </summary>
		/// <param name="role">The role.</param>
		/// <returns></returns>
		public virtual LoginResult AddRole(String role)
		{
			Roles.Add(role);
			return this;
		}

		/// <summary>
		/// Adds the roles to the Roles property
		/// </summary>
		/// <param name="roles">The roles.</param>
		/// <returns></returns>
		public virtual LoginResult AddRoles(IEnumerable<String> roles)
		{
			Roles.AddRange(roles);
			return this;
		}

		/// <summary>
		/// Adds the roles to the Roles property
		/// </summary>
		/// <param name="roles">The roles.</param>
		/// <returns></returns>
		public virtual LoginResult AddRoles(params String[] roles)
		{
			return AddRoles((IEnumerable<String>)roles);
		}
    }
}
