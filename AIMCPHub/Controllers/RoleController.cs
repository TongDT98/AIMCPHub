using App.Bussiness.DTOS.Request.User;
using App.Bussiness.DTOS.Request;
using App.Bussiness.DTOS.Response;
using Microsoft.AspNetCore.Mvc;
using App.Bussiness.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace AIMCPHub.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) 
        { 
            _roleService = roleService;
        }
        [HttpPost("list")]
        [Authorize]
        public GenericActionResult List()
        {
            return _roleService.ListRole();
        }
    }
}
