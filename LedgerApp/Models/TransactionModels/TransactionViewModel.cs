using LedgerApp.Models.BankAccountModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LedgerApp.Models.TransactionModels
{
    public class TransactionViewModel
    {
        public TransactionViewModel()
        {
        }
        public IEnumerable<BankAccount> Accounts { get; set; }

        [Display(Name = "TranMemo")]
        [Required]
        public string TranMemo { get; set; }

        [Display(Name = "TranAmt")]
        [Required]
        public decimal TranAmt { get; set; }

        public BankAccount TranAccount { get; set; }

        public int TranAccountID { get; set; }

    }
}
