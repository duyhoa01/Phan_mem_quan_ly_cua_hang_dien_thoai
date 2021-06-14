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
    public partial class ThongTinDienThoai : Form
    {
        private int maDT;
        public delegate void Mydel();
        public Mydel d;
        public ThongTinDienThoai(int MaDT)
        {
            InitializeComponent();
            maDT = MaDT;
            SetGUI();
        }
        private void SetGUI()
        {
            DienThoai dt = DienThoaiBUS.Instance.TimDTByMaDT(maDT);
            tbTenDT.Text = dt.TenDienThoai;
            tbMaDT.Text = dt.MaDT.ToString();
            tbSoLuong.Text = dt.SLHienTai.ToString();
            tbPtGiamGia.Text = String.Format("{0:0.## '%'}", dt.C_GiamGia);
            tbDonGia.Text = String.Format("{0:#,0 đ}", dt.GiaBanDT);
            tbDiemDanhGia.Text = ((float)Convert.ToDouble(dt.DiemDanhGia)).ToString() + " / 5";
            tbLuotDanhGia.Text = dt.LuotDanhGia.ToString();
            richTextBox1.Text = dt.ThongSoKyThuat;
            pictureBox1.Tag = dt.Anh;
            string path = MenuFor.path + dt.Anh;
            pictureBox1.Image = new Bitmap(path);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (!DienThoaiBUS.Instance.XoaDT(maDT))
                {
                    MessageBox.Show("Điện thoại này không thể xóa vì liên quan hóa đơn nhập bán trước đó", "Lỗi");
                }
                else
                {
                    d();
                    this.Close();
                }
            }
        }
        public void LoadListPhone()
        {
            d();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemSuaDienThoai f = new ThemSuaDienThoai(maDT);
            this.Hide();
            f.d += LoadListPhone;
            f.ShowDialog();
            SetGUI();
            this.Show();
        }
    }
}
