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
        public delegate void DeletgetKM(object sender, EventArgs e);
        public event DeletgetKM xoaKM;
        public event DeletgetKM luuKM;
        private bool KMMoi = true;
        public KhuyenMaii()
        {
            InitializeComponent();
            lich1.SetBackColor = Color.FromArgb(192, 255, 192);
            lich2.SetBackColor = Color.FromArgb(192, 255, 192);
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            if (KMMoi) SetKMCu();
            KMMoi = false;
            pbSave.Hide();
            panel1.Focus();
            luuKM(this, EventArgs.Empty);
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
        public DateTime NgayBatDau { get => lich1.GetDateTime(); set => lich1.SetDateTime(value); }
        public DateTime NgayKetThuc { get => lich2.GetDateTime(); set => lich2.SetDateTime(value); }
        public float TienToiThieu { get => (float)Convert.ToDecimal(tbGiaMin.Text); set => tbGiaMin.Text = value.ToString(); }
        public float PtGiamGia { get => (float)Convert.ToDecimal(numericUpDown1.Text); set => numericUpDown1.Text = value.ToString(); }
        public float GiamGiaMax { get => (float)Convert.ToDecimal(tbGiaGiaMax.Text); set => tbGiaGiaMax.Text = value.ToString(); }
        public void AnSave()
        {
            pbSave.Hide();
            KMMoi = false;
            SetKMCu();
        }
        private void SetKMCu()
        {
            this.BackColor = Color.White;
            panel10.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel5.BackColor = Color.White;
            tbGiaGiaMax.BackColor = Color.White;
            tbGiaMin.BackColor = Color.White;
            tbKhuyenMai.BackColor = Color.White;
            lich1.SetBackColor = Color.White;
            lich2.SetBackColor = Color.White;
            pbDelete.BackColor = Color.White;
            pbSave.BackColor = Color.White;
            numericUpDown1.BackColor = Color.White;
            pictureBox1.BackColor = Color.White;
            pictureBox2.BackColor = Color.White;
        }
    }
}
