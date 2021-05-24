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
        QuanLySanPhamForm fsanpham = new QuanLySanPhamForm();
        QuanLyDonHangForm fdonhang = new QuanLyDonHangForm();
        QuanLyKhuyenMaiForm fkhuyenmai = new QuanLyKhuyenMaiForm();
        public QuanlybanhangFrom()
        {
            InitializeComponent();
            SetGUI();
            button1_Click(fsanpham, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.BackColor = Color.White;
            panel8.BackColor = Color.FromArgb(48, 128, 185);
            setcot2();
            setcot3();
            fkhuyenmai.Hide();
            fdonhang.Hide();
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
            panel6.BackColor = Color.White;
            panel9.BackColor = Color.FromArgb(48, 128, 185);
            setcot1();
            setcot3();
            fsanpham.Hide();
            fkhuyenmai.Hide();
            fdonhang.Show();
        }
        private void SetGUI()
        {
            fsanpham.TopLevel = false;
            fsanpham.Dock = DockStyle.Fill;
            fdonhang.TopLevel = false;
            fdonhang.Dock = DockStyle.Fill;
            fkhuyenmai.TopLevel = false;
            fkhuyenmai.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(fsanpham);
            this.panelMain.Controls.Add(fdonhang);
            this.panelMain.Controls.Add(fkhuyenmai);
        }

        private void btKhuyenMai_Click(object sender, EventArgs e)
        {
            panel7.BackColor = Color.White;
            panel3.BackColor = Color.FromArgb(48, 128, 185);
            setcot2();
            setcot1();
            fdonhang.Hide();
            fsanpham.Hide();
            fkhuyenmai.Show();
        }
    }
}
