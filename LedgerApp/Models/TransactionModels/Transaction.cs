using LedgerApp.Models.BankAccountModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LedgerApp.Models.TransactionModels
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransId { get; set; }
        [Column(TypeName = "decimal(9, 2)")]
        public decimal  TranAmt { get; set; }
        public DateTime TranDate { get; set; }
        public string TranMemo { get; set; }


        public BankAccount TranAccount { get; set; }
        public int TranAccountId { get; set; }
    }
}
