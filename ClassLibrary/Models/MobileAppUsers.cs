using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public partial class MobileAppUsers
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; }
    }
}
