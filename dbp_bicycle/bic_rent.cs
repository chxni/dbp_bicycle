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
    public partial class bic_rent : Form
    {
        public bic_rent()
        {
            InitializeComponent();
        }
        private OracleConnection odpConn = new OracleConnection();
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("대여하시겠습니까?", "확인");
            {
                if (btnOK.Text == "확인")
                    if (INSERTRow() > 0)
                    {
                        MessageBox.Show("정상적으로 데이터가 업데이트됨!");
                    }
                    else MessageBox.Show("데이터 행이 업데이트되지 않음!");
                this.Close();
            }
        }
        private int INSERTRow() //사용자 함수 정의
            {
            odpConn.ConnectionString = "User Id=chani; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
            odpConn.Open();
            string strqry = "INSERT INTO rental VALUES (:memno, :bicno, :depnp, :rentaldate)";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            DateTime nowdate = DateTime.Now;

            OraCmd.Parameters.Add("memno", OracleDbType.Int32).Value = textBox2.Text.Trim();
            OraCmd.Parameters.Add("bicno", OracleDbType.Int32).Value = textBox1.Text.Trim();
            OraCmd.Parameters.Add("depno", OracleDbType.Int32).Value = textBox3.Text.Trim();
            OraCmd.Parameters.Add("rentaldate", OracleDbType.Varchar2, 40).Value = nowdate;
            return OraCmd.ExecuteNonQuery(); //추가되는 행수 반환
            }
        }
    }

