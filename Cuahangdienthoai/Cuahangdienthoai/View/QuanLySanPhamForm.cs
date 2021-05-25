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
            ShowListPhone();
        }
        public void ShowListPhone()
        {
            dataGridViewsanpham.DataSource = DienThoaiBUS.Instance.GetListDT(tbTimKiem.Text);
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            ThemSuaDienThoai f = new ThemSuaDienThoai();
            f.Show();
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
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string MaDT = dataGridViewsanpham.SelectedRows[0].Cells["MaDT"].Value.ToString();
            //ThemSuaDienThoai f = new ThemSuaDienThoai(Convert.ToInt32(MaDT));
            //f.Show();
        }

        private void btSapXep_Click(object sender, EventArgs e)
        {
            PBL3Entities db = new PBL3Entities();
            dataGridViewsanpham.DataSource = db.HoaDonBanHangs.Select(p => p).ToList();
        }
    }
}
