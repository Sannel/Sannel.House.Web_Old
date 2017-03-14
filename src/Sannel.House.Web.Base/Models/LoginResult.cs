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
