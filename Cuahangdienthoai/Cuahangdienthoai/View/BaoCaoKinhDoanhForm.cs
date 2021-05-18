using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace Cuahangdienthoai.View
{
    public partial class BaoCaoKinhDoanhForm : Form
    {
        public BaoCaoKinhDoanhForm()
        {
            InitializeComponent();
            panel2.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            var ButtonPath = new System.Drawing.Drawing2D.GraphicsPath();
            var myRectangle = panel3.ClientRectangle;
            myRectangle.Inflate(2, 30);
            ButtonPath.AddEllipse(myRectangle);
            panel3.Region = new Region(ButtonPath);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            var ButtonPath = new System.Drawing.Drawing2D.GraphicsPath();
            var myRectangle = panel2.ClientRectangle;
            myRectangle.Inflate(0, 494);
            ButtonPath.AddEllipse(myRectangle);
            panel2.Region = new Region(ButtonPath);
            PaintTransparentBackground(panel2, e);
            using (Brush b = new SolidBrush(Color.FromArgb(140, panel2.BackColor)))
            {
                e.Graphics.FillRectangle(b, e.ClipRectangle);
            }
        }
        private static void PaintTransparentBackground(Control c, PaintEventArgs e)
        {
            if (c.Parent == null || !Application.RenderWithVisualStyles)
                return;

            ButtonRenderer.DrawParentBackground(e.Graphics, c.ClientRectangle, c);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            var ButtonPath = new System.Drawing.Drawing2D.GraphicsPath();
            var myRectangle = panel4.ClientRectangle;
            myRectangle.Inflate(2, 30);
            ButtonPath.AddEllipse(myRectangle);
            panel4.Region = new Region(ButtonPath);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            var ButtonPath = new System.Drawing.Drawing2D.GraphicsPath();
            var myRectangle = panel5.ClientRectangle;
            myRectangle.Inflate(2, 30);
            ButtonPath.AddEllipse(myRectangle);
            panel5.Region = new Region(ButtonPath);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    pictureBox5.Height = pictureBox5.Height - 15;
            //    pictureBox5.Width = pictureBox5.Width - 15;
            //    pictureBox5.Top += 7;
            //    pictureBox5.Left += 7;
            //    Thread.Sleep(50);
            //    Application.DoEvents();
            //}
            //pictureBox5.Image = Image.FromFile("C:/Users/DELL/OneDrive/Máy tính/PBL3/Cuahangdienthoai/Cuahangdienthoai/ICON/samsung-galaxy-s21.jpg");
            //for (int i = 0; i < 10; i++)
            //{
            //    pictureBox5.Height = pictureBox5.Height + 15;
            //    pictureBox5.Width = pictureBox5.Width + 15;
            //    pictureBox5.Top -= 7;
            //    pictureBox5.Left -= 7;
            //    Thread.Sleep(50);
            //    Application.DoEvents();
            //}
        //    Thread t = new Thread(() => { HieuUng(); });
        //    t.Start();
        }
        //public void HieuUng()
        //{
        //    try
        //    {
        //        if (pictureBox5.InvokeRequired)
        //        {
        //            pictureBox5.Invoke(new Action(HieuUng));
        //            return;
        //        }
        //        for(int i = 0; i < 10; i++)
        //        {
        //            pictureBox5.Height = pictureBox5.Height - 15;
        //            pictureBox5.Width = pictureBox5.Width - 15;
        //            pictureBox5.Top += 7;
        //            pictureBox5.Left += 7;
        //            Thread.Sleep(50);
        //            //Application.DoEvents();
        //        }
        //        pictureBox5.Image = Image.FromFile("C:/Users/DELL/OneDrive/Máy tính/PBL3/Cuahangdienthoai/Cuahangdienthoai/ICON/samsung-galaxy-s21.jpg");
        //        for (int i = 0; i < 10; i++)
        //        {
        //            pictureBox5.Height = pictureBox5.Height + 15;
        //            pictureBox5.Width = pictureBox5.Width + 15;
        //            pictureBox5.Top -= 7;
        //            pictureBox5.Left -= 7;
        //            Thread.Sleep(50);
        //            //Application.DoEvents();
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            var ButtonPath = new System.Drawing.Drawing2D.GraphicsPath();
            var myRectangle = panel12.ClientRectangle;
            myRectangle.Inflate(2, 30);
            ButtonPath.AddEllipse(myRectangle);
            panel12.Region = new Region(ButtonPath);
        }
    }
}
