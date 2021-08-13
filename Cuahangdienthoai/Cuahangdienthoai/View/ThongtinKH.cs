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
    public partial class ThongTinKH : Form
    {
        public delegate void MyDel();
        public MyDel d;
        public int MaKH { get; set; }
        private string chucNang;
        public ThongTinKH(int m, string chucNang)
        {
            InitializeComponent();
            this.MaKH = m;
            this.chucNang = chucNang;
            SetGUI();
        }
        public void SetGUI()
        {
            tbMaKH.Enabled = false;
            if (chucNang == "edit")
            {
                BLL_CHDT bll = new BLL_CHDT();
                KhachHang k = bll.GetKHByMaKH_BLL(MaKH);
                tbMaKH.Text = k.MaKhachHang.ToString();
                tbMaKH.Enabled = false;
                tbTenKH.Text = k.TenKhachHang;
                tbDC.Text = k.DiaChi;
                tbSDT.Text = k.DienThoai;
                tbCMND.Text = k.CMND;
            }
            else
            {
                BLL_CHDT bll = new BLL_CHDT();
                tbMaKH.Text = "";
                tbMaKH.Enabled = false;
            }
        }
        private bool CheckData()
        {
            BLL_CHDT bll = new BLL_CHDT();
            if (tbTenKH.Text == "" || tbDC.Text == "" || tbCMND.Text == "" || tbSDT.Text == "") return false;
            else
                return true;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            BLL_CHDT bll = new BLL_CHDT();
            if (chucNang == "add" && bll.GetNVByMaNV_BLL(MaKH) == null)
            {
                if (CheckData())
                {
                    KhachHang k = new KhachHang()
                    {
                        MaKhachHang = 0,
                        TenKhachHang = tbTenKH.Text,
                        DienThoai = tbSDT.Text,
                        DiaChi = tbDC.Text,
                        CMND = tbCMND.Text

                    };
                    bll.AddKH_BLL(k);
                    this.Close();
                }
                else
                    MessageBox.Show("Vui lòng nhập ĐÚNG và ĐỦ thông tin!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (CheckData())
                {
                    KhachHang k = new KhachHang()
                    {
                        MaKhachHang = int.Parse(tbMaKH.Text),
                        TenKhachHang = tbTenKH.Text,
                        DienThoai = tbSDT.Text,
                        DiaChi = tbDC.Text,
                        CMND = tbCMND.Text

                    };
                    bll.EditKH_BLL(k);
                    this.Close();
                }
                else
                    MessageBox.Show("Vui lòng nhập ĐÚNG và ĐỦ thông tin!", "Thông báo", MessageBoxButtons.OK);
            }
            d();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
