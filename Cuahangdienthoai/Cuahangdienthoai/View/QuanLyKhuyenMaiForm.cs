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
    public partial class QuanLyKhuyenMaiForm : Form
    {
        public QuanLyKhuyenMaiForm()
        {
            InitializeComponent();
            LoadListKM();
        }

        private void btThemKM_Click(object sender, EventArgs e)
        {
            User_Control.KhuyenMaii km = new User_Control.KhuyenMaii();
            km.KMMoi = true;
            km.xoaKM += this.XoaKhuyenMai;
            km.luuKM += LuuKhuyenMai;
            flowLayoutPanel1.Controls.Add(km);
        }
        private void XoaKhuyenMai(Object sender, EventArgs e)
        {
            User_Control.KhuyenMaii km = sender as User_Control.KhuyenMaii;
            if (km.Tag != null)
            {
                lbSoLuong.Text = (Convert.ToInt32(lbSoLuong.Text) - 1).ToString();
                try
                {
                    KhuyenMaiBUS.Instance.XoaKM(Convert.ToInt32(km.Tag));
                }
                catch (Exception)
                {
                    KhuyenMaiBUS.Instance.AnKM(Convert.ToInt32(km.Tag));
                }
            }
            km.Dispose();
        }
        private void LuuKhuyenMai(Object sender, EventArgs e)
        {
            User_Control.KhuyenMaii km = sender as User_Control.KhuyenMaii;
            if(km.Tag == null)
            {
                lbSoLuong.Text = (Convert.ToInt32(lbSoLuong.Text) + 1).ToString();
                KhuyenMaiBUS.Instance.ThemKM(km.TenKM, km.NgayBatDau, km.NgayKetThuc, km.TienToiThieu, Convert.ToDecimal(km.PtGiamGia), km.GiamGiaMax);
                LoadListKM();
            }
            else
            {
                KhuyenMaiBUS.Instance.SuaKM(Convert.ToInt32(km.Tag), km.TenKM, km.NgayBatDau, km.NgayKetThuc, km.TienToiThieu, Convert.ToDecimal(km.PtGiamGia), km.GiamGiaMax);
            }
        }
        private void LoadListKM()
        {
            flowLayoutPanel1.Controls.Clear();
            int Soluong = 0;
            foreach (KhuyenMai item in KhuyenMaiBUS.Instance.GetListKM())
            {
                User_Control.KhuyenMaii km = new User_Control.KhuyenMaii();
                km.xoaKM += XoaKhuyenMai;
                km.luuKM += LuuKhuyenMai;
                km.TenKM = item.tenkhuyenmai;
                km.NgayBatDau = Convert.ToDateTime(item.ngaybatdau);
                km.NgayKetThuc = Convert.ToDateTime(item.ngayketthuc);
                km.TienToiThieu = (float)Convert.ToDouble(item.tientoithieu);
                km.GiamGiaMax = (float)Convert.ToDouble(item.khuyenmaitoida);
                km.PtGiamGia = (float)Convert.ToDouble(item.phantram);
                km.Tag = item.makhuyenmai;
                km.AnSave();
                flowLayoutPanel1.Controls.Add(km);
                Soluong++;
            }
            lbSoLuong.Text = Soluong.ToString();
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            LoadListKM();
        }
    }
}
