using Apteka.API.Dtos;
using Apteka.API.IRepository;
using Apteka.API.Models;
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

namespace Apteka.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        ApiUser _user;

        public AuthManager(UserManager<ApiUser> userManager, 
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var singInCreadentials = GetSignInCredentials();

            var claims = await GetClaimsAsync();

            var token = GenerateTokenOptions(singInCreadentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials singInCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var lifetime = Convert.ToDouble(jwtSettings.GetSection("lifetime").Value);

            var expiration = DateTime.Now.AddMinutes(lifetime);

            var issuer = jwtSettings.GetSection("Issuer").Value;

            var token = new JwtSecurityToken(
                issuer: issuer,
                claims: claims,
                expires: expiration,
                signingCredentials: singInCredentials);

            return token;
        }

        private async Task<List<Claim>> GetClaimsAsync()
        {
            var claims = new List<Claim>
             {
                 new Claim(ClaimTypes.Name, _user.UserName)
             };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSignInCredentials()
        {
            var key = _configuration.GetSection("Jwt").GetSection("Key").Value;

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginDto userDto)
        {
            _user = await _userManager.FindByNameAsync(userDto.Email);

            var validPassword = await _userManager.CheckPasswordAsync(_user, userDto.Password);

            return (_user != null && validPassword);
        }
    }
}
