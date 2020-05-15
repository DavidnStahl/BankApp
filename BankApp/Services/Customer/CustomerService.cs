using BankApp.Authentication;
using BankApp.Data;
using BankApp.Data.MobileAppUser;
using BankApp.ViewModels.Accounts;
using BankApp.ViewModels.Customers;
using BankApp.ViewModels.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMobileAppUserRepository _mobileAppUsersRepository;

        public CustomerService(
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository,
            ITransactionRepository transactionRepository,
            IMobileAppUserRepository mobileAppUserRepository)
        {
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _mobileAppUsersRepository = mobileAppUserRepository;
        }

        public CustomerListViewModel GetListOfCustomers(string sortcolumn, string sortorder, string page, string searchWord)
        {
           return _customerRepository.GetAllCustomers(sortcolumn,sortorder,page,searchWord);
        }

        public CustomerAccountInformationViewModel GetCustomerInformation(int id)
        {
            var viewModel = _customerRepository.GetCustomerById(id);
            foreach (var accounts in viewModel.Items)
            {
                viewModel.TotalBalance += accounts.Balance;
            }
            return viewModel;
        }

        public AccountInformationViewModel GetAccountInformation(string page, int id)
        {
            var accountInformationViewModel = _accountRepository.GetBalanceById(id);
            var items = _transactionRepository.GetAllTransactionsByAccountId(id).OrderByDescending(r => r.Date).ThenByDescending(r => r.TransactionId)
                                            .Select(t => new AccountInformationViewModel.TransactionItemViewModel
                                            {
                                                Date = t.Date.ToString("yyyy/MM/dd"),
                                                Amount = t.Amount,
                                                Balance = t.Balance,
                                                Operation = t.Operation,
                                                TransactionId = t.TransactionId,
                                                Type = t.Type
                                            });

            accountInformationViewModel.PagingViewModel.PageSize = 20;
            int currentPage = string.IsNullOrEmpty(page) ? 1 : Convert.ToInt32(page);
            var pageCount = (double)items.Count() / accountInformationViewModel.PagingViewModel.PageSize;
            accountInformationViewModel.PagingViewModel.MaxPages = (int)Math.Ceiling(pageCount);
            items = items.Skip((currentPage - 1) * accountInformationViewModel.PagingViewModel.PageSize).Take(accountInformationViewModel.PagingViewModel.PageSize);
            accountInformationViewModel.PagingViewModel.CurrentPage = currentPage;
            accountInformationViewModel.Items = items.ToList();

            return accountInformationViewModel;
        }


        public void AddCustomer(AddNewCustomerViewModel model)
        {
            var addedInfo = UpdateModel(model.Country);
            model.Telephonecountrycode = addedInfo[0];
            model.CountryCode = addedInfo[1];           
            _customerRepository.AddCustomer(model);
        }
       
        public void UpdateCustomer(UpdateCustomerViewModel model)
        {
            var addedInfo = UpdateModel(model.Country);
            model.Telephonecountrycode = addedInfo[0];
            model.CountryCode = addedInfo[1];
            _customerRepository.UpdateCustomer(model);
        }        
        public UpdateCustomerViewModel GetCustomerToUpdate(int id)
        {
            return _customerRepository.GetCustomerByIdToUpdateInformation(id);
        }

        private List<string> UpdateModel(string country)
        {
            var addedInfo = new List<string>();
            if (country == "Sweden")
            {
                addedInfo.Add("46");
                addedInfo.Add("SE");
            }
            else if (country == "Finland")
            {
                addedInfo.Add("358");
                addedInfo.Add("FI");
            }
            else if (country == "Denmark")
            {
                addedInfo.Add("45");
                addedInfo.Add("DK");
            }
            else if (country == "Norway")
            {
                addedInfo.Add("47");
                addedInfo.Add("NO");
            }
            return addedInfo;
        }
        public bool IsValidUser(string username,string password)
        {
            return _mobileAppUsersRepository.IsValidUser(username, password);           
        }


        public CustomerAccountInformationViewModel GetAuthenticatedUser(HttpRequest request)
        {
            string authHeader = request.Headers["Authorization"];
            string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
            var arr = usernamePassword.Split(':');
            var username = arr[0];
            var password = arr[1];
            var userId = _mobileAppUsersRepository.InloggedUserCustomerId(username, password);

            return GetCustomerInformation(userId);
        }

        public TransactionsApiViewModel GetTransactions(HttpRequest request,int id, int offset, int limit)
        {
            
            var customer= GetAuthenticatedUser(request);
            var accountcount = customer.Items.Where(a => a.AccountId == id).ToList();
            if (accountcount.Count == 0)
            {
                return null;
            }
            if(limit == 0)
            {
                limit = 20;
            }
            var transactionApiViewModel = new TransactionsApiViewModel();
            var items = _transactionRepository.GetAllTransactionsByAccountId(id)
                .OrderByDescending(r => r.TransactionId).Select(t => new TransactionsApiViewModel.TransactionItems
                {
                    TransactionId = t.TransactionId,
                    Balance = t.Balance,
                    Date = t.Date.ToString("yyyy/MM/dd"),
                    Amount = t.Amount,
                    Operation = t.Operation,
                    Type = t.Type
                }).Skip(offset).Take(limit).ToList();
            transactionApiViewModel.accountId = id;
            transactionApiViewModel.customerId = customer.CustomerId;
            transactionApiViewModel.Transactions = items;
           
            return transactionApiViewModel;      
        }
    }
}
