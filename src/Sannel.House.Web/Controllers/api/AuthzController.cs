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

		private async Task<TokenResponseViewModel> passwordGrantAsync(TokenRequestViewModel viewModel)
		{
			var signInResult = await signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
			if (signInResult.Succeeded)
			{
				var user = await userManager.FindByNameAsync(viewModel.Username);
				return await generateTokensForUserAsync(user);
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

		private async Task<TokenResponseViewModel> generateTokensForUserAsync(ApplicationUser user)
		{
			var claims = await signInManager.CreateUserPrincipalAsync(user ?? throw new ArgumentNullException(nameof(user)));
				var utcNow = DateTime.UtcNow;
				var (token, expires) = getToken(claims, utcNow.AddMinutes(20));
				var refreshToken = getRefreshToken(user.Id, expires);

				var expiresIn = TimeSpan.FromTicks(expires.Ticks) - TimeSpan.FromTicks(utcNow.Ticks);

				return new SuccessTokenResponseViewModel
				{
					TokenType = "bearer",
					AccessToken = token,
					RefreshToken = refreshToken,
					ExpiresIn = (long)expiresIn.TotalSeconds
				};
		}

		private async Task<TokenResponseViewModel> refreshTokenGrantAsync(TokenRequestViewModel viewModel)
		{
			var token = viewModel.RefreshToken;
			if (string.IsNullOrWhiteSpace(token))
			{
				return new ErrorTokenResponseViewModel
				{
					Error = "invalid_token",
					ErrorDescription = "Invalid token was provided"
				};
			}
			else
			{
				var data = Convert.FromBase64String(token);
				var rTokenBytes = rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA1);

				if(rTokenBytes.Length < 16 + sizeof(long))
				{
					return new ErrorTokenResponseViewModel
					{
						Error = "invalid_token",
						ErrorDescription = "Invalid token was provided"
					};
				}
				else
				{
					var guid = new Guid(rTokenBytes.Take(16).ToArray());
					var rt = context.RefreshTokens.FirstOrDefault(i => i.RefreshTokenId == guid);
					if(rt == null)
					{
						return new ErrorTokenResponseViewModel
						{
							Error = "invalid_token",
							ErrorDescription = "Invalid token was provided"
						};
					}
					var expires = rt.Expires;

					var ticks = BitConverter.ToInt64(rTokenBytes, 16);
					if(expires.Ticks != ticks)
					{
						context.RefreshTokens.Remove(rt);
						await context.SaveChangesAsync();
						return new ErrorTokenResponseViewModel
						{
							Error = "invalid_token",
							ErrorDescription = "Invalid token was provided"
						};
					}

					if (DateTime.UtcNow > expires)
					{
						context.RefreshTokens.Remove(rt);
						await context.SaveChangesAsync();
						return new ErrorTokenResponseViewModel
						{
							Error = "token_expired",
							ErrorDescription = "The refresh token has expired"
						};
					}

					var user = await userManager.FindByIdAsync(rt.UserId);
					if (user == null)
					{
						return new ErrorTokenResponseViewModel
						{
							Error = "invalid_token",
							ErrorDescription = "Invalid token was provided"
						};
					}

					return await generateTokensForUserAsync(user);
				}
			}
		}

		// POST api/values
		[HttpPost]
		public async Task<TokenResponseViewModel> Post([FromBody]TokenRequestViewModel viewModel)
		{
			if(viewModel == null)
			{
				return new ErrorTokenResponseViewModel
				{
					Error = "request_null",
					ErrorDescription = "No request was sent"
				};
			}

			switch (viewModel.GrantType)
			{
				case "password":
					return await passwordGrantAsync(viewModel);

				case "refresh_token":
					return await refreshTokenGrantAsync(viewModel);

				default:
					return new ErrorTokenResponseViewModel
					{
						Error = "invalid_grant_type",
						ErrorDescription = $"Grant type {viewModel.GrantType} is not supported."
					};
			}
		}

		private String getRefreshToken(String userId, DateTime expiresIn)
		{
			var refreshToken = new RefreshToken();
			refreshToken.RefreshTokenId = Guid.NewGuid();
			refreshToken.Expires = expiresIn.AddHours(2);
			refreshToken.UserId = userId;

			context.RefreshTokens.Add(refreshToken);
			context.SaveChanges();

			List<byte> data = new List<byte>(refreshToken.RefreshTokenId.ToByteArray());

			data.AddRange(BitConverter.GetBytes(refreshToken.Expires.Ticks));

			var rTokenBytes = rsa.Encrypt(data.ToArray(), RSAEncryptionPadding.OaepSHA1);

			return Convert.ToBase64String(rTokenBytes);
		}

		private (string token, DateTime expires) getToken(ClaimsPrincipal claims, DateTime expiresIn)
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
			return (handler.WriteToken(securityToken), securityToken.ValidTo);
		}
	}
}
