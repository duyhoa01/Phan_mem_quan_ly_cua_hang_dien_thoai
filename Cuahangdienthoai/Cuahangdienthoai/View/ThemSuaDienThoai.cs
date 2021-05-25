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
        public ThemSuaDienThoai()
        {
            InitializeComponent();
        }

        private void btChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            string path = Directory.GetParent((Directory.GetParent(Application.StartupPath)).FullName).FullName;
            path = Directory.GetParent(path).FullName + @"\AnhDT";
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
            DienThoaiBUS.Instance.ThemDT(tbTenDT.Text, (float)Convert.ToDouble(tbGiaNhap.Text)
                , (float)Convert.ToDouble(tbGiaBan.Text), (float)Convert.ToDouble(numericUpDown1.Text)
                , (float)Convert.ToDouble(tbDiemDanhGia.Text), Convert.ToInt32(tbLuotDanhGia.Text)
                , richTextBox1.Text, pictureBox1.Tag.ToString());
            this.Close();
        }
    }
}
