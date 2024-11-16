using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpayDapperApi.Models.Transaction;
using MTKDotNetCore.MiniKpayDapperApi.Models.Withdraw;
using System.Transactions;

namespace MTKDotNetCore.MiniKpayDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly DapperService _dapperService;

        public TransactionController(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        #region Get Transaction List

        [HttpGet]
        public IActionResult GetTransaction()
        {
            string query = "SELECT * FROM Tbl_Transaction WHERE DeleteFlag = 0;";
            List<TransactionModel> lst = _dapperService.Query<TransactionModel>(query).ToList();
            return Ok(lst);
        }

        #endregion

        #region Get Transaction By FromPhoneNumber

        [HttpGet("{fromPhoneNumber}")]
        public IActionResult GetTransactionByFromPhoneNumber(string fromPhoneNumber)
        {
            string query = "SELECT * FROM Tbl_Transaction WHERE FromPhoneNumber = @FromPhoneNumber AND DeleteFlag = 0;";

            var transaction = _dapperService.Query<TransactionModel>(query, new { FromPhoneNumber = fromPhoneNumber });

            if (transaction is null)
            {
                return NotFound("No transaction found for User With this phone number.");
            }
            return Ok(transaction);
        }

        #endregion 

    }
}
