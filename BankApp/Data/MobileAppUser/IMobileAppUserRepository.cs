using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Data.MobileAppUser
{
    public interface IMobileAppUserRepository
    {
        bool IsValidUser(string username, string password);
        int InloggedUserCustomerId(string username, string password);
    }
}
