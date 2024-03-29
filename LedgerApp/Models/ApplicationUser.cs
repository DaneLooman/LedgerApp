﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LedgerApp.Models.BankAccountModels;
using Microsoft.AspNetCore.Identity;

namespace LedgerApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BankAccount> Accounts { get; set; }
    }
}
