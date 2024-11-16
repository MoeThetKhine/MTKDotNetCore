using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpayDapperApi.Models.Deposit;

namespace MTKDotNetCore.MiniKpayDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly DapperService _dapperService;

        public DepositController(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        #region GetDeposits List

        [HttpGet]
        public IActionResult GetDeposits()
        {
            string query = "SELECT * FROM Tbl_Deposit WHERE DeleteFlag = 0;";
            List<DepositModel> lst = _dapperService.Query<DepositModel>(query).ToList();
            return Ok(lst);
        }

        #endregion

        #region Get Deposit By PhoneNumber

        [HttpGet("{phoneNumber}")]
        public IActionResult GetDepositByPhoneNumber(string phoneNumber)
        {
            string query = "SELECT * FROM Tbl_Deposit WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";

            var deposits = _dapperService.Query<DepositModel>(query, new { PhoneNumber = phoneNumber });

            if (deposits is null)
            {
                return NotFound("No deposits found for the given phone number.");
            }
            return Ok(deposits);
        }

        #endregion 

    }
}
