using BankApp.Models;
using BankApp.ViewModels.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SearchApp;
using SearchApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace BankApp.Data.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankAppDataContext _context;
        private readonly ISearchService _searchEngine;

        public CustomerRepository(BankAppDataContext context, ISearchService searchEngine)
        {
            _context = context;
            _searchEngine = searchEngine;
        }
        
        private IEnumerable<CustomerListViewModel.CustomerItemViewModel> GetCustomersBySearchWord(string searchWord,
            int skip, string column, string orderby)
        {
            if(searchWord == "undefined")
            {
                searchWord = "";
               var nothingsearched = _context.Customers.Select(c => new CustomerListViewModel.CustomerItemViewModel
                {
                    CustomerId = c.CustomerId,
                    NationalId = c.NationalId,
                    Address = c.Streetaddress,
                    City = c.City,
                    Name = c.Givenname + " " + c.Surname
                }).AsEnumerable();

                return nothingsearched;
            }
            
            var searchedCustomerResult = _searchEngine.RunSearchEngine(searchWord,skip,column,orderby).Results
                .Select(r => Convert.ToInt32(r.Document.CustomerId))
                .SelectMany(s => _context.Customers
                .Where(c => c.CustomerId == s)).Select(c => new CustomerListViewModel.CustomerItemViewModel
                {
                    CustomerId = c.CustomerId,
                    NationalId = c.NationalId,
                    Address = c.Streetaddress,
                    City = c.City,
                    Name = c.Givenname + " " + c.Surname
                });

            return searchedCustomerResult;
        }
        public CustomerListViewModel GetAllCustomers(string sortcolumn, string sortorder, string page, string searchWord)
        {
            if (string.IsNullOrEmpty(sortcolumn))
                sortcolumn = "CustomerId";
            if (string.IsNullOrEmpty(sortorder))
                sortorder = "asc";

            int currentPage = string.IsNullOrEmpty(page) ? 1 : Convert.ToInt32(page);
            var skip = (Convert.ToInt32(currentPage) * 50) - 50;
            var items = GetCustomersBySearchWord(searchWord,skip,sortcolumn,sortorder);
            var customerListViewModel = new CustomerListViewModel();
            customerListViewModel.PagingViewModel.PageSize = 50;
            var pageCount = Convert.ToDecimal(_searchEngine.RunSearchEngine(searchWord, skip, sortcolumn, sortorder).Count.Value) / customerListViewModel.PagingViewModel.PageSize;
            customerListViewModel.PagingViewModel.MaxPages = (int)Math.Ceiling(pageCount);
            customerListViewModel.PagingViewModel.CurrentPage = currentPage;
            customerListViewModel.Items = items.ToList();
            customerListViewModel.SortColumn = sortcolumn;
            customerListViewModel.SortOrder = sortorder;
            customerListViewModel.SearchWord = searchWord == "undefined" ? "" : searchWord;

            return customerListViewModel;
        }
        public CustomerAccountInformationViewModel GetCustomerById(int id)
        {
            var customer = _context.Customers.Include(customer => customer.Dispositions)
                                           .ThenInclude(d => d.Account)                                            
                                           .SingleOrDefault(customer => customer.CustomerId == id);
            var viewModel = new CustomerAccountInformationViewModel
            {
                Birthday =  customer.Birthday != null?  customer.Birthday.Value.ToString("yyyy-MM-dd") : "",
                City = customer.City,
                CountryCode = customer.CountryCode,
                CustomerId = customer.CustomerId,
                Givenname = customer.Givenname,
                Gender = customer.Gender,
                Emailaddress = customer.Emailaddress,
                Country = customer.Country,
                Streetaddress = customer.Streetaddress,
                NationalId = customer.NationalId,
                Telephonenumber = customer.Telephonenumber,
                Surname = customer.Surname,
                Telephonecountrycode = customer.Telephonecountrycode,
                Zipcode = customer.Zipcode
            };
            foreach(var disposition in customer.Dispositions)
            {
                var accountViewModel = new CustomerAccountInformationViewModel.AccountItemViewModel
                {
                    AccountId = disposition.Account.AccountId,
                    Balance = disposition.Account.Balance,
                    Created = disposition.Account.Created.ToString("yyyy/MM/dd"),
                    Type = disposition.Type
                };
                
                viewModel.Items.Add(accountViewModel);
            }

            return viewModel;
        }
        public bool CheckCustomerById(int id)
        {
            if(_context.Customers.FirstOrDefault(c => c.CustomerId == id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetTotalNumberOfCustomers()
        {
            return _context.Customers.Count();
        }

        public void AddCustomer(AddNewCustomerViewModel model)
        {
            var customer = new Customers
            {
                Birthday = model.Birthday,
                City = model.City,
                CountryCode = model.CountryCode,
                Country = model.Country,
                Emailaddress = model.Emailaddress,
                Gender = model.Gender,
                Streetaddress = model.Streetaddress,
                Givenname = model.Givenname,
                NationalId = model.NationalId,
                Telephonecountrycode = model.Telephonecountrycode,
                Surname = model.Surname,
                Telephonenumber = model.Telephonenumber,
                Zipcode = model.Zipcode                
            };

            var account = new Accounts
            {
                Balance = 0,
                Created = DateTime.Now,
                Frequency = "Monthly"
            };
            var disposion = new Dispositions
            {
                Account = account,
                Customer = customer,
                Type = "OWNER"
            };

            _context.Customers.Add(customer);
            _context.Accounts.Add(account);
            _context.Dispositions.Add(disposion);
            _context.SaveChanges();
            _searchEngine.RunAndUpdateSearchEngine();
        }

        public void UpdateCustomer(UpdateCustomerViewModel model)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == model.CustomerId);
            customer.CustomerId = model.CustomerId;
            customer.Birthday = model.Birthday;
            customer.City = model.City;
            customer.CountryCode = model.CountryCode;
            customer.Country = model.Country;
            customer.Emailaddress = model.Emailaddress;
            customer.Gender = model.Gender;
            customer.Streetaddress = model.Streetaddress;
            customer.Givenname = model.Givenname;
            customer.NationalId = model.NationalId;
            customer.Telephonecountrycode = model.Telephonecountrycode;
            customer.Surname = model.Surname;
            customer.Telephonenumber = model.Telephonenumber;
            customer.Zipcode = model.Zipcode;
            _context.Customers.Update(customer);
            _context.SaveChanges();

            var customers = new List<SearchCustomer>();
            var cust = new SearchCustomer
            {
                Id = model.CustomerId.ToString(),
                CustomerId = model.CustomerId,
                Address = model.Streetaddress,
                City = model.City,
                Name = model.Givenname + " " + model.Surname,
                NationalId = model.NationalId
            };
            customers.Add(cust);
            _searchEngine.UpdateCustomerSearchEngine(customers);
        }

        public UpdateCustomerViewModel GetCustomerByIdToUpdateInformation(int id)
        {
            var customer = _context.Customers.SingleOrDefault(customer => customer.CustomerId == id);
            var viewModel = new UpdateCustomerViewModel
            {
                Birthday = customer.Birthday,
                City = customer.City,
                CountryCode = customer.CountryCode,
                CustomerId = customer.CustomerId,
                Givenname = customer.Givenname,
                Gender = customer.Gender,
                Emailaddress = customer.Emailaddress,
                Country = customer.Country,
                Streetaddress = customer.Streetaddress,
                NationalId = customer.NationalId,
                Telephonenumber = customer.Telephonenumber,
                Surname = customer.Surname,
                Telephonecountrycode = customer.Telephonecountrycode,
                Zipcode = customer.Zipcode
            };
            return viewModel;
        }
    }
}
