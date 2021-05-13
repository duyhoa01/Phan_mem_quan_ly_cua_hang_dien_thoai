using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Cuahangdienthoai.View
{
    public partial class QuanlybanhangFrom : Form
    {
        public QuanlybanhangFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(237, 237, 237);
            panel8.BackColor = Color.FromArgb(48, 128, 185);
            setcot2();
            setcot3();
            this.AddForm(new QuanLySanPhamForm());
        }
        private void setcot2()
        {
            panel6.BackColor = Color.FromArgb(48, 128, 185);
            panel9.BackColor = Color.FromArgb(237, 237, 237);

        }
        private void setcot1()
        {
            panel4.BackColor = Color.FromArgb(48, 128, 185);
            panel8.BackColor = Color.FromArgb(237, 237, 237);
        }
        private void setcot3()
        {
            panel7.BackColor = Color.FromArgb(48, 128, 185);
            panel3.BackColor = Color.FromArgb(237, 237, 237);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(237, 237, 237);
            panel9.BackColor = Color.FromArgb(48, 128, 185);
            setcot1();
            setcot3();
            this.AddForm(new QuanLyDonHangForm());
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

        private void btKhuyenMai_Click(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(237, 237, 237);
            panel3.BackColor = Color.FromArgb(48, 128, 185);
            setcot2();
            setcot1();
            this.AddForm(new QuanLyKhuyenMaiForm());
        }
    }
}
