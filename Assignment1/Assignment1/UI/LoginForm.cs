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
        UserService userService;

        public LoginForm()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;

            String role = userService.login(username, password);

            if (role.Equals("not found"))
            {
                MessageBox.Show("Not Registered");
            }
            else
            {
                if (role.Equals("admin"))
                {
                    //admin form
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();


                }
                if (role.Equals("user"))
                {
                    //user form
                    AgentForm agentForm = new AgentForm();
                    agentForm.Show();
                }
            }
        }

     
    }
}
