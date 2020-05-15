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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BankApp.Tests
{
    [TestFixture]
    public class TransactionRepositoryTests
    { 
    

        [OneTimeSetUp]
        public void Initialize()
        {

        }

        [Test]
        public void Check_PostTransaction_Should_Add_Transaction_And_Save_To_Context()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BankAppDataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

            var context = new BankAppDataContext(options);
            var mockContext = new Mock<BankAppDataContext>(options);
            mockContext.Setup(c => c.Add(It.IsAny<Transaction>()));
            var sut = new TransactionRepository(context);
            var transaction = new Transactions
            {
                AccountId = 1,
                Amount = -200,
                Balance = 16000 - 200,
                Date = DateTime.Now,
                Type = "Debit",
                Operation = "Withdraw in Cash"
            };

            //Act
            sut.PostTransaction(transaction);

            //Assert
            Assert.IsTrue(context.Transactions.Count() == 1);
            Assert.IsTrue(context.Transactions.FirstOrDefault(t => t.AccountId == 1) != null);
        }


        [Test]
        public void Check_GetAllTransactionsByAccountId_Should_Return_List_Of_Transactions_With_AccountId()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BankAppDataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

            var context = new BankAppDataContext(options);

            var sut = new TransactionRepository(context);
            context.Transactions.Add(new Transactions
            {
                AccountId = 1,
                Amount = -200,
                Balance = 16000 - 200,
                Date = DateTime.Now,
                Type = "Debit",
                Operation = "Withdraw in Cash"
            });
            context.Transactions.Add(new Transactions
            {
                AccountId = 1,
                Amount = 400,
                Balance = 16000 + 200,
                Date = DateTime.Now,
                Type = "Credit",
                Operation = "Credit in Cash"
            });

            context.Transactions.Add(new Transactions
            {
                AccountId = 2,
                Amount = 400,
                Balance = 16000 + 200,
                Date = DateTime.Now,
                Type = "Credit",
                Operation = "Credit in Cash"
            });

            context.SaveChanges();

            //Act
            var result = sut.GetAllTransactionsByAccountId(1).ToList();

            //Assert
            Assert.IsTrue(result.Count() == 2);
        }



    }
        
    
}
