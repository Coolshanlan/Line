using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Line
{
    public partial class Sign_In : Form
    {
        public Sign_In()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = Sqlcalss.ToDatatable("select * from [User] where Account = N'" + textBox1.Text + "' And Password = N'" + textBox2.Text + "'");
            if (dt.Rows.Count ==1)
            {
                this.Hide();
                Sqlcalss.ToDatatable("Update [User] set Last_Sign_In = N'"+System.DateTime.Now+"' where Account = '"+textBox1.Text+"'");
                (new Line_Chat(dt)).ShowDialog();
                this.Show();
            }
            else
            {
                message_txt_location("Account or Password is incorrect");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Message_lb.Text = "";
        }
        void message_txt_location(string Message)
        {
            Message_lb.Text = Message;
            Message_lb.Location = new Point(140-Message_lb.Size.Width/2,203);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            (new Register()).ShowDialog();
            ((Label)(sender)).ForeColor = Color.Gray;
            ((Label)(sender)).ForeColor = Color.FromArgb(255, ((Label)(sender)).ForeColor.R -30, ((Label)(sender)).ForeColor.G -30, ((Label)(sender)).ForeColor.B -30);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I can not help you because you are so stupid ,sorry.");
            ((Label)(sender)).ForeColor = Color.Gray;
            ((Label)(sender)).ForeColor = Color.FromArgb(255, ((Label)(sender)).ForeColor.R-30, ((Label)(sender)).ForeColor.G -30, ((Label)(sender)).ForeColor.B -30);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1.PerformClick();
        }
    }
}
