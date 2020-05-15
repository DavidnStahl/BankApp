using BankApp.Models;
using BankApp.ViewModels.Accounts;
using BankApp.ViewModels.Customers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankAppDataContext _context;

        public AccountRepository(BankAppDataContext context)
        {
            _context = context;
        }
        

        public AccountInformationViewModel GetBalanceById(int id)
        {
            return _context.Accounts.Select(a => new AccountInformationViewModel
            {
                AccountId = a.AccountId,
                Balance = a.Balance,
            }).FirstOrDefault(a => a.AccountId == id);
        }
        
        public int GetTotalNumberOfAccounts()
        {
            return _context.Accounts.Count();
        }

        public decimal TotalMoneyInAccounts()
        {
            return _context.Accounts.Sum(account => account.Balance);
        }

        public List<TotalCustomersAccountsAndBalanceSumForCountryViewModel.CountryInfoViewModel> GetCountryCustomerAccountInformation()
        {
            var model = _context.Customers
                         .SelectMany(customer => _context.Dispositions
                         .Where(d => d.CustomerId == customer.CustomerId)
                         .SelectMany(disposition => _context.Accounts
                         .Where(a => disposition.AccountId == a.AccountId)
                         .Select(account => new
                         {
                             customer.Country,
                             account.Balance
                         })))
                         .GroupBy(c => new
                         {
                             c.Country
                         })
                         .Select(c => new TotalCustomersAccountsAndBalanceSumForCountryViewModel.CountryInfoViewModel
                         {
                             Country = c.Key.Country,
                             SumAccountBalance = c.Sum(b => b.Balance),
                             NumbersOfAccounts = c.Count()
                         })
                         .ToList();

            foreach (var country in model)
            {
                country.NumbersOfCustomers = _context.Customers.Where(r => r.Country == country.Country).Count();
            }

            return model;
        }

        public List<TopCustomerAccountInformationInCountryViewModel> GetTopAccountInfoInCountry(string country)
        {
            return _context.Customers.Where(c => c.Country == country).SelectMany(customer => _context.Dispositions
                                                         .Where(d => d.CustomerId == customer.CustomerId)
                                                         .SelectMany(disposition => _context.Accounts
                                                         .Where(a => disposition.AccountId == a.AccountId)
                                                         .Select(account => new TopCustomerAccountInformationInCountryViewModel
                                                         {
                                                             Balance = account.Balance,
                                                             City = customer.City,
                                                             CustomerId = customer.CustomerId,
                                                             Name = customer.Givenname + " " + customer.Surname,
                                                             Country = customer.Country,
                                                             StreetAddress = customer.Streetaddress
                                                         }))).OrderByDescending(r => r.Balance).Take(10).ToList();
        }

        public Accounts GetAccount(int accountId)
        {
            return _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
        }

        public void UpdateAccount(Accounts account)
        {
            _context.Accounts.Update(account).Context.SaveChanges();
        }
    }
}
