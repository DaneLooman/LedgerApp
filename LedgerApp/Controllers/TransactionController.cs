using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LedgerApp.Data;
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
        private readonly ApplicationDbContext _context;

        public TransactionController(ITransactionRepo tranContext, IBankAccountRepo bankContext, ApplicationDbContext context)
        {
            _bankContext = bankContext;
            _tranContext = tranContext;
            _context = context;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "BankAccount");
        }

        public IActionResult Deposit()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = _context.Users.FirstOrDefault(u => u.Id == userId);
            IEnumerable<BankAccount> accounts = _bankContext.GetAllUserAccounts(user.Id);

            TransactionViewModel viewModel = new TransactionViewModel
            {
                Accounts = accounts
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Deposit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.TranDate = DateTime.Now;
                _tranContext.CreateTransaction(transaction);
                return RedirectToAction("Details", "BankAccount", new { AccountNum = transaction.TranAccountId });
            }

            return View(transaction);
        }


    }
}