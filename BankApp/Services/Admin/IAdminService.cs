using BankApp.ViewModels.Employee;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services.Admin
{
    public interface IAdminService
    {
        Task<EmployeeListViewModel> GetAllEmployees(UserManager<IdentityUser> userManager);

        Task<UpdateEmployeeViewModel> GetEmployeeById(UserManager<IdentityUser> _userManager, string id);

        Task DeleteEmployeeById(UserManager<IdentityUser> _userManager, string id);

        Task UpdateEmployee(UserManager<IdentityUser> _userManager, UpdateEmployeeViewModel model, System.Security.Claims.ClaimsPrincipal user,SignInManager<IdentityUser> signInManager);

        void CreateNewEmployee(UserManager<IdentityUser> _userManager, CreateEmployeeViewModel employee);
    }
}
