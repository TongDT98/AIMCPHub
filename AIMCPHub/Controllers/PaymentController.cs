using App.Bussiness.DTOS.Request.Transaction;
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
        public async Task<IActionResult> Create([FromBody] PaymentRequest req)
        {
           var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var url =  _transactionService.CreatePaymentUrl(req,ip);

            return Ok(new { url });
        }

    }
}
