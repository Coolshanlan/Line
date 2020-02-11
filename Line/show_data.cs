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
    public partial class show_data : Form
    {
        public show_data()
        {
            InitializeComponent();
        }

        private void show_data_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DataSource = Sqlcalss.ToDatatable("select [User].ID , [User].User_Name,[User].Join_Date , [User].Last_Sign_In from [User]");
            dataGridView2.DataSource = Sqlcalss.ToDatatable("select * from [Group]");
        }
    }
}
