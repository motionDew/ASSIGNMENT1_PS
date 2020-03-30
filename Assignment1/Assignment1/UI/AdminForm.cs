using Assignment1.BL;
using Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1.UI
{
    public partial class AdminForm : Form
    {
        UserService userService;
        AppointmentService appointmentService;
        DataTable appointmetsTableDate = new DataTable();
        DataTable appointmetsTableName = new DataTable();

        public AdminForm()
        {
            InitializeComponent();
            userService = new UserService();
            appointmentService = new AppointmentService();

            appointmetsTableDate.Columns.Add("ID");
            appointmetsTableDate.Columns.Add("Date");
            appointmetsTableDate.Columns.Add("Hour");
            appointmetsTableDate.Columns.Add("Client name");
            appointmetsTableDate.Columns.Add("Telephone");
            appointmetsTableDate.Columns.Add("Car Brand");
            appointmetsTableDate.Columns.Add("Description");
            appointmetsTableDate.Columns.Add("Status");

            appointmetsTableName.Columns.Add("ID");
            appointmetsTableName.Columns.Add("Date");
            appointmetsTableName.Columns.Add("Hour");
            appointmetsTableName.Columns.Add("Client name");
            appointmetsTableName.Columns.Add("Telephone");
            appointmetsTableName.Columns.Add("Car Brand");
            appointmetsTableName.Columns.Add("Description");
            appointmetsTableName.Columns.Add("Status");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            String name = textBox4.Text;
            String role = textBox7.Text;
            userService.createAccount(username, password,name,role);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showAllAppointments(textBox5.Text, textBox6.Text);
        }

        private void showAllAppointments(string startDate, string endDate)
        {
            appointmetsTableDate.Clear();

            List<Appointment> appointmentsList = appointmentService.getAllAppointmentsFromDateToDate(startDate, endDate);

            foreach (Appointment ap in appointmentsList)
            {
                var row = appointmetsTableDate.NewRow();
                row["ID"] = ap.Id;
                row["Date"] = ap.Date;
                row["Hour"] = ap.Hour;
                row["Client Name"] = ap.ClientName;
                row["Car Brand"] = ap.CarBrand;
                row["Telephone"] = ap.TelephoneNo;
                row["Description"] = ap.Description;
                row["Status"] = ap.Status;

                appointmetsTableDate.Rows.Add(row);
            }

            dataGridView1.DataSource = appointmetsTableDate;
        }

        private void showAllAppointmentsByClient(string clientName)
        {
            appointmetsTableName.Clear();
            List<Appointment> appointmentsList = new List<Appointment>();

            appointmentsList = appointmentService.getAllAppointmentsByName(clientName);

            foreach (Appointment ap in appointmentsList)
            {
                var row = appointmetsTableName.NewRow();
                row["ID"] = ap.Id;
                row["Date"] = ap.Date;
                row["Hour"] = ap.Hour;
                row["Client Name"] = ap.ClientName;
                row["Car Brand"] = ap.CarBrand;
                row["Telephone"] = ap.TelephoneNo;
                row["Description"] = ap.Description;
                row["Status"] = ap.Status;

                appointmetsTableName.Rows.Add(row);
            }

            dataGridView2.DataSource = appointmetsTableName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showAllAppointmentsByClient(textBox3.Text);
        }
    }
}
