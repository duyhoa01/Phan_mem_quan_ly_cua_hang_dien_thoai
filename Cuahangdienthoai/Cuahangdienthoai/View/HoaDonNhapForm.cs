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
        private Account accLogin;
        private double ThanhToan = 0;
        private List<DienThoaiFormMua> listGioHang = new List<DienThoaiFormMua>();
        public HoaDonNhapForm(Account acc)
        {
            InitializeComponent();
            this.accLogin = acc;
            tbMaNhanVien.Text = acc.MaNhanVien.ToString();
            TbTenNV.Text = TaiKhoanBUS.Instance.GetNhanVien(acc).TenNhanVien;
            lich1.BackColor = this.TransparencyKey;
            pnNhaCungCap.Location = new Point(0, 210);
            dataGridViewGioHang.DataSource = listGioHang;
            SetGUI();
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
            dataGridViewGioHang.Focus();
            User_Control.DienThoai dt = sender as User_Control.DienThoai;
            foreach (DienThoaiFormMua item in listGioHang)
            {
                if (item.MaDT == dt.MaSP)
                {
                    MuaBanDienThoai form = new MuaBanDienThoai(dt.MaSP, item.SoLuong);
                    form.Ban = false;
                    form.Them += ThemVaoGioHang;
                    form.ShowBtXoa();
                    form.ShowDialog();
                    return;
                }
            }
            MuaBanDienThoai f = new MuaBanDienThoai(dt.MaSP, 1);
            f.Ban = false;
            f.Them += ThemVaoGioHang;
            f.ShowDialog();
        }
        private void LoadListPhone()
        {
            int SL = 0;
            flowLayoutPanel1.Controls.Clear();
            string path = MenuFor.path;
            foreach (DienThoaiViewFormKhoHang item in DienThoaiBUS.Instance.GetListDTFormKhoHang(tbTimKiem.Text, null, null))
            {
                SL++;
                User_Control.DienThoai dt = new User_Control.DienThoai();
                dt.SetFontGia();
                dt.MaSP = item.MaDT;
                dt.TenDT = item.TenDT;
                dt.SL = item.SoLuong;
                dt.Gia = String.Format("{0:          #,0 đ}", item.GiaNhap);
                dt.Gia2 = "";
                dt.LinkAnh = path + item.LinkAnh;
                dt.xemThongTin += DienThoai_DoubleClick;
                flowLayoutPanel1.Controls.Add(dt);
            }
            lbSoLuong.Text = SL.ToString();
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
            DienThoaiFormMua dt = DienThoaiBUS.Instance.GetDTMua(MaDT, SoLuong);
            bool ChuaCo = true;
            int index = 0;
            foreach (DienThoaiFormMua item in listGioHang)
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
                var l = new BindingList<DienThoaiFormMua>(listGioHang);
                dataGridViewGioHang.DataSource = l;
            }
        }

        private void dataGridViewGioHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewGioHang.SelectedRows.Count == 1)
            {
                int MaDT = (int)dataGridViewGioHang.SelectedRows[0].Cells["MaDT"].Value;
                int SL = (int)dataGridViewGioHang.SelectedRows[0].Cells["SoLuong"].Value;
                MuaBanDienThoai f = new MuaBanDienThoai(MaDT, SL);
                f.Ban = false;
                f.ShowBtXoa();
                f.Them += ThemVaoGioHang;
                f.ShowDialog();
            }
        }
        private void TinhTien(int MaDT, int ChenhLechSL)
        {
            DienThoai dt = DienThoaiBUS.Instance.TimDTByMaDT(MaDT);
            ThanhToan += (float)(dt.GiaNhapDT) * ChenhLechSL;
            tbTongTien.Text = String.Format("{0:#,0 đ}", ThanhToan);
        }
        private void SetGUI()
        {
            dataGridViewGioHang.Columns[0].HeaderText = "";
            dataGridViewGioHang.Columns[1].HeaderText = "Mã Điện Thoại";
            dataGridViewGioHang.Columns[2].HeaderText = "Tên Điện Thoại";
            dataGridViewGioHang.Columns[3].HeaderText = "Đơn Giá";
            dataGridViewGioHang.Columns[4].HeaderText = "Số Lượng";
            dataGridViewGioHang.Columns[5].HeaderText = "Thành Tiền";
            dataGridViewGioHang.Columns[3].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewGioHang.Columns[5].DefaultCellStyle.Format = "#,0 đ";
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            LoadListPhone();
        }

        private void btHuyDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TaoHoaDon()
        {
            DateTime NgayNhap = new DateTime(lich1.GetDateTime().Year, lich1.GetDateTime().Month, lich1.GetDateTime().Day
                                                , DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            NhapHangBUS.Instance.ThemNhapHang(Convert.ToInt32(tbMaNhanVien.Text), 1, NgayNhap, ThanhToan);
        }
        private void ThemNCCMoi()
        {

        }
        private void btThanhToan_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                ThemNCCMoi();
            }
            TaoHoaDon();
            int MaHD = NhapHangBUS.Instance.GetLastHD();
            foreach (DienThoaiFormMua item in listGioHang)
            {
                NhapHangBUS.Instance.ThemHoaDonNhapChiTiet(MaHD, item.MaDT, item.SoLuong, item.GiaNhap, item.ThanhTien);
                DienThoaiBUS.Instance.XuLyNhapDT(item.MaDT, item.SoLuong);
            }
            this.Close();
        }
    }
}
