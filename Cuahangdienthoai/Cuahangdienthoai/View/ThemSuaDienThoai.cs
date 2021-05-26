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
    public partial class ThemSuaDienThoai : Form
    {
        int? maDT;
        public ThemSuaDienThoai(int? MaDT)
        {
            InitializeComponent();
            maDT = MaDT;
            SetGui();
        }
        private void SetGui()
        {
            if (maDT != null)
            {
                DienThoai dt = DienThoaiBUS.Instance.TimDTByMaDT(Convert.ToInt32(maDT));
                tbTenDT.Text = dt.TenDienThoai;
                tbMaDT.Text = dt.MaDT.ToString();
                tbGiaNhap.Text = dt.GiaNhapDT.ToString();
                tbGiaBan.Text = dt.GiaBanDT.ToString();
                tbDiemDanhGia.Text = ((float)Convert.ToDouble(dt.DiemDanhGia)).ToString();
                tbLuotDanhGia.Text = dt.LuotDanhGia.ToString();
                numericUpDown1.Value = Convert.ToDecimal(dt.C_GiamGia);
                pictureBox1.Tag = dt.Anh;
                richTextBox1.Text = dt.ThongSoKyThuat;
                string path = MenuFor.path + dt.Anh;
                pictureBox1.Image = new Bitmap(path);
                tbMaDT.Enabled = false;
                tbGiaNhap.Enabled = false;
                tbGiaBan.Enabled = false;
            }
            else
            {
                label2.Hide();
                panel2.Hide();
                panel16.Location = new Point(0, 418);
            }
        }
        private void btChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            string path = MenuFor.path;
            f.InitialDirectory = path;
            f.Filter = "ALL|*.*|JPG Files|*.jpg|PNG Files|*.png";
            DialogResult r = f.ShowDialog();
            if (r == DialogResult.OK)
            {
                pictureBox1.Tag = Path.GetFileName(f.FileName);
                pictureBox1.Image = new Bitmap(f.FileName);
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(maDT == null)
            {
                DienThoaiBUS.Instance.ThemDT(tbTenDT.Text, (float)Convert.ToDouble(tbGiaNhap.Text)
                , (float)Convert.ToDouble(tbGiaBan.Text), (float)Convert.ToDouble(numericUpDown1.Value)
                , (float)Convert.ToDouble(tbDiemDanhGia.Text), Convert.ToInt32(tbLuotDanhGia.Text)
                , richTextBox1.Text, pictureBox1.Tag.ToString());
                this.Close();
            }
            else
            {
                DienThoaiBUS.Instance.SuaDT(Convert.ToInt32(tbMaDT.Text), tbTenDT.Text
                    , (float)Convert.ToDouble(numericUpDown1.Value), (float)Convert.ToDouble(tbDiemDanhGia.Text)
                    , Convert.ToInt32(tbLuotDanhGia.Text), richTextBox1.Text, pictureBox1.Tag.ToString());
                this.Close();
            }
        }
    }
}
