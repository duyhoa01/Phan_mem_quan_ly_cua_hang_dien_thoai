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
    public partial class HoaDonNhapForm : Form
    {
        private List<DienThoaiViewFormBan> listGioHang = new List<DienThoaiViewFormBan>();
        public HoaDonNhapForm()
        {
            InitializeComponent();
            lich1.BackColor = this.TransparencyKey;
            pnNhaCungCap.Location = new Point(0, 210);
            dataGridViewDanhmucsanpham.DataSource = listGioHang;
            LoadListPhone();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pnNhaCungCap.Show();
                tbNCCMoi.Show();
                cbbNCC.Hide();
            }
            else
            {
                tbNCCMoi.Hide();
                cbbNCC.Show();
                pnNhaCungCap.Hide();
            }
        }
        private void DienThoai_DoubleClick(object sender, EventArgs e)
        {
            User_Control.DienThoai dt = sender as User_Control.DienThoai;
            foreach (DienThoaiViewFormBan item in listGioHang)
            {
                if(item.MaDT == dt.MaSP)
                {
                    MuaBanDienThoai form = new MuaBanDienThoai(dt.MaSP, item.SoLuong);
                    form.Them += ThemVaoGioHang;
                    form.ShowDialog();
                    return;
                }
            }
            MuaBanDienThoai f = new MuaBanDienThoai(dt.MaSP, 1);
            f.Them += ThemVaoGioHang;
            f.ShowDialog();
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
                dt.Gia = String.Format("{0:0,0 đ}", item.GiaGoc);
                dt.LinkAnh = path + item.LinkAnh;
                dt.xemThongTin += DienThoai_DoubleClick;
                flowLayoutPanel1.Controls.Add(dt);
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
            dataGridViewDanhmucsanpham.DataSource = listGioHang;
        }
    }
}
