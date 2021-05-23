using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuahangdienthoai.View
{
    public partial class QuanLyNhanVienForm : Form
    {
        public QuanLyNhanVienForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThongtinNV f2 = new ThongtinNV(null, "add");
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btTimKiêm_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThongtinNV f2 = new ThongtinNV(null, "add");
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
