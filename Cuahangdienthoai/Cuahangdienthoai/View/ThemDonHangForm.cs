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
        private double TongTien = 0;
        private double TongGiamSP = 0;
        private double TongGiamKM = 0;
        private double ThanhTien = 0;
        private double TongLoiNhuan;
        private double TongTienNhap;
        public ThemDonHangForm()
        {
            InitializeComponent();
            tbCMND_Check.AppendText("CMND");
            dataGridViewGioHang.DataSource = listGioHang;
            SetGUI();
            LoadListPhone();
        }
        private void LoadListPhone()
        {
            int SL = 0;
            flowLayoutPanel1.Controls.Clear();
            string path = MenuFor.path;
            foreach (DienThoaiViewFormSP item in DienThoaiBUS.Instance.GetListDT(tbTimKiem.Text, null, null))
            {
                SL++;
                User_Control.DienThoai dt = new User_Control.DienThoai();
                dt.MaSP = item.MaDT;
                dt.TenDT = item.TenDT;
                dt.SL = item.SoLuong;
                dt.Gia = String.Format("{0:#,0'đ'}", item.GiaGoc);
                dt.Gia2 = String.Format("{0:#,0'đ'}", item.GiamCon);
                dt.LinkAnh = path + item.LinkAnh;
                dt.xemThongTin += DienThoai_DoubleClick;
                flowLayoutPanel1.Controls.Add(dt);
            }
            lbSoLuong.Text = SL.ToString();
        }
        private void DienThoai_DoubleClick(object sender, EventArgs e)
        {
            dataGridViewGioHang.Focus();
            User_Control.DienThoai dt = sender as User_Control.DienThoai;
            foreach (DienThoaiViewFormBan item in listGioHang)
            {
                if (item.MaDT == dt.MaSP)
                {
                    MuaBanDienThoai form = new MuaBanDienThoai(dt.MaSP, item.SoLuong);
                    form.Them += ThemVaoGioHang;
                    form.ShowBtXoa();
                    form.ShowDialog();
                    return;
                }
            }
            MuaBanDienThoai f = new MuaBanDienThoai(dt.MaSP, 1);
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
                pnKHCu.Location = new Point(rdbKHCu.Location.X + 65, rdbKHCu.Location.Y - 20);
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
            bool Thaydoi = false;
            DienThoaiViewFormBan dt = DienThoaiBUS.Instance.DTGioHang(MaDT, SoLuong);
            bool ChuaCo = true;
            int index = 0;
            foreach (DienThoaiViewFormBan item in listGioHang)
            {
                index++;
                if (dt.MaDT == item.MaDT)
                {
                    ChuaCo = false;
                    TinhTien(dt.MaDT, (SoLuong - item.SoLuong));
                    listGioHang.RemoveAt(index - 1);
                    listGioHang.Insert(index - 1, dt);
                    if (SoLuong == 0)
                    {
                        listGioHang.Remove(dt);
                    }
                    Thaydoi = true;
                    break;
                }
            }
            if (ChuaCo && (SoLuong > 0))
            {
                listGioHang.Add(dt);
                TinhTien(dt.MaDT, SoLuong);
                Thaydoi = true;
            }
            if (Thaydoi)
            {
                var l = new BindingList<DienThoaiViewFormBan>(listGioHang);
                dataGridViewGioHang.DataSource = l;
            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            LoadListPhone();
        }
        private void TinhTien(int MaDT, int ChenhLechSL)
        {
            DienThoai dt = DienThoaiBUS.Instance.TimDTByMaDT(MaDT);
            TongTien += (float)(dt.GiaBanDT) * ChenhLechSL;
            TongGiamSP += ((float)(dt.GiaBanDT *(dt.C_GiamGia)/100)) * ChenhLechSL;
            TongTienNhap += (float)(dt.GiaNhapDT) * ChenhLechSL;
        }

        private void dataGridViewGioHang_DataSourceChanged(object sender, EventArgs e)
        {
            this.TongGiamKM = 0;
            dataGridViewKhuyenMai.DataSource = KhuyenMaiBUS.Instance.GetListKMApDung(TongTien - TongGiamSP);
            foreach (DataGridViewRow item in dataGridViewKhuyenMai.Rows)
            {
                TongGiamKM += (float)item.Cells[5].Value;
            }
            tbTongGiamKM.Text = String.Format("{0:#,0}", TongGiamKM);
            ThanhTien = TongTien - TongGiamKM - TongGiamSP;
            TongLoiNhuan = ThanhTien - TongTienNhap;
            tbTongTien.Text = String.Format("{0:#,0}", TongTien);
            tbTongGiamSP.Text = String.Format("{0:#,0}", TongGiamSP);
            tbThanhToan.Text = String.Format("{0:#,0} đ", ThanhTien);
            tbThanhTien.Text = String.Format("{0:#,0}", ThanhTien);
        }

        private void dataGridViewGioHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridViewGioHang.SelectedRows.Count == 1)
            {
                int MaDT = (int)dataGridViewGioHang.SelectedRows[0].Cells["MaDT"].Value;
                int SL = (int)dataGridViewGioHang.SelectedRows[0].Cells["SoLuong"].Value;
                MuaBanDienThoai f = new MuaBanDienThoai(MaDT, SL);
                f.ShowBtXoa();
                f.Them += ThemVaoGioHang;
                f.ShowDialog();
            }
        }
        private void SetGUI()
        {
            dataGridViewGioHang.Columns[0].HeaderText = "";
            dataGridViewGioHang.Columns[1].HeaderText = "Mã Điện Thoại";
            dataGridViewGioHang.Columns[2].HeaderText = "Tên Điện Thoại";
            dataGridViewGioHang.Columns[3].HeaderText = "Giá Gốc";
            dataGridViewGioHang.Columns[4].HeaderText = "% Giảm Giá";
            dataGridViewGioHang.Columns[5].HeaderText = "Giảm Còn";
            dataGridViewGioHang.Columns[6].HeaderText = "Số Lượng";
            dataGridViewGioHang.Columns[7].HeaderText = "Tổng";
            dataGridViewGioHang.Columns[8].HeaderText = "Giảm";
            dataGridViewGioHang.Columns[9].HeaderText = "Thành Tiền";
            dataGridViewGioHang.Columns[3].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewGioHang.Columns[4].DefaultCellStyle.Format = "0.## '%'";
            dataGridViewGioHang.Columns[5].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewGioHang.Columns[7].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewGioHang.Columns[8].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewGioHang.Columns[9].DefaultCellStyle.Format = "#,0 đ";
            //
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

        private void btHuyDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TaoHoaDon()
        {
            DonHangBUS.Instance.ThemDonHang(1, 17, DateTime.Now, ThanhTien, TongLoiNhuan);
        }
        private void ThemKHMoi()
        {

        }
        private void ThemKhuyenMaiApDungHD(int MaHD)
        {
            foreach (DataGridViewRow item in dataGridViewKhuyenMai.Rows)
            {
                KhuyenMaiBUS.Instance.ThemKhuyenMaiApDungHD(MaHD, Convert.ToInt32(item.Cells["MaKM"].Value));
            }
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            if(rdbKHMoi.Checked == true)
            {
                ThemKHMoi();
            }
            TaoHoaDon();
            int MaHD = DonHangBUS.Instance.GetLastHD();
            ThemKhuyenMaiApDungHD(MaHD);
            foreach (DienThoaiViewFormBan item in listGioHang)
            {
                DonHangBUS.Instance.ThemHoaDonChiTiet(MaHD, item.MaDT, item.SoLuong);
                DienThoaiBUS.Instance.XuLyBanDT(item.MaDT, item.SoLuong);
            }
            this.Close();
        }
    }
}
