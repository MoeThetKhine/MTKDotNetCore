namespace MTKDotNetCore.MiniKpay.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepositController : BaseController
{
    private readonly BusinessLogic_Deposit _bL_Deposit;

    public DepositController(BusinessLogic_Deposit businessLogic_Deposit)
    {
        _bL_Deposit = businessLogic_Deposit;
    }

    #region Get Deposit List

        [HttpGet]
        public async Task<IActionResult> GetDeposits()
        {
            var result = await _bL_Deposit.GetDepositListAsync();

            if (result.IsError)
            {
                return result.Type switch
                {
                    EnumRespType.ValidationError => NotFound(result.Message),
                    EnumRespType.SystemError => StatusCode(500, result.Message),
                    _ => BadRequest("An unexpected error occurred.")
                };
            }

            return Ok(new { data = result.Data, message = result.Message });
        }

        #endregion

    #region Get Deposit By PhoneNumber

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetDepositByPhoneNumber(string phoneNumber)
        {
            var result = await _bL_Deposit.GetDepositByPhoneNumberAsync(phoneNumber);

            if (result.IsError)
            {
                return result.Type switch
                {
                    EnumRespType.ValidationError => NotFound(result.Message),
                    EnumRespType.SystemError => StatusCode(500, result.Message),
                    _ => BadRequest("An unexpected error occurred.")
                };
            }

            return Ok(new { data = result.Data, message = result.Message });
        }

        #endregion

    #region Create Deposit

        [HttpPost]
        public async Task<IActionResult> CreateDeposit([FromBody] DepositResponseModel deposit)
        {
            if (deposit is null)
            {
                return BadRequest("Invalid deposit request.");
            }

            var result = await _bL_Deposit.CreateDepositAsync(deposit);

            if (result.IsError)
            {
                return result.Type switch
                {
                    EnumRespType.ValidationError => BadRequest(result.Message),
                    EnumRespType.SystemError => StatusCode(500, result.Message),
                    _ => BadRequest("An unexpected error occurred.")
                };
            }

            return Ok(new { message = result.Message });
        }

        #endregion
}
