using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Entities;
using MySql.Data.MySqlClient;

namespace Assignment1.DAL
{
    class AppointmentDAO : IAppointmentDAO
    {
        private static IAppointmentDAO _appointmentDAO = null;
        private String connectionString;
        MySqlConnection connection = null;

        private AppointmentDAO()
        {
            connectionString = "server = localhost; uid = root; database = assignment1; port = 3306;Convert Zero Datetime=True";
            connection = new MySqlConnection(connectionString);
        }

        public static IAppointmentDAO getInstance()
        {
            if(_appointmentDAO == null)
            {
                _appointmentDAO = new AppointmentDAO();
            }
            return _appointmentDAO;
        }

        public void addAppointment(Appointment appointment)
        {
            String sqlCommand = "INSERT INTO appointments (date, hour, clientName, telephoneNo, carBrand, description,status)" +
                                "VALUES('"+appointment.Date+"', '"+appointment.Hour+"', '"+appointment.ClientName+"', '"+appointment.TelephoneNo+"','"+appointment.CarBrand+"','"+appointment.Description+"','"+"not done"+"');";
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

        public List<Appointment> getAllAppointments(string date)
        {
            Appointment a = null;
            List<Appointment> appointmentList = new List<Appointment>();  
            String sql = "SELECT * FROM assignment1.appointments WHERE date = '"+date+"'";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    do
                    {
                        a = new Appointment(
                            reader["idappointments"].ToString(),
                            reader["date"].ToString(),
                            reader["hour"].ToString(),
                            reader["clientName"].ToString(),
                            reader["telephoneNo"].ToString(),
                            reader["carBrand"].ToString(),
                            reader["description"].ToString(),
                            reader["status"].ToString());

                        appointmentList.Add(a);
                    } while (reader.Read());
                }
                else
                {
                    appointmentList = new List<Appointment>();
                }
                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return null;
            }

            return appointmentList;
        }

        public List<Appointment> getAllAppointmentsFromDateToDate(string startingDate, string endingDate)
        {
            Appointment a = null;
            List<Appointment> appointmentList = new List<Appointment>();
            String sql = "SELECT * FROM assignment1.appointments WHERE date >= '" + startingDate + "' AND date <= '" + endingDate + "';";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    do
                    { 
                        a = new Appointment(
                            reader["idappointments"].ToString(),
                            reader["date"].ToString(),
                            reader["hour"].ToString(),
                            reader["clientName"].ToString(),
                            reader["telephoneNo"].ToString(),
                            reader["carBrand"].ToString(),
                            reader["description"].ToString(),
                            reader["status"].ToString());

                        appointmentList.Add(a);
                    } while (reader.Read());
                }
                else
                {
                    appointmentList = new List<Appointment>();
                }
                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return null;
            }

            return appointmentList;
        }

        public List<Appointment> getAppointment(string clientName)
        {
            Appointment a = null;
            List<Appointment> appointmentList = new List<Appointment>();
            String sql = "SELECT * FROM assignment1.appointments WHERE clientName='"+clientName+"';";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    do
                    {
                        a = new Appointment(
                            reader["idappointments"].ToString(),
                            reader["date"].ToString(),
                            reader["hour"].ToString(),
                            reader["clientName"].ToString(),
                            reader["telephoneNo"].ToString(),
                            reader["carBrand"].ToString(),
                            reader["description"].ToString(),
                            reader["status"].ToString());

                        appointmentList.Add(a);
                    } while (reader.Read());
                }
                else
                {
                    appointmentList = new List<Appointment>();
                }
                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return null;
            }

            return appointmentList;
        }

        public void setAppointmentStatusDone(string ID)
        {
            String sqlCommand = "UPDATE assignment1.appointments SET status='done' WHERE idappointments='" + ID + "';";
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
    }
}
