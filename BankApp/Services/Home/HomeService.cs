using BankApp.Data;
using BankApp.Models;
using BankApp.ViewModels;
using BankApp.ViewModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class HomeService : IHomeService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;

        public HomeService(ICustomerRepository customerRepository, IAccountRepository accountRepository)
        {
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
        }
        public CustomersInfomationViewModel GetTotalBankInformation()
        {
            return new CustomersInfomationViewModel
                {
                  Accounts = _accountRepository.GetTotalNumberOfAccounts(),
                  Customers = _customerRepository.GetTotalNumberOfCustomers(),
                  Money = _accountRepository.TotalMoneyInAccounts().ToString("C2")
                };
        }
        public TotalCustomersAccountsAndBalanceSumForCountryViewModel GetCountryCustomerAccountInformation()
        {
            var model = new TotalCustomersAccountsAndBalanceSumForCountryViewModel();
            model.CountryInfoList = _accountRepository.GetCountryCustomerAccountInformation();
            return model;
        }

        public List<TopCustomerAccountInformationInCountryViewModel> GetTopAccountInfoInCountry(string country)
        {
            return _accountRepository.GetTopAccountInfoInCountry(country);
        }

        public bool CheckIfSearchCustomerOnIdExist(int id)
        {
            return _customerRepository.CheckCustomerById(id);
        }
    }
}
