using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanApp.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KanbanApp.Controllers
{
    
    [Produces("application/json")]
    [Route("[controller]/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;

           _userManager.CreateAsync(new ApplicationUser { UserName = _configuration["credentials:user"] }, _configuration["credentials:password"]);

        }

        [HttpPost]
        public async Task<ActionResult<UserToken>> Post([FromBody] User user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.login, user.senha,isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return BuildToken(user);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private UserToken BuildToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
            return new UserToken()
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expirationDate = expiration
            };
        }
    }
}