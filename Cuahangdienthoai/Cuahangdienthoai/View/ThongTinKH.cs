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
    public partial class ThongTinKH : Form
    {
        public delegate void MyDel();
        public MyDel d;
        public int MaKH { get; set; }
        private int identity = 1;
        private string chucNang;
        public ThongTinKH(int m, string chucNang)
        {
            InitializeComponent();
            this.MaKH = m;
            this.chucNang = chucNang;
            SetGUI();
        }
        public void SetGUI()
        {
            tbMaKH.Enabled = false;
            if (chucNang == "add")
            {
                tbMaKH.Text = identity.ToString();
            }
            else
            {

            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
