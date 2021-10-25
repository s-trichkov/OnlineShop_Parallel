using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop_Parallel
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = Password;
        }
    }
}
