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
    public partial class sign_up : Form
    {
        public sign_up()
        {
            InitializeComponent();
        }
        private OracleConnection odpConn = new OracleConnection();

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("회원가입 하시겠습니까?", "확인");
            {
                if (button1.Text == "회원가입")
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
            string strqry = "INSERT INTO member VALUES (:memno, :name, :birth, :gender, :phone)";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
            OraCmd.Parameters.Add("memno", OracleDbType.Int32).Value = txtid.Text.Trim();
            OraCmd.Parameters.Add("name", OracleDbType.Varchar2, 20).Value = txtname.Text.Trim();
            OraCmd.Parameters.Add("birth", OracleDbType.Varchar2, 20).Value = txtbirth.Text.Trim();
            OraCmd.Parameters.Add("gender", OracleDbType.Varchar2, 10).Value = txtgender.Text.Trim();
            OraCmd.Parameters.Add("phone", OracleDbType.Varchar2, 20).Value = txtphone.Text.Trim();
            return OraCmd.ExecuteNonQuery(); //추가되는 행수 반환
        }
    }
}
