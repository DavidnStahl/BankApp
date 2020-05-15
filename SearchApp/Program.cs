using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Configuration;
using SearchApp.Repository;

namespace SearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ISearchService searchService = new SearchService();
            searchService.RunAndUpdateSearchEngine();
            Console.WriteLine("Uploaded Index Successfull");
        }     
    }
}
