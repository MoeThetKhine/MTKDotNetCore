using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpay.Database.Models.Deposit;
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

        #region Create Deposit

        [HttpPost]
        public async Task<IActionResult> CreateDeposit([FromBody] DepositResponseModel deposit)
        {
            if (deposit is null)
            {
                return BadRequest("Invalid deposit request.");
            }

            var result = await _bL_Deposit.CreateDepositAsync(deposit);
            
            if(result is null)
            {
                return BadRequest("Deposit Failed");
            }
            return Ok("Deposit process completed successfully");
        }

        #endregion
    }
}
