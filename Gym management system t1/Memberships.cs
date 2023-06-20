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
    public partial class Memberships : Form
    {
        Function con;
        public Memberships()
        {
            InitializeComponent();
            con = new Function();
            ShowMShips();
        }
        private void ShowMShips()
        {
            string Query = "select * from MembershipTbl";
            dgvMembershipList.DataSource = con.GetData(Query);
        }
        private void Reset()
        {
            txtName.Text = "";
            txtCost.Text = "";
            txtDuration.Text = "";
            txtGoal.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtDuration.Text == "" || txtGoal.Text == "" || txtCost.Text == "")
                {
                    MessageBox.Show("Missing data !!!");
                }
                else
                {
                    string MshipName = txtName.Text;
                    int duration = Convert.ToInt32(txtDuration.Text);
                    string goal = txtGoal.Text;
                    int cost = Convert.ToInt32(txtCost.Text);
                    string query = "insert into MembershipTbl values ('{0}', '{1}', '{2}', '{3}')";
                    query = string.Format(query, MshipName, duration, goal, cost);
                    con.setData(query);
                    ShowMShips();
                    MessageBox.Show("Membership added !!!");
                    //Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void dgvMembershipList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvMembershipList.SelectedRows[0].Cells[1].Value.ToString();
            txtDuration.Text = dgvMembershipList.SelectedRows[0].Cells[2].Value.ToString();
            txtGoal.Text = dgvMembershipList.SelectedRows[0].Cells[3].Value.ToString();
            txtCost.Text = dgvMembershipList.SelectedRows[0].Cells[4].Value.ToString();
            
            if (txtName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dgvMembershipList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a Membership !!!");
                }
                else
                {
                    string MshipName = txtName.Text;
                    int duration = Convert.ToInt32(txtDuration.Text);
                    string goal = txtGoal.Text;
                    int cost = Convert.ToInt32(txtCost.Text);
                    string query = "delete from MembershipTbl where mShip_Id = {0}";
                    query = string.Format(query, key);
                    con.setData(query);
                    ShowMShips();
                    MessageBox.Show("Membership deleted !!!");
                    Reset();
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
                if (txtName.Text == "" || txtDuration.Text == "" || txtGoal.Text == "" || txtCost.Text == "")
                {
                    MessageBox.Show("Missing data !!!");
                }
                else
                {
                    string MshipName = txtName.Text;
                    int duration = Convert.ToInt32(txtDuration.Text);
                    string goal = txtGoal.Text;
                    int cost = Convert.ToInt32(txtCost.Text);
                    string query = "update MembershipTbl set mShip_Name = '{0}', mShip_Duration = {1}, mShip_goal = '{2}', mShip_Fee = {3} where mShip_Id = {4}";
                    query = string.Format(query, MshipName, duration, goal, cost,key);
                    con.setData(query);
                    ShowMShips();
                    MessageBox.Show("Membership Updated !!!");
                    //Reset();  
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
