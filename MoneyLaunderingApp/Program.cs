using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using MoneyLaunderingApp.Data;
using MoneyLaunderingApp.Email;
using MoneyLaunderingApp.Services;
using System;

namespace MoneyLaunderingApp
{
    class Program
    {
        private static readonly IEmailService _emailService = new EmailService();
        private static readonly IBatchRepository _repository = new BatchRepository();
        private static readonly BankAppDataContext _context = new BankAppDataContext();
        private static readonly DatabaseInitializer _databaseInitializer = new DatabaseInitializer();
        private static readonly ILaunderingService _service = new LaunderingService(_emailService, _repository);
        static void Main(string[] args)
        {            
            _databaseInitializer.Initialize(_context);
            _service.StartApp();
        }
       
    }
}
