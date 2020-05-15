using BankApp.ViewModels.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BankApp.Tests
{
    [TestFixture]
    class TransactionWithdrawViewModelTests
    {
        public ValidationContext validationContext { get; set; }
        [Test]
        public void Withdraw_Amount_LessOrEqual_Zero_Should_Return_One_ErrorMessage()
        {
            TransactionWithdrawViewModel model = new TransactionWithdrawViewModel
            {
                AccountId = 1,
                CustomerId = 1,
                Balance = 20000m,
                WithdrawAmount = 0m
            };

            var errorcount = model.Validate(validationContext).Count();
            Assert.AreEqual(1, errorcount);
        }
        [Test]
        public void Withdraw_Amount_Higher_Then_Balance_Should_Return_One_ErrorMessage()
        {
            TransactionWithdrawViewModel model = new TransactionWithdrawViewModel
            {
                AccountId = 1,
                CustomerId = 1,
                Balance = 20000m,
                WithdrawAmount = 20001m
            };

            var errorcount = model.Validate(validationContext).Count();
            Assert.AreEqual(1, errorcount);
        }
    }
}
