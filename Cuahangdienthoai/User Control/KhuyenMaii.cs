using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Control
{
    public partial class KhuyenMaii : UserControl
    {
        public KhuyenMaii()
        {
            InitializeComponent();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            pbSave.Hide();
            panel1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pbSave.Show();
        }

        private void lich1_SizeChanged(object sender, EventArgs e)
        {
            Lich lich = sender as Lich;
            if (!lich.ShowCalendar) textBox1_TextChanged(tbKhuyenMai, EventArgs.Empty);
        }
    }
}
