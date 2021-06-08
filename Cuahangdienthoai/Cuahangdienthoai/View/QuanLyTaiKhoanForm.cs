using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cuahangdienthoai.BUS;

namespace Cuahangdienthoai.View
{
    public partial class QuanLyTaiKhoanForm : Form
    {
        public QuanLyTaiKhoanForm()
        {
            InitializeComponent();
            LoadListAcc();
        }
        public void LoadListAcc()
        {
            dataGridViewAcc.DataSource = TaiKhoanBUS.Instance.GetListAcc();
        }
    }
}
