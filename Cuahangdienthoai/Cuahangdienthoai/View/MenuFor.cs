using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Cuahangdienthoai.View
{
    public partial class MenuFor : Form
    {
        private int ID;
        public MenuFor(int ID)
        {
            InitializeComponent();
            this.ID = ID;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panelmenu.Width == 225)
            {
                panelmenu.Width = 70;
            }
            else panelmenu.Width = 225;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            picMaximize.Visible = false;
            picRestore.Visible = true;
        }

        private void picRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picMaximize.Visible = true;
            picRestore.Visible = false;
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public delegate void MyDel();
        public MyDel d { get; set; }
        private void btLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("bạn chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {

                this.Hide();
                //form1.Show();
                d();
            }
        }
        private void SetLabel()
        {
            //User user = BLL_Usres.Instance.GetUserByIDBLL(ID);
            //labelName.Text = user.FirstName;
            //labelPosition.Text = user.Position;
        }
        private void Show(List<int> list)
        {
            MessageBox.Show("bạn có các quyền");
            foreach (int i in list)
            {
                MessageBox.Show(i + " ");
            }
        }

        private void AddForm(Form newForm)
        {
            if (this.panelMain.Controls.Count > 0)
                this.panelMain.Controls.RemoveAt(0);
            newForm.TopLevel = false;
            newForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(newForm);
            this.panelMain.Tag = newForm;
            newForm.Show();
        }

        private void btBanHang_Click(object sender, EventArgs e)
        {
            this.AddForm(new QuanlybanhangFrom());
        }

        private void btKhoHang_Click(object sender, EventArgs e)
        {
            this.AddForm(new QuanlykhoForm());
        }
    }
}
