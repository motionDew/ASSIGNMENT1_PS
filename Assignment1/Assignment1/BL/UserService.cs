using Assignment1.DAL;
using Assignment1.Entities;
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
        private IUserDAO _userDAO;

        public UserService()
        {
            _userDAO = UserDAO.getInstance();        
        }

        public String login(String username, String password)
        {
            String MD5Password = encryptPassword(password);
            User user = _userDAO.getUser(username, MD5Password);

            if (user != null)
            {
                return user.Role;
            }
            return "not found";
        }
        
        public void createAccount(String username, String password,String name,String role)
        {
            String MD5Password = encryptPassword(password);
            User user = new User(username,MD5Password,name,role);
            _userDAO.addUser(user);
        }

        private String encryptPassword(String input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
