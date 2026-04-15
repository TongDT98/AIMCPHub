using AIMCPHub.Utils.Extensions;
using App.Bussiness.DTOS.Request.Transaction;
using App.Bussiness.DTOS.Request.User;
using App.Bussiness.DTOS.Response;
using App.Bussiness.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIMCPHub.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }
       
        [HttpPost("login")]
        public GenericActionResult Login([FromBody] LoginRequest req)
        {


            return _auth.LoginAsync(req.UserName,req.Password);
        }
    }
}
