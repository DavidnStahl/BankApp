using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyLaunderingApp.Model
{
    public class LaunderingAccountModel
    {
        public string Country { get; set; }
        public List<CustomersInfo> Customer { get; set; } = new List<CustomersInfo>();

        public class CustomersInfo
        {
            
            public string SureName { get; set; }
            public string GivenName { get; set; }
            public bool overLimitLast72Hours { get; set; }


            public List<AccountInfo> Account { get; set; } = new List<AccountInfo>();
        }
        public class AccountInfo
        {
            
            public int AccountId{ get; set; }


            public List<TransactionsInfo> Transactions { get; set; } = new List<TransactionsInfo>();


            public class TransactionsInfo
            {                
                public bool over15000 { get; set; }
                public int TransactionId { get; set; }

            }
        }

    }
}
