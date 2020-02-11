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
    public partial class Add_Form : Form
    {
        public string mode;
        public DataTable Friend;
        public DataTable Group;
        public DataTable user;
        public  string txt = "";
        public bool done = false;
        public string Group_Name = "";
        public Add_Form(string M, DataTable F, DataTable G, DataTable U)
        {
            InitializeComponent();
            mode = M;
            Friend = F;
            user = U;
            Group = G;
        }
        public Add_Form(string M, DataTable F, DataTable G, DataTable U, string GN)
        {
            InitializeComponent();
            mode = M;
            Friend = F;
            user = U;
            Group = G;
            Group_Name = GN;
        }

        private void Add_Form_Load(object sender, EventArgs e)
        {
            if (mode == "Friend")
            {
                this.Text= "Add Friend";
                User_lb.Visible = true;
            }
            else if (mode == "Group")
            {
                this.Text = "Add Group";
                Group_lb.Visible = true;
                if (Friend != null)
                {
                    int ch_count = 0;
                    for (int i = 0; i < Friend.Rows.Count; i++)
                    {
                        CheckBox ch = new CheckBox();
                        ch = new CheckBox();
                        ch.Font = new Font("微軟正黑體", 12);
                        ch.Text = Friend.Rows[i]["User_Name"].ToString();
                        ch.Tag = "ch";
                        ch.AutoSize = true;
                        ch.Location = new Point(textBox1.Location.X, textBox1.Location.Y + textBox1.Size.Height + ch_count++ * ch.Size.Height + 10);
                        this.Controls.Add(ch);
                    }
                }
            }
            else if(mode == "Add friend in Group")
            {
                this.Text = "Add friend in Group";
                textBox1.Text = Group_Name;
                textBox1.Enabled = false;
                User_lb.Visible = true;
                if (Friend != null)
                {
                    DataTable HF = Sqlcalss.ToDatatable("select User_Id from [Group] where Group_Name = '" + Group_Name + "' ");
                    int ch_count = 0;
                    for (int i = 0; i < Friend.Rows.Count; i++)
                    {
                        bool have = false;
                        foreach (DataRow drr in HF.Rows)
                        {
                            if (drr["User_Id"].ToString() == Friend.Rows[i]["ID"].ToString()) have = true;
                        }
                        if (have) continue;
                        CheckBox ch = new CheckBox();
                        ch = new CheckBox();
                        ch.Font = new Font("微軟正黑體", 12);
                        ch.Text = Friend.Rows[i]["User_Name"].ToString();
                        ch.Tag = "ch";
                        ch.AutoSize = true;
                        ch.Location = new Point(textBox1.Location.X, textBox1.Location.Y + textBox1.Size.Height + ch_count++ * ch.Size.Height + 10);
                        this.Controls.Add(ch);
                    }
                }
            }
            else if(mode == "Remove Friend")
            {
                User_lb.Visible = true;
                this.Text = "Remove Friend";
            }
            else if (mode == "Remove Group")
            {
                this.Text = "Remove Group";
                Group_lb.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt = textBox1.Text;
            if(textBox1.Text == user.Rows[0]["User_Name"].ToString())
            {
                MessageBox.Show("可以不要加自己嗎????????\r\n\r\n臭邊緣人");
                return;
            }
            if (mode == "Friend")
            {
                DataTable dt = Sqlcalss.ToDatatable("select * from [User] where User_Name = N'" + textBox1.Text + "'");
                if (dt.Rows.Count == 1)
                {
                    if (!check_Friend(textBox1.Text))
                    {
                        MessageBox.Show("好友已存在！");
                        return;
                    }
                    Random rd = new Random();

                    double group_count = rd.NextDouble();
                    Sqlcalss.ToDatatable("Insert Into [Group] (Group_Id,User_Id,Group_Name,Personal) Values('" + group_count + "','" + user.Rows[0]["ID"] + "','" + "With_" + dt.Rows[0]["User_Name"] + "','True')");
                    Sqlcalss.ToDatatable("Insert Into [Group] (Group_Id,User_Id,Group_Name,Personal) Values('" + group_count + "','" + dt.Rows[0]["ID"] + "','" + "With_" + user.Rows[0]["User_Name"] + "','True')");
                    Sqlcalss.ToDatatable("Insert Into [Chat] (Group_Id,User_Id,Chat,Date) Values('" + group_count + "','" + user.Rows[0]["ID"] + "','" + user.Rows[0]["User_Name"] + "已加入聊天室" + "','" + DateTime.Now + "')");
                    Sqlcalss.ToDatatable("Insert Into [Chat] (Group_Id,User_Id,Chat,Date) Values('" + group_count + "','" + dt.Rows[0]["ID"] + "','" + dt.Rows[0]["User_Name"] + "已加入聊天室" + "','" + DateTime.Now + "')");
                    done = true;
                    MessageBox.Show("好友已成功加入");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("查無此用戶！");
                    return;
                }
            }
            else if (mode == "Group")
            {
                DataTable dt = Sqlcalss.ToDatatable("select * from [Group] where Group_Name = N'" + textBox1.Text + "'");
                if (dt.Rows.Count == 0)
                {
                    Random rd = new Random();

                    double group_count = rd.NextDouble();
                    Sqlcalss.ToDatatable("Insert Into [Group] (Group_Id,User_Id,Group_Name,Personal) Values('" + group_count + "','" + user.Rows[0]["ID"] + "','" + textBox1.Text + "','False')");
                    Sqlcalss.ToDatatable("Insert Into [Chat] (Group_Id,User_Id,Chat,Date) Values('" + group_count + "','" + user.Rows[0]["ID"] + "','" + user.Rows[0]["User_Name"] + "已加入聊天室" + "','" + DateTime.Now + "')");

                    foreach (Control c in this.Controls)
                    {
                        if (c.Tag != null)
                        {
                            if (((CheckBox)c).Checked == true)
                            {
                                string ID = "";
                                foreach (DataRow dr in Friend.Rows)
                                {
                                    if (dr["User_Name"].ToString() == c.Text)
                                    {
                                        ID = dr["ID"].ToString();
                                        break;
                                    }
                                }
                                Sqlcalss.ToDatatable("Insert Into [Group] (Group_Id,User_Id,Group_Name,Personal) Values('" + group_count + "','" + ID + "','" + textBox1.Text + "','False')");
                                Sqlcalss.ToDatatable("Insert Into [Chat] (Group_Id,User_Id,Chat,Date) Values('" + group_count + "','" + ID + "','" + c.Text + "已加入聊天室" + "','" + DateTime.Now + "')");
                            }
                        }
                    }
                    done = true;
                    MessageBox.Show("群組已建立成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("群組已重複！");
                    return;
                }
            }
            else if(mode == "Add friend in Group")
            {
                string group_count = Sqlcalss.ToDatatable("select Group_Id from [Group] where Group_Name = '" + Group_Name + "'").Rows[0][0].ToString();
                foreach (Control c in this.Controls)
                {
                    if (c.Tag != null)
                    {
                        if (((CheckBox)c).Checked == true)
                        {
                            string ID = "";
                            foreach (DataRow dr in Friend.Rows)
                            {
                                if (dr["User_Name"].ToString() == c.Text)
                                {
                                    ID = dr["ID"].ToString();
                                    break;
                                }
                            }
                            Sqlcalss.ToDatatable("Insert Into [Group] (Group_Id,User_Id,Group_Name,Personal) Values('" + group_count + "','" + ID + "','" + textBox1.Text + "','False')");
                            Sqlcalss.ToDatatable("Insert Into [Chat] (Group_Id,User_Id,Chat,Date) Values('" + group_count + "','" + ID + "','" + c.Text + "已加入聊天室" + "','" + DateTime.Now + "')");
                        }
                    }
                }
                done = true;
                MessageBox.Show("成功加入好友");
                this.Close();
            }
            else if (mode == "Remove Friend")
            {
                DataTable dt = Sqlcalss.ToDatatable("select * from [User] where User_Name = N'" + textBox1.Text + "'");
                if (dt.Rows.Count == 1)
                {
                    if (!check_Friend(textBox1.Text))
                    {
                        string group_Id = Sqlcalss.ToDatatable("select Group_Id from [Group] where Group_Name = '"+"With_"+textBox1.Text+"'").Rows[0][0].ToString();
                        if (MessageBox.Show("確定刪除好友  " + textBox1.Text + "  嗎？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Sqlcalss.ToDatatable("Delete from [Group] where Group_Id = '" + group_Id + "'");
                            Sqlcalss.ToDatatable("Delete from [Chat] where Group_Id = '" + group_Id + "'");
                            done = true;
                            MessageBox.Show("好友已刪除成功");
                            this.Close();
                        }
                        else return;
                    }
                    else
                    {
                        MessageBox.Show("此用戶不為您好友！");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("查無此用戶！");
                    return;
                }
            }
            else if(mode == "Remove Group")
            {
                if (!check_Group(textBox1.Text))
                {
                    string group_Id =Sqlcalss.ToDatatable("select Group_Id from [Group] where Group_Name = '" + textBox1.Text + "'").Rows[0][0].ToString();
                    if (MessageBox.Show("確定退出群組  " + textBox1.Text + "  嗎？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Sqlcalss.ToDatatable("Delete from [Group] where Group_Id = '" + group_Id + "' and User_Id = '"+user.Rows[0]["ID"]+"'");
                        Sqlcalss.ToDatatable("Insert Into [Chat] (Group_Id,User_Id,Chat,Date) Values('" + group_Id + "','" + user.Rows[0]["ID"] + "','" + user.Rows[0]["User_Name"] + "已退出聊天室" + "','" + DateTime.Now + "')");
                        done = true;
                        MessageBox.Show("已退出群組");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("你不在此群組中");
                }
            }
        }
        bool check_Friend(string Name)
        {
            
            foreach(DataRow dr in Friend.Rows)
            {
                if (dr["User_Name"].ToString() == Name) return false;
            }
            return true;
        }
        bool check_Group(string Name)
        {

            foreach (DataRow dr in Group.Rows)
            {
                if (dr["Group_Name"].ToString() == Name) return false;
            }
            return true;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1.PerformClick();
        }
    }
}
