using Microsoft.Azure.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchApp
{
    public class SearchCustomer
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Id { get; set; }
        [IsSortable]
        public int CustomerId { get; set; }
        [IsSortable]
        public string NationalId { get; set; }
        [IsSearchable]
        [IsSortable]
        public string Name { get; set; }
        [IsSortable]
        public string Address { get; set; }
        [IsSearchable]
        [IsSortable]
        public string City { get; set; }
    }
}
