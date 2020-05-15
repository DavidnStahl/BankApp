using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyLaunderingApp.Model
{
    public class LaunderingInformationModel
    {
        public int CustomerId { get; set; }
        public string Givenname { get; set; }

        public string Surname { get; set; }

        public string Country { get; set; }

        public int AccountId { get; set; }

        public int TransactionId { get; set; }

        public DateTime? Date { get; set; }

        public decimal Amount { get; set; }


    }
}
