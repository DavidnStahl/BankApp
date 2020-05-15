using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels.Transactions
{
    public class TransactionWithdrawViewModel : IValidatableObject
    {
        public int AccountId { get; set; }

        public int CustomerId { get; set; }
        public decimal Balance { get; set; }

        public decimal WithdrawAmount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {


            if (WithdrawAmount > Balance)
            {
                yield return new ValidationResult("Balance is to low", new List<string>() { "WithdrawAmount" });
            }
            else if(WithdrawAmount <= 0)
            {
                yield return new ValidationResult("Can not withdraw this amount", new List<string>() { "WithdrawAmount" });
            }
        }
   
    }
}
