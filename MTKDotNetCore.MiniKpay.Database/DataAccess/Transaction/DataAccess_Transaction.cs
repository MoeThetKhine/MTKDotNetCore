using MTKDotNetCore.MiniKpay.Database.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCore.MiniKpay.Database.DataAccess.Transaction
{
    public class DataAccess_Transaction
    {
        private readonly DapperService _dapperService;

        public DataAccess_Transaction(DapperService dapperService)
        {
            _dapperService = dapperService;
        }
        #region Get All Transactions

        public async Task<List<TransactionModel>> GetTransactionListAsync()
        {
            string query = "SELECT * FROM Tbl_Transaction WHERE DeleteFlag = 0;";
            var result = await _dapperService.QueryAsync<TransactionModel>(query);
            return result.ToList();
        }

        #endregion

        #region Get Transaction By From Phone Number

        public async Task<List<TransactionModel>> GetTransactionByFromPhoneNumberAsync(string fromPhoneNumber)
        {
            string query = "SELECT * FROM Tbl_Transaction WHERE FromPhoneNumber = @FromPhoneNumber AND DeleteFlag = 0;";
            var result = await _dapperService.QueryAsync<TransactionModel>(query, new { fromPhoneNumber = fromPhoneNumber });
            return result.ToList();
        }

        #endregion

        #region Get User By Phone Number 

        public async Task<UserModel> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            string query = "SELECT * FROM Tbl_User WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
            return await _dapperService.QueryFirstOrDefaultAsync<UserModel>(query, new { phoneNumber = phoneNumber });
        }

        #endregion

    }
}
