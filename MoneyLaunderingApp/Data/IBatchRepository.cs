using ClassLibary.Models;
using MoneyLaunderingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyLaunderingApp.Data
{
    public interface IBatchRepository
    {
        List<LaunderingInformationModel> GetTransactionsToScan();
        void SaveLatestScannedTransaction(BatchStatus model);

        BatchStatus LatestTransactionScanned();

    }
}
