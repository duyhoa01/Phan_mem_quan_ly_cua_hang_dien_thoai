﻿using Cuahangdienthoai.BLL;
using Cuahangdienthoai.View;
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
    public partial class QuanLyNhanVienForm : Form
    {
        public QuanLyNhanVienForm()
        {
            InitializeComponent();
            SetCBB();
            SetGUI();
        }
        public string LocDau(string str)
        {
            string[] VietNamChar = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
        }
        public void SetCBB()
        {
            cbbSort.Items.Add(new CBBItem { Value = 1, Text = "Tên" });
            cbbSort.Items.Add(new CBBItem { Value = 2, Text = "Ngày sinh" });
            cbbSort.SelectedIndex = 0;
        }
        public void SetGUI()
        {
            BLL_CHDT bll = new BLL_CHDT();
            dataGridViewNhanVien.DataSource = bll.GetAllNV_BLL();
        }
        public List<NhanVien> Sort(string change)
        {
            BLL_CHDT bll = new BLL_CHDT();
            List<NhanVien> data = new List<NhanVien>();
            data = bll.GetAllNV_BLL();
            if (change == "Tên")
            {
                for (int i = 0; i < data.Count - 1; i++)
                    for (int j = i + 1; j < data.Count; j++)
                    {
                        bool check;
                        check = (string.Compare(LocDau(data[i].TenNhanVien), LocDau(data[j].TenNhanVien)) == 1) ? true : false;
                        if (check)
                        {
                            NhanVien tmp = new NhanVien();
                            tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;
                        }

                    }
            }
            else
            if (change == "Ngày sinh")
            {
                for (int i = 0; i < data.Count - 1; i++)
                    for (int j = i + 1; j < data.Count; j++)
                    {
                        bool check;
                        check = (data[i].NgaySinh > data[j].NgaySinh) ? true : false;
                        if (check)
                        {
                            NhanVien tmp = new NhanVien();
                            tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;
                        }

                    }
            }
            return data;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            BLL_CHDT bll = new BLL_CHDT();
            List<NhanVien> data = new List<NhanVien>();
            foreach (NhanVien i in bll.GetAllNV_BLL())
            {
                if (LocDau(i.TenNhanVien.ToLower()).Contains(LocDau(search.ToLower())))
                {
                    data.Add(i);
                }
            }
            dataGridViewNhanVien.DataSource = data;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThongtinNV f = new ThongtinNV(0, "add");
            f.Show();
            f.d += SetGUI;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            dataGridViewNhanVien.DataSource = Sort(((CBBItem)cbbSort.SelectedItem).Text);
            //SetGUI();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                ThongtinNV f = new ThongtinNV(Convert.ToInt32(dataGridViewNhanVien.SelectedRows[0].Cells["MaNhanVien"].Value), "edit");
                f.Show();
                f.d += SetGUI;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            BLL_CHDT bll = new BLL_CHDT();
            if (dataGridViewNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                for (int i = 0; i < dataGridViewNhanVien.SelectedRows.Count; i++)
                {
                    int MaNV = int.Parse(dataGridViewNhanVien.SelectedRows[i].Cells["MaNhanVien"].Value.ToString());
                    try
                    {
                        NhanVien nv = bll.GetNVByMaNV_BLL(MaNV);
                        TaiKhoanBUS.Instance.XoaAcc(nv.Accounts.ToList().FirstOrDefault().ID);
                        bll.DelNV_BLL(MaNV);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể xóa nhân viên mã " + MaNV.ToString() +
                            "vì liên quan đến hóa đơn nhập bán trước đó!", "Lỗi!");
                    }
                }
            }
            SetGUI();
        }

        private void dataGridViewNhanVien_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridViewNhanVien.Columns[8].Visible = false;
            dataGridViewNhanVien.Columns[9].Visible = false;
            dataGridViewNhanVien.Columns[10].Visible = false;
        }
    }
}
