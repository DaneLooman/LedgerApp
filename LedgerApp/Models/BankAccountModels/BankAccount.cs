using LedgerApp.Models.TransactionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LedgerApp.Models.BankAccountModels
{
    public class BankAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountNum { get; set; }
        public string AccountName { get; set; }

           
        public ApplicationUser AccountUser { get; set; }
        public string AccountUserId { get; set; }

        public IEnumerable<Transaction> AccountTransactions { get; set; }

        public decimal Balance()
        {
            decimal total = 0.00M;
            if (AccountTransactions != null){
                foreach (Transaction t in AccountTransactions)
                {
                    total = (t.TranAmt + total);
                }
            }
            return total;
        }
    }
}
