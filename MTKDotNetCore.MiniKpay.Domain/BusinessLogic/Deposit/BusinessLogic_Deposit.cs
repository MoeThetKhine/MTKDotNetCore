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

        public async Task<Result<List<DepositModel>>> GetDepositListAsync()
        {
            try
            {
                var result = await _dA_Deposit.GetDepositListAsync();
                if (result is null || !result.Any())
                {
                    return Result<List<DepositModel>>.ValidationError("No deposits found.");
                }

                return Result<List<DepositModel>>.Success(result, "Deposit list retrieved successfully.");
            }
            catch (Exception ex)
            {
                return Result<List<DepositModel>>.SystemError(null, $"An error occurred while retrieving deposit list: {ex.Message}");
            }
        }

        #endregion

        #region Get Deposit By PhoneNumber Async

        public async Task<Result<List<DepositModel>>> GetDepositByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                var result = await _dA_Deposit.GetDepositByPhoneNumberAsync(phoneNumber);

                if (result is null || !result.Any())
                {
                    return Result<List<DepositModel>>.ValidationError("No deposits found for the given phone number.");
                }

                return Result<List<DepositModel>>.Success(result, "Deposit list retrieved successfully.");
            }
            catch (Exception ex)
            {
                return Result<List<DepositModel>>.SystemError(null, $"An error occurred while retrieving deposits: {ex.Message}");
            }
        }

        #endregion

        #region Create Deposit

        public async Task<Result<string>> CreateDepositAsync(DepositResponseModel deposit)
        {
            try
            {
                var currentUser = await _dA_Deposit.GetUserByPhoneNumberAsync(deposit.PhoneNumber);

                if (currentUser is null)
                {
                    return Result<string>.ValidationError("User with this phone number does not exist.");
                }

                if (deposit.Balance <= 0)
                {
                    return Result<string>.ValidationError("Deposit amount must be greater than 0.");
                }

                var updatedBalance = currentUser.Balance + deposit.Balance;

                int updateResult = await _dA_Deposit.UpdateUserBalanceAsync(deposit.PhoneNumber, updatedBalance);

                if (updateResult == 0)
                {
                    return Result<string>.SystemError(null, "Failed to update the user balance.");
                }

                int insertResult = await _dA_Deposit.CreateDepositAsync(deposit);

                return insertResult > 0
                    ? Result<string>.Success("Deposit process completed successfully.")
                    : Result<string>.SystemError(null, "Deposit process failed.");
            }
            catch (Exception ex)
            {
                return Result<string>.SystemError(null, $"An error occurred during deposit creation: {ex.Message}");
            }
        }

        #endregion
    }
}
