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
    public partial class QuanLyTaiKhoanForm : Form
    {
        public QuanLyTaiKhoanForm()
        {
            InitializeComponent();
            LoadListAcc();
            SetGUI();
        }
        public void LoadListAcc()
        {
            dataGridViewAcc.DataSource = TaiKhoanBUS.Instance.GetListAcc(tbTimKiem.Text);
        }

        private void btTimKiêm_Click(object sender, EventArgs e)
        {
            LoadListAcc();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ThemSuaTaiKhoanForm f = new ThemSuaTaiKhoanForm(null);
            f.d = LoadListAcc;
            f.ShowDialog();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if(dataGridViewAcc.SelectedRows.Count == 1)
            {
                Account acc = new Account();
                acc.ID = Convert.ToInt32(dataGridViewAcc.SelectedRows[0].Cells["ID"].Value);
                acc.MaNhanVien = Convert.ToInt32(dataGridViewAcc.SelectedRows[0].Cells["MaNhanVien"].Value);
                acc.TenDangNhap = dataGridViewAcc.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();
                acc.LoaiTK = dataGridViewAcc.SelectedRows[0].Cells["LoaiTK"].Value.ToString();
                acc.EmailKhoiPhuc = dataGridViewAcc.SelectedRows[0].Cells["EmailKhoiPhuc"].Value.ToString();
                ThemSuaTaiKhoanForm f = new ThemSuaTaiKhoanForm(acc);
                f.d = LoadListAcc;
                f.ShowDialog();
            }
        }
        private void SetGUI()
        {
            dataGridViewAcc.Columns["ID"].Visible = false;
            dataGridViewAcc.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dataGridViewAcc.Columns["TenDangNhap"].HeaderText = "Tên Đăng Nhập";
            dataGridViewAcc.Columns["LoaiTK"].HeaderText = "Loại Tài Khoản";
            dataGridViewAcc.Columns["EmailKhoiPhuc"].HeaderText = "Email khôi phục";
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridViewAcc.SelectedRows)
            {
                TaiKhoanBUS.Instance.XoaAcc(Convert.ToInt32(item.Cells["ID"].Value));
            }
            LoadListAcc();
        }
    }
}
