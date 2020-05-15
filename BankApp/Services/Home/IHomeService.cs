using BankApp.Models;
using BankApp.ViewModels;
using BankApp.ViewModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public interface IHomeService
    {
        CustomersInfomationViewModel GetTotalBankInformation();
        TotalCustomersAccountsAndBalanceSumForCountryViewModel GetCountryCustomerAccountInformation();

        List<TopCustomerAccountInformationInCountryViewModel> GetTopAccountInfoInCountry(string country);

        bool CheckIfSearchCustomerOnIdExist(int id);

    }
}
