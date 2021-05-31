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
        private bool load = false;
        public QuanLyDonHangForm()
        {
            InitializeComponent();
            SetGUI();
            ShowListDonHang();
            SetDatagridview();
        }
        private void ShowListDonHang()
        { 
            dataGridViewDonHang.DataSource = DonHangBUS.Instance.GetListDonHang(tbTimKiem.Text, lich1.GetDateTime(), lich2.GetDateTime());
            AddLinkColumn();
            double TongTien = 0;
            double TongLoiNhuan = 0;
            foreach (DataGridViewRow item in dataGridViewDonHang.Rows)
            {
                TongTien += Convert.ToDouble(item.Cells["TongTien"].Value);
                TongLoiNhuan += Convert.ToDouble(item.Cells["TongLoiNhuan"].Value);
            }
            lbSoLuong.Text = dataGridViewDonHang.Rows.Count.ToString();
            lbTongTien.Text = String.Format("{0:0,0 vnd}", TongTien);
            lbTongLoiNhuan.Text = String.Format("{0:0,0 vnd}", TongLoiNhuan);
        }
        private void SetGUI()
        {
            lich1.BackColor = this.TransparencyKey;
            lich2.BackColor = this.TransparencyKey;
            lich1.BringToFront();
            lich2.BringToFront();
            btThongKe.BringToFront();
        }
        private void SetDatagridview()
        {
            dataGridViewDonHang.Columns[0].HeaderText = "Mã Hóa Đơn";
            dataGridViewDonHang.Columns[1].HeaderText = "Ngày Bán";
            dataGridViewDonHang.Columns[2].HeaderText = "Nhân Viên Bán";
            dataGridViewDonHang.Columns[3].HeaderText = "Khách Hàng";
            dataGridViewDonHang.Columns[4].HeaderText = "Thanh Toán";
            dataGridViewDonHang.Columns[5].HeaderText = "Lợi Nhuận";
            dataGridViewDonHang.Columns["Value"].DefaultCellStyle.Format = "dd/MM/yyyy H:mm";
            dataGridViewDonHang.Columns[4].DefaultCellStyle.Format = "0,0 đ";
            dataGridViewDonHang.Columns[5].DefaultCellStyle.Format = "0,0 đ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThemDonHangForm themDonHangForm = new ThemDonHangForm();
            themDonHangForm.ShowDialog();
            ShowListDonHang();
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            ShowListDonHang();
        }

        private void QuanLyDonHangForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                load = true;
            }
            else
            {
                if (load) ShowListDonHang();
                load = !load;
            }
        }
        private void AddLinkColumn()
        {
            DataGridViewLinkColumn dgvLink = new DataGridViewLinkColumn();
            dgvLink.UseColumnTextForLinkValue = true;
            dgvLink.LinkBehavior = LinkBehavior.SystemDefault;
            dgvLink.HeaderText = "";
            dgvLink.Name = "Xoa";
            dgvLink.LinkColor = Color.Blue;
            dgvLink.TrackVisitedState = true;
            dgvLink.Text = "Xóa";
            dgvLink.UseColumnTextForLinkValue = true;
            if (dataGridViewDonHang.Columns["Xoa"] == null)
            {
                dataGridViewDonHang.Columns.Add(dgvLink);
            }
        }

        private void dataGridViewDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = sender as DataGridViewCell;
            if (e.ColumnIndex == 0)
            {
                int MaHO = Convert.ToInt32(dataGridViewDonHang.SelectedRows[0].Cells["MaHoaDon"].Value);
                KhuyenMaiBUS.Instance.XoaKhuyenMaiApDungHD(MaHO);
                DonHangBUS.Instance.XoaHoaDonChiTiet(MaHO);
                DonHangBUS.Instance.XoaDonHang(MaHO);
                ShowListDonHang();
            }
        }

        private void dataGridViewDonHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int MaHD = Convert.ToInt32(dataGridViewDonHang.SelectedRows[0].Cells["MaHoaDon"].Value);
            HoaDonBanChiTietForm f = new HoaDonBanChiTietForm(MaHD);
            f.Show();
        }

        private void btTuan_Click(object sender, EventArgs e)
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    lich1.SetDateTime(DateTime.Now.Date.AddDays(-6));
                    break;
                case DayOfWeek.Monday:
                    lich1.SetDateTime(DateTime.Now.Date);
                    break;
                case DayOfWeek.Tuesday:
                    lich1.SetDateTime(DateTime.Now.Date.AddDays(-1));
                    break;
                case DayOfWeek.Wednesday:
                    lich1.SetDateTime(DateTime.Now.Date.AddDays(-2));
                    break;
                case DayOfWeek.Thursday:
                    lich1.SetDateTime(DateTime.Now.Date.AddDays(-3));
                    break;
                case DayOfWeek.Friday:
                    lich1.SetDateTime(DateTime.Now.Date.AddDays(-4));
                    break;
                case DayOfWeek.Saturday:
                    lich1.SetDateTime(DateTime.Now.Date.AddDays(-5));
                    break;
            }
            lich2.SetDateTime(lich1.GetDateTime().Date.AddDays(6));
            ShowListDonHang();
        }

        private void btThang_Click(object sender, EventArgs e)
        {
            DateTime dauthang = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            lich1.SetDateTime(dauthang);
            DateTime cuoithang = dauthang.AddMonths(1).AddDays(-1);
            lich2.SetDateTime(cuoithang);
            ShowListDonHang();
        }

        private void btQuy_Click(object sender, EventArgs e)
        {
            int quy = 0;
            if (DateTime.Now.Month % 3 == 0) quy = DateTime.Now.Month % 3 - 1;
            else quy = DateTime.Now.Month / 3;
            DateTime dauquy = new DateTime(DateTime.Now.Year, quy*3 + 1, 1);
            DateTime cuoiquy = dauquy.AddMonths(3).AddDays(-1);
            lich1.SetDateTime(dauquy);
            lich2.SetDateTime(cuoiquy);
            ShowListDonHang();
        }
    }
}
