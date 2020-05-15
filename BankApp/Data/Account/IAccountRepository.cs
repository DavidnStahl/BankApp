using BankApp.Models;
using BankApp.ViewModels.Accounts;
using BankApp.ViewModels.Customers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Data
{
    public interface IAccountRepository
    {
        AccountInformationViewModel GetBalanceById(int id);

        int GetTotalNumberOfAccounts();

        decimal TotalMoneyInAccounts();
        //AccountInformationViewModel GetAccountById(string page, int id);

        List<TotalCustomersAccountsAndBalanceSumForCountryViewModel.CountryInfoViewModel> GetCountryCustomerAccountInformation();

        List<TopCustomerAccountInformationInCountryViewModel> GetTopAccountInfoInCountry(string country);

        Accounts GetAccount(int accountId);

        void UpdateAccount(Accounts account);

    }
}
