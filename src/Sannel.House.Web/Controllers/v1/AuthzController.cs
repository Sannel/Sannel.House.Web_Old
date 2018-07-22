/* Copyright 2018 Sannel Software, L.L.C.
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at
	   http://www.apache.org/licenses/LICENSE-2.0
   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Sannel.House.Web.Models;
using Sannel.House.Web.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sannel.House.Web.Controllers.v1
{
	[Route("api/v1/[controller]")]
	public class AuthzController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly IConfiguration configuration;
		private readonly IStringLocalizer localizer;
		private readonly ILogger log;

		public AuthzController(UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager,
			IConfiguration configuration,
			IStringLocalizer<AuthzController> localizer,
			ILogger<AuthzController> logger)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.roleManager = roleManager;
			this.configuration = configuration;
			this.localizer = localizer;
			log = logger;
		}

		private async Task<IActionResult> passwordGrantAsync(LoginRequest request)
		{
			var result = await signInManager.PasswordSignInAsync(request.Username, request.Password, false, true);
			if(result.Succeeded)
			{
				var section = configuration.GetSection("Jwt");
				if(section == null)
				{
					return this.StatusCode(500, "Configuration Error");
				}

				var user = await userManager.FindByNameAsync(request.Username);
				var c = await signInManager.CreateUserPrincipalAsync(user);
				var claims = new List<Claim>()
				{
					new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
					new Claim(JwtRegisteredClaimNames.Jti, user.Id)
				};
				claims.AddRange(c.Claims);

				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(section["Key"]));
				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

				var token = new JwtSecurityToken(
					issuer: section["Issuer"],
					audience: section["Issuer"],
					claims: claims,
					expires: DateTime.Now.AddMinutes(section.GetValue<long>("ExpireMinutes")),
					signingCredentials: creds);

				log.LogDebug($"User {user.UserName} logged in");

				return Ok(new LoginResult()
				{
					Token = new JwtSecurityTokenHandler().WriteToken(token)
				});
			}
			else
			{
				if (result.IsLockedOut)
				{
					return BadRequest("Account is locked");
				}
				else
				{
					return BadRequest("Invalid Username/Password was provided");
				}
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]LoginRequest request)
		{
			if(request == null)
			{
				return this.BadRequest();
			}

			switch (request.GrantType)
			{
				case "password":
					return await passwordGrantAsync(request);

				default:
					return BadRequest(localizer["InvalidGrantType"]);
			}
		}
	}
}
