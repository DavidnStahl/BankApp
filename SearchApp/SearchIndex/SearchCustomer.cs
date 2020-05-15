using Microsoft.Azure.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchApp
{
    public class SearchCustomer
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string CustomerId { get; set; }
        public string NationalId { get; set; }
        [IsSearchable]
        public string Name { get; set; }
        public string Address { get; set; }
        [IsSearchable]
        public string City { get; set; }
    }
}
