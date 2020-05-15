using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Services.Admin;
using BankApp.ViewModels.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BankApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IAdminService _service;
        public AdminController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,IAdminService service)
        {
            _service = service;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var viewModel = await _service.GetAllEmployees(_userManager);
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            var viewModel = new CreateEmployeeViewModel();
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmployee(CreateEmployeeViewModel model)
        {
            _service.CreateNewEmployee(_userManager, model);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(string id)
        {
            var viewModel = await _service.GetEmployeeById(_userManager, id);
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            await _service.UpdateEmployee(_userManager, model,User,_signInManager);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            // Can not remove user who is inlogged
            var inLoggedUser = _userManager.GetUserId(User);
            if (id != inLoggedUser)
            {
                await _service.DeleteEmployeeById(_userManager, id);
            }
            
            return RedirectToAction("Index");
        }
    }
}
