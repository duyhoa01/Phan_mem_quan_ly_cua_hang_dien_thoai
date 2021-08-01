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
using System.Drawing.Drawing2D;
using Cuahangdienthoai.View;
using Cuahangdienthoai.BUS;

namespace Cuahangdienthoai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void SetSize()
        {
            //tbUser.Autosize = false;
            //tbUser.Site = new Size(280, 40);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btLogin_Paint(object sender, PaintEventArgs e)
        {
            var ButtonPath = new System.Drawing.Drawing2D.GraphicsPath();
            var myRectangle = btLogin.ClientRectangle;
            myRectangle.Inflate(0, 30);
            ButtonPath.AddEllipse(myRectangle);
            btLogin.Region = new Region(ButtonPath);
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string userName = tbUser.Text;
            string password = tbPassword.Text;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("nhập đầy thông tin");
            }
            else if (TaiKhoanBUS.Instance.GetAccountLogin(userName,password)==null)
            {
                MessageBox.Show("username hoặc password không đúng");
                tbPassword.Clear();
                tbPassword.Focus();
            }
            else
            {
                MenuFor menuform = new MenuFor(TaiKhoanBUS.Instance.GetAccountLogin(userName, password));
                menuform.Show();
                //menuform.FormClosed += this.Logout;
                menuform.d += new MenuFor.MyDel(this.Logout);
                this.Hide();

            }
        }
        private void Logout()
        {
            tbUser.Text = "";
            tbPassword.Text = "";
            tbUser.Focus();
            this.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotUser forgot = new ForgotUser();
            forgot.Show();
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            tbPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            tbPassword.UseSystemPasswordChar = true;
        }
    }
}
