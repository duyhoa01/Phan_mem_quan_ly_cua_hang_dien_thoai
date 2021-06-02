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
    public partial class DienThoai : UserControl
    {
        public delegate void XemThongTin(object sender, EventArgs e);
        public event XemThongTin xemThongTin;
        public DienThoai()
        {
            InitializeComponent();
            this.Focus();
        }
        public int MaSP { get => Convert.ToInt32(lbMaSP.Text); set => lbMaSP.Text = value.ToString(); }
        public string Gia { get => lbGia.Text; set => lbGia.Text = value; }
        public string Gia2 { get => lbGia2.Text; set => lbGia2.Text = value; }
        public string TenDT { get => tbTenDT.Text; set => tbTenDT.Text = value; }
        public string LinkAnh { set => pictureBox1.Image = new Bitmap(value); }
        public int SL { get => Convert.ToInt32(lbSL.Text); set => lbSL.Text = value.ToString(); }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            tbTenDT.BackColor = Color.White;
            panel1.BackColor = Color.White;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(208, 239, 242);
            tbTenDT.BackColor = Color.FromArgb(208, 239, 242);
            panel1.BackColor = Color.FromArgb(208, 239, 242);
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            this.xemThongTin(this, EventArgs.Empty);
        }
        public void SetFontGia()
        {
            lbGia.Font = new Font(label1.Font, FontStyle.Bold);
            lbGia.ForeColor = Color.Red;
        }
    }
}
