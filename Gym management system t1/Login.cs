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
    public partial class Login : Form
    {
        Function con;
        
        public Login()
        {
            InitializeComponent();
            con = new Function();
        }
        public static int userId;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Missing Password or Username !!!");
            }
            else
            {
                try
                {
                    string Query = "select * from ReceptionistTbl where recep_Name = '{0}' and recep_Passward = '{1}'";
                    Query = string.Format(Query, username, password);
                    DataTable dataTable = con.GetData(Query);
                    if(dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Receptionist!!!, Please try again.");
                    }
                    else
                    {
                        userId = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                        Member Obj = new Member();
                        Obj.Show();
                        this.Hide();
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {
            
            AdminLogin Obj = new AdminLogin();
            Obj.Show();
            this.Hide();
                  
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
