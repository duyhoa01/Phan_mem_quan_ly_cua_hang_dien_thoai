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
            flowLayoutPanel1.Controls.Add(new User_Control.KhuyenMaii());
            lbSoLuong.Text = (Convert.ToInt32(lbSoLuong.Text) + 1).ToString();
        }
    }
}
