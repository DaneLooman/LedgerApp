using LedgerApp.Data;
using LedgerApp.Models.TransactionModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LedgerApp.Models.BankAccountModels
{
    public class BankAccountRepo : IBankAccountRepo
    {
        private readonly ApplicationDbContext _context;

        public BankAccountRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateAccount(BankAccount bankAccount)
        {
            _context.Accounts.Add(bankAccount);
            _context.SaveChanges();
        }

        public void DeleteAccount(int bankAccountId)
        {
            var transactionsToBeDeleted = _context.Transactions.Where(t => t.TranAccount.AccountNum == bankAccountId);

            foreach(Transaction t in transactionsToBeDeleted)
            {
                _context.Transactions.Remove(t);
                _context.SaveChanges();
            }

            var accountToBeDeleted = _context.Accounts.FirstOrDefault(b => b.AccountNum == bankAccountId);
            _context.Accounts.Remove(accountToBeDeleted);
            _context.SaveChanges();
        }

        public void EditGame(BankAccount bankAccount)
        {
            _context.Accounts.Update(bankAccount);
            _context.SaveChanges();
        }

        public IEnumerable<BankAccount> GetAllUserAccounts(string userId)
        {
            IEnumerable<BankAccount> bankAccounts = _context
                .Accounts.Include(a => a.AccountTransactions)
                .Where(t => t.AccountUser.Id == userId);
            return bankAccounts;
        }

        public BankAccount GetBankAccount(int? bankAccountId)
        {
            BankAccount bankAccount = null;
            if (bankAccountId != null)
            {
                bankAccount = _context.Accounts.Include(a => a.AccountTransactions).FirstOrDefault(b => b.AccountNum == bankAccountId);
                return bankAccount;
            }
            else
            {
                return bankAccount;
            }
        }
    }
}
