using BankApp.Models;
using BankApp.ViewModels.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        
        private IEnumerable<CustomerListViewModel.CustomerItemViewModel> AddSorting(IEnumerable<CustomerListViewModel.CustomerItemViewModel> items, ref string sortcolumn, ref string sortorder)
        {
            if (string.IsNullOrEmpty(sortcolumn))
                sortcolumn = "CustomerId";
            if (string.IsNullOrEmpty(sortorder))
                sortorder = "asc";

            if (sortcolumn == "Name")
            {
                if (sortorder == "asc")
                    items = items.OrderBy(p => p.Name);
                else
                    items = items.OrderByDescending(p => p.Name);
            }
            else if (sortcolumn == "CustomerId")
            {
                if (sortorder == "asc")
                    items = items.OrderBy(p => p.CustomerId);
                else
                    items = items.OrderByDescending(p => p.CustomerId);
            }
            else if (sortcolumn == "Address")
            {
                if (sortorder == "asc")
                    items = items.OrderBy(p => p.Address);
                else
                    items = items.OrderByDescending(p => p.Address);
            }
            else if (sortcolumn == "City")
            {
                if (sortorder == "asc")
                    items = items.OrderBy(p => p.City);
                else
                    items = items.OrderByDescending(p => p.City);
            }
            else
            {
                if (sortorder == "desc")
                    items = items.OrderBy(p => p.NationalId);
                else
                    items = items.OrderByDescending(p => p.NationalId);

                sortcolumn = "NationalId";
            }

            return items;
        }

        private IEnumerable<CustomerListViewModel.CustomerItemViewModel> GetCustomersBySearchWord(string searchWord)
        {
            if(searchWord == "undefined")
            {
                searchWord = "";
            }
            var x =  _searchEngine.RunSearchEngine(searchWord).Results.Select(r => new CustomerListViewModel.CustomerItemViewModel
            {
                CustomerId = Convert.ToInt32(r.Document.CustomerId),
                NationalId = r.Document.NationalId,
                Address = r.Document.Address,
                City = r.Document.City,
                Name = r.Document.Name

            });
            return x;
        }
        public CustomerListViewModel GetAllCustomers(string sortcolumn, string sortorder, string page, string searchWord)
        {
            var items = GetCustomersBySearchWord(searchWord);

            if (string.IsNullOrEmpty(sortorder))
                sortorder = "asc";

            items = AddSorting(items, ref sortcolumn, ref sortorder);
            return Paging(items,sortcolumn,sortorder,page,searchWord);

        }

        private CustomerListViewModel Paging(IEnumerable<CustomerListViewModel.CustomerItemViewModel> items,string sortcolumn, string sortorder, string page, string searchWord)
        {
            var customerListViewModel = new CustomerListViewModel();
            customerListViewModel.PagingViewModel.PageSize = 50;
            int currentPage = string.IsNullOrEmpty(page) ? 1 : Convert.ToInt32(page);
            var pageCount = (double)items.Count() / customerListViewModel.PagingViewModel.PageSize;
            customerListViewModel.PagingViewModel.MaxPages = (int)Math.Ceiling(pageCount);
            items = items.Skip((currentPage - 1) * customerListViewModel.PagingViewModel.PageSize).Take(customerListViewModel.PagingViewModel.PageSize);
            customerListViewModel.PagingViewModel.CurrentPage = currentPage;
            customerListViewModel.Items = items.ToList();
            customerListViewModel.SortColumn = sortcolumn;
            customerListViewModel.SortOrder = sortorder;
            customerListViewModel.SearchWord = searchWord == "undefined"? "" : searchWord;
            
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
            _searchEngine.RunAndUpdateSearchEngine();
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
