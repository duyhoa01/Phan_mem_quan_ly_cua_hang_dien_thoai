using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cuahangdienthoai.BUS;

namespace Cuahangdienthoai.View
{
    public partial class ThongTinAcc : Form
    {
        public delegate void MyDel();
        public MyDel d;
        private Account accLogin;
        public ThongTinAcc(Account acc)
        {
            InitializeComponent();
            this.accLogin = acc;
            SetGUI();
        }
        private void SetGUI()
        {
            tbTenDangNhap.Text = accLogin.TenDangNhap;
            tbTenHienThi.Text = accLogin.TenHienThi;
            tbEmail.Text = accLogin.EmailKhoiPhuc;
            try
            {
                pictureBox1.Load("../../AnhAcc/" + accLogin.AnhAcc);
                pictureBox1.Tag = accLogin.AnhAcc;
            }
            catch (Exception)
            {

            }
            NhanVien nhanVien = TaiKhoanBUS.Instance.GetNhanVien(accLogin);
            tbTenNV.Text = nhanVien.TenNhanVien;
            lbMaNV.Text = nhanVien.MaNhanVien.ToString();
            lbGioiTinh.Text = ((bool)nhanVien.Nam) ? "Nam" : "Nữ";
            lbChucVu.Text = nhanVien.ChucVu;
            lbNgaySinh.Text = ((DateTime)nhanVien.NgaySinh).ToString("dd/MM/yyyy");
            lbCMND.Text = nhanVien.CMND;
            lbSDT.Text = nhanVien.DienThoai;
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            string path = Directory.GetParent(Directory.GetParent(MenuFor.path).FullName).FullName + @"\AnhAcc\";
            f.InitialDirectory = path;
            f.Filter = "ALL|*.*|JPG Files|*.jpg|PNG Files|*.png";
            DialogResult r = f.ShowDialog();
            if (r == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Tag = Path.GetFileName(f.FileName);
                    pictureBox1.Image = new Bitmap(f.FileName);
                }
                catch (Exception)
                {
                }

            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (KtraDoiMK())
            {
                Account accNew = GetNewAcc();
                if (tbMKHienTai.Text != "")
                {
                    DialogResult dr = MessageBox.Show("Xác nhận đổi mật khẩu?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No)
                    {
                        return;
                    }
                    accLogin.MatKhau = tbMKMoi.Text;
                }
                accLogin.TenHienThi = accNew.TenHienThi;
                accLogin.EmailKhoiPhuc = accNew.EmailKhoiPhuc;
                accLogin.AnhAcc = accNew.AnhAcc;
                TaiKhoanBUS.Instance.SuaAccByUser(accLogin);
                d();
                this.Close();
            }
        }
        private Account GetNewAcc()
        {
            return new Account
            {
                TenHienThi = tbTenHienThi.Text,
                EmailKhoiPhuc = tbEmail.Text,
                AnhAcc = (pictureBox1.Tag != null) ? pictureBox1.Tag.ToString() : null
            };
        }
        private bool KtraDoiMK()
        {
            if (tbMKMoi.Text == "" && tbMKHienTai.Text == "" && tbNhapLaiMK.Text == "") return true;
            if(tbMKHienTai.Text != accLogin.MatKhau)
            {
                MessageBox.Show("Mật khẩu không chính xác!", "Lỗi");
                return false;
            }
            if(tbMKMoi.Text != tbNhapLaiMK.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng khớp!", "Lỗi");
                return false;
            }
            if (tbMKMoi.Text != tbNhapLaiMK.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng khớp!", "Lỗi");
                return false;
            }
            if (tbMKMoi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới!", "Thông báo");
                return false;
            }
            return true;
        }
    }
}
