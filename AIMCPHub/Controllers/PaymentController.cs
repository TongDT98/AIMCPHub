using AIMCPHub.Helpper;
using AIMCPHub.Utils.Extensions;
using App.Bussiness.DTOS.Request.Transaction;
using App.Bussiness.DTOS.Response;
using App.Bussiness.DTOS.Response.Transaction;
using App.Bussiness.Interfaces;
using App.Core.Helper;
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
        private readonly ILogger<PaymentController> _logger;
        public PaymentController(ITransactionService transactionService, IConfiguration config, ILogger<PaymentController> logger)
        {
            _transactionService = transactionService;
            _config = config;
            _logger = logger;
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
            if (ip.Length < 7) ip = "103.178.211.231"; // dia chi server
            string time = TimezoneConvert.GetVietnamTimeString();
            _logger.LogInformation($"[{time}] IP Create payment : {ip}");
            var url =  _transactionService.CreatePaymentUrl(req,ip);
            _logger.LogInformation($"[{time}] VNP Create Link : {url.Data}");
            return url;
        }     
        [HttpGet("ipn")]
        public IActionResult VnpayIPn()
        {
            var query = Request.Query;
            var requestData = Request.QueryString.Value ?? "";
            string time = TimezoneConvert.GetVietnamTimeString();
            _logger.LogInformation($"[{time}] VNP IPN : {requestData}");
            if (query == null) return Ok(new VnPayResponse {RspCode = "99",Message = "Input data required" });
            var validSerect = VnPayHelpper.ValidateSignature(query, _config["VnPay:HashSecret"] ?? "");
            if (!validSerect)
                _logger.LogError("Secretkey invalid");
                //return Ok(new VnPayResponse { RspCode = "97", Message = "Invalid signature" });
            var dataReuest = VnPayHelpper.GetDataVnpCallback(query,requestData);
            return Ok( _transactionService.HandlerVnpayIPN(dataReuest,validSerect));
            
        }
        [HttpGet("returnurl")]
        public IActionResult VnpayReturnUrl()
        {
            var query = Request.Query;
            var requestData = Request.QueryString.Value ?? "";
            string time = TimezoneConvert.GetVietnamTimeString();
            _logger.LogInformation($"[{time}] VNP Ruturn URL : {requestData}");
            if (query == null) return Ok(new VnPayResponse { RspCode = "99", Message = "Input data required" });          
            var validSerect = VnPayHelpper.ValidateSignature(query, _config["VnPay:HashSecret"] ?? "");
            if (!validSerect)
                _logger.LogError("Secretkey invalid");
            var dataReuest = VnPayHelpper.GetDataVnpCallback(query, requestData);
            return Ok(_transactionService.HandlerVnpayReturn(dataReuest, validSerect));           
        }
    }
}
