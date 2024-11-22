using MTKDotNetCore.MiniKpay.Database.Models.Deposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCore.MiniKpay.Database.DataAccess.Deposit
{
    public class DataAccess_Deposit
    {
        private readonly DapperService _dapperService;

        public DataAccess_Deposit(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        #region Get Deposit List 

        public async Task<List<DepositModel>> GetDepositListAsync()
        {
            string query = "SELECT * FROM Tbl_Deposit WHERE DeleteFlag = 0;";
            var result = await _dapperService.QueryAsync<DepositModel>(query); 
            return result.ToList();
        }

        #endregion

        #region Get Deposit By PhoneNumber Async

        public async Task<List<DepositModel>> GetDepositByPhoneNumberAsync(string phoneNumber)
        {
            string query = "SELECT * FROM Tbl_Deposit WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
            var result = await _dapperService.QueryAsync<DepositModel>(query, new { PhoneNumber = phoneNumber });
            return result.ToList();
        }

        #endregion

       
    }
}
    