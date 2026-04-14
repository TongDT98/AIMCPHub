using AIMCPHub.Helpper;
using App.Bussiness.DTOS.Request.Transaction;
using App.Bussiness.DTOS.Response;
using App.Bussiness.DTOS.Response.Transaction;
using App.Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AIMCPHub.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public PaymentController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpPost("create")]
        public GenericActionResult CreatePaymentLink([FromBody] PaymentRequest req)
        {
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
            var dataReuest = VnPayHelpper.GetDataVnpCallback(query,requestData);
            return Ok( _transactionService.HandlerVnpayIPN(dataReuest));
            
        }
        [HttpGet("return-url")]
        public IActionResult VnpayReturnUrl()
        {
            var query = Request.Query;
            var requestData = Request.QueryString.Value ?? "";
            if (query == null) return Ok(new VnPayResponse { RspCode = "99", Message = "Request is empty" });
            var dataReuest = VnPayHelpper.GetDataVnpCallback(query, requestData);
            return Ok(_transactionService.HandlerVnpayReturn(dataReuest));           
        }
    }
}
