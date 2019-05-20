using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LedgerApp.Models.BankAccountModels
{
    public interface IBankAccountRepo
    {
        IEnumerable<BankAccount> GetAllUserAccounts(string userId);
        BankAccount GetBankAccount(int? bankAccountId);
        void CreateAccount(BankAccount bankAccount);
        void DeleteAccount(int bankAccountId);
        void EditGame(BankAccount bankAccount);
    }
}
