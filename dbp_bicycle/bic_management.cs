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
            string ConStr = "User Id=chani; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
            OracleConnection myConnection = new OracleConnection(ConStr);
            //string commandString = "select * from bicycle";
            string commandString = "select B.bicno, B.status, D.area from bicycle B, depository D where B.depno = D.depno";
            OracleCommand myCommand = new OracleCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = commandString;
            myConnection.Open(); //
            OracleDataReader MR;
            MR = myCommand.ExecuteReader();
            while (MR.Read())
            {
                ListViewItem item = new ListViewItem(MR[0].ToString());
                item.SubItems.Add(MR[1].ToString());
                item.SubItems.Add(MR[2].ToString());
                listView1.Items.Add(item);
            }
            MR.Close();
            myConnection.Close();

        }
    }
}
