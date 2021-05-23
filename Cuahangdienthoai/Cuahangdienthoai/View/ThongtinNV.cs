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
        public delegate void MyDel(int MaNV, string tool);
        public MyDel d;
        public string MaNV { get; set; }
        private string chucNang;
        public ThongtinNV(string m, string chucNang)
        {
            InitializeComponent();
            this.MaNV = m;
            this.chucNang = chucNang;
            SetCBB();
        }
        public void SetCBB()
        {
            cbbChucVu.Items.Add(new CBBItem
            {
                Value = 1,
                Text = "Lau dọn"
            });
            cbbChucVu.SelectedIndex = 0;
        }
        private bool CheckData()
        {
            if (tbMaNV.Text == "" || tbTenNV.Text == "" || tbDC.Text == "" || tbCMND.Text == "" || tbSDT.Text == "") return false;
            else
                return true;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                MessageBox.Show("Done!", "Thông báo", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
