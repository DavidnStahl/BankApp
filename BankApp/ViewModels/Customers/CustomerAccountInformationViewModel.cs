using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BankApp.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApp.ViewModels.Customers
{
    public class CustomerAccountInformationViewModel
    {

        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "First Name")]
        public string Givenname { get; set; }

        [Display(Name = "Last Name")]
        public string Surname { get; set; }

        [Display(Name = "Street Address")]
        public string Streetaddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "ZipCode")]
        public string Zipcode { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        [Display(Name = "Birthday")]
        public string Birthday { get; set; }

        [Display(Name = "National Id")]
        public string NationalId { get; set; }

        [Display(Name = "Telephone Country Code")]
        public string Telephonecountrycode { get; set; }

        [Display(Name = "Telephone number")]
        public string Telephonenumber { get; set; }

        [Display(Name = "Email address")]
        public string Emailaddress { get; set; }

        public decimal TotalBalance { get; set; }

        public List<AccountItemViewModel> Items { get; set; } = new List<AccountItemViewModel>();


        
        public class AccountItemViewModel
        {

            public int AccountId { get; set; }


            public string Type { get; set; }


            public string Created { get; set; }

            
            public decimal Balance { get; set; }

            
        }

    }
}
