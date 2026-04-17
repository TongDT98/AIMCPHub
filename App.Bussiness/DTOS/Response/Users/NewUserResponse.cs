using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.DTOS.Response.Users
{
    public class NewUserResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string UserName { get; set; }
        public string DefaultPassword { get; set; }
        public string Role { get; set; }
    }
}
