using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using LedgerApp.Models;
using LedgerApp.Models.BankAccountModels;
using LedgerApp.Models.TransactionModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LedgerApp.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionRepo _tranContext;
        private readonly IBankAccountRepo _bankContext;

        public TransactionController(ITransactionRepo tranContext, IBankAccountRepo bankContext)
        {
            _bankContext = bankContext;
            _tranContext = tranContext;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "BankAccount");
        }

        public IActionResult Deposit(int TranAcct)
        {
           decimal TranAmt = 0.00m;
           string TranMemo = "";

            return View((TranAcct, TranMemo, TranAmt));
        }

        [HttpPost]
        public IActionResult Deposit(int TranAcct, string TranMemo, decimal TranAmt)
        {
            Transaction _transaction = new Transaction
            {
                TranAccount = _bankContext.GetBankAccount(TranAcct),
                TranAmt = TranAmt,
                TranMemo = TranMemo,
                TranDate = DateTime.Now                
            };
            
            _tranContext.CreateTransaction(_transaction);
            return RedirectToAction("Index", "BankAccount", new {AccountNum = TranAcct});
        }


    }
}