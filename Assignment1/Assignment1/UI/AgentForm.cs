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
    public partial class AgentForm : Form
    {
        AppointmentService appointmentService;
        DataTable appointmetsTable = new DataTable();

        public AgentForm()
        {
            InitializeComponent();
            appointmentService = new AppointmentService();
            appointmetsTable = new DataTable();

            appointmetsTable.Columns.Add("ID");
            appointmetsTable.Columns.Add("Date");
            appointmetsTable.Columns.Add("Hour");
            appointmetsTable.Columns.Add("Client name");
            appointmetsTable.Columns.Add("Telephone");
            appointmetsTable.Columns.Add("Car Brand");
            appointmetsTable.Columns.Add("Description");
            appointmetsTable.Columns.Add("Status");
         }

        private void button1_Click(object sender, EventArgs e)
        {
            String date = textBox1.Text;
            String hour = textBox2.Text;
            String clientName = textBox3.Text;
            String telephoneNo = textBox4.Text;
            String carBrand = textBox5.Text;
            String description = textBox6.Text;

            bool dateAndHourAvailable = appointmentService.exists(date, hour);

            if (dateAndHourAvailable == false)
            {
                Appointment appointment = new Appointment("", date, hour, clientName, telephoneNo, carBrand, description, "unsolved");
                appointmentService.registerAppointment(appointment);
                appointment = appointmentService.getLastAddedAppointment();

                label17.Text = appointment.Date;
                label18.Text = appointment.Hour;
                label19.Text = appointment.ClientName;
                label20.Text = appointment.TelephoneNo;
                label21.Text = appointment.CarBrand;
                label22.Text = appointment.Description;
                label24.Text = appointment.Id;
                label26.Text = appointment.Status;
            }
            else
            {
                MessageBox.Show("Appointment already exists on this date and hour!");
            }
        }

        private void AgentForm_Load(object sender, EventArgs e)
        {
            showAllAppointments("1900-01-01","2030-01-01");
        }

        private void showAllAppointments(string startDate, string endDate)
        {
            appointmetsTable.Clear();

            List<Appointment> appointmentsList = appointmentService.getAllAppointmentsFromDateToDate(startDate, endDate);

            foreach (Appointment ap in appointmentsList)
            {
                var row = appointmetsTable.NewRow();
                row["ID"] = ap.Id;
                row["Date"] = ap.Date;
                row["Hour"] = ap.Hour;
                row["Client Name"] = ap.ClientName;
                row["Car Brand"] = ap.CarBrand;
                row["Telephone"] = ap.TelephoneNo;
                row["Description"] = ap.Description;
                row["Status"] = ap.Status;

                appointmetsTable.Rows.Add(row);
            }

            dataGridView1.DataSource = appointmetsTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showAllAppointments(textBox7.Text, textBox7.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showAllAppointments("1900-01-01", "2030-01-01");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            appointmentService.setAppointmentDone(textBox8.Text);
        }
    }
}
