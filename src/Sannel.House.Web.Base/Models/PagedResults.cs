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
		public virtual int CurrentPage
		{
			get;
			set;
		}
    }
}
