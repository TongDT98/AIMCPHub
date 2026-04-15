using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.DTOS.Response.Users
{
    public class AuthUserDto
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public int Gender { get; set; }      
        public string Code { get; set; }
        public string Token { get; set; }
        public List<string>? Permissions { get; set; }
        public string RefreshToken { get; set; }
        public string RoleCode { get; set; }
    }
}
