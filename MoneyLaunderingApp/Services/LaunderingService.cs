using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using BankApp.Models;
using ClassLibary.Models;
using Microsoft.EntityFrameworkCore;
using MoneyLaunderingApp.Data;
using MoneyLaunderingApp.Email;
using MoneyLaunderingApp.Model;
using Z.EntityFramework.Plus;

namespace MoneyLaunderingApp.Services
{
    public class LaunderingService : ILaunderingService
    {
        private readonly IEmailService _emailService;
        private readonly IBatchRepository _repository;

        public LaunderingService(IEmailService emailService, IBatchRepository repository)
        {
            _emailService = emailService;
            _repository = repository;
        }

        public void StartApp()
        {
            Console.WriteLine("Getting Transactions...");
            var latestScannedTransaction = _repository.LatestTransactionScanned();
            var model = _repository.GetTransactionsToScan();
            if(model.Count == 0)
            {
                Console.WriteLine("No transactions to scan..");
            }
            else
            {
                StartScan(model);
                latestScannedTransaction.LastId = model.OrderBy(t => t.TransactionId).Last().TransactionId;
                _repository.SaveLatestScannedTransaction(latestScannedTransaction);
            }
            
            Console.WriteLine("Application finished..");
        }
        private void StartScan(List<LaunderingInformationModel> model)
        {
            var countries = model.Select(r => r.Country).Distinct().ToList();
            Console.WriteLine("Scan Starts...");
            foreach (var country in countries)
            {
                var result = ScanCountry(model, country);
                Console.WriteLine($"{country} scan completed");
                Console.WriteLine("Sending email....");
                var content = _emailService.BuildEmailReport(result);
                _emailService.SendEmail(country, content);
            }
            Console.WriteLine("Full Scan Completed");
        }
        private LaunderingAccountModel ScanCountry(List<LaunderingInformationModel> model, string country)
        {
            var eachCountry = new LaunderingAccountModel();
            eachCountry.Country = country;
            var customers = model.Where(r => r.Country == country).ToList();
            var numbers = customers.Select(r => r.CustomerId).Distinct().ToList();
            foreach (var numb in numbers)
            {
                eachCountry.Customer.Add(ScanCustomer(model, numb));
            }
            return eachCountry;
        }
        private LaunderingAccountModel.CustomersInfo ScanCustomer(List<LaunderingInformationModel> model,int numb)
        {
            var acc = model.Where(r => r.CustomerId == numb).ToList();
            var num = acc.Select(r => r.AccountId).Distinct().ToList();
            var transactionLast72Hours = acc.Where(r => r.Date > DateTime.Now.AddDays(-3));
            var moneyTot = transactionLast72Hours.Sum(r => r.Amount);
            var customer = new LaunderingAccountModel.CustomersInfo
            {
                GivenName = acc[0].Givenname,
                SureName = acc[0].Surname,
                overLimitLast72Hours = moneyTot > 23000 ? true : false
            };
            foreach (var a in num)
            {
                customer.Account.Add(ScanAccount(model,a));
            }
            return customer;
        }
        private LaunderingAccountModel.AccountInfo ScanAccount(List<LaunderingInformationModel> model,int a)
        {
            var account = new LaunderingAccountModel.AccountInfo();
            account.AccountId = a;
            account.Transactions = model.Where(r => r.AccountId == a).Select(r => new LaunderingAccountModel.AccountInfo.TransactionsInfo
            {
                over15000 = r.Amount > 1500 ? true : false,
                TransactionId = r.TransactionId
            }).ToList();
            return account;
        }
        
    }
}
