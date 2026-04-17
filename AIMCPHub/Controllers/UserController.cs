using AIMCPHub.Utils.Extensions;
using App.Bussiness.DTOS.Request;
using App.Bussiness.DTOS.Request.User;
using App.Bussiness.DTOS.Response;
using App.Bussiness.Interfaces;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AIMCPHub.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet(Name = "GetUserById")]
        public GenericActionResult Get(Guid id)
        {
            return _userService.GetUser(id);
        }
        [HttpPost("Search")]
        public GenericActionResult Search(FilterModel<SearchUserRequest> request)
        {
            return _userService.Search(request);
        }
        [HttpPost("Create")]
        public GenericActionResult Create(CreateUSerRequest request)
        {
            return _userService.CreateUser(request);
        }
        [HttpPost("change-password")]
        [Authorize]
        public GenericActionResult ChangePassword(ChangePasswordRequest request)
        {
            var id = User.GetUserId();
            Guid guidId = Guid.Parse(id);
            return _userService.ChangePassword(request,guidId);
        }

    }
}
