using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels.Accounts
{
    public class TopCustomerAccountInformationInCountryViewModel 
    {
        
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        public string StreetAddress { get; set; }

        public decimal Balance { get; set; }
    }
}
