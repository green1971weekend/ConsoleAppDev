using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientServer.BL
{
    /// <summary>
    /// User class.
    /// </summary>
    public class User
    {
        public string Login { get; set; }

        /// <summary>
        /// Constructor for name assign.
        /// </summary>
        /// <param name="name">Name.</param>
        public User(string name)
        {
            Login = name;
        }
    }
}
