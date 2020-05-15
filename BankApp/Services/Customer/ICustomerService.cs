using BankApp.ViewModels.Accounts;
using BankApp.ViewModels.Customers;
using BankApp.ViewModels.Transactions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public interface ICustomerService
    {
        CustomerListViewModel GetListOfCustomers(string sortcolumn, string sortorder, string page, string searchWord);
        CustomerAccountInformationViewModel GetCustomerInformation(int id);

        UpdateCustomerViewModel GetCustomerToUpdate(int id);

        AccountInformationViewModel GetAccountInformation(string page, int id);

        void AddCustomer(AddNewCustomerViewModel model);
        void UpdateCustomer(UpdateCustomerViewModel model);
        //bool IsValidUser(string userId);
        bool IsValidUser(string username, string password);

        CustomerAccountInformationViewModel GetAuthenticatedUser(HttpRequest request);

        TransactionsApiViewModel GetTransactions(HttpRequest request,int id, int offset, int limit);

    }
}
