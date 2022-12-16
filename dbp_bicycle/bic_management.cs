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
    
    public partial class bic_management : Form
    {
        public bic_management()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string ConStr = "User Id=chani; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
            OracleConnection conn = new OracleConnection(ConStr);
            conn.Open();
            OracleDataAdapter DBAdapter = new OracleDataAdapter();

            DataSet DS = new DataSet();
            if (comboBox1.SelectedIndex == 0)
            {
                DBAdapter.SelectCommand = new OracleCommand("select B.bicno, B.status, D.area from bicycle B, depository D where B.depno = D.depno and bicno =:bicno", conn);

                DBAdapter.SelectCommand.Parameters.Add("bicno", OracleDbType.Varchar2, 20);
                DBAdapter.SelectCommand.Parameters["bicno"].Value = textBox1.Text.Trim();

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DBAdapter.SelectCommand = new OracleCommand("select B.bicno, B.status, D.area from bicycle B, depository D where B.depno = D.depno and status =:status", conn);
                DBAdapter.SelectCommand.Parameters.Add("status", OracleDbType.Varchar2, 20);
                DBAdapter.SelectCommand.Parameters["status"].Value = textBox1.Text.Trim();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                DBAdapter.SelectCommand = new OracleCommand("select B.bicno, B.status, D.area from bicycle B, depository D where B.depno = D.depno and area =:status ", conn);
                DBAdapter.SelectCommand.Parameters.Add("status", OracleDbType.Varchar2, 20);
                DBAdapter.SelectCommand.Parameters["status"].Value = textBox1.Text.Trim();
            }
            else
            {
                DBAdapter.SelectCommand = new OracleCommand("select B.bicno, B.status, D.area from bicycle B, depository D where B.depno = D.depno", conn);

            }
            DBAdapter.Fill(DS, "RelTable");
            DataTable RelTable = DS.Tables["RelTable"];
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
