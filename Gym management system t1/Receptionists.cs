using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Gym_management_system_t1
{
    public partial class Receptionists : Form
    {
        Function con;
        public Receptionists()

        {
            InitializeComponent();
            con = new Function();
            ShowReceptionist();
        }
        private void ShowReceptionist()
        {
            string Query = "select * from ReceptionistTbl";
            dgvReceptionistList.DataSource = con.GetData(Query);
        }

        
        int key = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvReceptionistList.SelectedRows[0].Cells[1].Value.ToString();
            cmbGender.SelectedItem = dgvReceptionistList.SelectedRows[0].Cells[2].Value.ToString();
            txtDOB.Text = dgvReceptionistList.SelectedRows[0].Cells[3].Value.ToString();
            txtAddress.Text = dgvReceptionistList.SelectedRows[0].Cells[4].Value.ToString();
            txtPhone.Text = dgvReceptionistList.SelectedRows[0].Cells[5].Value.ToString();
            txtPassward.Text = dgvReceptionistList.SelectedRows[0].Cells[6].Value.ToString();

            if (txtName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dgvReceptionistList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtPhone.Text == "" || txtDOB.Text == "" || txtPassward.Text == "" || txtAddress.Text == "" || cmbGender.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing data !!!");
                }
                else
                {
                    string recepName = txtName.Text;
                    string gender = cmbGender.SelectedItem.ToString();
                    string phone = txtPhone.Text;
                    string DOB = txtDOB.Value.Date.ToString(); 
                    string address = txtAddress.Text;
                    string passward = txtPassward.Text;
                    string query = "insert into ReceptionistTbl values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
                    query = string.Format(query, recepName, gender, DOB, address, phone,passward);
                    con.setData(query);
                    ShowReceptionist();
                    MessageBox.Show("Receptionist added !!!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a Receptionist !!!");
                }
                else
                {
                    
                    string query = "delete from ReceptionistTbl where recep_Id = {0}";
                    query = string.Format(query, key);
                    con.setData(query);
                    ShowReceptionist();
                    MessageBox.Show("Receptionist deleted !!!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtPhone.Text == "" || txtDOB.Text == "" || txtPassward.Text == "" || txtAddress.Text == "" || cmbGender.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing data !!!");
                }
                else
                {
                    string recepName = txtName.Text;
                    string gender = cmbGender.SelectedItem.ToString();
                    string phone = txtPhone.Text;
                    string DOB = txtDOB.Value.Date.ToString();
                    string address = txtAddress.Text;
                    string passward = txtPassward.Text;
                    string query = "update ReceptionistTbl set recep_Name = '{0}', recep_Gender = '{1}', recep_DOB = '{2}', recep_Address = '{3}', recep_Phone = '{4}', recep_Passward = '{5}' where recep_Id = {6}";
                    query = string.Format(query, recepName, gender, DOB, address, phone, passward,key);
                    con.setData(query);
                    ShowReceptionist();
                    MessageBox.Show("Receptionist Updated !!!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void btnMship_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payment Obj = new Payment();
            Obj.Show();
            this.Hide();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            Member Obj = new Member();
            Obj.Show();
            this.Hide();
        }

        private void btnCoach_Click(object sender, EventArgs e)
        {
            Coaches Obj = new Coaches();
            Obj.Show();
            this.Hide();
        }
    }
}
