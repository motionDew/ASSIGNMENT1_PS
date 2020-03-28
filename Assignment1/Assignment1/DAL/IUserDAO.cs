using Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.DAL
{
    interface IUserDAO
    {
        User getUser(String username, String password);
        void addUser(User user);
    }
}
