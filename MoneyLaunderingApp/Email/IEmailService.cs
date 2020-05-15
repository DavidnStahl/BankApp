using MoneyLaunderingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyLaunderingApp.Email
{
    public interface IEmailService
    {
        void SendEmail(string country, string content);
        string BuildEmailReport(LaunderingAccountModel scanResult);
    }
}
