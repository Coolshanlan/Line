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
    public partial class test_show : Form
    {
        public test_show()
        {
            InitializeComponent();
        }

        private void test_show_Load(object sender, EventArgs e)
        {
            DataTable dt = Sqlcalss.ToDatatable("select * from [Group]");
            dt.Namespace = "Grouop";
            dt.TableName = "Group"; 
        }

        private void groupBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {   
            this.Validate();

        }
    }
}
