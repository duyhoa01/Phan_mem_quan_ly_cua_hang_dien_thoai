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
        Form NhapKho = new NhapKhoForm();
        Form KhoHang = new KhoHangForm();
        public QuanlykhoForm()
        {
            InitializeComponent();
            SetGUI();
            btNhapKho_Click(btNhapKho, EventArgs.Empty);
        }

        private void btNhapKho_Click(object sender, EventArgs e)
        {
            panelNhapKho.BackColor = Color.White;
            panelNhapKhoON.BackColor = Color.FromArgb(48, 128, 185);
            setcot2();
            this.panelMain.Controls[0].Show();
            this.panelMain.Controls[1].Hide();
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
            panelTonKho.BackColor = Color.White;
            panelTonkhoOn.BackColor = Color.FromArgb(48, 128, 185);
            setcot1();
            this.panelMain.Controls[1].Show();
            this.panelMain.Controls[0].Hide();
        }
        private void SetGUI()
        {
            NhapKho.TopLevel = false;
            KhoHang.TopLevel = false;
            NhapKho.Dock = DockStyle.Fill;
            KhoHang.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(NhapKho);
            this.panelMain.Controls.Add(KhoHang);
            this.panelMain.Controls[0].Show();
        }
    }
}
