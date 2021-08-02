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
    public partial class ThemSuaTaiKhoanForm : Form
    {
        private Account acc;
        public delegate void MyDel();
        public MyDel d;
        public ThemSuaTaiKhoanForm(Account Acc)
        {
            InitializeComponent();
            this.acc = Acc;
            SetGUI();
            if(cbbTenNV.Items.Count > 0) cbbTenNV.SelectedIndex = 0;
        }
        private void SetGUI()
        {
            if(acc == null)
            {
                lbTenForm.Text = "Thêm Tài Khoản";
                cbbTenNV.DataSource = TaiKhoanBUS.Instance.GetListNVKhongAcc();
                cbbTenNV.DisplayMember = "TenNhanVien";
                tbMaNV.DataBindings.Add("Text", cbbTenNV.DataSource, "MaNhanVien");
            }
            else
            {
                lbTenForm.Text = "Sửa Tài Khoản";
                cbbLoaiTK.SelectedItem = acc.LoaiTK;
                tbTenDangNhap.Text = acc.TenDangNhap;
                tbMaNV.Text = acc.MaNhanVien.ToString();
                tbEmail.Text = acc.EmailKhoiPhuc;
                cbbTenNV.Items.Add(TaiKhoanBUS.Instance.GetNhanVien(acc).TenNhanVien);
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if(!KtraDuLieu())
            {
                MessageBox.Show("Mời Nhập Đầy Đủ Thông Tin!", "Lỗi");
            }
            else
            {
                Account newAcc = GetAccNew();
                if (acc == null)
                {
                    newAcc.TenHienThi = cbbTenNV.Text;
                    newAcc.MatKhau = "123";
                    TaiKhoanBUS.Instance.ThemAcc(newAcc);
                    newAcc.ID = TaiKhoanBUS.Instance.GetMaIDMoi();
                    TaiKhoanBUS.Instance.ThemPhanQuyenLienKet(newAcc);
                    MessageBox.Show("Tạo tài khoản mới thành công!\nMật khẩu mặc định là ''123''", "Thành công");
                }
                else
                {
                    newAcc.ID = acc.ID;
                    TaiKhoanBUS.Instance.SuaAcc(newAcc);
                    if (newAcc.LoaiTK != acc.LoaiTK) TaiKhoanBUS.Instance.ThemPhanQuyenLienKet(newAcc);
                }
                d();
                this.Close();
            }
        }
        private Account GetAccNew()
        {
            return new Account
            {
                MaNhanVien = Convert.ToInt32(tbMaNV.Text),
                TenDangNhap = tbTenDangNhap.Text,
                LoaiTK = cbbLoaiTK.Text,
                EmailKhoiPhuc = tbEmail.Text,
            };
        }
        private bool KtraDuLieu()
        {
            if (cbbTenNV.SelectedItem == null || tbTenDangNhap.Text == "" || tbEmail.Text == ""
                || cbbLoaiTK.SelectedItem == null) return false;
            return true;
        }
    }
}
