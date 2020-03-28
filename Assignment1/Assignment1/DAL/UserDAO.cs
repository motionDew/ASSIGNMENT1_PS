using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Entities;
using MySql.Data.MySqlClient;

namespace Assignment1.DAL
{
    class UserDAO : IUserDAO
    {
        private static IUserDAO _userDAO = null;
        private String connectionString;
        MySqlConnection connection = null;

        private UserDAO()
        {
            connectionString = "server = localhost; uid = root; database=assignment1; port=3306";
            connection = new MySqlConnection(connectionString);
        }

        public static IUserDAO getInstance()
        {
            if(_userDAO == null)
            {
                _userDAO = new UserDAO();
            }
            return _userDAO;
        }

        public void addUser(User user)
        {
            String sqlCommand = "INSERT INTO users (role, name, username, password) VALUES('" + user.Role + "','" + user.Name + "','" + user.Username + "','" + user.Password + "');";
            //TODO inserting uniquely into DB; 
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        public User getUser(string username, string password)
        {
            User u = null;
            String sql = "SELECT * FROM users WHERE username= '" + username + "'AND password='" + password + "'";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["role"].ToString());
                }
                else
                {
                    u = null;
                }
                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return null;
            }

            return u;
        }
    }
}
