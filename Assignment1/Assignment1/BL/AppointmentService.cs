using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DAL;
using Assignment1.Entities;

namespace Assignment1.BL
{
    class AppointmentService : IAppointmentService
    {
        IAppointmentDAO appointmentDAO;

        public AppointmentService() {
            appointmentDAO = AppointmentDAO.getInstance();
        }

        public Appointment getAppointment(string id)
        {
            return appointmentDAO.getAppointment(id);
        }

        public List<Appointment> getAllAppointmentsByDate(string date)
        {
            return appointmentDAO.getAllAppointments(date);
        }

        public List<Appointment> getAllAppointmentsFromDateToDate(string startDate, string endDate)
        {
            return appointmentDAO.getAllAppointmentsFromDateToDate(startDate, endDate);
        }

        public void registerAppointment(Appointment appointment)
        {
            appointmentDAO.addAppointment(appointment);
        }

        public void setAppointmentDone(string ID)
        {
            appointmentDAO.setAppointmentStatusDone(ID);
        }

        public Appointment getLastAddedAppointment()
        {
            return appointmentDAO.getLastAddedAppointment();
        }
        public List<Appointment> getAllAppointmentsByName(String client)
        {
            return appointmentDAO.getAppointments(client);
        }

        public bool exists(string date, string hour)
        {
            int entries = appointmentDAO.exists(date, hour);

            if(entries == -1)
            {
                Console.WriteLine("Error: Reading Unsuccesful");
            }else if( entries == 0)
            {
                return false;
            }
            return true;
        }
    }
}
