using MTKDotNetCore.MiniKpay.Database.DataAccess.Transaction;
using MTKDotNetCore.MiniKpay.Database.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCore.MiniKpay.Domain.BusinessLogic.Transaction
{
    public class BusinessLogic_Transaction
    {
        private readonly DataAccess_Transaction _dA_Transaction;

        public BusinessLogic_Transaction(DataAccess_Transaction dataAccessTransaction)
        {
            _dA_Transaction = dataAccessTransaction;
        }

        #region Get  Transaction

        public async Task<List<TransactionModel>> GetTransactionAsync()
        {
            return await _dA_Transaction.GetTransactionListAsync();
        }

        #endregion

        #region Get Transactions by FromPhoneNumber

        public async Task<List<TransactionModel>> GetTransactionByFromPhoneNumberAsync(string fromPhoneNumber)
        {
            return await _dA_Transaction.GetTransactionByFromPhoneNumberAsync(fromPhoneNumber);
        }

        #endregion
        #region Create Transaction

        public async Task<string> CreateTransactionAsync(TransactionResponseModel transaction)
        {
            if (transaction.Amount <= 0)
            {
                return "Transaction amount must be greater than 0.";
            }

            if (transaction.FromPhoneNumber == transaction.ToPhoneNumber)
            {
                return "Sender and receiver phone numbers must be different.";
            }

            var sender = await _dA_Transaction.GetUserByPhoneNumberAsync(transaction.FromPhoneNumber);
            if (sender is null)
            {
                return "Sender phone number does not exist.";
            }

            if (sender.Pin != transaction.Pin)
            {
                return "Invalid PIN for the sender.";
            }

            var receiver = await _dA_Transaction.GetUserByPhoneNumberAsync(transaction.ToPhoneNumber);
            if (receiver is null)
            {
                return "Receiver phone number does not exist.";
            }

            if (sender.Balance < transaction.Amount)
            {
                return "Sender has insufficient balance.";
            }

            var updatedSenderBalance = sender.Balance - transaction.Amount;
            var updatedReceiverBalance = receiver.Balance + transaction.Amount;

            int updateSenderResult = await _dA_Transaction.UpdateUserBalanceAsync(transaction.FromPhoneNumber, updatedSenderBalance);
            if (updateSenderResult == 0)
            {
                return "Failed to update sender's balance.";
            }

            int updateReceiverResult = await _dA_Transaction.UpdateUserBalanceAsync(transaction.ToPhoneNumber, updatedReceiverBalance);
            if (updateReceiverResult == 0)
            {
                return "Failed to update receiver's balance.";
            }

            int insertResult = await _dA_Transaction.CreateTransactionAsync(transaction);
            return insertResult > 0 ? "Transaction completed successfully." : "Transaction process failed.";
        }

        #endregion
    }

}

