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

        #region Get Transactions by FromPhoneNumber

        [HttpGet("{fromPhoneNumber}")]
        public async Task<IActionResult> GetTransactionByFromPhoneNumber(string fromPhoneNumber)
        {
            var transaction = await _bL_Transaction.GetTransactionByFromPhoneNumberAsync(fromPhoneNumber);
            if(transaction is null)
            {
                return NotFound("No transaction found");
            }
            return Ok(transaction);
        }

        #endregion

        #region Create Transaction

        [HttpPost]
        public async Task<IActionResult> CreateTransactionAsync([FromBody] TransactionResponseModel transaction)
        {
            if(transaction is null)
            {
                return BadRequest("Invalid transaction request.");
            }
            var result = await _bL_Transaction.CreateTransactionAsync(transaction);

            if(result is null)
            {
                return BadRequest("Transaction Failed");
            }
            return Ok("Transaction completed successfully");
        }

        #endregion
    }
}
