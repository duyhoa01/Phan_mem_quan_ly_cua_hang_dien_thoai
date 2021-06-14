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
using System.Globalization;

namespace Cuahangdienthoai.View
{
    public partial class ThemSuaDienThoai : Form
    {
        public delegate void Mydel();
        public Mydel d;
        int? maDT;
        decimal GiaNhap = 0;
        decimal GiaBan = 0;
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
                GiaNhap = (decimal)dt.GiaNhapDT;
                GiaBan = (decimal)dt.GiaBanDT;
                tbGiaNhap.Text = dt.GiaNhapDT.ToString();
                tbGiaBan.Text = dt.GiaBanDT.ToString();
                tbDiemDanhGia.Text = ((float)Convert.ToDouble(dt.DiemDanhGia)).ToString();
                tbLuotDanhGia.Text = dt.LuotDanhGia.ToString();
                numericUpDown1.Value = Convert.ToDecimal(dt.C_GiamGia);
                pictureBox1.Tag = dt.Anh;
                richTextBox1.Text = dt.ThongSoKyThuat;
                string path = MenuFor.path + dt.Anh;
                pictureBox1.Image = new Bitmap(path);
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
                try
                {
                    pictureBox1.Tag = Path.GetFileName(f.FileName);
                    pictureBox1.Image = new Bitmap(f.FileName);
                }
                catch (Exception)
                {
                    pictureBox1.Tag = "Loi.png";
                    pictureBox1.Image = new Bitmap(MenuFor.path + "Loi.png");
                }

            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!KtraDuLieu())
            {
                MessageBox.Show("Mời nhập thông tin đầy đủ!");
            }
            else
            {
                try
                {
                    if (maDT == null)
                    {
                        DienThoaiBUS.Instance.ThemDT(tbTenDT.Text, (float)Convert.ToDouble(tbGiaNhap.Text)
                        , (float)Convert.ToDouble(tbGiaBan.Text), (float)Convert.ToDouble(numericUpDown1.Value)
                        , (float)Convert.ToDouble(tbDiemDanhGia.Text), Convert.ToInt32(tbLuotDanhGia.Text)
                        , richTextBox1.Text, pictureBox1.Tag.ToString());
                    }
                    else
                    {
                        if (!DienThoaiBUS.Instance.SuaDT(Convert.ToInt32(tbMaDT.Text), tbTenDT.Text
                            , (float)Convert.ToDouble(numericUpDown1.Value), (float)Convert.ToDouble(tbDiemDanhGia.Text)
                            , Convert.ToInt32(tbLuotDanhGia.Text), richTextBox1.Text, pictureBox1.Tag.ToString()
                            , (float)Convert.ToDouble(tbGiaBan.Text), (float)Convert.ToDouble(tbGiaNhap.Text)))
                        {
                            MessageBox.Show("Điện thoại này liên quan đến hóa đơn nhập bán trước."
                                            + "\nKhông thể thay đổi giá nhập, giá bán");
                        }
                    }
                    d();
                    this.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ\n" + e1.Message);
                }
            }
        }

        private void tbGiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (tbGiaNhap.Text.Equals(""))
            {
                GiaNhap = 0;
            }
            else
            {
                CultureInfo culture = new CultureInfo("en-US");
                decimal value = GiaNhap;
                try
                {
                    value = decimal.Parse(tbGiaNhap.Text, NumberStyles.AllowThousands);
                    GiaNhap = value;
                }
                catch (Exception)
                {
                    value = GiaNhap;
                }
                tbGiaNhap.Text = String.Format(culture, "{0:N0}", value);
                tbGiaNhap.Select(tbGiaNhap.Text.Length, 0);
            }
        }

        private void tbGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (tbGiaBan.Text.Equals(""))
            {
                GiaBan = 0;
            }
            else
            {
                CultureInfo culture = new CultureInfo("en-US");
                decimal value = GiaBan;
                try
                {
                    value = decimal.Parse(tbGiaBan.Text, NumberStyles.AllowThousands);
                    GiaBan = value;
                }
                catch (Exception)
                {
                    value = GiaBan;
                }
                tbGiaBan.Text = String.Format(culture, "{0:N0}", value);
                tbGiaBan.Select(tbGiaBan.Text.Length, 0);
            }
        }
        private bool KtraDuLieu()
        {
            if (tbTenDT.Text == "" || tbGiaNhap.Text == "" || tbGiaBan.Text == "" || pictureBox1.Tag == null 
                || tbDiemDanhGia.Text == "" || tbLuotDanhGia.Text == "") return false;
            return true;
        }
    }
}
