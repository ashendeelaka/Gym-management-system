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
    public partial class Payment : Form
    {
        Function con;
        public Payment()
        {
            InitializeComponent();
            con = new Function();
            ShowPayment();
            GetMember();
        }
        private void ShowPayment()
        {
            string Query = "select * from PaymentTbl";
            dgvPaymentList.DataSource = con.GetData(Query);
        }
        private void GetMember()
        {
            string Query = "select * from MemberTbl";
            cmbMember.DisplayMember = con.GetData(Query).Columns["member_Name"].ToString();
            cmbMember.ValueMember = con.GetData(Query).Columns["member_Id"].ToString();
            cmbMember.DataSource = con.GetData(Query);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMember.Text == "" || txtAmount.Text == "")
                {
                    MessageBox.Show("Missing data !!!");
                }
                else
                {
                    int agent = Login.userId;
                    string member = cmbMember.SelectedValue.ToString(); 
                    string period = txtPeriod.Value.Date.Month + "-" + txtPeriod.Value.Date.Year;
                    string billDate = txtBillingDate.Value.Date.ToString();
                    string amount = txtAmount.Text;
                    string query = "insert into PaymentTbl values('{0}', '{1}', '{2}', '{3}', '{4}')";
                    query = string.Format(query, agent, member, period, billDate, amount);
                    con.setData(query);
                    ShowPayment();
                    MessageBox.Show("Payment Successfull !!!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAmount.Text = "";
            cmbMember.SelectedIndex = -1;
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

        private void btnMember_Click(object sender, EventArgs e)
        {
            Member Obj = new Member();
            Obj.Show();
            this.Hide();
        }

        private void btnReceptionist_Click(object sender, EventArgs e)
        {
            Receptionists Obj = new Receptionists();
            Obj.Show();
            this.Hide();
        }

        private void btnMship_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }
    }
}
