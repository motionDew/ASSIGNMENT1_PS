using System;
using System.Collections.Generic;
using System.Globalization;
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
                                "VALUES('"+appointment.Date+"', '"+appointment.Hour+"', '"+appointment.ClientName+"', '"+appointment.TelephoneNo+"','"+appointment.CarBrand+"','"+appointment.Description+"','"+"unsolved"+"');";
            //TODO inserting uniquely into DB; 
            try
            {
                connection.Open();
                Console.WriteLine("Connection success, executing command...");
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

        //getAllAppointments -> Tested -> Works correctly;
        public List<Appointment> getAllAppointments(string date)
        {
            String sql = "SELECT * FROM assignment1.appointments WHERE date = '"+date+"'";
            return tryFetchRepetitive(sql);
        }

        //getAllAppointmentsFromDateToDate -> Tested -> Works correctly;
        public List<Appointment> getAllAppointmentsFromDateToDate(string startingDate, string endingDate)
        {
            String sql = "SELECT * FROM assignment1.appointments WHERE date >= '" + startingDate + "' AND date <= '"+endingDate+"'";
            return tryFetchRepetitive(sql);
        }

        //Test getAppointment
        public Appointment getAppointment(string id)
        {
            String sql = "SELECT FROM assignment1.appointments WHERE id='" + id + "';";
            return tryFetchDirect(sql);
        }

        //getAppointments -> Tested -> Works correctly;
        public List<Appointment> getAppointments(string clientName)
        {
            String sql = "SELECT * FROM assignment1.appointments WHERE clientName='" + clientName + "';";
            return tryFetchRepetitive(sql);
        }

        //getLastAddedAppointment -> Tested -> Works correctly;
        public Appointment getLastAddedAppointment()
        {
            String sql = "SELECT * FROM appointments ORDER BY idappointments DESC LIMIT 1";
            return tryFetchDirect(sql);
        }

        public void setAppointmentStatusDone(string ID)
        {
            String sqlCommand = "UPDATE assignment1.appointments SET status='solved' WHERE idappointments='" + ID + "';";
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
        private List<Appointment> tryFetchRepetitive(String sqlCommand)
        {
            Appointment a = null;
            List<Appointment> appointmentList = new List<Appointment>();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    do
                    {
                        a = new Appointment(
                            reader["idappointments"].ToString(),
                            Convert.ToDateTime(reader["date"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
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
                return appointmentList;
            }
            return appointmentList;
        }
        private Appointment tryFetchDirect(String sqlCommand)
        {
            Appointment a = null;
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    a = new Appointment(
                        reader["idappointments"].ToString(),
                       Convert.ToDateTime(reader["date"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        reader["hour"].ToString(),
                        reader["clientName"].ToString(),
                        reader["telephoneNo"].ToString(),
                        reader["carBrand"].ToString(),
                        reader["description"].ToString(),
                        reader["status"].ToString());
                }
                else
                {
                    return null;
                }
                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return null;
            }
            return a;
        }

        public int exists(string date, string hour)
        {
            int entries=-1;
            String sqlCommand = "SELECT COUNT(*) FROM appointments WHERE date = '"+date+"' AND hour = '"+hour+"';";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                entries = Int32.Parse(reader["COUNT(*)"].ToString());
                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
            return entries;
        }
    }
}
