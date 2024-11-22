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

        #region Get Withdraw By PhoneNumber

        public async Task<List<WithdrawModel>> GetWithdrawByPhoneNumberAsync(string phoneNumber)
        {
            return await _dA_Withdraw.GetWithdrawByPhoneNumberAsync(phoneNumber);
        }

        #endregion

        #region Create Withdraw

        public async Task<string> CreateWithdrawAsync(WithdrawResponseModel withdraw)
        {
            var currentUser = await _dA_Withdraw.GetUserByPhoneNumberAsync(withdraw.PhoneNumber);
            if (currentUser is null)
            {
                return "User with this phone number does not exist.";
            }

            if (withdraw.Balance <= 0)
            {
                return "Withdrawal amount must be greater than 0.";
            }

            if (currentUser.Balance < withdraw.Balance)
            {
                return "Insufficient balance.";
            }

            var updatedBalance = currentUser.Balance - withdraw.Balance;
            var updateResult = await _dA_Withdraw.UpdateUserBalanceAsync(withdraw.PhoneNumber, updatedBalance);

            if (updateResult == 0)
            {
                return "Failed to update the user balance.";
            }

            int result = await _dA_Withdraw.CreateWithdrawAsync(withdraw);
            return result > 0 ? "Withdrawal completed successfully." : "Withdrawal failed.";
        }

        #endregion

    }
}
