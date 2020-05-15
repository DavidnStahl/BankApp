using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Data.MobileAppUser
{
    public class MobileAppUserRepository : IMobileAppUserRepository
    {
        private readonly BankAppDataContext _context;


        public MobileAppUserRepository(BankAppDataContext context)
        {
            _context = context;
        }
        public int InloggedUserCustomerId(string username, string password)
        {
            return _context.MobileAppUsers.FirstOrDefault(m => m.Username == username && m.Password == password).CustomerId;
        }

        public bool IsValidUser(string username,string password)
        {
            var user = _context.MobileAppUsers.FirstOrDefault(m => m.Username == username && m.Password == password);
            if (user != null)
                return true;

            return false;
        }
    }
}
