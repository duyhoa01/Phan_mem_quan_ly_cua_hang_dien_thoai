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
    public partial class QuanLyKhuyenMaiForm : Form
    {
        public QuanLyKhuyenMaiForm()
        {
            InitializeComponent();
        }

        private void btThemKM_Click(object sender, EventArgs e)
        {
            User_Control.KhuyenMaii km = new User_Control.KhuyenMaii();
            km.xoaKM += this.XoaKhuyenMai;
            flowLayoutPanel1.Controls.Add(km);
            lbSoLuong.Text = (Convert.ToInt32(lbSoLuong.Text) + 1).ToString();
        }
        public void XoaKhuyenMai(Object sender, EventArgs e)
        {
            User_Control.KhuyenMaii km = sender as User_Control.KhuyenMaii;
            km.Dispose();
            lbSoLuong.Text = (Convert.ToInt32(lbSoLuong.Text) - 1).ToString();
        }
    }
}
