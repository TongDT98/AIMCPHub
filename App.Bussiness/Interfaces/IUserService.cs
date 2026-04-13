using App.Bussiness.DTOS.Request.User;
using App.Bussiness.DTOS.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Bussiness.DTOS.Response;

namespace App.Bussiness.Interfaces
{
    public interface IUserService
    {
        GenericActionResult GetUser(Guid id);
        GenericActionResult Search(FilterModel<SearchUserRequest> filter);
    }
}
