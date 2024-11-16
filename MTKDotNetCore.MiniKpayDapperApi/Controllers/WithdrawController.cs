using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpayDapperApi.Models.Deposit;
using MTKDotNetCore.MiniKpayDapperApi.Models.Withdraw;

namespace MTKDotNetCore.MiniKpayDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        private readonly DapperService _dapperService;

        public WithdrawController(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        #region Get Withdraw List

        [HttpGet]
        public IActionResult GetWithdraw()
        {
            string query = "SELECT * FROM Tbl_Withdraw WHERE DeleteFlag = 0;";
            List<WithdrawModel> lst = _dapperService.Query<WithdrawModel>(query).ToList();
            return Ok(lst);
        }

        #endregion

        #region Get Withdraw By PhoneNumber

        [HttpGet("{phoneNumber}")]
        public IActionResult GetWithdrawByPhoneNumber(string phoneNumber)
        {
            string query = "SELECT * FROM Tbl_Withdraw WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";

            var withdraws = _dapperService.Query<WithdrawModel>(query, new { PhoneNumber = phoneNumber });

            if (withdraws is null)
            {
                return NotFound("No withdraws found for the given phone number.");
            }
            return Ok(withdraws);
        }

        #endregion 


    }
}
