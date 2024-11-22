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
    }
}
