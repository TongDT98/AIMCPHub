using App.Bussiness.DTOS.Request;
using App.Bussiness.DTOS.Request.User;
using App.Bussiness.DTOS.Response;
using App.Bussiness.Interfaces;
using Azure.Core;
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
        //public bool ValidateSignature(IQueryCollection query)
        //{
        //    var hashSecret = _config["VnPay:HashSecret"];

        //    var data = new SortedList<string, string>();

        //    foreach (var key in query.Keys)
        //    {
        //        if (key.StartsWith("vnp_") && key != "vnp_SecureHash")
        //        {
        //            data.Add(key, query[key]);
        //        }
        //    }

        //    var raw = string.Join("&", data.Select(x => $"{x.Key}={x.Value}"));

        //    var checkHash = HmacSHA512(hashSecret, raw);

        //    return checkHash == query["vnp_SecureHash"];
        //}

    }
}
