using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cuahangdienthoai.View;

namespace Cuahangdienthoai
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HoaDonBanChiTietForm form1 = new HoaDonBanChiTietForm();
            Application.Run(form1);
        }
    }
}
