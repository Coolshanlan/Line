namespace Line
{
    partial class Add_Form
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
            this.User_lb = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Group_lb = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // User_lb
            // 
            this.User_lb.AutoSize = true;
            this.User_lb.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_lb.Location = new System.Drawing.Point(12, 49);
            this.User_lb.Name = "User_lb";
            this.User_lb.Size = new System.Drawing.Size(106, 19);
            this.User_lb.TabIndex = 1;
            this.User_lb.Text = "User_Name：";
            this.User_lb.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // Group_lb
            // 
            this.Group_lb.AutoSize = true;
            this.Group_lb.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Group_lb.Location = new System.Drawing.Point(12, 49);
            this.Group_lb.Name = "Group_lb";
            this.Group_lb.Size = new System.Drawing.Size(118, 19);
            this.Group_lb.TabIndex = 3;
            this.Group_lb.Text = "Group_Name：";
            this.Group_lb.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Add_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(212, 112);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Group_lb);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.User_lb);
            this.Name = "Add_Form";
            this.Text = "Add_Form";
            this.Load += new System.EventHandler(this.Add_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label User_lb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Group_lb;
        private System.Windows.Forms.Button button1;
    }
}