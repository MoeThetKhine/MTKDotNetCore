using MTKDotNetCore.MiniKpay.Database.DataAccess.Withdraw;
using MTKDotNetCore.MiniKpay.Database.Models.Withdraw;

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

        public async Task<Result<List<WithdrawModel>>> GetWithdrawListAsync()
        {
            var withdraws = await _dA_Withdraw.GetWithdrawListAsync();

            if (withdraws is null)
            {
                return Result<List<WithdrawModel>>.ValidationError("No withdrawals found.");
            }

            return Result<List<WithdrawModel>>.Success(withdraws, "Withdrawal list retrieved successfully.");
        }

        #endregion

        #region Get Withdraw By PhoneNumber

        public async Task<Result<List<WithdrawModel>>> GetWithdrawByPhoneNumberAsync(string phoneNumber)
        {
            var withdraws = await _dA_Withdraw.GetWithdrawByPhoneNumberAsync(phoneNumber);

            if (withdraws is null)
            {
                return Result<List<WithdrawModel>>.ValidationError($"No withdrawals found for phone number {phoneNumber}.");
            }

            return Result<List<WithdrawModel>>.Success(withdraws, "Withdrawals retrieved successfully.");
        }

        #endregion

        #region Create Withdraw

        public async Task<Result<string>> CreateWithdrawAsync(WithdrawResponseModel withdraw)
        {
            var currentUser = await _dA_Withdraw.GetUserByPhoneNumberAsync(withdraw.PhoneNumber);

            if (currentUser is null)
            {
                return Result<string>.ValidationError("User with this phone number does not exist.");
            }

            if (withdraw.Balance <= 0)
            {
                return Result<string>.ValidationError("Withdrawal amount must be greater than 0.");
            }

            if (currentUser.Balance < withdraw.Balance)
            {
                return Result<string>.ValidationError("Insufficient balance.");
            }

            var updatedBalance = currentUser.Balance - withdraw.Balance;
            var updateResult = await _dA_Withdraw.UpdateUserBalanceAsync(withdraw.PhoneNumber, updatedBalance);

            if (updateResult == 0)
            {
                return Result<string>.SystemError(null, "Failed to update the user balance.");
            }

            int result = await _dA_Withdraw.CreateWithdrawAsync(withdraw);

            return result > 0
                ? Result<string>.Success("Withdrawal completed successfully.")
                : Result<string>.SystemError(null, "Withdrawal failed.");
        }

        #endregion

    }
}
