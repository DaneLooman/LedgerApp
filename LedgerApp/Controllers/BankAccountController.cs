using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LedgerApp.Models.BankAccountModels;
using Microsoft.AspNetCore.Mvc;

namespace LedgerApp.Controllers
{
    public class BankAccountController : Controller
    {
        public readonly IBankAccountRepo _bankAccountRepo;

        public BankAccountController(IBankAccountRepo bankAccountRepo)
        {
            _bankAccountRepo = bankAccountRepo;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var accounts = _bankAccountRepo.GetAllUserAccounts(userId);
            return View(accounts);
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