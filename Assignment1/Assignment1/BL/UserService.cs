using Assignment1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.BL
{   
    class UserService
    {

        private UserDAO _userDAO;

        public UserService(){}

        public void login(String username, String password)
        {

        }
        
        public void createAccount(String username, String password)
        {

        }

        private String encryptPassword(String input)
        {
            //Create a new instance of MD5 object;
            MD5 md5Hasher = MD5.Create();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            Console.WriteLine("UsersDAO.getMD5Hash::" + stringBuilder.ToString());

            return stringBuilder.ToString();
        }


    }
}
