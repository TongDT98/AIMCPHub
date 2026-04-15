using App.Bussiness.DTOS.Response.Users;
using App.Core.Configurations;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.Helpper
{
    public static class AuthHelper
    {
        public static string GenerateAccessToken(AuthUserDto user, JwtConfiguration? jwtConfiguration, bool rememberMe = false)
        {
            var expiresVal = rememberMe
                ? new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime
                : new DateTimeOffset(DateTime.Now.AddMinutes(60))
                    .DateTime; // in this case: user selected remember me button
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration?.SecretKey ?? string.Empty));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwtConfiguration?.Issuer ?? string.Empty,
                audience: jwtConfiguration?.Audience ?? string.Empty,
                claims: BuildClaims(user),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: expiresVal,
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private static IEnumerable<Claim> BuildClaims(AuthUserDto data)
        {
            var claims = new[]
            {
                 new Claim(ClaimTypes.Name, data.UserName ?? string.Empty),
                 new Claim(ClaimTypes.NameIdentifier, data.Id.ToString()),
                 new Claim(ClaimTypes.Role, data.RoleCode ?? string.Empty),
                 new Claim("Code", data.Code),
                 new Claim("Email", data.Email ?? string.Empty),               

            };
            return claims;
        }
        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
