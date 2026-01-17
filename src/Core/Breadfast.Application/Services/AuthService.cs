using Breadfast.Domain.Entities.User;
using Breadfast.Domain.Interfaces.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(ApplcationUser user, UserManager<ApplcationUser> userManager)
        {

            // token 3
            // header // 2.TokenType, Algo
            // payload //  Clamis
            // Signature // SecrtKey --> Hashing


            var authClamis = new List<Claim>()
                {
                  new Claim(ClaimTypes.Email, user.Email!),
                  new Claim(ClaimTypes.MobilePhone, user.PhoneNumber!)
                };

            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                authClamis.Add(new Claim(ClaimTypes.Role, role));
            }


            var key = _configuration["JWT:authKey"];

            var secrtkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key ?? string.Empty));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:issuer"],
                audience: _configuration["JWT:audience"],
                claims: authClamis,
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:expireData"] ?? "0")),
                signingCredentials: new SigningCredentials(secrtkey, SecurityAlgorithms.HmacSha256Signature));




            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
