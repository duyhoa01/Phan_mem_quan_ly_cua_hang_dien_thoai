using Cuahangdienthoai.BUS;
using Cuahangdienthoai.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuahangdienthoai
{
    public partial class QuanLyNhaCungCap : Form
    {
        public QuanLyNhaCungCap()
        {
            InitializeComponent();
           // show(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NhaCungCapds f = new NhaCungCapds(0);
            f.d += new NhaCungCapds.mydel(show);
            f.Show();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int mncc = Convert.ToInt32(dataGridView1.SelectedRows[i].Cells["MaNhanCungCap"].Value.ToString());
                NhaCungCapBUS.Intance.xoa_nccBus(mncc);
            }
        }
        public void show(string name)
        {
            dataGridView1.DataSource = NhaCungCapBUS.Intance.getlistnamebus(name);

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int mncc = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaNhanCungCap"].Value.ToString());
                NhaCungCapds f = new NhaCungCapds(mncc);
                f.d += new NhaCungCapds.mydel(show);
                f.Show();
            }
        }

        private void btTimKiêm_Click(object sender, EventArgs e)
        {
            show(textBox1.Text);
        }
    }
}
