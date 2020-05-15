using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Services.Transaction;
using Microsoft.AspNetCore.Mvc;
using BankApp.ViewModels.Transactions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BankApp.ViewModels.Customers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace BankApp.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(TransactionWithdrawViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            _service.Withdraw(model);

            return RedirectToAction("ViewCustomer", "Customer", new { id = model.CustomerId });
        }
        [HttpGet]
        [Authorize]
        public IActionResult Withdraw(int accountId, int customerId)
        {

            var viewModel = new TransactionWithdrawViewModel
            {
                AccountId = accountId,
                Balance = _service.GetBalance(accountId),
                CustomerId = customerId
            };
            
            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(TransactionDepositViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); };
            _service.Deposit(model);
            return RedirectToAction("ViewCustomer", "Customer", new {id = model.CustomerId });
        }
        [HttpGet]
        [Authorize]
        public IActionResult Deposit(int accountId, int customerId)
        {
            var viewModel = new TransactionDepositViewModel
            {
                AccountId = accountId,
                Balance = _service.GetBalance(accountId),
                CustomerId = customerId
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(TransactionTransferToAccountViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            _service.TransferMoney(model);

            return RedirectToAction("ViewCustomer", "Customer",new { id = model.CustomerId });
        }
        [HttpGet]
        [Authorize]
        public IActionResult Transfer(int accountId, int customerId)
        {
            var viewModel = new TransactionTransferToAccountViewModel
            {
                AccountId = accountId,
                Balance = _service.GetBalance(accountId),
                CustomerId = customerId
            };
            return View(viewModel);
        }
        
    }
}
