using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Cuahangdienthoai
{
    public partial class ThuDong : UserControl
    {
        public ThuDong()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void picMinimize_Click(object sender, EventArgs e)
        {
            Form f = (Form)this.TopLevelControl;
            f.WindowState = FormWindowState.Minimized;
        }

        private void picRestore_Click(object sender, EventArgs e)
        {
            Form f = (Form)this.TopLevelControl;
            f.WindowState = FormWindowState.Normal;
            picMaximize.Visible = true;
            picRestore.Visible = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Form f = (Form)this.TopLevelControl;
            f.Close();
        }
        private void picMaximize_Click(object sender, EventArgs e)
        {
            Form f = (Form)this.TopLevelControl;
            f.WindowState = FormWindowState.Maximized;
            picMaximize.Visible = false;
            picRestore.Visible = true;
        }

        private void ThuDong_MouseDown(object sender, MouseEventArgs e)
        {
            Form f = (Form)this.TopLevelControl;
            ReleaseCapture();
            SendMessage(f.Handle, 0x112, 0xf012, 0);
        }
    }
}
