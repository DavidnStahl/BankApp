using BankApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels.Transactions
{
    public class TransactionTransferToAccountViewModel : IValidatableObject
    {
        public BankAppDataContext Context { get; set; } = new BankAppDataContext();

        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
        public decimal TransferAmount { get; set; }

        public int AccountIdSendTo { get; set; }

        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TransferAmount <= 0)
            {
                yield return new ValidationResult("Can not transfer this amount", new List<string>() { "TransferAmount" });
            }
            else if (TransferAmount > Balance)
            {
                yield return new ValidationResult("Balance is to low", new List<string>() { "TransferAmount" });
            }


            if (AccountIdSendTo == AccountId)
            {
                yield return new ValidationResult("Can´t be your own accountId", new List<string>() { "AccountIdSendTo" });
            }
            else if (Context.Accounts.FirstOrDefault(a => a.AccountId == AccountIdSendTo) == null)
            {
                yield return new ValidationResult("Account dosent exist", new List<string>() { "AccountIdSendTo" });
            }

        }
    }
}
