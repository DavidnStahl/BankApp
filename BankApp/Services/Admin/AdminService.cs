using BankApp.ViewModels.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankApp.Services.Admin
{
    public class AdminService : IAdminService
    {
        public void CreateNewEmployee(UserManager<IdentityUser> _userManager, CreateEmployeeViewModel employee)
        {
            var user = new IdentityUser
            {
                UserName = employee.EmailAddress
            };

            var result = _userManager.CreateAsync(user, employee.Password).Result;

            if (result.Succeeded)
            {
               _userManager.AddToRoleAsync(user, employee.Role).Wait();
            }
            
        }

        public async Task DeleteEmployeeById(UserManager<IdentityUser> _userManager, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<EmployeeListViewModel> GetAllEmployees(UserManager<IdentityUser> _userManager)
        {
            var users = await _userManager.Users.Select(u => new EmployeeListViewModel.EmployeeItemViewModel
            {
                EmailAddress = u.UserName,
                Id = u.Id,
                Role = _userManager.IsInRoleAsync(u, "Admin").Result ? "Admin" : "Cashier"
            }).ToListAsync();
            var viewModel = new EmployeeListViewModel { Employees = users };
            return viewModel;
        }

        public async Task<UpdateEmployeeViewModel> GetEmployeeById(UserManager<IdentityUser> _userManager,string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var model = new UpdateEmployeeViewModel
            {
                Id = user.Id,
                EmailAddress = user.UserName,
                Role = _userManager.IsInRoleAsync(user, "Admin").Result ? "Admin" : "Cashier"
            };
            return model;
        }

        public async Task  UpdateEmployee(UserManager<IdentityUser> _userManager, UpdateEmployeeViewModel model, ClaimsPrincipal user, SignInManager<IdentityUser> signInManager)
        {
            var employee = await _userManager.FindByIdAsync(model.Id);
            employee.UserName = model.EmailAddress;
            if (model.Password != null)
            {
                var code = await _userManager.GeneratePasswordResetTokenAsync(employee);
                await _userManager.ResetPasswordAsync(employee, code, model.Password);   
            }
            var role = _userManager.IsInRoleAsync(employee, "Admin").Result ? "Admin" : "Cashier";

            var result = _userManager.IsInRoleAsync(employee, model.Role).Result ? true : false;
            if(result == false)
            {
                await _userManager.RemoveFromRoleAsync(employee, role);
                await _userManager.AddToRoleAsync(employee, model.Role);
            }

            await _userManager.UpdateNormalizedUserNameAsync(employee);


            var name = user.Identity.Name;
            if (name == employee.UserName)
            {
                await signInManager.RefreshSignInAsync(employee);
            }
            await _userManager.UpdateAsync(employee);
            
        }

        
    }
}
