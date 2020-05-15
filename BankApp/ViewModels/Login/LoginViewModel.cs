using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels.Login
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required]
        public string EmailAddress { get; set; }
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
    }
}
