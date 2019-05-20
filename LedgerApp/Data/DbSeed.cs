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
        public static void Initialize(ApplicationDbContext context, 
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();
            //creates test account
            if (userManager.FindByNameAsync("test@test.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser {
                UserName = "test@test.com",
                Email = "test@test.com",
                FirstName = "John",
                LastName = "Customer",
                Id = "testId",
                EmailConfirmed = true
            };

                userManager.CreateAsync(user, "Password1234!").Wait();             
            }
            //creates sample accounts for test account
            if (!context.Accounts.Any())
            {
                var accounts = new BankAccount[]
                {
                    new BankAccount {AccountName = "Checking", AccountUser = context.Users.FirstOrDefault(u => u.Id =="testId") },
                    new BankAccount {AccountName = "Savings", AccountUser = context.Users.FirstOrDefault(u => u.Id =="testId") }
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
                new Transaction { TranAmt = 10.50m, TranDate = new DateTime(2018, 1, 1, 18, 30, 0), TranMemo = "Mowed Lawn Money", TranAccount = context.Accounts.FirstOrDefault(a => a.AccountNum == 1)},
                new Transaction { TranAmt = -5.05m, TranDate = new DateTime(2018, 1, 10, 18, 30, 0), TranMemo = "Pizza Hut", TranAccount = context.Accounts.FirstOrDefault(a => a.AccountNum == 1)},
                new Transaction { TranAmt = 1000.99m, TranDate = new DateTime(2018, 2, 1, 18, 30, 0), TranMemo = "Paycheck", TranAccount = context.Accounts.FirstOrDefault(a => a.AccountNum == 2)},
                new Transaction { TranAmt = -50.00m, TranDate = new DateTime(2018, 1, 1, 18, 30, 0), TranMemo = "ATM withdrawl", TranAccount = context.Accounts.FirstOrDefault(a => a.AccountNum == 2)}
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
