using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using NUnit.Framework;
using Moq;
using BankApp.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BankApp.Data.Transaction;
using Org.BouncyCastle.Security;
using System.Transactions;
using Microsoft.Extensions.DependencyInjection;
using BankApp.Services.Admin;
using BankApp.Services.Transaction;
using SearchApp.Repository;
using BankApp.Services;
using BankApp.Data.Customer;
using BankApp.ViewModels.Transactions;

namespace BankApp.Tests
{
    [TestFixture]
    class TransactionServiceTests
    {

        [OneTimeSetUp]
        public void Initialize()
        {                    
        }

        [Test]
        public void Check_Deposit_Should_Add_Transaction_And_Update_AccountBalance()
        {
            //Arrange
            var mockaccounRepository = new Mock<IAccountRepository>();
            var mocktransactionRepository = new Mock<ITransactionRepository>();
            var sut = new TransactionService(mocktransactionRepository.Object, mockaccounRepository.Object);
            mocktransactionRepository.Setup(t => t.PostTransaction(It.IsAny<Transactions>()));
            mockaccounRepository.Setup(a => a.GetAccount(It.IsAny<int>())).Returns(new Accounts());
            mockaccounRepository.Setup(a => a.UpdateAccount(It.IsAny<Accounts>()));
            //Act
            sut.Deposit(new TransactionDepositViewModel());
            var account = mockaccounRepository.Object.GetAccount(1);
            var oldbalance = account.Balance;
            var newbalance = account.Balance + 2000;
            //Assert
            mocktransactionRepository.Verify(y => y.PostTransaction(It.IsAny<Transactions>()), Times.Once());
            Assert.IsNotNull(account);
            Assert.IsTrue(oldbalance < newbalance);
            mockaccounRepository.Verify(a => a.UpdateAccount(It.IsAny<Accounts>()),Times.Once());
        }

        [Test]
        public void Check_Withdraw_Should_Add_Transaction_And_Update_AccountBalance()
        {
            //Arrange
            var mockaccounRepository = new Mock<IAccountRepository>();
            var mocktransactionRepository = new Mock<ITransactionRepository>();
            var sut = new TransactionService(mocktransactionRepository.Object, mockaccounRepository.Object);
            mocktransactionRepository.Setup(t => t.PostTransaction(It.IsAny<Transactions>()));
            mockaccounRepository.Setup(a => a.GetAccount(It.IsAny<int>())).Returns(new Accounts());
            mockaccounRepository.Setup(a => a.UpdateAccount(It.IsAny<Accounts>()));

            //Act
            sut.Withdraw(new TransactionWithdrawViewModel());
            var account = mockaccounRepository.Object.GetAccount(1);
            var oldbalance = account.Balance;
            var newbalance = account.Balance - 2000;
            //Assert
            mocktransactionRepository.Verify(y => y.PostTransaction(It.IsAny<Transactions>()), Times.Once());
            Assert.IsNotNull(account);
            Assert.IsTrue(oldbalance > newbalance);
            mockaccounRepository.Verify(a => a.UpdateAccount(It.IsAny<Accounts>()), Times.Once());

        }

        [Test]
        public void Check_TransferMoney_Should_Add_Two_Transactions_And_Update_AccountBalance_On_TwoAccounts()
        {
            //Arrange
            var mockaccounRepository = new Mock<IAccountRepository>();
            var mocktransactionRepository = new Mock<ITransactionRepository>();
            var sut = new TransactionService(mocktransactionRepository.Object, mockaccounRepository.Object);
            mocktransactionRepository.Setup(t => t.PostTransaction(It.IsAny<Transactions>()));
            mockaccounRepository.Setup(a => a.GetAccount(It.IsAny<int>())).Returns(new Accounts());
            mockaccounRepository.Setup(a => a.UpdateAccount(It.IsAny<Accounts>()));

            //Act
            sut.TransferMoney(new TransactionTransferToAccountViewModel());
            var account = mockaccounRepository.Object.GetAccount(1);
            var oldbalance = account.Balance;
            var newbalance = account.Balance + 2000;

            var toAccount = mockaccounRepository.Object.GetAccount(1);
            var toAccountoldbalance = toAccount.Balance;
            var toAccountnewBalance = toAccount.Balance - 200;

            //Assert
            mocktransactionRepository.Verify(y => y.PostTransaction(It.IsAny<Transactions>()), Times.Exactly(2));
            Assert.IsNotNull(account);
            Assert.IsNotNull(toAccount);
            Assert.IsTrue(oldbalance < newbalance);
            Assert.IsTrue(toAccountoldbalance > toAccountnewBalance);
            mockaccounRepository.Verify(a => a.UpdateAccount(It.IsAny<Accounts>()), Times.Exactly(2));

        }

    }
}
