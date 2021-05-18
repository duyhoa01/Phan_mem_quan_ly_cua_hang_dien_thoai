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
        public DienThoai()
        {
            InitializeComponent();
            this.Focus();
        }
        public string MaSP { get => (lbMaSP.Text); set => lbMaSP.Text = value; }
        public string Gia { get => lbGia.Text; set => lbGia.Text = value; }
        public string TenDT { get => tbTenDT.Text; set => tbTenDT.Text = value; }
        public string LinkAnh { set => pictureBox1.Image = new Bitmap(value); }
        public int SL { get => Convert.ToInt32(lbSL.Text); set => lbSL.Text = value.ToString(); }
    }
}
