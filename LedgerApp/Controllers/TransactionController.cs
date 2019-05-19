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

        public IActionResult Deposit(int? id)
        {
            BankAccount bankAccount = _bankContext.GetBankAccount(id);
            Transaction transaction = new Transaction
            {
                TranAccount = bankAccount               
            };
            return View(transaction);
        }

        [HttpPost]
        public IActionResult Deposit(Transaction transaction)
        {
            Transaction _transaction = transaction;
            _transaction.TranDate = DateTime.Now;
            _tranContext.CreateTransaction(_transaction);
            return RedirectToAction("Index", "BankAccount", new { AccountNum = transaction.TranAccount });
        }


    }
}