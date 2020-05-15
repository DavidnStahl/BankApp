using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankApp.Models;
using BankApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BankApp.ViewModels.Customers;
using BankApp.ViewModels;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHomeService _service;
       
        public HomeController(IHomeService service)
        {
            _service = service;
        }
        
        [Authorize]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public IActionResult Index()
        {
                ViewBag.Error = "";
                var viewModel = _service.GetCountryCustomerAccountInformation();
                return View(viewModel);           
        }
        [HttpGet]
        [Authorize]
        public IActionResult SearchOnId(int searchid)
        {
            if (!_service.CheckIfSearchCustomerOnIdExist(searchid))
            {
                var viewModel = _service.GetCountryCustomerAccountInformation();
                ViewBag.Error = "Could not find customer";
                return View("Index",viewModel);
            }
            else
            {
                return RedirectToAction("ViewCustomer", "Customer", new { id = searchid });
            }

        }
        [Authorize]
        [ResponseCache(CacheProfileName = "Country")]
        public IActionResult Country(string country)
        {

            var viewModel = _service.GetTopAccountInfoInCountry(country);
            return View(viewModel);
        }

    }
}
