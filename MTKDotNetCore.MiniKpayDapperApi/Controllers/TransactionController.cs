using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MiniKpayDapperApi.Models.Transaction;
using MTKDotNetCore.MiniKpayDapperApi.Models.User;
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

        #region Create Transaction

        [HttpPost]
        public IActionResult CreateTransaction(TransactionResponseModel transaction)
        {
            if (transaction.Amount <= 0)
            {
                return BadRequest("Transaction amount must be greater than 0.");
            }

            if (transaction.FromPhoneNumber == transaction.ToPhoneNumber)
            {
                return BadRequest("Sender and receiver phone numbers must be different.");
            }

            #region Check existence of FromPhoneNumber (Sender)

            string senderQuery = "SELECT Balance, Pin FROM Tbl_User WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";

            var senderUser = _dapperService.QueryFirstOrDefault<UserModel>(senderQuery, new { PhoneNumber = transaction.FromPhoneNumber });

            if (senderUser is null)
            {
                return BadRequest("Sender phone number does not exist in the system.");
            }

            if (senderUser.Pin != transaction.Pin)
            {
                return BadRequest("Invalid PIN for the sender's phone number.");
            }


            #endregion

            #region Check existence of ToPhoneNumber (Receiver)

            var receiverUser = _dapperService.QueryFirstOrDefault<UserModel>(senderQuery, new { PhoneNumber = transaction.ToPhoneNumber });

            if (receiverUser is null)
            {
                return BadRequest("Receiver phone number does not exist in the system.");
            }

            #endregion

            if (senderUser.Balance < transaction.Amount)
            {
                return BadRequest("Sender has insufficient balance for this transaction.");
            }

            var updatedSenderBalance = senderUser.Balance - transaction.Amount;
            var updatedReceiverBalance = receiverUser.Balance + transaction.Amount;

            #region Update sender's balance

            string updateSenderBalanceQuery = "UPDATE Tbl_User SET Balance = @UpdatedBalance WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
            int updateSenderResult = _dapperService.Execute(updateSenderBalanceQuery, new
            {
                UpdatedBalance = updatedSenderBalance,
                PhoneNumber = transaction.FromPhoneNumber
            });

            if (updateSenderResult == 0)
            {
                return BadRequest("Failed to update sender's balance.");
            }

            #endregion

            #region Update receiver's balance

            string updateReceiverBalanceQuery = "UPDATE Tbl_User SET Balance = @UpdatedBalance WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
            int updateReceiverResult = _dapperService.Execute(updateReceiverBalanceQuery, new
            {
                UpdatedBalance = updatedReceiverBalance,
                PhoneNumber = transaction.ToPhoneNumber
            });

            if (updateReceiverResult == 0)
            {
                return BadRequest("Failed to update receiver's balance.");
            }

            #endregion

            #region Insert transaction record

            string insertTransactionQuery = @"INSERT INTO Tbl_Transaction 
                                      (FromPhoneNumber, ToPhoneNumber, Amount,Pin, DeleteFlag) 
                                      VALUES (@FromPhoneNumber, @ToPhoneNumber, @Amount,@Pin, 0);";

            int insertResult = _dapperService.Execute(insertTransactionQuery, transaction);

            if (insertResult == 0)
            {
                return BadRequest("Transaction process failed.");
            }

            #endregion

            return Ok("Transaction completed successfully.");
        }

        #endregion
    }
}
