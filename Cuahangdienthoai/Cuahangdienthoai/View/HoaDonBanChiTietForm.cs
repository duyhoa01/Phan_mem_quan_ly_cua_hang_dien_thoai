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
using Cuahangdienthoai.DTO;

namespace Cuahangdienthoai.View
{
    public partial class HoaDonBanChiTietForm : Form
    {
        private int maHD;
        private double TongTien = 0;
        private double TongGiamSP = 0;
        private double TongGiamKM = 0;
        private double TongGiaNhap = 0;
        private double ThanhTien = 0;
        private double LoiNhuan = 0;
        public HoaDonBanChiTietForm(int MaHD)
        {
            InitializeComponent();
            maHD = MaHD;
            SetGUI();
            dataGridViewGioHang.DataSource = DonHangBUS.Instance.GetListHDBCTByMaHD(MaHD);
            TinhTien();
            dataGridViewKhuyenMai.DataSource = KhuyenMaiBUS.Instance.GetListKMApDungByMaHD(MaHD, TongTien);
            SetHienThiDataGridView();
            TinhTongGiamKM();
            ThanhTien = TongTien - TongGiamSP - TongGiamKM;
            LoiNhuan = ThanhTien - TongGiaNhap;
            HienThiKQ();
        }
        private void SetGUI()
        {
            HoaDonBanViewFormHDBCT hd = DonHangBUS.Instance.HDBH(maHD);
            tbTenDonHang.Text += maHD.ToString();
            lbTenNV.Text = hd.TenNV;
            lbMaKH.Text = hd.MaKH.ToString();
            lbTenKH.Text = hd.TenKH;
            lbNgayBan.Text = hd.NgayBan.ToString("dd/MM/yyyy H:mm");
            lbMaNV.Text = hd.MaNV.ToString();
        }
        private void TinhTien()
        {
            foreach (DataGridViewRow item in dataGridViewGioHang.Rows)
            {
                TongTien += (float)Convert.ToDouble(item.Cells["TongTien"].Value);
                TongGiamSP += (float)Convert.ToDouble(item.Cells["TongGiam"].Value);
                TongGiaNhap += (float)Convert.ToDouble(item.Cells["TongGiaNhap"].Value);
            }
        }
        private void TinhTongGiamKM()
        {
            foreach (DataGridViewRow item in dataGridViewKhuyenMai.Rows)
            {
                TongGiamKM += (float)Convert.ToDouble(item.Cells["Apdung"].Value);
            }
        }
        private void HienThiKQ()
        {
            tbTongTien.Text = String.Format("{0:#,0 đ}", TongTien);
            tbTongGiamSP.Text = String.Format("{0:#,0 đ}", TongGiamSP);
            tbTongGiamKM.Text = String.Format("{0:#,0 đ}", TongGiamKM);
            tbThanhTien.Text = String.Format("{0:#,0 đ}", ThanhTien);
            tbTongTienNhap.Text = String.Format("{0:#,0 đ}", TongGiaNhap);
            tbLoiNhuan.Text = String.Format("{0:#,0 đ}", LoiNhuan);
        }
        private void SetHienThiDataGridView()
        {
            //gio hang
            dataGridViewGioHang.Columns[0].HeaderText = "";
            dataGridViewGioHang.Columns[1].HeaderText = "Mã ĐT";
            dataGridViewGioHang.Columns[2].HeaderText = "Tên ĐT";
            dataGridViewGioHang.Columns[3].HeaderText = "Giá Bán";
            dataGridViewGioHang.Columns[4].HeaderText = "% Giảm Giá";
            dataGridViewGioHang.Columns[5].HeaderText = "Giảm Còn";
            dataGridViewGioHang.Columns[6].HeaderText = "Giá Nhập";
            dataGridViewGioHang.Columns[7].HeaderText = "Số Lượng";
            dataGridViewGioHang.Columns[8].HeaderText = "Tổng Tiền";
            dataGridViewGioHang.Columns[9].HeaderText = "Tổng Giảm";
            dataGridViewGioHang.Columns[10].HeaderText = "Thành Tiền";
            dataGridViewGioHang.Columns[11].HeaderText = "Tổng Nhập";
            dataGridViewGioHang.Columns[0].Width = 80;
            dataGridViewGioHang.Columns[3].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewGioHang.Columns[4].DefaultCellStyle.Format = "0.## '%'";
            dataGridViewGioHang.Columns[5].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewGioHang.Columns[6].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewGioHang.Columns[8].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewGioHang.Columns[9].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewGioHang.Columns[10].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewGioHang.Columns[11].DefaultCellStyle.Format = "#,0 đ";
            //khuyenmai
            dataGridViewKhuyenMai.Columns[1].HeaderText = "Tên KM";
            dataGridViewKhuyenMai.Columns[2].HeaderText = "Hóa Đơn Từ";
            dataGridViewKhuyenMai.Columns[3].HeaderText = "% Giảm Giá";
            dataGridViewKhuyenMai.Columns[4].HeaderText = "Tối Đa";
            dataGridViewKhuyenMai.Columns[5].HeaderText = "Được Giảm";
            dataGridViewKhuyenMai.Columns[2].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewKhuyenMai.Columns[3].DefaultCellStyle.Format = "0.##'%'";
            dataGridViewKhuyenMai.Columns[4].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewKhuyenMai.Columns[5].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewKhuyenMai.Columns[0].Visible = false;
            dataGridViewKhuyenMai.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9, FontStyle.Bold);
            dataGridViewKhuyenMai.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void HoaDonBanChiTietForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState.ToString().Equals("Maximized")) 
            {
                dataGridViewGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                pnTinhTien.Location = new Point(pnTinhTien.Location.X + 280, pnTinhTien.Location.Y);
            } 
            else if (this.WindowState.ToString().Equals("Normal")) 
            {
                dataGridViewGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridViewGioHang.Columns[0].Width = 80;
                pnTinhTien.Location = new Point(260, 20);
            }
        }
    }
}
