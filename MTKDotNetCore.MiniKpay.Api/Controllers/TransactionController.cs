using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpay.Domain.BusinessLogic.Transaction;

namespace MTKDotNetCore.MiniKpay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly BusinessLogic_Transaction _bL_Transaction;

        public TransactionController(BusinessLogic_Transaction businessLogicTransaction)
        {
            _bL_Transaction = businessLogicTransaction;
        }

        #region GetTransactions

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transaction = await _bL_Transaction.GetTransactionAsync();
            if(transaction is null)
            {
                return NotFound("No transaction found");
            }
            return Ok(transaction);
        }

        #endregion
    }
}
