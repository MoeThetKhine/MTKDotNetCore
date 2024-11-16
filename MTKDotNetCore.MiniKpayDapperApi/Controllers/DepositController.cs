using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpayDapperApi.Models.Deposit;
using MTKDotNetCore.MiniKpayDapperApi.Models.User;
using MTKDotNetCore.MiniKpayDapperApi.Models.Withdraw;

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

        #region CreateDeposit

        [HttpPost]

        public IActionResult CreateDeposit(DepositResponseModel deposit)
        {

            #region Check User with this PhNo Exist or not

            string userQuery = "SELECT Balance FROM Tbl_User WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
            var currentUser = _dapperService.QueryFirstOrDefault<UserModel>(userQuery,new {PhoneNumber = deposit.PhoneNumber});

            #endregion

            if (currentUser is null)
            {
                return BadRequest("User with this phone number does not exists.");
            }
            if(deposit.Balance <= 0)
            {
                return BadRequest("Deposit amount must be greater than 0.");
            }

            var updatedBalance = currentUser.Balance + deposit.Balance;

            #region Update balance in user table

            string updateBalanceQuery = "UPDATE Tbl_User SET Balance = @UpdatedBalance WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
            int updateResult = _dapperService.Execute(updateBalanceQuery, new
            {
                UpdatedBalance = updatedBalance,  // Corrected to match the SQL query
                PhoneNumber = deposit.PhoneNumber
            });

            #endregion

            if (updateResult == 0)
            {
                return NotFound("Update the user balance failed.");
            }
            string insertDepositQuery = @"INSERT INTO Tbl_Deposit (PhoneNumber, Balance, DeleteFlag) VALUES (@PhoneNumber, @Balance, 0);";

            int insertResult = _dapperService.Execute(insertDepositQuery, deposit);

            if(insertResult == 0)
            {
                return BadRequest("Deposit process failed");
            }
            return Ok("Deposit process completed successfully.");
        }

        #endregion

    }
}
