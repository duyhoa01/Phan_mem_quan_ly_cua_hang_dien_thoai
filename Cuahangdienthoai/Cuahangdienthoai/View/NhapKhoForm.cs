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
    public partial class NhapKhoForm : Form
    {
        public NhapKhoForm()
        {
            InitializeComponent();
            SetGUI();
        }
        private void SetGUI()
        {
            lich1.BackColor = this.TransparencyKey;
            lich2.BackColor = this.TransparencyKey;
            lich1.BringToFront();
            lich2.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new HoaDonNhapForm();
            f.Show();
        }
        private void ChonThoiGian(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.FromArgb(255, 128, 0);
            bt.ForeColor = Color.White;
        }
        private void ShowTime(object sender, EventArgs e)
        {
            MessageBox.Show(lich1.GetDateTime().ToString());
        }
    }
}
