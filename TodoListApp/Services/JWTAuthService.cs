using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Models;
using TodoListApp.Models.Dto.Request;

namespace TodoListApp.Services
{
    public class JWTAuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public JWTAuthService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration config )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.config = config;
        }
        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await this.userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return null;
            }
            var checkPassResult = await this.signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
            if (checkPassResult.Succeeded)
            {
                return BuildJWTToken(user);
            }
            return null;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
        private string BuildJWTToken(ApplicationUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["JwtToken:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = this.config["JwtToken:Issuer"];
            var audience = this.config["JwtToken:Audience"];
            var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(this.config["JwtToken:TokenExpiry"]));
            var claims = new Claim[] {
                new Claim("carut", user.UserName),
                new Claim("id", user.Id)
            };
            var token = new JwtSecurityToken(issuer,
              audience,
              claims,
              expires: jwtValidity,
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
