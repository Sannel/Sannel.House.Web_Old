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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sannel.House.Web.Controllers.api
{
	[Route("api/[controller]")]
	public class AuthzController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly TokenAuthOptions tokenOptions;

		public AuthzController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager,
			TokenAuthOptions tokenOptions)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.roleManager = roleManager;
			this.tokenOptions = tokenOptions;
		}

		// POST api/values
		[HttpPost]
		public async Task<LoginResult> Post([FromBody]LoginViewModel viewModel)
		{
			var signInResult = await signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, false);
			if (signInResult.Succeeded)
			{
				var user = await userManager.FindByNameAsync(viewModel.Email);
				var claims = await signInManager.CreateUserPrincipalAsync(user);
				// return Bearor;
				return new LoginResult()
				{
					Success = true,
					Data = getToken(claims, null)
				}.AddRoles(await userManager.GetRolesAsync(user));
			}
			else
			{
				// return Error;
				return (LoginResult)new LoginResult()
				{
					Success = false
				}.AddError("Invalid username and password");
			}
		}

		private string getToken(ClaimsPrincipal claims, DateTime? expires)
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
				Expires = expires
			});
			return handler.WriteToken(securityToken);
		}
	}
}
