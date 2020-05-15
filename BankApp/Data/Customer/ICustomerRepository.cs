using BankApp.Models;
using BankApp.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Data
{
    public interface ICustomerRepository
    {
        CustomerListViewModel GetAllCustomers(string sortcolumn, string sortorder, string page, string searchWord);

        int  GetTotalNumberOfCustomers();
        CustomerAccountInformationViewModel GetCustomerById(int id);

        UpdateCustomerViewModel GetCustomerByIdToUpdateInformation(int id);
        void AddCustomer(AddNewCustomerViewModel model);

        void UpdateCustomer(UpdateCustomerViewModel model);
        bool CheckCustomerById(int id);

        

    }
}
