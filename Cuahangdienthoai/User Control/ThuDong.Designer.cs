namespace Cuahangdienthoai
{
    partial class ThuDong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThuDong));
            this.picRestore = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picMaximize = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // picRestore
            // 
            this.picRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picRestore.Image = ((System.Drawing.Image)(resources.GetObject("picRestore.Image")));
            this.picRestore.Location = new System.Drawing.Point(108, 2);
            this.picRestore.Margin = new System.Windows.Forms.Padding(2);
            this.picRestore.Name = "picRestore";
            this.picRestore.Size = new System.Drawing.Size(19, 20);
            this.picRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRestore.TabIndex = 6;
            this.picRestore.TabStop = false;
            this.picRestore.Visible = false;
            this.picRestore.Click += new System.EventHandler(this.picRestore_Click);
            // 
            // picMinimize
            // 
            this.picMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimize.Image = ((System.Drawing.Image)(resources.GetObject("picMinimize.Image")));
            this.picMinimize.Location = new System.Drawing.Point(85, 2);
            this.picMinimize.Margin = new System.Windows.Forms.Padding(2);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(19, 20);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMinimize.TabIndex = 7;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            // 
            // picMaximize
            // 
            this.picMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMaximize.Image = ((System.Drawing.Image)(resources.GetObject("picMaximize.Image")));
            this.picMaximize.Location = new System.Drawing.Point(108, 2);
            this.picMaximize.Margin = new System.Windows.Forms.Padding(2);
            this.picMaximize.Name = "picMaximize";
            this.picMaximize.Size = new System.Drawing.Size(19, 20);
            this.picMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMaximize.TabIndex = 5;
            this.picMaximize.TabStop = false;
            this.picMaximize.Click += new System.EventHandler(this.picMaximize_Click);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.Location = new System.Drawing.Point(132, 2);
            this.picClose.Margin = new System.Windows.Forms.Padding(2);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(19, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picClose.TabIndex = 4;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // ThuDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picRestore);
            this.Controls.Add(this.picMinimize);
            this.Controls.Add(this.picMaximize);
            this.Controls.Add(this.picClose);
            this.Name = "ThuDong";
            this.Size = new System.Drawing.Size(153, 29);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ThuDong_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picRestore;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.PictureBox picMaximize;
        private System.Windows.Forms.PictureBox picClose;
    }
}
