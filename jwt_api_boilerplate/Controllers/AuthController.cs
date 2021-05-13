using System;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using jwt_api_boilerplate.Models;

namespace jwt_api_boilerplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserLogin userData)
        {
            var userInfo = await AuthenticateUser(userData.UserName, userData.Password);
            
            if(userInfo != null)
            {
                return Ok(new { access_token = GenerateJWT(userInfo) });
            }

            return Unauthorized();
        }

        private async Task<UserInfo> AuthenticateUser(string userName, string password)
        {
            // AUTHENTICATION LOGIC GOES HERE

            // HARDCODED USER
            if (userName == "admin" && password == "admin")
            {
                return new UserInfo()
                {
                    Id = new Guid(),
                    Name = "Administrator",
                    LastName = "",
                    Email = "admin@gmail.com",
                    Role = "administrator",
                };
            }
            else
            {
                return null;
            }
        }

        private string GenerateJWT(UserInfo userInfo)
        {
            // HEADER CREATION
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            // CLAIM ARRAY CREATION
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, userInfo.Id.ToString()),
                new Claim("name", userInfo.Name),
                new Claim("lastname", userInfo.LastName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.Role)
            };

            // PAYLOAD CREATION
            var payload = new JwtPayload(configuration["JWT:Issuer"], configuration["JWT:Audience"], claims, DateTime.UtcNow, DateTime.UtcNow.AddHours(24));

            // TOKEN GENERATION
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}