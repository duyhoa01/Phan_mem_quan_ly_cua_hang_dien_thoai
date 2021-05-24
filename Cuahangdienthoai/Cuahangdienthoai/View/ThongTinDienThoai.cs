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
    public partial class ThongTinDienThoai : Form
    {
        private int maDT;
        public ThongTinDienThoai(int MaDT)
        {
            InitializeComponent();
            maDT = MaDT;
            SetGUI();
        }
        private void SetGUI()
        {
            DienThoai dt = DienThoaiBUS.Instance.TimDTByMaDT(maDT);
            lbTenDT.Text = dt.TenDienThoai;
            lbMaDT.Text = dt.MaDT.ToString();
            lbSL.Text = dt.SLHienTai.ToString();
            lbPtGiamGia.Text = dt.C_GiamGia.ToString() + "%";
            lbDonGia.Text = dt.GiaBanDT.ToString();
            lbDiemDanhGia.Text = dt.DiemDanhGia.ToString();
            lbLuotDanhGia.Text = dt.LuotDanhGia.ToString();
            richTextBox1.Text = dt.ThongSoKyThuat;
            pictureBox1.Tag = dt.Anh;
            string path = Directory.GetParent((Directory.GetParent(Application.StartupPath)).FullName).FullName;
            path += @"\AnhDT\" + dt.Anh;
            pictureBox1.Image = new Bitmap(path);
        }
    }
}
