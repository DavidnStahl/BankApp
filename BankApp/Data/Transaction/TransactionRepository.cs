using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BankApp.Data.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankAppDataContext _context;

        public TransactionRepository(BankAppDataContext context)
        {
            _context = context;
        }
        

        public void PostTransaction(Transactions transaction)
        {
            _context.Transactions.Add(transaction).Context.SaveChanges();
            
        }

        public IQueryable<Transactions> GetAllTransactionsByAccountId(int accountId)
        {
            return _context.Transactions.Where(transaction => transaction.AccountId == accountId);
        }
    }
}
