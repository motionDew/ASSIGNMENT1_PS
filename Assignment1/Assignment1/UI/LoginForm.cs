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
    public partial class LoginForm : Form
    {
        UserService userService = new UserService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String pass = textBox2.Text;

            
            //Retrieve user
            //User user = ...;

            /*if (u == null)
            {
                MessageBox.Show("Not Registered");
            }
            else
            {
                if (u.Role.Equals("admin"))
                {
                    //admin form
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();


                }
                if (u.Role.Equals("agent"))
                {
                    //user form
                    AgentForm agentForm = new AgentForm();
                    agentForm.Show();
                }
            }*/
        }
    }
}
