using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchApp.Repository
{
    public interface ISearchService
    {
        void RunAndUpdateSearchEngine();
        DocumentSearchResult<SearchCustomer> RunSearchEngine(string searchWord,int skip, string column, string orderby);
        void UpdateCustomerSearchEngine(List<SearchCustomer> customers);
    }
}
