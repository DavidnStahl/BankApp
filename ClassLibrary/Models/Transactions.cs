﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BankApp.Models
{
    public partial class Transactions
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Operation { get; set; }
        [JsonIgnore]
        public decimal Amount { get; set; }
        [JsonIgnore]
        public decimal Balance { get; set; }
        public string Symbol { get; set; }
        public string Bank { get; set; }
        public string Account { get; set; }

        public virtual Accounts AccountNavigation { get; set; }
    }
}
