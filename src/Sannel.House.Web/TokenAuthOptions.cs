using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web
{
    public class TokenAuthOptions
    {
		public String Issuer{ get; set; }
		public String Audience { get; set; }
		public SigningCredentials Credentials { get; set; }
	}
}
