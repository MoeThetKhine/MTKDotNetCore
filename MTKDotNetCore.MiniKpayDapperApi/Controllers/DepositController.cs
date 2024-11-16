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
    }
}
