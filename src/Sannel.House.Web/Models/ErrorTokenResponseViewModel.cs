using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Models
{
    public class ErrorTokenResponseViewModel : TokenResponseViewModel
    {
		[JsonProperty("error")]
		public String Error { get; set; }

		[JsonProperty("error_description")]
		public String ErrorDescription { get; set; }
	}
}
