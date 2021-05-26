using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cuahangdienthoai.DTO;
using Cuahangdienthoai.BUS;

namespace Cuahangdienthoai.View
{
    public partial class ThemDonHangForm : Form
    {
        private List<DienThoaiViewFormBan> listGioHang = new List<DienThoaiViewFormBan>();
        public ThemDonHangForm()
        {
            InitializeComponent();
            tbCMND_Check.AppendText("CMND");
            dataGridViewGioHang.DataSource = listGioHang;
            LoadListPhone();
        }
        private void LoadListPhone()
        {
            flowLayoutPanel1.Controls.Clear();
            string path = MenuFor.path;
            foreach (DienThoaiViewFormSP item in DienThoaiBUS.Instance.GetListDT(tbTimKiem.Text, null))
            {
                User_Control.DienThoai dt = new User_Control.DienThoai();
                dt.MaSP = item.MaDT;
                dt.TenDT = item.TenDT;
                dt.SL = item.SoLuong;
                dt.Gia = item.GiaBan;
                dt.LinkAnh = path + item.LinkAnh;
                dt.xemThongTin += DienThoai_DoubleClick;
                flowLayoutPanel1.Controls.Add(dt);
            }
        }
        private void DienThoai_DoubleClick(object sender, EventArgs e)
        {
            User_Control.DienThoai dt = sender as User_Control.DienThoai;
            MuaBanDienThoai f = new MuaBanDienThoai(dt.MaSP);
            f.Them += ThemVaoGioHang;
            f.ShowDialog();
        }
        private void btKtraKH_Click(object sender, EventArgs e)
        {
            
        }

        private void rdbKHMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKHMoi.Checked == false)
            {
                pnKHCu.Show();
                pnThongTinKH.Enabled = false;
            }
            else
            {
                pnKHCu.Hide();
                pnThongTinKH.Enabled = true;
            }
        }

        private void btThemSP_Click(object sender, EventArgs e)
        {
            ThemSuaDienThoai f = new ThemSuaDienThoai(null);
            f.ShowDialog();
            LoadListPhone();
        }
        public void ThemVaoGioHang(int MaDT, int SoLuong)
        {
            listGioHang.Add(DienThoaiBUS.Instance.DTGioHang(MaDT, SoLuong));
            List<DienThoaiViewFormBan> l = new List<DienThoaiViewFormBan>();
            l.AddRange(listGioHang);
            dataGridViewGioHang.DataSource = l;
        }

        private void dataGridViewGioHang_DataSourceChanged(object sender, EventArgs e)
        {
            MessageBox.Show("da them");
        }
    }
}
