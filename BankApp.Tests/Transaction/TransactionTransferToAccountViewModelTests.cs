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
    public class TransactionTransferToAccountViewModelTests
    {
        public ValidationContext validationContext { get; set; }
        [Test]
        public void Transfer_Amount_LessOrEqual_Zero_Should_Return_One_ErrorMessage()
        {
            TransactionTransferToAccountViewModel model = new TransactionTransferToAccountViewModel
            {
               AccountId = 1,
               CustomerId = 1,
               Balance = 20000m,
               TransferAmount = 0m,
               AccountIdSendTo = 2
            };

            var errorcount = model.Validate(validationContext).Count();
            Assert.AreEqual(1, errorcount);
        }

        [Test]
        public void Transfer_Amount_Higher_Then_Balance_Should_Return_One_ErrorMessage()
        {
            TransactionTransferToAccountViewModel model = new TransactionTransferToAccountViewModel
            {
                AccountId = 1,
                CustomerId = 1,
                Balance = 20000m,
                TransferAmount = 210000m,
                AccountIdSendTo = 2
            };

            var errorcount = model.Validate(validationContext).Count();
            Assert.AreEqual(1, errorcount);
        }

        [Test]
        public void AccountIdSendTo_Being_Equal_AccountId__Should_Return_One_ErrorMessage()
        {
            TransactionTransferToAccountViewModel model = new TransactionTransferToAccountViewModel
            {
                AccountId = 1,
                CustomerId = 1,
                Balance = 20000m,
                TransferAmount = 15000m,
                AccountIdSendTo = 1
            };

            var errorcount = model.Validate(validationContext).Count();
            Assert.AreEqual(1, errorcount);
        }

        [Test]
        public void AccountIdSendTo_Not_Exist_In_Database_Should_Return_One_ErrorMessage()
        {
            TransactionTransferToAccountViewModel model = new TransactionTransferToAccountViewModel
            {
                AccountId = 1,
                CustomerId = 1,
                Balance = 20000m,
                TransferAmount = 15000m,
                AccountIdSendTo = 0
            };

            var errorcount = model.Validate(validationContext).Count();
            Assert.AreEqual(1, errorcount);
        }

    }
}
