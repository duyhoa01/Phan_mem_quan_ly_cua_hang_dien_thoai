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
    public partial class ThongtinNV : Form
    {
        public delegate void MyDel();
        public MyDel d;
        public int MaNV { get; set; }
        private int identity = 3;
        private string chucNang;
        public ThongtinNV(int m, string chucNang)
        {
            InitializeComponent();
            this.MaNV = m;
            this.chucNang = chucNang;
            SetGUI();
        }
        public void SetGUI()
        {
            cbbChucVu.Items.Add(new CBBItem
            {
                Value = 1,
                Text = "Lau dọn"
            });
            cbbChucVu.SelectedIndex = 0;
            if(chucNang == "edit")
            {
                BLL_CHDT bll = new BLL_CHDT();
                NhanVien s = bll.GetNVByMaNV_BLL(MaNV);
                tbMaNV.Text = s.MaNhanVien.ToString();
                tbMaNV.Enabled = false;
                tbTenNV.Text = s.TenNhanVien;
                tbDC.Text = s.DiaChi;
                if(s.Nam == true) radioButtonMale.Checked = true;
                else
                    radioButtonFemale.Checked = true;
                tbSDT.Text = s.DienThoai;
                tbCMND.Text = s.CMND;
                ((CBBItem)cbbChucVu.SelectedItem).Text = s.ChucVu;
            }    
            else
            {
                BLL_CHDT bll = new BLL_CHDT();
                tbMaNV.Text = identity.ToString();
                tbMaNV.Enabled = false;
            }    
        }
        private bool CheckData()
        {
            BLL_CHDT bll = new BLL_CHDT();
            int MaNV = int.Parse(tbMaNV.Text);
            if (tbMaNV.Text == "" || tbTenNV.Text == "" || tbDC.Text == "" || tbCMND.Text == "" || tbSDT.Text == "") return false;
            else
                return true;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            BLL_CHDT bll = new BLL_CHDT();
            if (chucNang == "add" && bll.GetNVByMaNV_BLL(MaNV) == null)
            {
                if (CheckData())
                {
                    NhanVien s = new NhanVien
                    {
                        MaNhanVien = int.Parse(tbMaNV.Text),
                        TenNhanVien = tbTenNV.Text,
                        Nam = (radioButtonMale.Checked) ? true : false,
                        DiaChi = tbDC.Text,
                        CMND = tbCMND.Text,
                        DienThoai = tbSDT.Text,
                        NgaySinh = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day),
                        ChucVu = ((CBBItem)cbbChucVu.SelectedItem).Text
                    };
                    bll.AddNV_BLL(s);
                    identity++;
                    this.Close();
                }
                else
                    MessageBox.Show("Vui lòng nhập ĐÚNG và ĐỦ thông tin!", "Thông báo", MessageBoxButtons.OK);
            }   
            else
            {
                if (CheckData())
                {
                    NhanVien s = new NhanVien
                    {
                        MaNhanVien = int.Parse(tbMaNV.Text),
                        TenNhanVien = tbTenNV.Text,
                        Nam = (radioButtonMale.Checked) ? true : false,
                        DiaChi = tbDC.Text,
                        CMND = tbCMND.Text,
                        DienThoai = tbSDT.Text,
                        NgaySinh = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day),
                        ChucVu = ((CBBItem)cbbChucVu.SelectedItem).Text
                    };
                    bll.EditNV_BLL(s);
                    this.Close();
                }
                else
                    MessageBox.Show("Vui lòng nhập ĐÚNG và ĐỦ thông tin!", "Thông báo", MessageBoxButtons.OK);
            }
            d();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
