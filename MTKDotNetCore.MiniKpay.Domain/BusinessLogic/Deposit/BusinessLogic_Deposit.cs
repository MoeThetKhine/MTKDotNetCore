using MTKDotNetCore.MiniKpay.Database.DataAccess.Deposit;
using MTKDotNetCore.MiniKpay.Database.Models.Deposit;

namespace MTKDotNetCore.MiniKpay.Domain.BusinessLogic.Deposit
{
    public class BusinessLogic_Deposit
    {
        private readonly DataAccess_Deposit _dA_Deposit;

        public BusinessLogic_Deposit(DataAccess_Deposit dA_Deposit)
        {
            _dA_Deposit = dA_Deposit;
        }

        #region Get Deposit List Async

        public async Task<List<DepositModel>> GetDepositListAsync()
        {
            var result = await _dA_Deposit.GetDepositListAsync();
            return result;
        }

        #endregion

        #region Get Deposit By PhoneNumber Async

        public async Task<List<DepositModel>> GetDepositByPhoneNumberAsync(string phoneNumber)
        {
            var result = await _dA_Deposit.GetDepositByPhoneNumberAsync(phoneNumber);
            return result;
        }

        #endregion
    }
}
