using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cuahangdienthoai.BUS;

namespace Cuahangdienthoai.View
{
    public partial class QuanLyDonHangForm : Form
    {
        public QuanLyDonHangForm()
        {
            InitializeComponent();
            SetGUI();
            ShowListDonHang();           
        }
        private void ShowListDonHang()
        {
            dataGridViewDonHang.DataSource = DonHangBUS.Instance.GetListDonHang(tbTimKiem.Text, lich1.GetDateTime(), lich2.GetDateTime());
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
            ThemDonHangForm themDonHangForm = new ThemDonHangForm();
            themDonHangForm.Show();
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            ShowListDonHang();
        }
    }
}
