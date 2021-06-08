using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cuahangdienthoai.BUS;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Cuahangdienthoai.View
{
    public partial class QuanLySanPhamForm : Form
    {
        private bool load = false;
        public QuanLySanPhamForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            ShowListPhone();
            SetGUI();
        }
        private void SetGUI()
        {
            dataGridViewsanpham.Columns[0].HeaderText = "";
            dataGridViewsanpham.Columns[1].HeaderText = "Mã Điện Thoại";
            dataGridViewsanpham.Columns[2].HeaderText = "Tên Điện Thoại";
            dataGridViewsanpham.Columns[3].HeaderText = "Số Lượng";
            dataGridViewsanpham.Columns[4].HeaderText = "Giá Gốc";
            dataGridViewsanpham.Columns[4].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewsanpham.Columns[5].HeaderText = "% Giảm Giá";
            dataGridViewsanpham.Columns[5].DefaultCellStyle.Format = "0.## '%'";
            dataGridViewsanpham.Columns[6].HeaderText = "Giảm Còn";
            dataGridViewsanpham.Columns[6].DefaultCellStyle.Format = "#,0 đ";
            dataGridViewsanpham.Columns[7].HeaderText = "Điểm Đánh Giá";
            dataGridViewsanpham.Columns[8].Visible = false;
        }
        public void ShowListPhone()
        {
            dataGridViewsanpham.DataSource = DienThoaiBUS.Instance.GetListDT(tbTimKiem.Text, comboBox1.Text, comboBox2.Text);
            lbSoLuong.Text = dataGridViewsanpham.Rows.Count.ToString();
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            ThemSuaDienThoai f = new ThemSuaDienThoai(null);
            f.d += ShowListPhone;
            f.ShowDialog();
        }

        private void btTimKiêm_Click(object sender, EventArgs e)
        {
            ShowListPhone();
        }

        private void dataGridViewsanpham_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dataGridViewsanpham.SelectedRows.Count == 1)
            {
                string MaDT = dataGridViewsanpham.SelectedRows[0].Cells["MaDT"].Value.ToString();
                ThongTinDienThoai f = new ThongTinDienThoai(Convert.ToInt32(MaDT));
                f.d += ShowListPhone;
                f.Show();
            }
        }

        private void QuanLySanPhamForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                load = true;
            }
            else
            {
                if (load) ShowListPhone();
                load = !load;
            }
        }

        private void btXuatFile_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string Path = Directory.GetParent((Directory.GetParent(Application.StartupPath)).FullName).FullName + @"\Export Excel\Sản Phẩm";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Path;
            string filePath = "";
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            if (string.IsNullOrEmpty(Path))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    p.Workbook.Properties.Title = "Báo cáo thống kê";
                    p.Workbook.Worksheets.Add("Sheet 1");
                    ExcelWorksheet ws = p.Workbook.Worksheets[0];
                    ws.Name = "Sheet 1";
                    ws.DefaultColWidth = 30;
                    ws.Cells.Style.Font.Name = "Calibri";
                    ws.Cells.Style.Font.Size = 12;
                    var countColHeader = 6;
                    ws.Cells[1, 1].Value = "Danh sách sản phẩm (cập nhật ngày " + DateTime.Now.ToShortDateString() + ")";
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Color.SetColor(Color.Red);
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 15;
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    int rowIndex = 2;
                    for (int i = 1; i < 7; i++)
                    {
                        var cell = ws.Cells[rowIndex, i];

                        //set màu
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.LightBlue);

                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Medium;

                        cell.Value = dataGridViewsanpham.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dataGridViewsanpham.RowCount; i++)
                    {
                        for (int j = 1; j < 7; j++)
                        {
                            var border = ws.Cells[i + 3, j].Style.Border;
                            border.Bottom.Style =
                                border.Top.Style =
                                border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Medium;
                            if (j == 5) ws.Cells[i + 3, j].Value = String.Format("{0:0,## '%'}", dataGridViewsanpham.Rows[i].Cells[j].Value);
                            else if (j == 4 || j == 6) 
                            {
                                ws.Cells[i + 3, j].Value = String.Format("{0:#,0 đ}", dataGridViewsanpham.Rows[i].Cells[j].Value);
                            }
                            else ws.Cells[i + 3, j].Value = dataGridViewsanpham.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    //Lưu file lại
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                MessageBox.Show("Xuất excel thành công!");
            }
            catch (Exception ef)
            {
                MessageBox.Show("Có lỗi khi lưu file!\n" + ef.Message);
            }
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            tbTimKiem.Text = "";
            ShowListPhone();
        }
    }
}
