﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;

namespace Gym_management_system_t1
{
    public partial class Coaches : Form
    {
        Function con;
        public Coaches()
        {
            InitializeComponent();
            con = new Function();
            ShowCoach();
        }
        private void ShowCoach()
        {
            string Query = "select * from CoachesTbl";
            dgvCoachesList.DataSource = con.GetData(Query);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try { 
                if(txtName.Text == "" || txtPhone.Text == "" || txtExp.Text == "" || txtPassward.Text == "" || txtAddress.Text == "" || cmbGender.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing data !!!");
                }
                else
                {
                    string coName = txtName.Text;
                    string gender = cmbGender.SelectedItem.ToString();
                    string phone = txtPhone.Text;
                    int experience = Convert.ToInt32(txtExp.Text);
                    string address = txtAddress.Text;
                    string passward = txtPassward.Text;
                    string query = "insert into CoachesTbl values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}' ,'{6}')";
                    query = string.Format(query, coName, gender, dateDOB.Value.Date, phone, experience, address, passward);
                    con.setData(query);
                    ShowCoach();
                    MessageBox.Show("Coach added !!!");
                }
            }
            catch(Exception Ex) {
                MessageBox.Show(Ex.Message);
            }
        }

        int key = 0;
        private void dgvCoachesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvCoachesList.SelectedRows[0].Cells[1].Value.ToString();
            cmbGender.SelectedItem = dgvCoachesList.SelectedRows[0].Cells[2].Value.ToString();
            dateDOB.Text = dgvCoachesList.SelectedRows[0].Cells[3].Value.ToString();
            txtPhone.Text = dgvCoachesList.SelectedRows[0].Cells[4].Value.ToString();
            txtExp.Text = dgvCoachesList.SelectedRows[0].Cells[5].Value.ToString();
            txtAddress.Text = dgvCoachesList.SelectedRows[0].Cells[6].Value.ToString();
            txtPassward.Text = dgvCoachesList.SelectedRows[0].Cells[7].Value.ToString();
            if (txtName.Text == "")
            {
                key = 0;
            }
            else {
                key = Convert.ToInt32(dgvCoachesList.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (key ==0)
                {
                    MessageBox.Show("Select a Coach !!!");
                }
                else
                {
                    string coName = txtName.Text;
                    string gender = cmbGender.SelectedItem.ToString();
                    string phone = txtPhone.Text;
                    int experience = Convert.ToInt32(txtExp.Text);
                    string address = txtAddress.Text;
                    string passward = txtPassward.Text;
                    string query = "delete from CoachesTbl where coach_Id = {0}";
                    query = string.Format(query, key);
                    con.setData(query);
                    ShowCoach();
                    MessageBox.Show("Coach deleted !!!");
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
                if (txtName.Text == "" || txtPhone.Text == "" || txtExp.Text == "" || txtPassward.Text == "" || txtAddress.Text == "" || cmbGender.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing data !!!");
                }
                else
                {
                    string coName = txtName.Text;
                    string gender = cmbGender.SelectedItem.ToString();
                    string phone = txtPhone.Text;
                    int experience = Convert.ToInt32(txtExp.Text);
                    string address = txtAddress.Text;
                    string passward = txtPassward.Text;
                    string query = "update CoachesTbl set coach_Name = '{0}', coach_Gender = '{1}', coach_DOB = '{2}', coach_Phone = '{3}', coach_Exp = '{4}', coach_Address = '{5}' , coach_Passward = '{6}' where coach_Id = {7}";
                    query = string.Format(query, coName, gender, dateDOB.Value.Date, phone, experience, address, passward, key);
                    con.setData(query);
                    ShowCoach();
                    MessageBox.Show("Coach Updated !!!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}