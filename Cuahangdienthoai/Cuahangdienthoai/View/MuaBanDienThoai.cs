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
    public partial class MuaBanDienThoai : Form
    {
        public int maDT;
        public int SoLuong = 0;
        public bool Ban { get; set; }
        public delegate void ThemGioHang(int MaDT, int SoLuong);
        public ThemGioHang Them { get; set; }
        public MuaBanDienThoai(int MaDT, int SoLuong)
        {
            InitializeComponent();
            Ban = true;
            this.maDT = MaDT;
            this.SoLuong = SoLuong;
            SetGUI();
            nudSL.Value = SoLuong;
        }
        private void SetGUI()
        {
            DienThoai dt = DienThoaiBUS.Instance.TimDTByMaDT(maDT);
            tbTenDT.Text = dt.TenDienThoai;
            tbMaDT.Text = dt.MaDT.ToString();
            tbSoLuong.Text = dt.SLHienTai.ToString();
            tbPtGiamGia.Text = ((float)Convert.ToDouble(dt.C_GiamGia)).ToString() + "%";
            tbGiaBan.Text = String.Format("{0:#,0 đ}", dt.GiaBanDT);
            tbGiaNhap.Text = String.Format("{0:#,0 đ}", dt.GiaNhapDT);
            richTextBox1.Text = dt.ThongSoKyThuat;
            pictureBox1.Tag = dt.Anh;
            string path = MenuFor.path + dt.Anh;
            pictureBox1.Image = new Bitmap(path);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if(Ban && (Convert.ToInt32(tbSoLuong.Text) < Convert.ToInt32(nudSL.Value)))
            {
                MessageBox.Show("Số máy hiện tại không đủ đáp ứng!");
            }
            else
            {
                this.SoLuong = Convert.ToInt32(nudSL.Value);
                Them(maDT, SoLuong);
                this.Close();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            nudSL.Value = 0;
            btOk_Click(btOk, EventArgs.Empty);
        }
        public void ShowBtXoa()
        {
            btXoa.Show();
        }
    }
}
