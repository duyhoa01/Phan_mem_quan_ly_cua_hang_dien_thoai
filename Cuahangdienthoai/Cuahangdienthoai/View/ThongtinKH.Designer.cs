
namespace Cuahangdienthoai.View
{
    partial class ThongTinKH
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbMaKH = new System.Windows.Forms.TextBox();
            this.tbCMND = new System.Windows.Forms.TextBox();
            this.tbDC = new System.Windows.Forms.TextBox();
            this.tbSDT = new System.Windows.Forms.TextBox();
            this.tbTenKH = new System.Windows.Forms.TextBox();
            this.lbMaKH = new System.Windows.Forms.Label();
            this.lbTenKH = new System.Windows.Forms.Label();
            this.lbDT = new System.Windows.Forms.Label();
            this.lbDC = new System.Windows.Forms.Label();
            this.lbCMND = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMaKH
            // 
            this.tbMaKH.Location = new System.Drawing.Point(168, 43);
            this.tbMaKH.Name = "tbMaKH";
            this.tbMaKH.Size = new System.Drawing.Size(186, 22);
            this.tbMaKH.TabIndex = 0;
            // 
            // tbCMND
            // 
            this.tbCMND.Location = new System.Drawing.Point(467, 118);
            this.tbCMND.Name = "tbCMND";
            this.tbCMND.Size = new System.Drawing.Size(186, 22);
            this.tbCMND.TabIndex = 4;
            // 
            // tbDC
            // 
            this.tbDC.Location = new System.Drawing.Point(467, 43);
            this.tbDC.Name = "tbDC";
            this.tbDC.Size = new System.Drawing.Size(186, 22);
            this.tbDC.TabIndex = 3;
            // 
            // tbSDT
            // 
            this.tbSDT.Location = new System.Drawing.Point(168, 188);
            this.tbSDT.Name = "tbSDT";
            this.tbSDT.Size = new System.Drawing.Size(186, 22);
            this.tbSDT.TabIndex = 2;
            // 
            // tbTenKH
            // 
            this.tbTenKH.Location = new System.Drawing.Point(168, 118);
            this.tbTenKH.Name = "tbTenKH";
            this.tbTenKH.Size = new System.Drawing.Size(186, 22);
            this.tbTenKH.TabIndex = 1;
            // 
            // lbMaKH
            // 
            this.lbMaKH.AutoSize = true;
            this.lbMaKH.Location = new System.Drawing.Point(27, 48);
            this.lbMaKH.Name = "lbMaKH";
            this.lbMaKH.Size = new System.Drawing.Size(113, 17);
            this.lbMaKH.TabIndex = 5;
            this.lbMaKH.Text = "Mã khách hàng :";
            // 
            // lbTenKH
            // 
            this.lbTenKH.AutoSize = true;
            this.lbTenKH.Location = new System.Drawing.Point(27, 123);
            this.lbTenKH.Name = "lbTenKH";
            this.lbTenKH.Size = new System.Drawing.Size(119, 17);
            this.lbTenKH.TabIndex = 6;
            this.lbTenKH.Text = "Tên khách hàng :";
            // 
            // lbDT
            // 
            this.lbDT.AutoSize = true;
            this.lbDT.Location = new System.Drawing.Point(27, 193);
            this.lbDT.Name = "lbDT";
            this.lbDT.Size = new System.Drawing.Size(80, 17);
            this.lbDT.TabIndex = 7;
            this.lbDT.Text = "Điện thoại :";
            // 
            // lbDC
            // 
            this.lbDC.AutoSize = true;
            this.lbDC.Location = new System.Drawing.Point(402, 48);
            this.lbDC.Name = "lbDC";
            this.lbDC.Size = new System.Drawing.Size(59, 17);
            this.lbDC.TabIndex = 8;
            this.lbDC.Text = "Địa chỉ :";
            // 
            // lbCMND
            // 
            this.lbCMND.AutoSize = true;
            this.lbCMND.Location = new System.Drawing.Point(402, 123);
            this.lbCMND.Name = "lbCMND";
            this.lbCMND.Size = new System.Drawing.Size(56, 17);
            this.lbCMND.TabIndex = 9;
            this.lbCMND.Text = "CMND :";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(225, 272);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 54);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(375, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 54);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ThongTinKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 345);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbCMND);
            this.Controls.Add(this.lbDC);
            this.Controls.Add(this.lbDT);
            this.Controls.Add(this.lbTenKH);
            this.Controls.Add(this.lbMaKH);
            this.Controls.Add(this.tbTenKH);
            this.Controls.Add(this.tbSDT);
            this.Controls.Add(this.tbDC);
            this.Controls.Add(this.tbCMND);
            this.Controls.Add(this.tbMaKH);
            this.Name = "ThongTinKH";
            this.Text = "Thông tin khách hàng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMaKH;
        private System.Windows.Forms.TextBox tbCMND;
        private System.Windows.Forms.TextBox tbDC;
        private System.Windows.Forms.TextBox tbSDT;
        private System.Windows.Forms.TextBox tbTenKH;
        private System.Windows.Forms.Label lbMaKH;
        private System.Windows.Forms.Label lbTenKH;
        private System.Windows.Forms.Label lbDT;
        private System.Windows.Forms.Label lbDC;
        private System.Windows.Forms.Label lbCMND;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}