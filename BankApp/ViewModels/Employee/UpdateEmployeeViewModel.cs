using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels.Employee
{
    public class UpdateEmployeeViewModel
    {

        public string Id { get; set; }

        [Display(Name = "Email address")]
        [StringLength(256, ErrorMessage = "Max 256 characters")]
        [EmailAddress(ErrorMessage = "Not a valid Emailaddress")]
        [Required(ErrorMessage = "Email is required")]
        public string EmailAddress { get; set; }
        [Display(Name = "Role")]

        public string Role { get; set; }
        [Display(Name = "Password")]
        [StringLength(25, ErrorMessage = "Max 25 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{8,}$", ErrorMessage = "The {0} does not meet requirements.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<SelectListItem> Roles
        {
            get
            {
                return new[]
                {
                    new SelectListItem("Admin", "Admin"),
                    new SelectListItem("Cashier", "Cashier"),
                    
                };
            }

        }
    }
}
