using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Models
{
    public class TokenRequestViewModel
    {
		[JsonProperty("client_id")]
		public String ClientId { get; set; }
		[JsonProperty("client_secret")]
		public String ClientSecret { get; set; }
		[JsonProperty("grant_type")]
		public String GrantType { get; set; }
		[JsonProperty("code")]
		public String Code { get; set; }
		[JsonProperty("redirect_uri")]
		public Uri RedirectUri { get; set; }
		[JsonProperty("username")]
		public String Username { get; set; }
		[JsonProperty("password")]
		public String Password { get; set; }
	}
}
