using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Services;
using BankApp.ViewModels.Accounts;
using BankApp.ViewModels.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        
        [HttpGet]
        [Authorize]
        public IActionResult Index(string sortcolumn, string sortorder, string page, string searchWord)
        {
            var viewModel = _service.GetListOfCustomers(sortcolumn, sortorder, page, searchWord);
            return View(viewModel);
        }
        [Authorize]
        [HttpGet]
        public IActionResult ViewCustomer(int id)
        {
            var viewModel = _service.GetCustomerInformation(id);
            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddCustomer()
        {
            var model = new AddNewCustomerViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomer(AddNewCustomerViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            _service.AddCustomer(model);
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        [Authorize]
        public IActionResult UpdateCustomer(int id)
        {
            var viewModel = _service.GetCustomerToUpdate(id);             
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCustomer(UpdateCustomerViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            _service.UpdateCustomer(model);
            return RedirectToAction("Index", new { searchWord = ""});
        }
        [Authorize]
        public IActionResult ViewTransactions(string page,int id, int customerId)
        {
            var viewModel = _service.GetAccountInformation(page,id);
            viewModel.CustomerId = customerId;
            return View(viewModel);
        }
        [Authorize]
        public IActionResult MoreTransactions(string page, int id, int customerId)
        {
            var viewModel = _service.GetAccountInformation(page, id);
            viewModel.CustomerId = customerId;
            return PartialView("_Transactions", viewModel);
        }

    }

}
