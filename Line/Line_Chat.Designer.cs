namespace Line
{
    partial class Line_Chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.User_Name_lb = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.ad_fg_bu = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FriendTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.re_f_bu = new System.Windows.Forms.Button();
            this.ad_f_bu = new System.Windows.Forms.Button();
            this.Friend_ListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.re_g_bu = new System.Windows.Forms.Button();
            this.ad_g_bu = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ChatTab = new System.Windows.Forms.TabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.FriendTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // User_Name_lb
            // 
            this.User_Name_lb.AutoSize = true;
            this.User_Name_lb.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.User_Name_lb.ForeColor = System.Drawing.Color.Black;
            this.User_Name_lb.Location = new System.Drawing.Point(348, 8);
            this.User_Name_lb.Name = "User_Name_lb";
            this.User_Name_lb.Size = new System.Drawing.Size(56, 21);
            this.User_Name_lb.TabIndex = 0;
            this.User_Name_lb.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.ad_fg_bu);
            this.panel1.Controls.Add(this.User_Name_lb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 36);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(-1, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "All the User";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ad_fg_bu
            // 
            this.ad_fg_bu.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ad_fg_bu.Location = new System.Drawing.Point(660, 1);
            this.ad_fg_bu.Name = "ad_fg_bu";
            this.ad_fg_bu.Size = new System.Drawing.Size(158, 33);
            this.ad_fg_bu.TabIndex = 1;
            this.ad_fg_bu.Text = "Add Frienf in Group";
            this.ad_fg_bu.UseVisualStyleBackColor = true;
            this.ad_fg_bu.Visible = false;
            this.ad_fg_bu.Click += new System.EventHandler(this.ad_fg_bu_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.FriendTab);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(298, 546);
            this.panel2.TabIndex = 2;
            // 
            // FriendTab
            // 
            this.FriendTab.Controls.Add(this.tabPage1);
            this.FriendTab.Controls.Add(this.tabPage2);
            this.FriendTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FriendTab.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FriendTab.ItemSize = new System.Drawing.Size(50, 25);
            this.FriendTab.Location = new System.Drawing.Point(0, 0);
            this.FriendTab.Name = "FriendTab";
            this.FriendTab.SelectedIndex = 0;
            this.FriendTab.Size = new System.Drawing.Size(296, 544);
            this.FriendTab.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.FriendTab.TabIndex = 4;
            this.FriendTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.re_f_bu);
            this.tabPage1.Controls.Add(this.ad_f_bu);
            this.tabPage1.Controls.Add(this.Friend_ListBox);
            this.tabPage1.Font = new System.Drawing.Font("Georgia", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(288, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Friend";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // re_f_bu
            // 
            this.re_f_bu.Dock = System.Windows.Forms.DockStyle.Right;
            this.re_f_bu.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.re_f_bu.Location = new System.Drawing.Point(139, 472);
            this.re_f_bu.Name = "re_f_bu";
            this.re_f_bu.Size = new System.Drawing.Size(146, 36);
            this.re_f_bu.TabIndex = 3;
            this.re_f_bu.Text = "Remove Friend";
            this.re_f_bu.UseVisualStyleBackColor = true;
            this.re_f_bu.Click += new System.EventHandler(this.re_f_bu_Click);
            // 
            // ad_f_bu
            // 
            this.ad_f_bu.Dock = System.Windows.Forms.DockStyle.Left;
            this.ad_f_bu.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ad_f_bu.Location = new System.Drawing.Point(3, 472);
            this.ad_f_bu.Name = "ad_f_bu";
            this.ad_f_bu.Size = new System.Drawing.Size(136, 36);
            this.ad_f_bu.TabIndex = 2;
            this.ad_f_bu.Text = "Add Friend";
            this.ad_f_bu.UseVisualStyleBackColor = true;
            this.ad_f_bu.Click += new System.EventHandler(this.ad_f_bu_Click);
            // 
            // Friend_ListBox
            // 
            this.Friend_ListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.Friend_ListBox.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Friend_ListBox.FormattingEnabled = true;
            this.Friend_ListBox.HorizontalScrollbar = true;
            this.Friend_ListBox.ItemHeight = 31;
            this.Friend_ListBox.Location = new System.Drawing.Point(3, 3);
            this.Friend_ListBox.Name = "Friend_ListBox";
            this.Friend_ListBox.Size = new System.Drawing.Size(282, 469);
            this.Friend_ListBox.TabIndex = 0;
            this.Friend_ListBox.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.re_g_bu);
            this.tabPage2.Controls.Add(this.ad_g_bu);
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(288, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Group";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // re_g_bu
            // 
            this.re_g_bu.Dock = System.Windows.Forms.DockStyle.Right;
            this.re_g_bu.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.re_g_bu.Location = new System.Drawing.Point(139, 472);
            this.re_g_bu.Name = "re_g_bu";
            this.re_g_bu.Size = new System.Drawing.Size(146, 36);
            this.re_g_bu.TabIndex = 5;
            this.re_g_bu.Text = "Remove Group";
            this.re_g_bu.UseVisualStyleBackColor = true;
            this.re_g_bu.Click += new System.EventHandler(this.re_g_bu_Click);
            // 
            // ad_g_bu
            // 
            this.ad_g_bu.Dock = System.Windows.Forms.DockStyle.Left;
            this.ad_g_bu.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ad_g_bu.Location = new System.Drawing.Point(3, 472);
            this.ad_g_bu.Name = "ad_g_bu";
            this.ad_g_bu.Size = new System.Drawing.Size(136, 36);
            this.ad_g_bu.TabIndex = 4;
            this.ad_g_bu.Text = "Add Group";
            this.ad_g_bu.UseVisualStyleBackColor = true;
            this.ad_g_bu.Click += new System.EventHandler(this.ad_g_bu_Click);
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox2.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.ItemHeight = 31;
            this.listBox2.Location = new System.Drawing.Point(3, 3);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(282, 469);
            this.listBox2.TabIndex = 1;
            this.listBox2.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.ChatTab);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(298, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(523, 546);
            this.panel3.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(418, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 31);
            this.button1.TabIndex = 7;
            this.button1.Text = "Send message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(0, 513);
            this.textBox1.MaxLength = 25;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(418, 29);
            this.textBox1.TabIndex = 6;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // ChatTab
            // 
            this.ChatTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChatTab.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ChatTab.ItemSize = new System.Drawing.Size(50, 25);
            this.ChatTab.Location = new System.Drawing.Point(0, 0);
            this.ChatTab.Name = "ChatTab";
            this.ChatTab.SelectedIndex = 0;
            this.ChatTab.Size = new System.Drawing.Size(521, 513);
            this.ChatTab.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.ChatTab.TabIndex = 5;
            this.ChatTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.ChatTab_Selected);
            this.ChatTab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChatTab_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Line_Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 582);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Line_Chat";
            this.Text = "Line_Chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Line_Chat_FormClosed);
            this.Load += new System.EventHandler(this.Line_Chat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.FriendTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label User_Name_lb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl FriendTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox Friend_ListBox;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TabControl ChatTab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button re_f_bu;
        private System.Windows.Forms.Button ad_f_bu;
        private System.Windows.Forms.Button re_g_bu;
        private System.Windows.Forms.Button ad_g_bu;
        private System.Windows.Forms.Button ad_fg_bu;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button2;
    }
}