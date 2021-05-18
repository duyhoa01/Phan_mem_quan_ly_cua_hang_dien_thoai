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
    public partial class ThemDonHangForm : Form
    {
        public ThemDonHangForm()
        {
            InitializeComponent();
            tbCMND_Check.AppendText("CMND");
        }

        private void btKtraKH_Click(object sender, EventArgs e)
        {
            
        }

        private void rdbKHMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKHMoi.Checked == false)
            {
                pnKHCu.Show();
                pnThongTinKH.Enabled = true;
            }
            else
            {
                pnKHCu.Hide();
                pnThongTinKH.Enabled = false;
            }
        }
    }
}
