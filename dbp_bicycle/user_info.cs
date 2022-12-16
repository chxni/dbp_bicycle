using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace dbp_bicycle
{
    public partial class user_info : Form
    {
        public user_info()
        {
            InitializeComponent();
        }
        private OracleConnection odpConn = new OracleConnection();
        static String connectionString = "User Id=chani; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
        OracleConnection myConnection = new OracleConnection(connectionString);
        OracleDataAdapter DBAdapter = new OracleDataAdapter();
        DataSet DS = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                DBAdapter.SelectCommand = new OracleCommand("select * from member where memno =:memno", myConnection);

                DBAdapter.SelectCommand.Parameters.Add("memno", OracleDbType.Varchar2, 20);
                DBAdapter.SelectCommand.Parameters["memno"].Value = textBox1.Text.Trim();

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DBAdapter.SelectCommand = new OracleCommand("select * from member where name =:name", myConnection);

                DBAdapter.SelectCommand.Parameters.Add("name", OracleDbType.Varchar2, 20);
                DBAdapter.SelectCommand.Parameters["name"].Value = textBox1.Text.Trim();
            }
            else
            {
                DBAdapter.SelectCommand = new OracleCommand("select * from member", myConnection);
            }
            DBAdapter.Fill(DS, "member");
            DataTable RelTable = DS.Tables["member"];
            DataRowCollection rows = RelTable.Rows;
            foreach (DataRow dr in rows)
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                for (int i = 1; i < RelTable.Columns.Count; i++)
                {
                    item.SubItems.Add(dr[i].ToString());
                }
                listView2.Items.Add(item);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                DBAdapter.SelectCommand = new OracleCommand("select * from rental where memno =memno:", myConnection);

                DBAdapter.SelectCommand.Parameters.Add("memno", OracleDbType.Varchar2, 20);
                DBAdapter.SelectCommand.Parameters["memno"].Value = textBox1.Text.Trim();

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DBAdapter.SelectCommand = new OracleCommand("select R.rentaldate, R.bicno, D.area from rental R, member M, depository D where R.memno = M.memno and R.depno = D.depno and M.name =:name", myConnection);

                DBAdapter.SelectCommand.Parameters.Add("name", OracleDbType.Varchar2, 20);
                DBAdapter.SelectCommand.Parameters["name"].Value = textBox1.Text.Trim();
            }
            else
            {
                DBAdapter.SelectCommand = new OracleCommand("select R.rentaldate, R.bicno, D.area from rental R, member M, depository D where R.memno = M.memno and R.depno = D.depno and M.name =:name", myConnection);
            }
            DBAdapter.Fill(DS, "rental");
            DataTable RelTable = DS.Tables["rental"];
            DataRowCollection rows = RelTable.Rows;
            foreach (DataRow dr in rows)
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                for (int i = 1; i < RelTable.Columns.Count; i++)
                {
                    item.SubItems.Add(dr[i].ToString());
                }
                listView1.Items.Add(item);

            }
        }
    }
}
