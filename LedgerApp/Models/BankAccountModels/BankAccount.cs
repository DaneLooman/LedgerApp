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

           
        ApplicationUser AccountUser { get; set; }
        public string AccountUserId { get; set; }
        ICollection<Transaction> AccountTransactions { get; set; }

    }
}
