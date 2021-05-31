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
        public bool KMMoi { get; set; }
        public KhuyenMaii()
        {
            InitializeComponent();
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
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
        }
        private void SetKMMoi()
        {
            this.BackColor = Color.FromArgb(192, 255, 192);
            panel10.BackColor = Color.FromArgb(192, 255, 192);
            panel2.BackColor = Color.FromArgb(192, 255, 192);
            panel3.BackColor = Color.FromArgb(192, 255, 192);
            panel4.BackColor = Color.FromArgb(192, 255, 192);
            panel5.BackColor = Color.FromArgb(192, 255, 192);
            tbGiaGiaMax.BackColor = Color.FromArgb(192, 255, 192);
            tbGiaMin.BackColor = Color.FromArgb(192, 255, 192);
            tbKhuyenMai.BackColor = Color.FromArgb(192, 255, 192);
            lich1.SetBackColor = Color.FromArgb(192, 255, 192);
            lich2.SetBackColor = Color.FromArgb(192, 255, 192);
            pbDelete.BackColor = Color.FromArgb(192, 255, 192);
            pbSave.BackColor = Color.FromArgb(192, 255, 192);
            numericUpDown1.BackColor = Color.FromArgb(192, 255, 192);
            pictureBox1.BackColor = Color.FromArgb(192, 255, 192);
            pictureBox2.BackColor = Color.FromArgb(192, 255, 192);
            lich1.SetBackColor = Color.FromArgb(192, 255, 192);
            lich2.SetBackColor = Color.FromArgb(192, 255, 192);
        }

        private void KhuyenMaii_Load(object sender, EventArgs e)
        {
            if (KMMoi) SetKMMoi();
        }

        private void Tien_TextChanged(object sender, EventArgs e)
        {
            pbSave.Show();
            TextBox tb = sender as TextBox;
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = 0;
            try
            {
                value = decimal.Parse(tb.Text, System.Globalization.NumberStyles.AllowThousands);
            }
            catch (Exception)
            {
            }
            tb.Text = String.Format(culture, "{0:N0}", value);
            tb.Select(tb.Text.Length, 0);
        }
    }
}
