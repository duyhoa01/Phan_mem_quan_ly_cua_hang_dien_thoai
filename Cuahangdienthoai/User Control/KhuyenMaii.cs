using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Control
{
    public partial class KhuyenMaii : UserControl
    {
        public delegate void XoaKM(object sender, EventArgs e);
        public event XoaKM xoaKM;
        public KhuyenMaii()
        {
            InitializeComponent();

        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            pbSave.Hide();
            panel1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pbSave.Show();
        }

        private void lich1_SizeChanged(object sender, EventArgs e)
        {
            Lich lich = sender as Lich;
            if (!lich.ShowCalendar) textBox1_TextChanged(tbKhuyenMai, EventArgs.Empty);
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            xoaKM(this, EventArgs.Empty);
        }
        public string TenKM { get => tbKhuyenMai.Text; set => tbKhuyenMai.Text = value; }
        public DateTime NgayBatDau { get => lich1.GetDateTime(); set => lich1.SetDateTime(value.ToString()); }
        public float TienToiThieu { get => (float)Convert.ToDecimal(tbGiaMin.Text); set => tbGiaMin.Text = value.ToString(); }
        public float PtGiamGia { get => (float)Convert.ToDecimal(numericUpDown1.Text); set => numericUpDown1.Text = value.ToString(); }
        public float GiamGiaMax { get => (float)Convert.ToDecimal(tbGiaGiaMax.Text); set => tbGiaGiaMax.Text = value.ToString(); }
    }
}
