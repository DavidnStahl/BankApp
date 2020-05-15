using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels.Transactions
{
    public class TransactionDepositViewModel : IValidatableObject
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
        
        public decimal DepositAmount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DepositAmount <= 0 || DepositAmount >= 1000000000000 || (DepositAmount + Balance) >= 1000000000000)
            {
                yield return new ValidationResult("Can not deposit this amount", new List<string>() { "DepositAmount" });
            }
            
        }
    }
}
