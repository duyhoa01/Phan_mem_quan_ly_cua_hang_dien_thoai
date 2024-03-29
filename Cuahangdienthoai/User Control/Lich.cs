﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Control
{
    public partial class Lich : UserControl
    {
        public delegate void ValueChanged(object sender, EventArgs e);
        public event ValueChanged valueChanged;
        public bool ShowCalendar = false;
        public Lich()
        {
            InitializeComponent();
            tbNgay.Text = monthCalendar1.TodayDate.ToString("dd/MM/yyyy");
            monthCalendar1.Location = new Point(0, 28);
        }
        private void ShowLich()
        {
            if (this.Width < 227) this.Width = 227;
            this.Height += 162;
            monthCalendar1.Show();
        }
        private void HideLich()
        {
            tbNgay.Text = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
            monthCalendar1.Hide();
            this.Size = new Size(panel10.Width, panel10.Height);
            valueChanged?.Invoke(this, EventArgs.Empty);
        }
        private void XuLy()
        {
            if (ShowCalendar) ShowLich();
            else HideLich();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            ShowCalendar = !ShowCalendar;
            XuLy();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            ShowCalendar = false;
            XuLy();
        }
        public DateTime GetDateTime()
        {
            String[] time = tbNgay.Text.Split('/');
            return new DateTime(Convert.ToInt32(time[2]), Convert.ToInt32(time[1]), Convert.ToInt32(time[0]));
        }
        public Color SetBackColor
        {
            set
            {
                panel10.BackColor = value;
                tbNgay.BackColor = value;
                button16.BackColor = value;
            }
        }
        public void SetDateTime(DateTime date)
        {
            monthCalendar1.SelectionStart =date;
            XuLy();
        }
    }
}
