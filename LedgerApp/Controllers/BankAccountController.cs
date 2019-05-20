using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LedgerApp.Data;
using LedgerApp.Models;
using LedgerApp.Models.BankAccountModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LedgerApp.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly IBankAccountRepo _bankAccountRepo;
        private readonly ApplicationDbContext _context;

        public BankAccountController(IBankAccountRepo bankAccountRepo, ApplicationDbContext context)
        {
            _bankAccountRepo = bankAccountRepo;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var accounts = _bankAccountRepo.GetAllUserAccounts(userId);
            return View(accounts);
        }

        public IActionResult MakeBankAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeBankAccount(BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = _context.Users.FirstOrDefault(i => i.UserName == User.Identity.Name);
                bankAccount.AccountUser = user;
                _bankAccountRepo.CreateAccount(bankAccount);
                return RedirectToAction("Details", "BankAccount", new { AccountNum = bankAccount.AccountNum });
            }
            return View(bankAccount);
        }

        public IActionResult Details(int? accountNum)
        {
            BankAccount account = _bankAccountRepo.GetBankAccount(accountNum);
            if (account != null)
            {
                return View(account);

            } else
            {
                return NotFound();
            }
        }
    }
}