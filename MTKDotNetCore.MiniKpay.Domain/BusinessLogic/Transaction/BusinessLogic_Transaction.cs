namespace MTKDotNetCore.MiniKpay.Domain.BusinessLogic.Transaction
{
    public class BusinessLogic_Transaction
    {
        private readonly DataAccess_Transaction _dA_Transaction;

        public BusinessLogic_Transaction(DataAccess_Transaction dataAccessTransaction)
        {
            _dA_Transaction = dataAccessTransaction;
        }

        #region Get Transactions

        public async Task<Result<List<TransactionModel>>> GetTransactionAsync()
        {
            try
            {
                var transactions = await _dA_Transaction.GetTransactionListAsync();

                if (transactions is null)
                {
                    return Result<List<TransactionModel>>.ValidationError("No transactions found.");
                }

                return Result<List<TransactionModel>>.Success(transactions);
            }
            catch (Exception ex)
            {
                return Result<List<TransactionModel>>.SystemError(null, $"An error occurred while retrieving transactions: {ex.Message}");
            }
        }

        #endregion

        #region Get Transactions by FromPhoneNumber

        public async Task<Result<List<TransactionModel>>> GetTransactionByFromPhoneNumberAsync(string fromPhoneNumber)
        {
            try
            {
                var transactions = await _dA_Transaction.GetTransactionByFromPhoneNumberAsync(fromPhoneNumber);

                if (transactions is null)
                {
                    return Result<List<TransactionModel>>.ValidationError("No transactions found for this phone number.");
                }

                return Result<List<TransactionModel>>.Success(transactions);
            }
            catch (Exception ex)
            {
                return Result<List<TransactionModel>>.SystemError(null, $"An error occurred while retrieving transactions for phone number {fromPhoneNumber}: {ex.Message}");
            }
        }

        #endregion


        #region Create Transaction

        public async Task<Result<string>> CreateTransactionAsync(TransactionResponseModel transaction)
        {
            if (transaction.Amount <= 0)
            {
                return Result<string>.ValidationError("Transaction amount must be greater than 0.");
            }

            if (transaction.FromPhoneNumber == transaction.ToPhoneNumber)
            {
                return Result<string>.ValidationError("Sender and receiver phone numbers must be different.");
            }

            var sender = await _dA_Transaction.GetUserByPhoneNumberAsync(transaction.FromPhoneNumber);
            if (sender == null)
            {
                return Result<string>.ValidationError("Sender phone number does not exist.");
            }

            if (sender.Pin != transaction.Pin)
            {
                return Result<string>.ValidationError("Invalid PIN for the sender.");
            }

            var receiver = await _dA_Transaction.GetUserByPhoneNumberAsync(transaction.ToPhoneNumber);
            if (receiver is null)
            {
                return Result<string>.ValidationError("Receiver phone number does not exist.");
            }

            if (sender.Balance < transaction.Amount)
            {
                return Result<string>.ValidationError("Sender has insufficient balance.");
            }

            var updatedSenderBalance = sender.Balance - transaction.Amount;
            var updatedReceiverBalance = receiver.Balance + transaction.Amount;

            int updateSenderResult = await _dA_Transaction.UpdateUserBalanceAsync(transaction.FromPhoneNumber, updatedSenderBalance);
            if (updateSenderResult == 0)
            {
                return Result<string>.SystemError(null, "Failed to update sender's balance.");
            }

            int updateReceiverResult = await _dA_Transaction.UpdateUserBalanceAsync(transaction.ToPhoneNumber, updatedReceiverBalance);
            if (updateReceiverResult == 0)
            {
                return Result<string>.SystemError(null, "Failed to update receiver's balance.");
            }

            int insertResult = await _dA_Transaction.CreateTransactionAsync(transaction);
            if (insertResult <= 0)
            {
                return Result<string>.SystemError(null, "Transaction process failed.");
            }

            return Result<string>.Success("Transaction completed successfully.");
        }

        #endregion
    }
}
