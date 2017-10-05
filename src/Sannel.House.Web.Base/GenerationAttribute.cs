using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base
{
	public class GenerationAttribute : Attribute
	{
		public GenerationAttribute()
		{
		}

		public bool Ignore { get; set; }

		public bool IsRequired { get; set; }

		public bool CheckForEmptyString { get; set; }

		public bool GreaterThenZero { get; set; }

		public bool IsNow { get; set; }

		public bool ShouldBeCount { get; set; }

		public bool CantUpdate { get; set; }
		public object AlwaysValue { get; set; }

		public string[] GetIncludes { get; set; }

		public ApiCalls[] DontGenerateMethods
		{
			get;
			set;
		}

		public enum ApiCalls
		{
			Get,
			GetWithId,
			Post,
			Put,
			Delete
		}

		public bool ShouldGenerateMethod(ApiCalls method)
		{
			if(DontGenerateMethods != null && DontGenerateMethods.Contains(method))
			{
				return false;
			}
			return true;
		}
	}
}
