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
    public partial class HoaDonNhapForm : Form
    {
        bool HienThiDS = false;
        int ChieuRong;
        public HoaDonNhapForm()
        {
            InitializeComponent();
            ChieuRong = this.Width;
            this.Width = 534;
            panel2.Hide();
            monthCalendar1.Location = new Point(278, 216);
            pnNhaCungCap.Location = new Point(0, 458);
            tbNgayNhap.Text = monthCalendar1.TodayDate.ToString("dd/MM/yyyy");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            HienThiDS = !HienThiDS;
            if (HienThiDS)
            {
                this.Width = ChieuRong;
                panel2.Show();
            }
            else
            {
                panel2.Hide();
                this.Width = 534;
            }           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            monthCalendar1.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Hide();
            tbNgayNhap.Text = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pnNhaCungCap.Show();
                tbNCCMoi.Show();
                cbbNCC.Hide();
                this.Height = this.Height + 100;
            }
            else
            {
                tbNCCMoi.Hide();
                cbbNCC.Show();
                pnNhaCungCap.Hide();
                this.Height = this.Height - 100;
            }
        }
    }
}
