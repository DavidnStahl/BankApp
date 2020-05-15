using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels.Employee
{
    public class CreateEmployeeViewModel
    {

        [Display(Name = "Email address")]
        [StringLength(256, ErrorMessage = "Max 256 characters")]
        [EmailAddress(ErrorMessage = "Not a valid Emailaddress")]
        [Required(ErrorMessage = "Email is required")]
        public string EmailAddress { get; set; }
        [Display(Name = "Role")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Role is required")]
        public string Role { get; set; }
        [Display(Name = "Password")]
        [StringLength(25,MinimumLength = 8, ErrorMessage = "Max 25 characters and minimum 8")]
        [Required(ErrorMessage = "Password required")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$",
            ErrorMessage = "Password must be at least 8 characters and contain at least 1 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        public IEnumerable<SelectListItem> Roles
        {
            get
            {
                return new[]
                {
                    new SelectListItem("Choose Role", ""),
                    new SelectListItem("Admin", "Admin"),
                    new SelectListItem("Cashier", "Cashier"),

                };
            }

        }
    }
}
