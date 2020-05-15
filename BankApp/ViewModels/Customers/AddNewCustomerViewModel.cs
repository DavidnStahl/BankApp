using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace BankApp.ViewModels.Customers
{
    public class AddNewCustomerViewModel
    {
        public IEnumerable<SelectListItem> Countries
        {
            get
            {
                return new[]
                {
                    new SelectListItem("Choose Country", ""),
                    new SelectListItem("Sweden", "Sweden"),
                    new SelectListItem("Denmark", "Denmark"),
                    new SelectListItem("Finland", "Finland"),
                    new SelectListItem("Norway", "Norway")
                };
            }
            
        }
        public IEnumerable<SelectListItem> GenderList
        {
            get
            {
                return new[]
                {
                    new SelectListItem("Choose Gender", ""),
                    new SelectListItem("male", "male"),
                    new SelectListItem("female", "female")
                };
            }
        }

        public string Telephonecountrycode { get; set; }
        public string CountryCode { get; set; }

        [Display(Name = "Gender*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Display(Name = "First Name*")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [Required(ErrorMessage = "First Name Required")]
        [RegularExpression(@"^[a-zA-ZäöåÄÖÅ]+$",
            ErrorMessage = "Not A Valid Name")]
        
        public string Givenname { get; set; }
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [Display(Name = "Last Name*")]
        [Required(ErrorMessage = "Last Name Required")]
        [RegularExpression(@"^[a-zA-ZäöåÄÖÅ]+$",
            ErrorMessage = "Not A Valid Name")]

        public string Surname { get; set; }

        [Display(Name = "Street Address*")]
        [Required(ErrorMessage = "Street Address Required")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string Streetaddress { get; set; }

        [Display(Name = "City*")]
        [Required(ErrorMessage = "City Required")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]

        public string City { get; set; }

        [Display(Name = "ZipCode*")]
        [RegularExpression(@"^([0-9]{5})$",
            ErrorMessage = "Not a Valid ZipCode")]
        [Required(ErrorMessage = "ZipCode Required")]
        [StringLength(5, ErrorMessage = "Max 5 characters")]
        public string Zipcode { get; set; }

        [Display(Name = "Country*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country is required")]
        public string Country { get; set; }
        
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        [Display(Name = "National Id")]
        [RegularExpression("^(19|20)?[0-9]{2}[- ]?((0[0-9])|(10|11|12))[- ]?(([0-2][0-9])|(3[0-1])|(([7-8][0-9])|(6[1-9])|(9[0-1])))[- ]?[0-9]{4}$",
            ErrorMessage = "Not a Valid National Id")]
        public string NationalId { get; set; }

        [Display(Name = "Telephone number")]
        [RegularExpression(@"^([0-9]{10})$",
            ErrorMessage = "Not a Valid Telephone number")]
        public string Telephonenumber { get; set; }

        [Display(Name = "Email address")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [EmailAddress(ErrorMessage = "Not a valid Emailaddress")]
        public string Emailaddress { get; set; }

    }
}
