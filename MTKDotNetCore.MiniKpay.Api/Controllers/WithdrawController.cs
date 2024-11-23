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
        var result = await _bL_Withdraw.GetWithdrawListAsync();

        if (result.IsError)
            return StatusCode((int)result.Type, result.Message);

        return Ok(result.Data);
    }

    #endregion

    #region Get Withdraw By Phone Number

    [HttpGet("{phoneNumber}")]
    public async Task<IActionResult> GetWithdrawByPhoneNumber(string phoneNumber)
    {
        var result = await _bL_Withdraw.GetWithdrawByPhoneNumberAsync(phoneNumber);

        if (result.IsError)
            return StatusCode((int)result.Type, result.Message);

        return Ok(result.Data);
    }

    #endregion

    #region Create Withdraw

    [HttpPost]
    public async Task<IActionResult> CreateWithdraw([FromBody] WithdrawResponseModel withdraw)
    {
        if (withdraw is null)
            return BadRequest("Invalid withdrawal request.");

        var result = await _bL_Withdraw.CreateWithdrawAsync(withdraw);

        if (result.IsError)
            return StatusCode((int)result.Type, result.Message);

        return Ok(result.Message);
    }

    #endregion
}
