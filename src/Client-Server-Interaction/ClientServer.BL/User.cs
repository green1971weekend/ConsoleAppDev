using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientServer.BL
{
    public class User
    {
        public string Login { get; set; }

        public User(string name)
        {
            Login = name;
        }
    }
}
