using BankApp.Models;
using ClassLibary.Models;
using MoneyLaunderingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyLaunderingApp.Data
{
    
    public class BatchRepository : IBatchRepository
    {
        private readonly BankAppDataContext _context = new BankAppDataContext();
        public List<LaunderingInformationModel> GetTransactionsToScan()
        {
            var latestScannedTransaction = LatestTransactionScanned();
            var model = (from a in _context.Customers
                         join b in _context.Dispositions on a.CustomerId equals b.CustomerId
                         join c in _context.Accounts on b.AccountId equals c.AccountId
                         join d in _context.Transactions on c.AccountId equals d.AccountId
                         select new LaunderingInformationModel()
                         {
                             Givenname = a.Givenname,
                             Surname = a.Surname,
                             Country = a.Country,
                             AccountId = c.AccountId,
                             TransactionId = d.TransactionId,
                             Date = d.Date,
                             Amount = d.Amount,
                             CustomerId = a.CustomerId
                         }).OrderBy(r => r.TransactionId).Where(r => r.TransactionId > latestScannedTransaction.LastId)
                       .Where(r => r.Amount > 15000 || r.Date > DateTime.Now.AddDays(-3))
                       .OrderBy(r => r.Country)
                       .ToList();
            return model;
        }
        public BatchStatus LatestTransactionScanned()
        {
            return _context.BatchStatus.First();
        }

        public void SaveLatestScannedTransaction(BatchStatus model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
    }
}
