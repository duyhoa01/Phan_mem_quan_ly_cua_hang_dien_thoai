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
            lbTongTien.Text = String.Format("{0:0,0 đ}", TongTien);
            lbTongLoiNhuan.Text = String.Format("{0:0,0 đ}", TongLoiNhuan);
        }
        private void SetGUI()
        {
            lich1.BackColor = this.TransparencyKey;
            lich2.BackColor = this.TransparencyKey;
            lich1.BringToFront();
            lich2.BringToFront();
        }
        private void SetDatagridview()
        {
            dataGridViewDonHang.Columns[0].HeaderText = "Mã Hóa Đơn";
            dataGridViewDonHang.Columns[1].HeaderText = "Ngày Bán";
            dataGridViewDonHang.Columns[2].HeaderText = "Nhân Viên Bán";
            dataGridViewDonHang.Columns[3].HeaderText = "Khách Hàng";
            dataGridViewDonHang.Columns[4].HeaderText = "Thanh Toán";
            dataGridViewDonHang.Columns[5].HeaderText = "Lợi Nhuận";
            dataGridViewDonHang.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy H:mm";
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
            if (this.Visible)
            {
                ShowListDonHang();
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

        private void dataGridViewDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
