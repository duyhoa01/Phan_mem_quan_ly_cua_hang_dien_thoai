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
using Cuahangdienthoai.BUS;
using Cuahangdienthoai.DTO;
using System.Globalization;

namespace Cuahangdienthoai.View
{
    public partial class BaoCaoKinhDoanhForm : Form
    {
        public BaoCaoKinhDoanhForm()
        {
            InitializeComponent();
            panel2.Visible = false;
            comboBox1.SelectedIndex = 0;
            setGuiBieuDo();
            lbFrom.Text = "Hôm nay";
            lbTo.Text = "";
            lbDoanhThuTiLe.Text = "";
            lbHoaDonTiLe.Text = "";
            lbKhachHangTiLe.Text = "";
            lbLoiNhuanTiLe.Text = "";
            fistTime = DateTime.Now.Date;
            lastTime = DateTime.Now;
            fistTimeCp = fistTime.AddDays(-1).Date;
            lastTimeCp = fistTimeCp.AddDays(1);
            checkBox2.Checked = true;
            Button1();
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
            myRectangle.Inflate(0, 496);
            ButtonPath.AddEllipse(myRectangle);
            panel2.Region = new Region(ButtonPath);
            //PaintTransparentBackground(panel2, e);
            //using (Brush b = new SolidBrush(Color.FromArgb(140, panel2.BackColor)))
            //{
            //    e.Graphics.FillRectangle(b, e.ClipRectangle);
            //}


        }
        //private static void PaintTransparentBackground(Control c, PaintEventArgs e)
        //{
        //    if (c.Parent == null || !Application.RenderWithVisualStyles)
        //        return;

        //    ButtonRenderer.DrawParentBackground(e.Graphics, c.ClientRectangle, c);
        //}

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

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            var ButtonPath = new System.Drawing.Drawing2D.GraphicsPath();
            var myRectangle = panel12.ClientRectangle;
            myRectangle.Inflate(2, 30);
            ButtonPath.AddEllipse(myRectangle);
            panel12.Region = new Region(ButtonPath);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                fistTime = dateTimePickerFrom.Value.Date;
                lastTime = dateTimePickerTo.Value.AddDays(1).Date;
                lbFrom.Text = fistTime.Day+"/"+ fistTime.Month+"/"+fistTime.Year+"->";
                lbTo.Text = lastTime.AddDays(-1).Day+"/"+lastTime.Month+"/" +lastTime.Year;
            }  
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                lbFrom.Text = "Hôm nay";
                lbTo.Text = "";
                fistTime = DateTime.Now.Date;
                lastTime = DateTime.Now;
                fistTimeCp = fistTime.AddDays(-1).Date;
                lastTimeCp = fistTimeCp.AddDays(1);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                fistTime = NgayCuaTuan(DateTime.Now.Date);
                lastTime = DateTime.Now;
                fistTimeCp = fistTime.AddDays(-7);
                lastTimeCp = fistTime;
                lbFrom.Text = "Tuần này";
                lbTo.Text = "";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = false;

                fistTime = GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
                lbFrom.Text = "Tháng này";
                lbTo.Text = "";
                lastTime = DateTime.Now;
                fistTimeCp = GetFistDayInMonth(fistTime.AddDays(-1).Year,fistTime.AddDays(-1).Month);
                lastTimeCp = fistTime;
            }
        }
        public static DateTime NgayCuaTuan(DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                DateTime dateTime= date.AddDays(-6);
              
                return date.AddDays(-6);
            }
            int offset = dayOfWeek - DayOfWeek.Monday;
            return date.AddDays(-offset);
        }
        public static DateTime GetFistDayInMonth(int year,int month)
        {
            DateTime dateTime = new DateTime(year, month, 1);
            return dateTime;
        }
        private static DateTime fistTime;
        private static DateTime lastTime;
        private static DateTime fistTimeCp;
        private static DateTime lastTimeCp;
        private void button1_Click(object sender, EventArgs e)
        {
            Button1();     
        }
        public void Button1()
        {
            lbDoanhThu.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", BaoCaoBUS.Instance.GetTongTien(fistTime, lastTime));
            lbHoaDon.Text = BaoCaoBUS.Instance.CountHoaDon(fistTime, lastTime) + "";
            lbKhachHang.Text = BaoCaoBUS.Instance.CountKhachHang(fistTime, lastTime) + "";
            lbLoiNhuan.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}",BaoCaoBUS.Instance.GetLoiNhuan(fistTime, lastTime));
            SetGuiTiLe();
            panel2.Visible = false;
        }
        private void SetGuiTiLe()
        {
            if ((checkBox2.Checked == true||checkBox3.Checked==true||checkBox4.Checked==true)
                && BaoCaoBUS.Instance.GetTongTien(fistTimeCp, lastTimeCp) != 0)
            {
                GetLuacChon();
                double tile1 = BaoCaoBUS.Instance.GetTongTien(fistTime, lastTime) /
                BaoCaoBUS.Instance.GetTongTien(fistTimeCp, lastTimeCp);
                if (tile1 >= 1)
                {
                    lbDoanhThuTiLe.Text = string.Format("{0:N2}%", tile1 * 100) + luachon;
                    lbDoanhThuTiLe.ForeColor = Color.Green;
                }
                else if (tile1 < 1)
                {
                    lbDoanhThuTiLe.Text = string.Format("{0:N2}%", tile1 * 100) + luachon;
                    lbDoanhThuTiLe.ForeColor = Color.Red;
                }
                double tile2 = BaoCaoBUS.Instance.CountHoaDon(fistTime, lastTime)*1.0 /
                    BaoCaoBUS.Instance.CountHoaDon(fistTimeCp, lastTimeCp)*1.0;
                if (tile2 >= 1)
                {
                    lbHoaDonTiLe.Text = string.Format("{0:N2}%", tile2 * 100) + luachon;
                    lbHoaDonTiLe.ForeColor = Color.Green;
                }
                else if (tile2 < 1)
                {
                    lbHoaDonTiLe.Text = string.Format("{0:N2}%", tile2 * 100) + luachon;
                    lbHoaDonTiLe.ForeColor = Color.Red;
                }
                double tile3 = BaoCaoBUS.Instance.CountKhachHang(fistTime, lastTime)*1.0 /
                    BaoCaoBUS.Instance.CountKhachHang(fistTimeCp, lastTimeCp)*1.0;
                if (tile3 >= 1)
                {
                    lbKhachHangTiLe.Text = string.Format("{0:N2}%", tile3 * 100) + luachon;
                    lbKhachHangTiLe.ForeColor = Color.Green;
                }
                else if (tile3 < 1)
                {
                    lbKhachHangTiLe.Text = string.Format("{0:N2}%", tile3 * 100) + luachon;
                    lbKhachHangTiLe.ForeColor = Color.Red;
                }
                double tile4 = BaoCaoBUS.Instance.GetLoiNhuan(fistTime, lastTime) /
                    BaoCaoBUS.Instance.GetLoiNhuan(fistTimeCp, lastTimeCp);
                if (tile4 >= 1)
                {
                    lbLoiNhuanTiLe.Text = string.Format("{0:N2}%", tile4 * 100) + luachon;
                    lbLoiNhuanTiLe.ForeColor = Color.Green;
                }
                else if (tile4 < 1)
                {
                    lbLoiNhuanTiLe.Text = string.Format("{0:N2}%", tile4 * 100) + luachon;
                    lbLoiNhuanTiLe.ForeColor = Color.Red;
                }        
            } else if (checkBox1.Checked == true)
            {
                lbDoanhThuTiLe.Text = "";
                lbHoaDonTiLe.Text = "";
                lbKhachHangTiLe.Text = "";
                lbLoiNhuanTiLe.Text = "";
            }
            else
            {
                lbDoanhThuTiLe.Text = "";
                lbHoaDonTiLe.Text = "";
                lbKhachHangTiLe.Text = "";
                lbLoiNhuanTiLe.Text = "";
            }
        }
        private String luachon;
        private void GetLuacChon()
        {
            if (checkBox2.Checked == true)
            {
                luachon = " so với hôm qua";
            } else if (checkBox3.Checked == true)
            {
                luachon = " so với tuần vừa rồi";
            } else if (checkBox4.Checked == true)
            {
                luachon = " so với tháng vừa rồi";
            }
        }
        public void setGuiBieuDo()
        {
            List<DoanhThuLoiNhuan> list = new List<DoanhThuLoiNhuan>();
            if (comboBox1.SelectedIndex == 0)
            {
                list= BaoCaoBUS.Instance.GetDoanhThuLoiNhuan(0);
            } else if(comboBox1.SelectedIndex == 1)
            {
                list = BaoCaoBUS.Instance.GetDoanhThuLoiNhuan(1);
            } else if (comboBox1.SelectedIndex == 2)
            {
                list = BaoCaoBUS.Instance.GetDoanhThuLoiNhuan(2);
            }
            foreach(var series in chartLoiNhuanCot.Series)
            {
                series.Points.Clear();
            }
            int t = list.Count - 1;
            for(int i = list.Count-1; i >=0 ; i--)
            {
                chartLoiNhuanCot.Series[0].Points.Add((double)list[i].DoanhThu);
                //chartLoiNhuanCot.Series[0].Points[t-i].Label = list[i].DoanhThu.ToString();
                chartLoiNhuanCot.Series[0].Points[t-i].AxisLabel = list[i].ThoiGian;

                chartLoiNhuanCot.Series[1].Points.Add((double)list[i].LoiNhuan);
                //chartLoiNhuanCot.Series[1].Points[t-i].Label = list[i].LoiNhuan.ToString();
            }
            chartLoiNhuanCot.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            List<DoanhThuLoiNhuan> list2 = list;
            Double TongLoiNhuan = 0;
            foreach(DoanhThuLoiNhuan l in list2)
            {
                TongLoiNhuan += l.LoiNhuan;
            }
            if(TongLoiNhuan!=0)
            {              
                foreach (DoanhThuLoiNhuan l in list2)
                {
                    l.LoiNhuan = l.LoiNhuan / TongLoiNhuan * 1.0;
                }          
            }
            chartBieuDoTron.DataSource = list2;
            chartBieuDoTron.Series[0].XValueMember = "ThoiGian";
            chartBieuDoTron.Series[0].YValueMembers = "LoiNhuan";
            chartBieuDoTron.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartBieuDoTron.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
        }


        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                fistTime = dateTimePickerFrom.Value.Date;
                lastTime = dateTimePickerTo.Value.AddDays(1).Date;
                lbFrom.Text = fistTime.Day + "/" + fistTime.Month + "/" + fistTime.Year + "->";
                lbTo.Text = lastTime.AddDays(-1).Day + "/" + lastTime.Month + "/" + lastTime.Year;
            }
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                fistTime = dateTimePickerFrom.Value.Date;
                lastTime = dateTimePickerTo.Value.AddDays(1).Date;
                lbFrom.Text = fistTime.Day + "/" + fistTime.Month + "/" + fistTime.Year + "->";
                lbTo.Text = lastTime.AddDays(-1).Day + "/" + lastTime.Month + "/" + lastTime.Year;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setGuiBieuDo();
        }
    }
}
