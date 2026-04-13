using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.DTOS.Request.User
{
    public class SearchUserRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
