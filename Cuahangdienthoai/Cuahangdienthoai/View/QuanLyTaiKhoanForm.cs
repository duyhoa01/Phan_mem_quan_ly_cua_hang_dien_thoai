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
    public partial class QuanLyTaiKhoanForm : Form
    {
        public QuanLyTaiKhoanForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PBL3Entities db = new PBL3Entities();
            dataGridView1.DataSource = db.KhuyenMais.Where(p => p.ngayketthuc >= DateTime.Now).Select(p => p).ToList();
        }

        private void btTimKiêm_Click(object sender, EventArgs e)
        {

        }
    }
}

