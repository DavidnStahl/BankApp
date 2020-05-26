using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using MoneyLaunderingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace MoneyLaunderingApp.Email
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string country, string content)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new System.Net.NetworkCredential(configuration["username"], configuration["password"]),
                EnableSsl = true
            };
            client.Send("MoneyLaunderingApp@app.se", $"{country}@testbanken.se", "report", content);
            Console.WriteLine("Sent");
        }
        public string BuildEmailReport(LaunderingAccountModel scanResult)
        {
            var message = new MailMessage();
            message.IsBodyHtml = false;
            var customerInfo = "";
            foreach (var customer in scanResult.Customer)
            {
                customerInfo += $"{Environment.NewLine}{Environment.NewLine}{customer.GivenName} {customer.SureName}, over limit Last 72 hours: {customer.overLimitLast72Hours} {Environment.NewLine}{Environment.NewLine}";
                foreach (var account in customer.Account)
                {
                    customerInfo += $"{Environment.NewLine}accountId: {account.AccountId} {Environment.NewLine}{Environment.NewLine}Transactions:{Environment.NewLine}{Environment.NewLine}";
                    var distinctTransactions = account.Transactions.Select(r => r.TransactionId).Distinct().ToList();
                    foreach (var transaction in distinctTransactions)
                    {
                        customerInfo += $"{transaction} ";
                    }
                }
            }
            return message.Body = $"country: {scanResult.Country} {Environment.NewLine}{customerInfo}";
        }
    }
}
