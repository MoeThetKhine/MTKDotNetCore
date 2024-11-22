using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpay.Domain.BusinessLogic.Withdraw;

namespace MTKDotNetCore.MiniKpay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
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
    }
}
