using BankApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels.Accounts
{
    public class TotalCustomersAccountsAndBalanceSumForCountryViewModel : IValidatableObject
    {
        
      
       /* [Display(Name = "Number of Customers")]
        public int Customers { get; set; }
        [Display(Name = "Number of Accounts")]
        public int Accounts { get; set; }
        [Display(Name = "Money in Accounts")]
        public string Money { get; set; }*/

        public List<CountryInfoViewModel> CountryInfoList { get; set; }

        public BankAppDataContext Context { get; set; } = new BankAppDataContext();
        public int CustomerId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (Context.Customers.FirstOrDefault(c => c.CustomerId == CustomerId) == null)
            {
                yield return new ValidationResult("Not found", new List<string>() { "CustomerId" });
            }

        }

        public class CountryInfoViewModel
        {
            public string Country { get; set; }
            public int NumbersOfCustomers { get; set; }

            public int NumbersOfAccounts { get; set; }
            public decimal SumAccountBalance { get; set; }
        }
        
    }
}
