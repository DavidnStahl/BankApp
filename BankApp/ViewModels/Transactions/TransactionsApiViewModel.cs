using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BankApp.ViewModels.Transactions
{
    public class TransactionsApiViewModel
    {
        public List<TransactionItems> Transactions { get; set; } = new List<TransactionItems>();

        public int customerId { get; set; }

        public int accountId { get; set; }

        public class TransactionItems
        {
            public int TransactionId { get; set; }
            public string Date { get; set; }
            public string Type { get; set; }
            public string Operation { get; set; }
            public decimal Amount { get; set; }
            public decimal Balance { get; set; }
        }

    }
}
