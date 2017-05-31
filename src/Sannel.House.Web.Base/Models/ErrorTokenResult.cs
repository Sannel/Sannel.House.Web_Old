using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Web.Base.Models
{
    public class ErrorTokenResult : Result<String>
    {
		public ErrorTokenResult()
		{
			Success = false;
		}
		public override string Data { get => Error; set => Error = value; }
		[JsonProperty("error")]
		public String Error { get; set; }

		[JsonProperty("error_description")]
		public String ErrorDescription
		{
			get
			{
				return (Errors.Count > 0) ? Errors[0] : "";
			}
			set
			{
				if(Errors.Count <= 0)
				{
					Errors.Add(value);
				}
				else
				{
					Errors[0] = value;
				}
			}
		}
    }
}
