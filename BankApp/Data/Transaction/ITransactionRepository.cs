using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BankApp.Data
{
    public interface ITransactionRepository
    {

        void PostTransaction(Transactions transaction);

        IQueryable<Transactions> GetAllTransactionsByAccountId(int accountId);

    }
}
