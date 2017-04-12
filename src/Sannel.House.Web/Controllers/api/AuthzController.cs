using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sannel.House.Web.Models;
using Microsoft.AspNetCore.Identity;
using Sannel.House.Web.Base.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Sannel.House.Web.Base.Interfaces;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sannel.House.Web.Controllers.api
{
	[Route("api/v1/[controller]")]
	public class AuthzController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly TokenAuthOptions tokenOptions;
		private readonly IDataContext context;
		private readonly RSA rsa;

		public AuthzController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager,
			TokenAuthOptions tokenOptions,
			IDataContext context,
			RSA rsa)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.roleManager = roleManager;
			this.tokenOptions = tokenOptions;
			this.context = context;
			this.rsa = rsa;
		}

		// POST api/values
		[HttpPost]
		public async Task<TokenResponseViewModel> Post([FromBody]TokenRequestViewModel viewModel)
		{
			if(String.Compare(viewModel.GrantType, "password") != 0)
			{
				return new ErrorTokenResponseViewModel
				{
					Error = "invalid_grant_type",
					ErrorDescription = $"Grant type {viewModel.GrantType} is not supported."
				};
			}
			var signInResult = await signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
			if (signInResult.Succeeded)
			{
				var user = await userManager.FindByNameAsync(viewModel.Username);
				var claims = await signInManager.CreateUserPrincipalAsync(user);
				var utcNow = DateTime.UtcNow;
				var expires = utcNow.AddMinutes(20);
				var token = getToken(claims, expires);
				var refreshToken = getRefreshToken(token, expires);

				var expiresIn = TimeSpan.FromTicks(expires.Ticks) - TimeSpan.FromTicks(utcNow.Ticks);

				return new SuccessTokenResponseViewModel
				{
					TokenType = "bearer",
					AccessToken = token,
					RefreshToken = refreshToken,
					ExpiresIn = (long)expiresIn.TotalSeconds
				};
			}
			else
			{
				return new ErrorTokenResponseViewModel
				{
					Error = "invalid_credentials",
					ErrorDescription = "Invalid Username/Password was provided"
				};
			}
		}

		private String getRefreshToken(String token, DateTime expiresIn)
		{
			var refreshToken = new RefreshToken();
			refreshToken.RefreshTokenId = Guid.NewGuid();
			refreshToken.Expires = expiresIn.AddHours(2);
			refreshToken.AccessToken = token;

			context.RefreshTokens.Add(refreshToken);
			context.SaveChanges();

			var rTokenBytes = rsa.Encrypt(refreshToken.RefreshTokenId.ToByteArray(), RSAEncryptionPadding.OaepSHA1);

			return Convert.ToBase64String(rTokenBytes);
		}

		private string getToken(ClaimsPrincipal claims, DateTime expiresIn)
		{
			var handler = new JwtSecurityTokenHandler();


			// Here, you should create or look up an identity for the user which is being authenticated.
			// For now, just creating a simple generic identity.

			/*var claimsA = new Claim[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};*/

			var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor()
			{
				Issuer = tokenOptions.Issuer,
				Audience = tokenOptions.Audience,
				SigningCredentials = tokenOptions.Credentials,
				Subject = claims.Identities.FirstOrDefault(),
				Expires = expiresIn,
				NotBefore = DateTime.UtcNow.AddTicks(-1)
			});
			return handler.WriteToken(securityToken);
		}
	}
}
