
using BankApp.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchApp.Repository
{
    public class SearchService : ISearchService
    {
        private void CreateIndex(string indexName, SearchServiceClient serviceClient)
        {
            var definition = new Microsoft.Azure.Search.Models.Index()
            {
                Name = indexName,
                Fields = FieldBuilder.BuildForType<SearchCustomer>()
                
                
            };

            serviceClient.Indexes.Create(definition);
        }

        public void RunAndUpdateSearchEngine()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            SearchServiceClient serviceClient = CreateSearchServiceClient(configuration);
            string indexName = configuration["SearchIndexName"];
            DeleteIndexIfExists(indexName, serviceClient);
            CreateIndex(indexName, serviceClient);
            ISearchIndexClient indexClient = serviceClient.Indexes.GetClient(indexName);
            UploadDocuments(indexClient);
            
        }

        private void DeleteIndexIfExists(string indexName, SearchServiceClient serviceClient)
        {
            if (serviceClient.Indexes.Exists(indexName))
            {
                serviceClient.Indexes.Delete(indexName);
            }
        }
        private SearchIndexClient CreateSearchIndexClient(string indexName, IConfigurationRoot configuration)
        {
            string searchServiceName = configuration["SearchServiceName"];
            string queryApiKey = configuration["SearchServiceQueryApiKey"];

            SearchIndexClient indexClient = new SearchIndexClient(searchServiceName, indexName, new SearchCredentials(queryApiKey));
            return indexClient;
        }
        private SearchServiceClient CreateSearchServiceClient(IConfigurationRoot configuration)
        {
            string searchServiceName = configuration["SearchServiceName"];
            string adminApiKey = configuration["SearchServiceAdminApiKey"];

            SearchServiceClient serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));
            return serviceClient;
        }
        public DocumentSearchResult<SearchCustomer> RunSearchEngine(string searchWord)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            SearchServiceClient serviceClient = CreateSearchServiceClient(configuration);
            string indexName = configuration["SearchIndexName"];
            ISearchIndexClient indexClient = serviceClient.Indexes.GetClient(indexName);
            ISearchIndexClient indexClientForQueries = CreateSearchIndexClient(indexName, configuration);
            return RunQueries(indexClientForQueries, searchWord);
        }
        private DocumentSearchResult<SearchCustomer> RunQueries(ISearchIndexClient indexClient, string searchWord)
        {
            SearchParameters parameters =
            new SearchParameters()
            {
                Select = new[] { "CustomerId","NationalId","Name","Address","City" },
                Top = 6000
                
            };

            return indexClient.Documents.Search<SearchCustomer>(searchWord, parameters);
           
        }
        private void UploadDocuments(ISearchIndexClient indexClient)
        {
            BankAppDataContext context = new BankAppDataContext();
            var searchCustomer = context.Customers.Select(c => new SearchCustomer
            {
                CustomerId = c.CustomerId.ToString(),
                NationalId = c.NationalId,
                Name = c.Givenname + " " + c.Surname,
                Address = c.Streetaddress,
                City = c.City
            }).ToArray();

            var batch = IndexBatch.Upload(searchCustomer);

            indexClient.Documents.Index(batch);
        }


    }
}
