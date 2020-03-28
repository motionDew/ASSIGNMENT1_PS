using Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.DAL
{
    interface IAppointmentDAO
    {
        List<Appointment> getAppointment(String clientName);
        List<Appointment> getAllAppointments(String date);
        List<Appointment> getAllAppointmentsFromDateToDate(String startingDate,String endingDate);
        void addAppointment(Appointment appointment);
        void setAppointmentStatusDone(String clientName);
    }
}
