﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Cuahangdienthoai.DAL;
using Cuahangdienthoai.BUS;

namespace Cuahangdienthoai.View
{
    public partial class MenuFor : Form
    {
        private Account account;
        private List<string> listquyen;
        //public MenuFor(Account account);
        //private int ID;
        public static string path = Directory.GetParent((Directory.GetParent(Application.StartupPath)).FullName).FullName + @"\AnhDT\";
        public MenuFor(Account account)
        {
            InitializeComponent();
            this.account = account;
            this.listquyen = TaiKhoanBUS.Instance.GetPhanQuyenTaiKhoan(account);
            SetGui();
            SetGuiAcc();
            //this.ID = ID;
            btBanHang_Click(btBanHang, EventArgs.Empty);
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
            SetColorButton(sender);
            this.AddForm(new QuanlybanhangFrom(this.account));
        }

        private void btKhoHang_Click(object sender, EventArgs e)
        {
            SetColorButton(sender);
            this.AddForm(new QuanlykhoForm(this.account));
        }

        private void btKinhDoanh_Click(object sender, EventArgs e)
        {
            SetColorButton(sender);
            this.AddForm(new BaoCaoKinhDoanhForm());
        }

        private void btNhanVien_Click(object sender, EventArgs e)
        {
            SetColorButton(sender);
            this.AddForm(new QuanLyNhanVienForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetColorButton(sender);
            this.AddForm(new QuanLyTaiKhoanForm());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SetColorButton(sender);
            this.AddForm(new QuanLyKhachHang());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetColorButton(sender);
            this.AddForm(new QuanLyNhaCungCap());
        }
        public void SetGui()
        {
            if (!this.listquyen.Contains("BANHANG"))
            {
                btBanHang.Visible = false;
            } 
            if (!this.listquyen.Contains("KHOHANG"))
            {
                btKhoHang.Visible = false;
            } 
            if (!this.listquyen.Contains("BAOCAO"))
            {
                btKinhDoanh.Visible = false;
            } 
            if (!this.listquyen.Contains("NHANVIEN"))
            {
                btNhanVien.Visible = false;
            } 
            if (!this.listquyen.Contains("TAIKHOAN"))
            {
                button1.Visible = false;
            }
        }
        private void SetGuiAcc()
        {
            NhanVien nhanVien = TaiKhoanBUS.Instance.GetNhanVien(account);
            try
            {
                pictureBoxAnh.LoadAsync("../../AnhAcc/" + account.AnhAcc);
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

                gp.AddEllipse(0, 0, pictureBoxAnh.Width - 3, pictureBoxAnh.Height - 3);
                Region rg = new Region(gp);
                pictureBoxAnh.Region = rg;
            }
            catch (Exception)
            {

            }
            labelName.Text = account.TenHienThi;
            labelPosition.Text = nhanVien.ChucVu;
        }

        private void pictureBoxAnh_Click(object sender, EventArgs e)
        {
            ThongTinAcc f = new ThongTinAcc(account);
            f.d = SetGuiAcc;
            f.Show();
        }

        void SetColorButton(object sender)
        {
            Button bt = sender as Button;
            foreach (Button item in pnChucNang.Controls)
            {
                item.BackColor = Color.FromArgb(30, 114, 174);
            }
            bt.BackColor = Color.Purple;
        }
    }
}
