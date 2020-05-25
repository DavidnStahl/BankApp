using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels.Customers
{
    public class CustomerListViewModel
    {
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public string SearchWord { get; set; }

        public decimal Results { get; set; }

        public List<CustomerItemViewModel> Items { get; set; } = new List<CustomerItemViewModel>();

        public PagingViewModel PagingViewModel { get; set; } = new PagingViewModel();

        public class CustomerItemViewModel
        {
            public int CustomerId { get; set; }
            public string NationalId { get; set; }

            public string Name { get; set; }
            public string Address { get; set; }

            public string City { get; set; }
        }
        
    }
}
