using Cuahangdienthoai.BLL;
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
    public partial class QuanLyKhachHangForm : Form
    {
        public QuanLyKhachHangForm()
        {
            InitializeComponent();
            SetGUI();
        }
        public void SetGUI()
        {
            BLL_CHDT bll = new BLL_CHDT();
            dataGridViewKhachHang.DataSource = bll.GetAllKH_BLL();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThongTinKH f = new ThongTinKH(0, "add");
            f.Show();
            f.d += SetGUI;
        }
    }
}
