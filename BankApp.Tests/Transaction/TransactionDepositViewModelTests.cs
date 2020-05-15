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
    public class TransactionDepositViewModelTests
    {
        public ValidationContext validationContext { get; set; }
        [Test]
        public void Deposit_Amount_LessOrEqual_Zero_Should_Return_One_ErrorMessage()
        {
            TransactionDepositViewModel model = new TransactionDepositViewModel
            {
                AccountId = 1,
                CustomerId = 1,
                Balance = 20000m,
                DepositAmount = 0m
            };

            var errorcount = model.Validate(validationContext).Count();
            Assert.AreEqual(1, errorcount);
            Assert.GreaterOrEqual(model.DepositAmount, 0);
        }

        [Test]
        public void Deposit_Amount_Higher_Then_Or_Equal_OneTrillion_Should_Return_One_ErrorMessage()
        {
            TransactionDepositViewModel model = new TransactionDepositViewModel
            {
                AccountId = 1,
                CustomerId = 1,
                Balance = 20000m,
                DepositAmount = 1000000000000m

            };

            var errorcount = model.Validate(validationContext).Count();
            Assert.AreEqual(1, errorcount);
        }

        [Test]
        public void Deposit_Amount_Plus_Balance_With_Sum_Higher_Then_Or_Equal_OneTrillion_Should_Return_One_ErrorMessage()
        {
            TransactionDepositViewModel model = new TransactionDepositViewModel
            {
                AccountId = 1,
                CustomerId = 1,
                Balance = 20000m,
                DepositAmount = 999999980000m
            };

            var errorcount = model.Validate(validationContext).Count();
            Assert.AreEqual(1, errorcount);
        }

    }
}
