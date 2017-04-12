using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Models
{
    public class SuccessTokenResponseViewModel : TokenResponseViewModel
    {
		[JsonProperty("access_token")]
		public String AccessToken { get; set; }
		[JsonProperty("token_type")]
		public String TokenType { get; set; }
		[JsonProperty("expires_in")]
		public long ExpiresIn { get; set; }
		[JsonProperty("refresh_token")]
		public String RefreshToken { get; set; }
    }
}
