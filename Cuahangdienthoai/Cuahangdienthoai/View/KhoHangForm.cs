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
using Cuahangdienthoai.DTO;

namespace Cuahangdienthoai.View
{
    public partial class KhoHangForm : Form
    {
        private bool load = false;
        public KhoHangForm()
        {
            InitializeComponent();
            cbSapXep.SelectedIndex = 0;
            cbPhanKhuc.SelectedIndex = 0;
            LoadListDT();
            SetGUI();
        }
        public void LoadListDT()
        {
            dataGridViewsanpham.DataSource = DienThoaiBUS.Instance.GetListDTFormKhoHang(tbTimKiem.Text, cbSapXep.Text, cbPhanKhuc.Text);
            lbSoLuong.Text = dataGridViewsanpham.Rows.Count.ToString();
        }
        private void SetGUI()
        {
            dataGridViewsanpham.Columns[0].HeaderText = "";
            dataGridViewsanpham.Columns[1].HeaderText = "Mã Điện Thoại";
            dataGridViewsanpham.Columns[2].HeaderText = "Tên Điện Thoại";
            dataGridViewsanpham.Columns[3].HeaderText = "Số Lượng";
            dataGridViewsanpham.Columns[4].HeaderText = "Giá Nhập";
            dataGridViewsanpham.Columns[4].DefaultCellStyle.Format = "0,0 đ";
            dataGridViewsanpham.Columns[5].HeaderText = "Giá Bán";
            dataGridViewsanpham.Columns[5].DefaultCellStyle.Format = "0,0 đ";
            dataGridViewsanpham.Columns[6].HeaderText = "Bán Ra Trong Năm";
            dataGridViewsanpham.Columns[7].HeaderText = "Điểm Đánh Giá";
            dataGridViewsanpham.Columns[8].Visible = false;
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            LoadListDT();
        }

        private void btSapHet_Click(object sender, EventArgs e)
        {
            dataGridViewsanpham.DataSource = DienThoaiBUS.Instance.GetListDTSapHetFormKhoHang
                                                                        (tbTimKiem.Text, cbSapXep.Text, cbPhanKhuc.Text);
        }

        private void KhoHangForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                load = true;
            }
            else
            {
                if (load) LoadListDT();
                load = !load;
            }
        }

        private void dataGridViewsanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewsanpham.SelectedRows.Count == 1)
            {
                string MaDT = dataGridViewsanpham.SelectedRows[0].Cells["MaDT"].Value.ToString();
                ThongTinDienThoai f = new ThongTinDienThoai(Convert.ToInt32(MaDT));
                f.d += LoadListDT;
                f.Show();
            }
        }
    }
}
