﻿using System;
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
            tbPtGiamGia.Text = ((float)Convert.ToDouble(dt.C_GiamGia)).ToString() + "%";
            tbDonGia.Text = ((float)Convert.ToDouble(dt.GiaBanDT)).ToString();
            tbDiemDanhGia.Text = ((float)Convert.ToDouble(dt.DiemDanhGia)).ToString() + " / 5";
            tbLuotDanhGia.Text = dt.LuotDanhGia.ToString();
            richTextBox1.Text = dt.ThongSoKyThuat;
            pictureBox1.Tag = dt.Anh;
            string path = MenuFor.path + dt.Anh;
            pictureBox1.Image = new Bitmap(path);
        }
    }
}
