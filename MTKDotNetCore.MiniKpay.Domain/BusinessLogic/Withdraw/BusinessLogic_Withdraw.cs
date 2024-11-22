using MTKDotNetCore.MiniKpay.Database.DataAccess.Withdraw;
using MTKDotNetCore.MiniKpay.Database.Models.Withdraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCore.MiniKpay.Domain.BusinessLogic.Withdraw
{
    public class BusinessLogic_Withdraw
    {
        private readonly DataAccess_Withdraw _dA_Withdraw;

        public BusinessLogic_Withdraw(DataAccess_Withdraw dA_Withdraw)
        {
            _dA_Withdraw = dA_Withdraw;
        }

        #region Get Withdraw List

        public async Task<List<WithdrawModel>> GetWithdrawListAsync()
        {
            return await _dA_Withdraw.GetWithdrawListAsync();
        }

        #endregion

    }
}
