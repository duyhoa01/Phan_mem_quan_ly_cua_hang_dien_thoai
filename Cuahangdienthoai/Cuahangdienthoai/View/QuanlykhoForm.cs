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
        public QuanlykhoForm()
        {
            InitializeComponent();
        }

        private void btNhapKho_Click(object sender, EventArgs e)
        {
            panelNhapKho.BackColor = Color.FromArgb(237, 237, 237);
            panelNhapKhoON.BackColor = Color.FromArgb(48, 128, 185);
            setcot2();
            this.AddForm(new NhapKhoForm());
        }
        private void setcot1()
        {
            panelNhapKho.BackColor = Color.FromArgb(48, 128, 185);
            panelNhapKhoON.BackColor = Color.FromArgb(237, 237, 237);
        }
        private void setcot2()
        {
            panelTonKho.BackColor = Color.FromArgb(48, 128, 185);
            panelTonkhoOn.BackColor = Color.FromArgb(237, 237, 237);

        }

        private void btTonKho_Click(object sender, EventArgs e)
        {
            panelTonKho.BackColor = Color.FromArgb(237, 237, 237);
            panelTonkhoOn.BackColor = Color.FromArgb(48, 128, 185);
            this.AddForm(new TonKhoForm());
            setcot1();
        }
        private void AddForm(Form newForm)
        {
            if (this.panelMain.Controls.Count > 0)
                this.panelMain.Controls.RemoveAt(0);
            newForm.TopLevel = false;
            newForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(newForm);
            this.panelMain.Tag = newForm;
            newForm.Show();
        }
    }
}
