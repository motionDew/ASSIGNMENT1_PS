using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Entities
{
    class User
    {
        private String _username;
        private String _password;
        private String _name;
        private String _role;

        public User(){}
        public User(String username,String password, String name, String role)
        {
            Username = username;
            Password = password;
            Name = name;
            Role = role;
        }


        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Name { get => _name; set => _name = value; }
        public string Role { get => _role; set => _role = value; }
     
    }
}
