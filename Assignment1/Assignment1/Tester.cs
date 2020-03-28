using Assignment1.DAL;
using Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Tester
    {

        static void Main(string[] args)
        {
            //UserDAO.getInstance().addUser(new User("test_user", "81dc9bdb52d04dc20036dbd8313ed055", "Alex Test", "user"));
            //User u = UserDAO.getInstance().getUser("giovanniboss", "0004e955268823c83745d920b4a2e92b");
            AppointmentDAO.getInstance().setAppointmentStatusDone("5");


           

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}

