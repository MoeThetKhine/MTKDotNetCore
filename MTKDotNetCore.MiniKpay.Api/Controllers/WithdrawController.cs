namespace MTKDotNetCore.MiniKpay.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WithdrawController : BaseController
{
    private readonly BusinessLogic_Withdraw _bL_Withdraw;

    public WithdrawController(BusinessLogic_Withdraw businessLogic_Withdraw)
    {
        _bL_Withdraw = businessLogic_Withdraw;
    }

    #region Get Withdraw List

    [HttpGet]
    public async Task<IActionResult> GetWithdrawList()
    {
        var withdrawList = await _bL_Withdraw.GetWithdrawListAsync();

        if (withdrawList is null)
        {
            return NotFound("No withdrawal records found.");
        }

        return Ok(withdrawList);
    }

    #endregion

    #region Get Withdraw By Phone Number

    [HttpGet("{phoneNumber}")]
    public async Task<IActionResult> GetWithdrawByPhoneNumber(string phoneNumber)
    {
        var withdraws = await _bL_Withdraw.GetWithdrawByPhoneNumberAsync(phoneNumber);

        if (withdraws is null)
        {
            return NotFound("No withdrawals found for phone number.");
        }

        return Ok(withdraws);
    }

    #endregion

    #region Create Withdraw

    [HttpPost]
    public async Task<IActionResult> CreateWithdraw([FromBody] WithdrawResponseModel withdraw)
    {
        if (withdraw is null)
        {
            return BadRequest("Invalid withdrawal request.");
        }

        var result = await _bL_Withdraw.CreateWithdrawAsync(withdraw);

        if (result is null)
        {
            return BadRequest("Withdrawal completed successfully.");
        }
        return Ok(result);
    }

    #endregion
}
