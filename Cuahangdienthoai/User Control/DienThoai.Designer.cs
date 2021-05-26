namespace User_Control
{
    partial class DienThoai
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DienThoai));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbTenDT = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbMaSP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbSL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbGia = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 201);
            this.panel1.TabIndex = 0;
            this.panel1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.panel1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(8, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbTenDT);
            this.panel2.Location = new System.Drawing.Point(0, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 29);
            this.panel2.TabIndex = 1;
            this.panel2.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.panel2.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // tbTenDT
            // 
            this.tbTenDT.BackColor = System.Drawing.Color.White;
            this.tbTenDT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTenDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenDT.Location = new System.Drawing.Point(0, 0);
            this.tbTenDT.Multiline = true;
            this.tbTenDT.Name = "tbTenDT";
            this.tbTenDT.ReadOnly = true;
            this.tbTenDT.Size = new System.Drawing.Size(172, 26);
            this.tbTenDT.TabIndex = 2;
            this.tbTenDT.Text = "Tên Điện Thoại";
            this.tbTenDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTenDT.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.tbTenDT.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.tbTenDT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbMaSP);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(32, 224);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(108, 25);
            this.panel3.TabIndex = 2;
            this.panel3.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.panel3.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // lbMaSP
            // 
            this.lbMaSP.AutoSize = true;
            this.lbMaSP.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lbMaSP.Location = new System.Drawing.Point(81, 0);
            this.lbMaSP.Name = "lbMaSP";
            this.lbMaSP.Size = new System.Drawing.Size(27, 16);
            this.lbMaSP.TabIndex = 5;
            this.lbMaSP.Text = "Mã";
            this.lbMaSP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbMaSP.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.lbMaSP.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.lbMaSP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã SP:";
            this.label1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.label1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbSL);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.lbGia);
            this.panel4.Location = new System.Drawing.Point(0, 251);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(172, 25);
            this.panel4.TabIndex = 6;
            this.panel4.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.panel4.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // lbSL
            // 
            this.lbSL.AutoSize = true;
            this.lbSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSL.Location = new System.Drawing.Point(132, 3);
            this.lbSL.Name = "lbSL";
            this.lbSL.Size = new System.Drawing.Size(36, 16);
            this.lbSL.TabIndex = 5;
            this.lbSL.Text = "1000";
            this.lbSL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbSL.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.lbSL.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.lbSL.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(98, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "|  SL:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.label5.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.label5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // lbGia
            // 
            this.lbGia.AutoSize = true;
            this.lbGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGia.ForeColor = System.Drawing.Color.Red;
            this.lbGia.Location = new System.Drawing.Point(9, 3);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(29, 16);
            this.lbGia.TabIndex = 4;
            this.lbGia.Text = "Giá";
            this.lbGia.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.lbGia.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.lbGia.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // DienThoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DienThoai";
            this.Size = new System.Drawing.Size(172, 276);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbTenDT;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbMaSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbSL;
        private System.Windows.Forms.Label lbGia;
        private System.Windows.Forms.Label label5;
    }
}
