using App.Bussiness.DTOS.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.Interfaces
{
    public interface IAuthService
    {
        GenericActionResult LoginAsync(string username, string password);
    }
}
