using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gym_management_system_t1
{
    class Function
    {
        private SqlConnection con;
        private SqlCommand cmd;
        string conStr;
        public Function() {
            conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DELL\\Documents\\GymManagementDB.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(conStr);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public int setData(string Query)
        {
            int cnt = 0;
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = Query;
            cnt = cmd.ExecuteNonQuery();
            con.Close();
            return cnt;
        }
        public DataTable GetData(string Query) {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(Query, conStr);
            sda.Fill(dt);
            return dt;
        }
    }
}
