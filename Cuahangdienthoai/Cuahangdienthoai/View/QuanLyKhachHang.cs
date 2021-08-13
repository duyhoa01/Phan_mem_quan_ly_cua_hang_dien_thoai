using Cuahangdienthoai.BLL;
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
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
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
            cbbSort.SelectedIndex = 0;
        }
        public void SetGUI()
        {
            BLL_CHDT bll = new BLL_CHDT();
            dataGridViewKhachHang.DataSource = bll.GetAllKH_BLL();
        }
        public List<KhachHang> Sort(string change)
        {
            BLL_CHDT bll = new BLL_CHDT();
            List<KhachHang> data = new List<KhachHang>();
            data = bll.GetAllKH_BLL();
            if (change == "Tên")
            {
                for (int i = 0; i < data.Count - 1; i++)
                    for (int j = i + 1; j < data.Count; j++)
                    {
                        bool check;
                        check = (string.Compare(LocDau(data[i].TenKhachHang), LocDau(data[j].TenKhachHang)) == 1) ? true : false;
                        if (check)
                        {
                            KhachHang tmp = new KhachHang();
                            tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;
                        }

                    }
            }
            /*else
            if (change == "Ngày sinh")
            {
                for (int i = 0; i < data.Count - 1; i++)
                    for (int j = i + 1; j < data.Count; j++)
                    {
                        bool check;
                        check = (data[i].N > data[j].NgaySinh) ? true : false;
                        if (check)
                        {
                            NhanVien tmp = new NhanVien();
                            tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;
                        }

                    }
            }*/
            return data;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThongTinKH f = new ThongTinKH(0, "add");
            f.Show();
            f.d += SetGUI;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                ThongTinKH f = new ThongTinKH(Convert.ToInt32(dataGridViewKhachHang.SelectedRows[0].Cells["MaKhachHang"].Value), "edit");
                f.Show();
                f.d += SetGUI;
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            BLL_CHDT bll = new BLL_CHDT();
            if (dataGridViewKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                for (int i = 0; i < dataGridViewKhachHang.SelectedRows.Count; i++)
                {
                    int MaKH = int.Parse(dataGridViewKhachHang.SelectedRows[i].Cells["MaKhachHang"].Value.ToString());
                    bll.DelKH_BLL(MaKH);
                }
            }
            SetGUI();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            BLL_CHDT bll = new BLL_CHDT();
            List<KhachHang> data = new List<KhachHang>();
            foreach (KhachHang i in bll.GetAllKH_BLL())
            {
                if (LocDau(i.TenKhachHang.ToLower()).Contains(LocDau(search.ToLower())))
                {
                    data.Add(i);
                }
            }
            dataGridViewKhachHang.DataSource = data;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            dataGridViewKhachHang.DataSource = Sort(((CBBItem)cbbSort.SelectedItem).Text);
        }

        private void dataGridViewKhachHang_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridViewKhachHang.Columns[5].Visible = false;
        }
    }
}
