using Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.BL
{
    interface IAppointmentService
    {
        void registerAppointment(Appointment appointment);
        void setAppointmentDone(string ID);
        List<Appointment> getAllAppointmentsByDate(String date);
        List<Appointment> getAllAppointmentsByName(String name);
        Appointment getAppointment(String id);
        List<Appointment> getAllAppointmentsFromDateToDate(String startDate, String endDate);
        Appointment getLastAddedAppointment();
        bool exists(String date, String hour);

    }
}
