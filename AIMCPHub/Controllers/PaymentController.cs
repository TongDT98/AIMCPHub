using AIMCPHub.Helpper;
using AIMCPHub.Utils.Extensions;
using App.Bussiness.DTOS.Request.Transaction;
using App.Bussiness.DTOS.Response;
using App.Bussiness.DTOS.Response.Transaction;
using App.Bussiness.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AIMCPHub.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IConfiguration _config;
        public PaymentController(ITransactionService transactionService, IConfiguration config)
        {
            _transactionService = transactionService;
            _config = config;
        }
        [Authorize]
       // [Authorize(Roles = "ACC")]
        [HttpPost("create-link")]
        public GenericActionResult CreatePaymentLink([FromBody] PaymentRequest req)
        {
            var role = User.GetRole();
           // var userRole = UserExtensions.GetRole();
           // if (userRole != "Accounting") return new GenericActionResult { HttpStatusCode = 403,Message = "BẠn không có quyền tạo chuyenr khoản" };
           var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
                       
            var url =  _transactionService.CreatePaymentUrl(req,ip);
            return url;
        }     
        [HttpGet("ipn")]
        public IActionResult VnpayIPn()
        {
            var query = Request.Query;
            var requestData = Request.QueryString.Value ?? "";
            if (query == null) return Ok(new VnPayResponse {RspCode = "99",Message = "Request is empty"});
            var validSerect = VnPayHelpper.ValidateSignature(query, _config["VnPay:HashSecret"] ?? "");
            if (!validSerect) return Ok(new VnPayResponse { RspCode = "97", Message = "Invalid signature" });
            var dataReuest = VnPayHelpper.GetDataVnpCallback(query,requestData);
            return Ok( _transactionService.HandlerVnpayIPN(dataReuest));
            
        }
        [HttpGet("return-url")]
        public IActionResult VnpayReturnUrl()
        {
            var query = Request.Query;
            var requestData = Request.QueryString.Value ?? "";
            if (query == null) return Ok(new VnPayResponse { RspCode = "99", Message = "Request is empty" });
            var validSerect = VnPayHelpper.ValidateSignature(query, _config["VnPay:HashSecret"] ?? "");
            var dataReuest = VnPayHelpper.GetDataVnpCallback(query, requestData);
            return Ok(_transactionService.HandlerVnpayReturn(dataReuest));           
        }
    }
}
