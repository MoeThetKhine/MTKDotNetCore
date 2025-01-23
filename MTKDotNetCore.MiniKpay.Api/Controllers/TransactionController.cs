namespace MTKDotNetCore.MiniKpay.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : BaseController
{
    private readonly BusinessLogic_Transaction _bL_Transaction;

    public TransactionController(BusinessLogic_Transaction businessLogic_Transaction)
    {
        _bL_Transaction = businessLogic_Transaction;
    }

    #region Get Transaction List

        [HttpGet]
        public async Task<IActionResult> GetTransactionList()
        {
            var result = await _bL_Transaction.GetTransactionAsync();
            if (result.IsError)
            {
                if (result.Type == EnumRespType.SystemError)
                {
                    return StatusCode(500, result.Message); 
                }
                return BadRequest(result.Message); 
            }
            return Ok(result.Data);
        }

        #endregion

    #region Get Transactions by Phone Number

        [HttpGet("{fromPhoneNumber}")]
        public async Task<IActionResult> GetTransactionByFromPhoneNumber(string fromPhoneNumber)
        {
            var result = await _bL_Transaction.GetTransactionByFromPhoneNumberAsync(fromPhoneNumber);
            if (result.IsError)
            {
                if (result.Type == EnumRespType.SystemError)
                {
                    return StatusCode(500, result.Message); 
                }
                return BadRequest(result.Message); 
            }
            return Ok(result.Data);
        }

        #endregion

    #region Create Transaction

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionResponseModel transaction)
        {
            var result = await _bL_Transaction.CreateTransactionAsync(transaction);
            if (result.IsError)
            {
                if (result.Type == EnumRespType.SystemError)
                {
                    return StatusCode(500, result.Message); 
                }
                return BadRequest(result.Message); 
            }
            return Ok(result.Message);
        }

        #endregion
}
