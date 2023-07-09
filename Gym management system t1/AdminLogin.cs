using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_management_system_t1
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = "Admin";
            string password = "1234";
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;
            if (enteredUsername == "" || enteredPassword == "")
            {
                MessageBox.Show("Missing Password or Username !!!");
            }
            else
            {
                try
                {

                    if (username == enteredUsername && password == enteredPassword)
                    {
                        Receptionists Obj = new Receptionists();
                        Obj.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Receptionist!!!, Please try again.");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
