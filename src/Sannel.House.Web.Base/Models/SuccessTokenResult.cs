using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Web.Base.Models
{
    public class SuccessTokenResult : Result<String>
    {
		public SuccessTokenResult()
		{
			Success = true;
		}
		public override string Data { get => AccessToken; set => AccessToken = value; }

		[JsonProperty("access_token")]
		public String AccessToken { get; set; }
		[JsonProperty("token_type")]
		public String TokenType { get; set; }
		[JsonProperty("expires_in")]
		public long ExpiresIn { get; set; }
		[JsonProperty("expires_at")]
		public DateTime ExpiresAt { get; set; }
		[JsonProperty("refresh_token")]
		public String RefreshToken { get; set; }
	}
}
