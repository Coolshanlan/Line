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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        string User_Id, Account, Password,Confirm_Password;
        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)if(c.Tag!=null)if(c.Text.Trim() == "")
                    {
                        Message_txt_Location("Blank information is not allowed");
                        return;
                    }
            User_Id = textBox1.Text;
            Account = textBox2.Text;
            Password = textBox3.Text;
            Confirm_Password = textBox4.Text;
            if(Sqlcalss.ToDatatable("select * from [User] where User_Name = N'"+User_Id+"'").Rows.Count == 0)
            {
                if(Sqlcalss.ToDatatable("select * from [User] where Account = N'" + Account + "'").Rows.Count == 0)
                {
                    if (Password == Confirm_Password)
                    {
                        try
                        {
                            Sqlcalss.ToDatatable("Insert into [User] (User_Name,Account,Password,Join_Date) Values(N'" + User_Id + "',N'" + Account + "',N'" + Password + "',N'" + System.DateTime.Now + "')  ");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        MessageBox.Show("註冊成功！");
                        this.Close();
                    }
                    else
                    {
                        Message_txt_Location("The password is inconsistent");
                    }
                }
                else
                {
                    Message_txt_Location("Account has been repeated");
                }
            }
            else
            {
                Message_txt_Location("User_ID has been repeated");
            }
        }
        void Message_txt_Location(string message)
        {
            Message_lb.Text = message;
            Message_lb.Location = new Point(142-(Message_lb.Size.Width/2),339);
        }
    }
}
