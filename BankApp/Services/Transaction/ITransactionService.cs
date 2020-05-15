using BankApp.ViewModels.Accounts;
using BankApp.ViewModels.Transactions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services.Transaction
{
    public interface ITransactionService
    {
        void Deposit(TransactionDepositViewModel model);
        void Withdraw(TransactionWithdrawViewModel model);
        decimal GetBalance(int id);
        void TransferMoney(TransactionTransferToAccountViewModel model);

    }
}
