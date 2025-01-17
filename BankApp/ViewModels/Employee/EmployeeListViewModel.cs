﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels.Employee
{
    public class EmployeeListViewModel
    {
        public List<EmployeeItemViewModel> Employees { get; set; }

        public class EmployeeItemViewModel
        {
            public string Id { get; set; }
            public string EmailAddress { get; set; }
            public string Role { get; set; }
        }
    }
}
