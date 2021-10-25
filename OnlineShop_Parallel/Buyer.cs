using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop_Parallel
{
    public class Buyer : User
    {
        public string Email { get; set; }
        public string Address { get; set; }
        public Buyer(string name, string username, string password, string email, string adress) : base(name, username, password)
        {
            Email = email;
            Address = adress;
        }
    }
}
