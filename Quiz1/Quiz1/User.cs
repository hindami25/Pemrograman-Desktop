using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1
{
    internal class User
    {
        public string Username { get; }
        private string Password { get; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool Login(string username, string password)
        {
            return Username == username && Password == password;
        }
    }
}
