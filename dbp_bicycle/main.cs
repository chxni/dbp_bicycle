using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbp_bicycle
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rent_return_info form2 = new rent_return_info();
            form2.ShowDialog();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            bic_management form3 = new bic_management();
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            user_info form4 = new user_info();
            form4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dipository_info form5 = new dipository_info();
            form5.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sign_up form6 = new sign_up();
            form6.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bic_rent form7 = new bic_rent();
            form7.ShowDialog();
        }
    }
}
