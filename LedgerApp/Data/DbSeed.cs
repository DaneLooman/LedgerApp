using LedgerApp.Models;
using LedgerApp.Models.BankAccountModels;
using LedgerApp.Models.TransactionModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LedgerApp.Data
{
    public class DbSeed
    {
        public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();
            //creates test account
            if (userManager.FindByNameAsync("test@test.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "test@test.com";
                user.Email = "looman.dane@gmail.com";
                user.FirstName = "John";
                user.LastName = "Customer";
                user.Id = "testId";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "password1!").Result;
            }
            //creates sample accounts for test account
            if (!context.Accounts.Any())
            {
                var accounts = new BankAccount[]
                {
                    new BankAccount {AccountName = "Checking", AccountUserId = "testId" },
                    new BankAccount {AccountName = "Savings", AccountUserId = "testId" }
                };

                foreach (BankAccount b in accounts)
                {
                    context.Accounts.Add(b);
                }
                context.SaveChanges();
            }
            //Adds transactions to both test accounts
            if (!context.Transactions.Any())
            {
                var transactions = new Transaction[]
                {
                new Transaction { TranAmt = 10.50m, TranDate = new DateTime(2018, 1, 1, 18, 30, 0), TranMemo = "Mowed Lawn Money", TranAccountId = 1  },
                new Transaction { TranAmt = -5.05m, TranDate = new DateTime(2018, 1, 10, 18, 30, 0), TranMemo = "Pizza Hut", TranAccountId = 1  },
                new Transaction { TranAmt = 1000.99m, TranDate = new DateTime(2018, 2, 1, 18, 30, 0), TranMemo = "Paycheck", TranAccountId = 2  },
                new Transaction { TranAmt = -50.00m, TranDate = new DateTime(2018, 1, 1, 18, 30, 0), TranMemo = "ATM withdrawl", TranAccountId = 2 }
                };

                foreach (Transaction t in transactions)
                {
                    context.Transactions.Add(t);
                }
                context.SaveChanges();
            }
        }
    }
}
