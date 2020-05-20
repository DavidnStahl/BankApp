using BankApp.Data;
using BankApp.Models;
using BankApp.ViewModels.Accounts;
using BankApp.ViewModels.Transactions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services.Transaction
{
   
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }
        public decimal GetBalance(int id)
        {
            return _accountRepository.GetBalanceById(id).Balance;
        }

        public void Deposit(TransactionDepositViewModel model)
        {
            _transactionRepository.PostTransaction(new Transactions
            {
                AccountId = model.AccountId,
                Amount = model.DepositAmount,
                Balance = model.Balance + model.DepositAmount,
                Date = DateTime.Now,
                Type = "Credit",
                Operation = "Credit in Cash"
            });
            var account = _accountRepository.GetAccount(model.AccountId);
            account.Balance = account.Balance + model.DepositAmount;

            _accountRepository.UpdateAccount(account);
        }

        public void TransferMoney(TransactionTransferToAccountViewModel model)
        {
            
            _transactionRepository.PostTransaction(new Transactions
            {
                AccountId = model.AccountId,
                Amount = -model.TransferAmount,
                Balance = model.Balance - model.TransferAmount,
                Date = DateTime.Now,
                Type = "Debit",
                Operation = "Remittance to Account",
                Account = model.AccountIdSendTo.ToString()
            });
            var account = _accountRepository.GetAccount(model.AccountId);
            account.Balance = account.Balance - model.TransferAmount;
            _accountRepository.UpdateAccount(account);

            var toAccount = _accountRepository.GetAccount(model.AccountIdSendTo);
            toAccount.Balance = toAccount.Balance + model.TransferAmount;
            _accountRepository.UpdateAccount(toAccount);

           _transactionRepository.PostTransaction(new Transactions
            {
                AccountId = model.AccountIdSendTo,
                Amount = model.TransferAmount,
                Balance = toAccount.Balance,
                Date = DateTime.Now,
                Type = "Credit",
                Operation = "Collection from Another Account",
                Account = model.AccountId.ToString()
            });           
        }
        public void Withdraw(TransactionWithdrawViewModel model)
        {
            _transactionRepository.PostTransaction(new Transactions
            {
                AccountId = model.AccountId,
                Amount = -model.WithdrawAmount,
                Balance = model.Balance - model.WithdrawAmount,
                Date = DateTime.Now,
                Type = "Debit",
                Operation = "Withdraw in Cash"
            });

            var account = _accountRepository.GetAccount(model.AccountId);
            account.Balance = account.Balance - model.WithdrawAmount;

            _accountRepository.UpdateAccount(account);
        }      

    }

}
