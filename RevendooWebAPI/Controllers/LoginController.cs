using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using RevendooWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace RevendooWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly revendoodbContext _context;

        
        public LoginController(IConfiguration config, revendoodbContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody]Users login)
        {
            IActionResult response = Unauthorized();
            Users user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJWTToken(user);
                response = Ok(new { token = tokenString, userDetails = user, });
            }
            return response;
        }

        Users AuthenticateUser(Users loginCredentials)
        {
            Users user = _context.Users.SingleOrDefault(x =>
            x.Username == loginCredentials.Username && x.Senha == loginCredentials.Senha);
            return user;
        }

        string GenerateJWTToken(Users userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:SecretKey")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim("fullName", userInfo.NomeCompleto.ToString()),
                new Claim("role", userInfo.Cargo),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: _config.GetValue<string>("Jwt:Issuer"),
                audience: _config.GetValue<string>("Jwt:Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}