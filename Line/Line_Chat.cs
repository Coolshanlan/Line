using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Line
{
    public partial class Line_Chat : Form
    {
        DataTable User_Data;
        DataSet Chat_db = new DataSet();
        DataTable Friend = new DataTable();
        DataTable Group = new DataTable();
        DataTable Friend_N = new DataTable();
        DataTable Group_N = new DataTable();
        public Line_Chat(DataTable data)
        {
            User_Data = data;
            InitializeComponent();
        }

        void Update_left()
        {
            while (true)
            {
                Thread.Sleep(971);
                try
                {
                    Group_N = Sqlcalss.Search_Group(User_Data.Rows[0]["ID"].ToString());
                    Friend_N = Sqlcalss.Search_Friend(User_Data.Rows[0]["ID"].ToString());

                }
                catch
                {

                }
               }
        }
        private void Line_Chat_Load(object sender, EventArgs e)
        {

            
            CheckForIllegalCrossThreadCalls = false;
            User_Name_lb.Text = "User_Name： "+User_Data.Rows[0]["User_Name"].ToString();
            User_Name_lb.Location = new Point(this.Size.Width/2-User_Name_lb.Size.Width/2,8);

            DataTable ddt = Sqlcalss.ToDatatable("select * from [User]");
            // foreach (DataRow dr in ddt.Rows) All_user.Add(dr);
            Thread t1 = new Thread(Update_left);
            t1.IsBackground = true;
            t1.Start();
            Group = Sqlcalss.Search_Group(User_Data.Rows[0]["ID"].ToString());
            Friend = Sqlcalss.Search_Friend(User_Data.Rows[0]["ID"].ToString());
            foreach (DataRow dr in Friend.Rows)
            {
                Friend_ListBox.Items.Add(dr[0].ToString());
            }
            foreach (DataRow dr in Group.Rows)
            {
                listBox2.Items.Add(dr[0].ToString());
            }
            timer2.Enabled = true;
        }
        void Friend_Update()
        {
           if(Friend_N.Rows.Count != Friend.Rows.Count)
            {
                Friend_ListBox.Items.Clear();
                Friend = Friend_N;
                foreach (DataRow dr in Friend.Rows)
                {
                    Friend_ListBox.Items.Add(dr[0].ToString());
                }
            }
        }
        void Group_Update()
        {
            if(Group_N.Rows.Count != Group.Rows.Count)
            {
                listBox2.Items.Clear();
                Group = Group_N;
                foreach (DataRow dr in Group.Rows)
                {
                    listBox2.Items.Add(dr[0].ToString());
                }
            }
           
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
           
        }
        void Update_Chat_Data()
        {
  while (true)
            {
                string now_page = ChatTab.SelectedTab.Text;
                DataTable dt = Sqlcalss.ToDatatable("select * from Chat where Group_Id = (select [Group].Group_Id from[Group] where Group_Name = '" + now_page + "' and User_Id = '" + User_Data.Rows[0]["ID"] + "')");
                int now_data_count = Chat_db.Tables[now_page].Rows.Count;
                for(int i = now_data_count; i < dt.Rows.Count; i++)
                {
                    Chat_Update(ChatTab.SelectedTab, dt.Rows[i], i,0);
                }
            }
          
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            ListBox lbx = (ListBox)sender;
            string group_txt= "";
            bool have = false;
            try
            {
                 group_txt = lbx.SelectedItem.ToString();
            }
            catch
            {
                return;
            };
            if (FriendTab.SelectedTab.Text == "Friend")
                group_txt = "With_"+lbx.SelectedItem.ToString();
            else
            {
                group_txt = lbx.SelectedItem.ToString();
                ad_fg_bu.Visible = true;
            }
            foreach (TabPage tp in ChatTab.TabPages)
            {
                if (tp.Text == group_txt) have = true ;
            }
           // foreach()
            if (!have)
            {
                
                ChatTab.TabPages.Add(group_txt);
                ChatTab.TabPages[ChatTab.TabPages.Count - 1].Name = group_txt;
                ChatTab.TabPages[ChatTab.TabPages.Count - 1].AutoScroll = true;
                DataTable dt = Sqlcalss.ToDatatable("select * from Chat where Group_Id = (select [Group].Group_Id from [Group] where Group_Name = '" + group_txt + "' and User_Id = '" + User_Data.Rows[0]["ID"] + "')");
                dt.TableName = group_txt;
                Chat_db.Tables.Add(dt);
                for (int i = 0; i < Chat_db.Tables[group_txt].Rows.Count; i++)
                    Chat_Update(ChatTab.TabPages[group_txt], Chat_db.Tables[group_txt].Rows[i], i, 0);
                timer1.Enabled = true;
               }
            ChatTab.SelectedTab = ChatTab.TabPages[group_txt];
            ChatTab.TabPages[group_txt].VerticalScroll.Value = ChatTab.TabPages[group_txt].VerticalScroll.Maximum;
        }
        void Chat_Update(TabPage tp,DataRow a,int lb_index,int mistake)
        {
            tp.BackColor = Color.White;
            //List<Label> Chat_Data = new List<Label>();
            TextBox Chat_Data = new TextBox();
            Chat_Data.BorderStyle = BorderStyle.None;
            if (a["User_Id"].ToString() != User_Data.Rows[0]["ID"].ToString())
            {
                int hh = 0;
                Chat_Data.Font = User_Name_lb.Font;
                Chat_Data.Font = new Font("微軟正黑體", 9);
                string Name = Sqlcalss.ToDatatable("select User_Name from [User] Where ID ='"+a["User_Id"]+"'").Rows[0][0].ToString();
                Chat_Data.Text = Name+ "："+a["Date"];
                if (lb_index != 0)
                    Chat_Data.Location = new Point(3, Chat_Data.Location.Y + (Chat_Data.Size.Height + 35) * lb_index-mistake);
                else
                    Chat_Data.Location = new Point(3, 10);
                hh = Chat_Data.Height + Chat_Data.Location.Y;
                Chat_Data.Width = System.Text.Encoding.Default.GetBytes(Chat_Data.Text).Length * 10;
                tp.Controls.Add(Chat_Data);
                Chat_Data = new TextBox();
                Chat_Data.BorderStyle = BorderStyle.None;
                Chat_Data.Font = User_Name_lb.Font;
                lb_index++;
                Chat_Data.Text = a["Chat"].ToString();
                Chat_Data.Width = System.Text.Encoding.Default.GetBytes(Chat_Data.Text).Length * 10;
                Chat_Data.Location = new Point(3, Chat_Data.Location.Y + hh + Chat_Data.Size.Height-20);
                Chat_Data.TabIndex = 0;
                tp.Controls.Add(Chat_Data);
            }
            else
            {
                int hh = 0;
                Chat_Data.Font = User_Name_lb.Font;
                Chat_Data.Font = new Font("微軟正黑體",9);
                Chat_Data.Text = a["Date"]+"";
                Chat_Data.Width = System.Text.Encoding.Default.GetBytes(Chat_Data.Text).Length * 10;
                Chat_Data.TextAlign = HorizontalAlignment.Right;
                if (lb_index != 0)
                    Chat_Data.Location = new Point(tp.Size.Width - Chat_Data.Size.Width-20, Chat_Data.Location.Y + (Chat_Data.Size.Height + 35) * lb_index - mistake);
                else
                    Chat_Data.Location = new Point(tp.Size.Width - Chat_Data.Size.Width - 20, 10);
                hh = Chat_Data.Height + Chat_Data.Location.Y;
                tp.Controls.Add(Chat_Data);
                Chat_Data = new TextBox();
                Chat_Data.TextAlign = HorizontalAlignment.Right;
                Chat_Data.BorderStyle = BorderStyle.None;
                Chat_Data.Font = User_Name_lb.Font;
                lb_index++;
                Chat_Data.Text = a["Chat"].ToString();
                Chat_Data.Width = System.Text.Encoding.Default.GetBytes(Chat_Data.Text).Length * 10;
                Chat_Data.Location = new Point(tp.Size.Width - Chat_Data.Size.Width - 20, Chat_Data.Location.Y + hh + Chat_Data.Size.Height - 20);
                Chat_Data.TabIndex = 0;
                tp.Controls.Add(Chat_Data);
            }
        }
        private void Add_Bu_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() != "")
                    Sqlcalss.ToDatatable("Insert Into [Chat] (Group_Id,User_Id,Chat,Date) Values((select [Group].Group_Id from [Group] where Group_Name = '" + ChatTab.SelectedTab.Text + "' And User_Id ='" + User_Data.Rows[0]["ID"] + "' Group By [Group].Group_Id),'" + User_Data.Rows[0]["ID"] + "','" + textBox1.Text + "',N'" + DateTime.Now + "')");
                textBox1.Text = "";
            }
            catch
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ChatTab.TabPages.Count == 0) return;
            string now_page = ChatTab.SelectedTab.Text;
            DataTable dt = Sqlcalss.ToDatatable("select * from Chat where Group_Id = (select [Group].Group_Id from[Group] where Group_Name = '" + now_page + "' and User_Id = '" + User_Data.Rows[0]["ID"] + "')");
            int now_data_count = Chat_db.Tables[now_page].Rows.Count;
            for (int i = now_data_count; i < dt.Rows.Count; i++)
            {
                Chat_Update(ChatTab.SelectedTab, dt.Rows[i], 10,10);
                Chat_db.Tables[now_page].ImportRow(dt.Rows[i]);
                ChatTab.TabPages[now_page].VerticalScroll.Value = ChatTab.TabPages[now_page].VerticalScroll.Maximum;
            }


        }

        private void ad_f_bu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            Add_Form ad_f = new Add_Form("Friend",Friend,Group,User_Data);
            ad_f.ShowDialog();

            string group_txt;
            if (ad_f.done)
            {
                group_txt = "With_" + ad_f.txt;
                ChatTab.TabPages.Add(group_txt);
                ChatTab.TabPages[ChatTab.TabPages.Count - 1].Name = group_txt;
                ChatTab.TabPages[ChatTab.TabPages.Count - 1].AutoScroll = true;
                DataTable dt = Sqlcalss.ToDatatable("select * from Chat where Group_Id = (select [Group].Group_Id from [Group] where Group_Name = '" + group_txt + "' and User_Id = '" + User_Data.Rows[0]["ID"] + "')");
                dt.TableName = group_txt;
                Chat_db.Tables.Add(dt);
                for (int i = 0; i < Chat_db.Tables[group_txt].Rows.Count; i++)
                    Chat_Update(ChatTab.TabPages[group_txt], Chat_db.Tables[group_txt].Rows[i], i, 0);
                timer1.Enabled = true;
                ChatTab.SelectedTab = ChatTab.TabPages[group_txt];
                ChatTab.TabPages[group_txt].VerticalScroll.Value = ChatTab.TabPages[group_txt].VerticalScroll.Maximum;
                Friend_N = Sqlcalss.Search_Friend(User_Data.Rows[0]["ID"].ToString());
                Friend_Update();
            }
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void ad_g_bu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            Add_Form ad_g = new Add_Form("Group", Friend, Group, User_Data);
            ad_g.ShowDialog(); 
            if (ad_g.done)
            {
                string group_txt;
                group_txt = ad_g.txt;
                ChatTab.TabPages.Add(group_txt);
                ChatTab.TabPages[ChatTab.TabPages.Count - 1].Name = group_txt;
                ChatTab.TabPages[ChatTab.TabPages.Count - 1].AutoScroll = true;
                DataTable dt = Sqlcalss.ToDatatable("select * from Chat where Group_Id = (select [Group].Group_Id from [Group] where Group_Name = '" + group_txt + "' and User_Id = '" + User_Data.Rows[0]["ID"] + "')");
                dt.TableName = group_txt;
                Chat_db.Tables.Add(dt);
                for (int i = 0; i < Chat_db.Tables[group_txt].Rows.Count; i++)
                    Chat_Update(ChatTab.TabPages[group_txt], Chat_db.Tables[group_txt].Rows[i], i, 0);
                timer1.Enabled = true;
                ChatTab.SelectedTab = ChatTab.TabPages[group_txt];
                ChatTab.TabPages[group_txt].VerticalScroll.Value = ChatTab.TabPages[group_txt].VerticalScroll.Maximum;
                Group_N = Sqlcalss.Search_Group(User_Data.Rows[0]["ID"].ToString());
                Group_Update();
            }
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void ad_fg_bu_Click(object sender, EventArgs e)
        {
            Add_Form ad_g = new Add_Form("Add friend in Group", Friend, Group, User_Data,ChatTab.SelectedTab.Text);
            ad_g.ShowDialog();
            Group_Update();
            string group_txt;
            group_txt = ChatTab.SelectedTab.Text;
            timer1.Enabled = true;
            ChatTab.SelectedTab = ChatTab.TabPages[group_txt];
            ChatTab.TabPages[group_txt].VerticalScroll.Value = ChatTab.TabPages[group_txt].VerticalScroll.Maximum;
        }

        private void re_f_bu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            Add_Form ad_f = new Add_Form("Remove Friend", Friend, Group, User_Data);
            ad_f.ShowDialog();
            if (ad_f.done)
            {
                try
                {
                    Chat_db.Tables.Remove("With_" + ad_f.txt);
                    ChatTab.TabPages["With_" + ad_f.txt].Dispose();
                }
                catch
                {

                }
                Friend_N = Sqlcalss.Search_Friend(User_Data.Rows[0]["ID"].ToString());
                Friend_Update();
            }
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void re_g_bu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            Add_Form ad_f = new Add_Form("Remove Group", Friend, Group, User_Data);
            ad_f.ShowDialog();

            if (ad_f.done)
            {
                try
                {
                    Chat_db.Tables.Remove(ad_f.txt);
                    ChatTab.TabPages[ad_f.txt].Dispose();
                }
                catch
                {

                }
                Group_N = Sqlcalss.Search_Group(User_Data.Rows[0]["ID"].ToString());
                Group_Update();
            }
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Friend_Update();
            Group_Update();
        }

        private void Line_Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        private void ChatTab_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                foreach (DataRow dr in Group.Rows)
                {
                    if (dr["Group_Name"].ToString() == e.TabPage.Text)
                    {
                        ad_fg_bu.Visible = true;
                        return;
                    }
                }
                ad_fg_bu.Visible = false;
            }
            catch
            {

            }
        }

        private void ChatTab_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Chat_db.Tables.Remove(ChatTab.SelectedTab.Text);
                ChatTab.SelectedTab.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new show_data()).Show();
        }
    }
}
