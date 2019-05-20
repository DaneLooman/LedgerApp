using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LedgerApp.Models.TransactionModels
{
    public interface ITransactionRepo
    {
        void CreateTransaction(Transaction transaction);

    }
}
