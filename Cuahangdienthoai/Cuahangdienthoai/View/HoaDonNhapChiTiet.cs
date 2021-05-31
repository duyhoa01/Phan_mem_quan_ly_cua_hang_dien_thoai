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
    public partial class HoaDonNhapChiTiet : Form
    {
        public HoaDonNhapChiTiet(int MaHD, int MaNV, int MaNCC, string TenNV, string TenNCC, DateTime NgayNhap, double TongTienNhap)
        {
            InitializeComponent();
            tbTTHD.Text += MaHD.ToString();
            lbMaNV.Text = MaNV.ToString();
            lbMaNCC.Text = MaNCC.ToString();
            lbTenNV.Text = TenNV;
            lbTenNCC.Text = TenNCC;
            lbNgayNhap.Text = NgayNhap.ToString("dd/MM/yyyy H:mm");
            lbTongTienNhap.Text = String.Format("{0:0,0 vnd}", TongTienNhap);
            dataGridViewGioHang.DataSource = NhapHangBUS.Instance.GetListHDNCTByMaHD(MaHD);
            SetDatagridview();
        }
        private void SetDatagridview()
        {
            dataGridViewGioHang.Columns[0].HeaderText = "";
            dataGridViewGioHang.Columns[1].HeaderText = "Mã ĐT";
            dataGridViewGioHang.Columns[2].HeaderText = "Tên ĐT";
            dataGridViewGioHang.Columns[3].HeaderText = "Đơn Giá";
            dataGridViewGioHang.Columns[4].HeaderText = "Số Lượng";
            dataGridViewGioHang.Columns[5].HeaderText = "Thành Tiền";
            dataGridViewGioHang.Columns[3].DefaultCellStyle.Format = "0,0 đ";
            dataGridViewGioHang.Columns[5].DefaultCellStyle.Format = "0,0 đ";
        }
    }
}
