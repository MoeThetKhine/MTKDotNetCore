using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpayDapperApi.Models.Deposit;
using MTKDotNetCore.MiniKpayDapperApi.Models.User;
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

        #region Create Withdraw

        [HttpPost]
        public IActionResult CreateWithdraw(WithdrawResponseModel withdraw)
        {
            #region Check User with this PhNo Exist or not

            string userQuery = "SELECT Balance FROM Tbl_User WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
            var currentUser = _dapperService.QueryFirstOrDefault<UserModel>(userQuery, new { PhoneNumber = withdraw.PhoneNumber });

            #endregion

            if (currentUser is null)
            {
                return BadRequest("User with this phone number does not exist.");
            }
            if (withdraw.Balance <= 0)
            {
                return BadRequest("Withdrawal amount must be greater than 0.");
            }
            if (currentUser.Balance < withdraw.Balance)
            {
                return BadRequest("Insufficient balance.");
            }
            var updatedBalance = currentUser.Balance - withdraw.Balance;

            #region Update balance from user table

            string updateBalanceQuery = "UPDATE Tbl_User SET Balance = @UpdatedBalance WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
            int updateResult = _dapperService.Execute(updateBalanceQuery, new { UpdatedBalance = updatedBalance, PhoneNumber = withdraw.PhoneNumber });

            #endregion

            if (updateResult == 0)
            {
                return NotFound("Update the user balance failed.");
            }

            string insertWithdrawQuery = @"
        INSERT INTO Tbl_Withdraw (PhoneNumber, Balance, DeleteFlag)
        VALUES (@PhoneNumber, @Balance, 0);";

            int insertResult = _dapperService.Execute(insertWithdrawQuery, withdraw);

            if (insertResult == 0)
            {
                return BadRequest("Withdrawal failed.");
            }

            return Ok("Withdrawal completed successfully.");
        }

        #endregion 

    }
}
