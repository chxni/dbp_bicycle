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
            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****
        }
        private OracleConnection odpConn = new OracleConnection();
        DBClass dbc = new DBClass();
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            String connectionString = "User Id=eeezi; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
            OracleConnection myConnection = new OracleConnection(connectionString);
            string commandString = "select memno, name, birth, gender, phone from member";
            try
            {
                OracleDataAdapter DBAdapter = new OracleDataAdapter();
                
                DBAdapter.SelectCommand = new OracleCommand("select * from member", myConnection);
                
                DataSet DS = new DataSet();
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
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }

            /*
            OracleCommand myCommand = new OracleCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = commandString;
            myConnection.Open(); //
            OracleDataReader MR;
            MR = myCommand.ExecuteReader();
            OracleDataReader Mt;
            Mt = myCommand.ExecuteReader();

            while (Mt.Read())
            {
                ListViewItem item = new ListViewItem(Mt[0].ToString());
                item.SubItems.Add(Mt[1].ToString());
                item.SubItems.Add(Mt[2].ToString());
                item.SubItems.Add(Mt[3].ToString());
                item.SubItems.Add(Mt[4].ToString());

                listView2.Items.Add(item);
            }
            MR.Close();
            while (MR.Read())
            {
                ListViewItem item = new ListViewItem(MR[0].ToString());
                item.SubItems.Add(MR[1].ToString());
                listView1.Items.Add(item);
            }
            MR.Close();
            myConnection.Close();
            */
        }

    }
}
