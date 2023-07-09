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
    public partial class Member : Form
    {
        Function con;
        public Member()
        {
            InitializeComponent();
            con = new Function();
            ShowMembers();
            GetCoaches();
            GetMembership();
        }
        private void ShowMembers()
        {
            string Query = "select * from MemberTbl";
            dgvMemberList.DataSource = con.GetData(Query);
        }
        private void GetCoaches()
        {
            string Query = "select * from CoachesTbl";
            cmbCoach.DisplayMember = con.GetData(Query).Columns["coach_Name"].ToString();
            cmbCoach.ValueMember = con.GetData(Query).Columns["coach_Id"].ToString();
            cmbCoach.DataSource = con.GetData(Query);
        }
        private void GetMembership()
        {
            string Query = "select * from MembershipTbl";
            cmbMshipType.DisplayMember = con.GetData(Query).Columns["mShip_Name"].ToString();
            cmbMshipType.ValueMember = con.GetData(Query).Columns["mShip_Id"].ToString();
            cmbMshipType.DataSource = con.GetData(Query);
        }
        int key = 0;
        private void dgvMemberList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvMemberList.SelectedRows[0].Cells[1].Value.ToString();
            cmbGender.SelectedItem = dgvMemberList.SelectedRows[0].Cells[2].Value.ToString();
            txtDOB.Text = dgvMemberList.SelectedRows[0].Cells[3].Value.ToString();
            txtJoinDate.Text = dgvMemberList.SelectedRows[0].Cells[4].Value.ToString();
            cmbMshipType.SelectedItem = dgvMemberList.SelectedRows[0].Cells[5].Value.ToString();
            txtPhone.Text = dgvMemberList.SelectedRows[0].Cells[6].Value.ToString();
            cmbTiming.SelectedItem = dgvMemberList.SelectedRows[0].Cells[7].Value.ToString();
            cmbStatus.SelectedItem = dgvMemberList.SelectedRows[0].Cells[8].Value.ToString();
            cmbCoach.SelectedItem = dgvMemberList.SelectedRows[0].Cells[9].Value.ToString();
            if (txtName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dgvMemberList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtPhone.Text == "" || txtDOB.Text == "" || txtJoinDate.Text == "" || cmbCoach.SelectedIndex == -1 || cmbGender.SelectedIndex == -1 || cmbMshipType.SelectedIndex == -1 || cmbStatus.SelectedIndex == -1 || cmbTiming.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing data !!!");
                }
                else
                {
                    string memName = txtName.Text;
                    string gender = cmbGender.SelectedItem.ToString();
                    string timing = cmbTiming.SelectedItem.ToString();
                    int mShipType = Convert.ToInt32(cmbMshipType.SelectedValue.ToString());
                    string status = cmbStatus.SelectedItem.ToString();
                    int coach = Convert.ToInt32(cmbCoach.SelectedValue.ToString());
                    string phone = txtPhone.Text;
                    string doB = txtDOB.Value.Date.ToString();
                    string joinDate = txtJoinDate.Value.Date.ToString();
                    string query = "insert into MemberTbl values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}' ,'{6}', '{7}' ,'{8}')";
                    query = string.Format(query, memName, gender, doB, joinDate, mShipType, phone, timing, status, coach);
                    con.setData(query);
                    ShowMembers();
                    MessageBox.Show("Member added !!!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtPhone.Text == "" || txtDOB.Text == "" || txtJoinDate.Text == "" || cmbCoach.SelectedIndex == -1 || cmbGender.SelectedIndex == -1 || cmbMshipType.SelectedIndex == -1 || cmbStatus.SelectedIndex == -1 || cmbTiming.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing data !!!");
                }
                else
                {
                    string memName = txtName.Text;
                    string gender = cmbGender.SelectedItem.ToString();
                    string timing = cmbTiming.SelectedItem.ToString();
                    int mShipType = Convert.ToInt32(cmbMshipType.SelectedValue.ToString());
                    string status = cmbStatus.SelectedItem.ToString();
                    int coach = Convert.ToInt32(cmbCoach.SelectedValue.ToString());
                    string phone = txtPhone.Text;
                    string doB = txtDOB.Value.Date.ToString();
                    string joinDate = txtJoinDate.Value.Date.ToString();
                    string query = "update MemberTbl set member_Name = '{0}', member_Gender = '{1}', member_DOB = '{2}',member_Date = '{3}', member_Mship = '{4}', member_Phone = '{5}' , member_Timing = '{6}', member_Status = '{7}', member_Coach = '{8}' where member_Id = {9}";
                    query = string.Format(query, memName, gender, doB, joinDate, mShipType, phone, timing, status, coach, key);
                    con.setData(query);
                    ShowMembers();
                    MessageBox.Show("Member Updated !!!");
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
                    MessageBox.Show("Select a Member !!!");
                }
                else
                {
                    
                    string query = "delete from MemberTbl where member_Id = {0}";
                    query = string.Format(query, key);
                    con.setData(query);
                    ShowMembers();
                    MessageBox.Show("Coach deleted !!!");
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

        private void btnCoach_Click(object sender, EventArgs e)
        {
            Coaches Obj = new Coaches();
            Obj.Show();
            this.Hide();
        }

        private void btnMship_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void btnReceptionist_Click(object sender, EventArgs e)
        {
            Receptionists Obj = new Receptionists();
            Obj.Show();
            this.Hide();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payment Obj = new Payment();
            Obj.Show();
            this.Hide();
        }
    }
}
