

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

        #region Create Deposit

        public async Task<string> CreateDepositAsync(DepositResponseModel deposit)
        {
            var currentUser = await _dA_Deposit.GetUserByPhoneNumberAsync(deposit.PhoneNumber);
            if (currentUser is null)
            {
                return "User with this phone number does not exist.";
            }

            if (deposit.Balance <= 0)
            {
                return "Deposit amount must be greater than 0.";
            }

            var updatedBalance = currentUser.Balance + deposit.Balance;
            int updateResult = await _dA_Deposit.UpdateUserBalanceAsync(deposit.PhoneNumber, updatedBalance);

            if (updateResult == 0)
            {
                return "Failed to update the user balance.";
            }

            int insertResult = await _dA_Deposit.CreateDepositAsync(deposit);

            return insertResult > 0 ? "Deposit process completed successfully." : "Deposit process failed.";
        }

        #endregion
    }
}
