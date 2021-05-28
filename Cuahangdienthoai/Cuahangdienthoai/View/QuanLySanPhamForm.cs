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
    public partial class QuanLySanPhamForm : Form
    {
        public QuanLySanPhamForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            ShowListPhone();
            SetGUI();
        }
        private void SetGUI()
        {
            dataGridViewsanpham.Columns[0].Width = 180;
            dataGridViewsanpham.Columns[0].HeaderText = "";
            dataGridViewsanpham.Columns[1].HeaderText = "Mã Điện Thoại";
            dataGridViewsanpham.Columns[2].HeaderText = "Tên Điện Thoại";
            dataGridViewsanpham.Columns[3].HeaderText = "Số Lượng";
            dataGridViewsanpham.Columns[4].HeaderText = "Giá Gốc";
            dataGridViewsanpham.Columns[4].DefaultCellStyle.Format = "0,0 đ";
            dataGridViewsanpham.Columns[5].HeaderText = "% Giảm Giá";
            dataGridViewsanpham.Columns[5].DefaultCellStyle.Format = "0.## '%'";
            dataGridViewsanpham.Columns[6].HeaderText = "Giảm Còn";
            dataGridViewsanpham.Columns[6].DefaultCellStyle.Format = "0,0 đ";
            dataGridViewsanpham.Columns[7].HeaderText = "Điểm Đánh Giá";
            dataGridViewsanpham.Columns[8].Visible = false;
        }
        public void ShowListPhone()
        {
            dataGridViewsanpham.DataSource = DienThoaiBUS.Instance.GetListDT(tbTimKiem.Text, comboBox1.Text);
            lbSoLuong.Text = dataGridViewsanpham.Rows.Count.ToString();
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            ThemSuaDienThoai f = new ThemSuaDienThoai(null);
            f.ShowDialog();
            ShowListPhone();
        }

        private void btTimKiêm_Click(object sender, EventArgs e)
        {
            ShowListPhone();
        }

        private void dataGridViewsanpham_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dataGridViewsanpham.SelectedRows.Count == 1)
            {
                string MaDT = dataGridViewsanpham.SelectedRows[0].Cells["MaDT"].Value.ToString();
                ThongTinDienThoai f = new ThongTinDienThoai(Convert.ToInt32(MaDT));
                f.Show();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewsanpham.SelectedRows.Count; i++)
            {
                string MaDT = dataGridViewsanpham.SelectedRows[i].Cells["MaDT"].Value.ToString();
                if (!DienThoaiBUS.Instance.XoaDT(Convert.ToInt32(MaDT)))
                {
                    MessageBox.Show("Điện thoại mã " + MaDT + " không thể xóa được vì liên quan đến dữ liệu mua bán");
                }
            }
            ShowListPhone();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string MaDT = dataGridViewsanpham.SelectedRows[0].Cells["MaDT"].Value.ToString();
            ThemSuaDienThoai f = new ThemSuaDienThoai(Convert.ToInt32(MaDT));
            f.ShowDialog();
            ShowListPhone();
        }

        private void QuanLySanPhamForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                ShowListPhone();
            }
        }
    }
}
