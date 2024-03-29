﻿using Cuahangdienthoai.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuahangdienthoai.View
{
    public partial class NhaCungCapds : Form
    {
        public delegate void mydel(string name);
        public mydel d { get; set; }
        public int mncc { get; set; }
        public string chucnang;

        public NhaCungCapds(int m)
        {
            InitializeComponent();
            this.mncc = m;
            gui();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool checktb()
        {
            if ((tbDC.Text == "") || (tbEM.Text == "") || (tbTNCC.Text == "") || (tbSDT.Text == "")) return false;
            return true;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (!checktb()) MessageBox.Show("nhap thong tin day du");
            else
            {
                NhaCungCap s = new NhaCungCap();
                if (mncc != 0) s.MaNhanCungCap = mncc;
                s.TenNhaCungCap = tbTNCC.Text;
                s.DiaChi = tbDC.Text;
                s.SoDienThoai = tbSDT.Text;
                s.Email = tbEM.Text;
                NhaCungCapBUS.Intance.extbus(s);
            }
            d(null);
            this.Close();
        }
        public void gui()
        {
            NhaCungCap s = NhaCungCapBUS.Intance.getnccbus(mncc);
            if (s != null)
            {
                tbTNCC.Text = s.TenNhaCungCap;
                tbSDT.Text = s.SoDienThoai;
                tbEM.Text = s.Email;
                tbDC.Text = s.DiaChi;
            }
        }
    }
}
