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
    public partial class QuanlybanhangFrom : Form
    {
        QuanLySanPhamForm fsanpham;
        QuanLyDonHangForm fdonhang;
        QuanLyKhuyenMaiForm fkhuyenmai;
        public QuanlybanhangFrom()
        {
            InitializeComponent();
            button1_Click(fsanpham, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(fsanpham == null)
            {
                fsanpham = new QuanLySanPhamForm();
                fsanpham.TopLevel = false;
                fsanpham.Dock = DockStyle.Fill;
                panelMain.Controls.Add(fsanpham);
            } 
            panel4.BackColor = Color.White;
            panel8.BackColor = Color.FromArgb(48, 128, 185);
            setcot2();
            setcot3();
            if(fkhuyenmai != null) fkhuyenmai.Hide();
            if(fdonhang != null) fdonhang.Hide();
            fsanpham.Show();
        }
        private void setcot2()
        {
            panel6.BackColor = Color.FromArgb(48, 128, 185);
            panel9.BackColor = Color.White;

        }
        private void setcot1()
        {
            panel4.BackColor = Color.FromArgb(48, 128, 185);
            panel8.BackColor = Color.White;
        }
        private void setcot3()
        {
            panel7.BackColor = Color.FromArgb(48, 128, 185);
            panel3.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fdonhang == null)
            {
                fdonhang = new QuanLyDonHangForm();
                fdonhang.TopLevel = false;
                fdonhang.Dock = DockStyle.Fill;
                panelMain.Controls.Add(fdonhang);
            }
            panel6.BackColor = Color.White;
            panel9.BackColor = Color.FromArgb(48, 128, 185);
            setcot1();
            setcot3();
            fsanpham.Hide();
            if(fkhuyenmai != null) fkhuyenmai.Hide();
            fdonhang.Show();
        }

        private void btKhuyenMai_Click(object sender, EventArgs e)
        {
            if (fkhuyenmai == null)
            {
                fkhuyenmai = new QuanLyKhuyenMaiForm();
                fkhuyenmai.TopLevel = false;
                fkhuyenmai.Dock = DockStyle.Fill;
                panelMain.Controls.Add(fkhuyenmai);
            }
            panel7.BackColor = Color.White;
            panel3.BackColor = Color.FromArgb(48, 128, 185);
            setcot2();
            setcot1();
            if(fdonhang != null) fdonhang.Hide();
            fsanpham.Hide();
            fkhuyenmai.Show();
        }
    }
}
