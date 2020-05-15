using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels.Accounts
{
    public class AccountInformationViewModel
    {
        public int CustomerId { get; set; }

        [Display(Name = "Account Id")]
        public int AccountId { get; set; }
        [Display(Name = "Balance")]
        public decimal Balance { get; set; }


        public PagingViewModel PagingViewModel { get; set; } = new PagingViewModel();

        public IEnumerable<TransactionItemViewModel> Items { get; set; }

        public List<TransactionItemViewModel> Transactions { get; set; }

        public class TransactionItemViewModel
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
