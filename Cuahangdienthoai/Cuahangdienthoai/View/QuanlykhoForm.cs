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
    public partial class QuanlykhoForm : Form
    {
        private Account accLogin;
        NhapKhoForm NhapKho;
        KhoHangForm KhoHang;
        public QuanlykhoForm(Account acc)
        {
            InitializeComponent();
            this.accLogin = acc;
            btNhapKho_Click(btNhapKho, EventArgs.Empty);
        }

        private void btNhapKho_Click(object sender, EventArgs e)
        {
            if (NhapKho == null)
            {
                NhapKho = new NhapKhoForm(this.accLogin);
                NhapKho.TopLevel = false;
                NhapKho.Dock = DockStyle.Fill;
                panelMain.Controls.Add(NhapKho);
            }
            panelNhapKho.BackColor = Color.White;
            panelNhapKhoON.BackColor = Color.FromArgb(48, 128, 185);
            setcot2();
            if (KhoHang != null) KhoHang.Hide();
            NhapKho.Show();
        }
        private void setcot1()
        {
            panelNhapKho.BackColor = Color.FromArgb(48, 128, 185);
            panelNhapKhoON.BackColor = Color.White;
        }
        private void setcot2()
        {
            panelTonKho.BackColor = Color.FromArgb(48, 128, 185);
            panelTonkhoOn.BackColor = Color.White;

        }

        private void btKhoHang_Click(object sender, EventArgs e)
        {
            if (KhoHang == null)
            {
                KhoHang = new KhoHangForm();
                KhoHang.TopLevel = false;
                KhoHang.Dock = DockStyle.Fill;
                panelMain.Controls.Add(KhoHang);
            }
            panelTonKho.BackColor = Color.White;
            panelTonkhoOn.BackColor = Color.FromArgb(48, 128, 185);
            setcot1();
            NhapKho.Hide();
            KhoHang.Show();
        }
    }
}
