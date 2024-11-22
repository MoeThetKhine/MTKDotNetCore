using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpay.Domain.BusinessLogic.Deposit;

namespace MTKDotNetCore.MiniKpay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
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
            var deposits = await _bL_Deposit.GetDepositListAsync();
            if (deposits is null)
            {
                return NotFound("No deposits found.");
            }

            return Ok(deposits);
        }

        #endregion

        #region Get Deposit By PhoneNumber

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetDepositByPhoneNumber(string phoneNumber)
        {
            var deposits = await _bL_Deposit.GetDepositByPhoneNumberAsync(phoneNumber);
            if (deposits is null)
            {
                return NotFound("No deposits found for phone number.");
            }

            return Ok(deposits);
        }

        #endregion
    }
}
