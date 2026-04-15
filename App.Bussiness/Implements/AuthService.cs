using App.Bussiness.DTOS.Response;
using App.Bussiness.DTOS.Response.Users;
using App.Bussiness.Helpper;
using App.Bussiness.Interfaces;
using App.Core.Configurations;
using App.Core.Helper;
using App.DAL.Entities;
using App.DAL.Repositories.Implements;
using App.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _user;
        private readonly IRoleRepository _role;
        private readonly IUserPermissionRepository _permission;
        private readonly IConfiguration _config;
        public AuthService(IUserRepository user, IRoleRepository role, IUserPermissionRepository permission, IConfiguration config)
        {
            _user = user;
            _role = role;
            _permission = permission;
            _config = config;
        }
        public GenericActionResult LoginAsync(string username, string password)
        {
            var user =  _user.Queryable().FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return new GenericActionResult("404", "User Name not found", 404
                  );
            }
            byte[] saltBytes = Convert.FromBase64String(user.PasswordSalt);
            var pass = PasswordHasher.VerifyPassword(password, user.PasswordHash, saltBytes);

            var role = _role.Queryable().FirstOrDefault(x=>x.Id == user.RoleId);
            var userauth = new AuthUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                LastName = user.LastName,
                FirstName = user.FirstName,
                RoleCode = role?.Code ?? "",
                Code = user.Code,

            };
            var jwr = new JwtConfiguration
            {
                SecretKey = _config["Jwt:SecretKey"],
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
            };



            var permissions = new List<string>();
            var token = AuthHelper.GenerateAccessToken(userauth, jwr, true);
            var refreshToken = AuthHelper.GenerateRefreshToken();
           
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            user.RefreshToken = refreshToken;
            _user.Update(user);
             _user.SaveChange();
           
            userauth.Token = token;
            userauth.RefreshToken = refreshToken;
            return new GenericActionResult(userauth);
        }
    //    private string GenerateJwt(ApplicationUser user, List<string> permissions)
    //    {
    //        var claims = new List<Claim>
    //{
    //    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    //    new Claim(ClaimTypes.Name, user.UserName),
    //    new Claim(ClaimTypes.Role, user.RoleId.ToString())
    //};

    //        // Add permissions
    //        claims.AddRange(permissions.Select(p => new Claim("permission", p)));

    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SECRET_KEY"));
    //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //        var token = new JwtSecurityToken(
    //            claims: claims,
    //            expires: DateTime.UtcNow.AddHours(2),
    //            signingCredentials: creds
    //        );

    //        return new JwtSecurityTokenHandler().WriteToken(token);
    //    }
    }
}
