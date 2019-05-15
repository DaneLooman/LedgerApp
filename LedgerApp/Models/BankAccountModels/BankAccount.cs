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
        public int AccountNum { get; set; }
        public string AccountName { get; set; }
        public string  AccountUserId { get; set; }

        [ForeignKey("ApplicationUser")]
        ApplicationUser AccountUser { get; set; }
        IEnumerable<Transaction> AccountTransactions { get; set; }

    }
}
