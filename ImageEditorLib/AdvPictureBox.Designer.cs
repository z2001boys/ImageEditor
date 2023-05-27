namespace ImageEditorLib
{
    partial class AdvPictureBox
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvPictureBox));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenFileBtn = new System.Windows.Forms.ToolStripButton();
            this.DrawRectangleBtn = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PixelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.RGBInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.ClearObjectBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileBtn,
            this.DrawRectangleBtn,
            this.ClearObjectBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(412, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenFileBtn
            // 
            this.OpenFileBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileBtn.Image")));
            this.OpenFileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFileBtn.Name = "OpenFileBtn";
            this.OpenFileBtn.Size = new System.Drawing.Size(23, 22);
            this.OpenFileBtn.Text = "OpenImage";
            this.OpenFileBtn.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // DrawRectangleBtn
            // 
            this.DrawRectangleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawRectangleBtn.Image = ((System.Drawing.Image)(resources.GetObject("DrawRectangleBtn.Image")));
            this.DrawRectangleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawRectangleBtn.Name = "DrawRectangleBtn";
            this.DrawRectangleBtn.Size = new System.Drawing.Size(23, 22);
            this.DrawRectangleBtn.Text = "DrawRectangle";
            this.DrawRectangleBtn.Click += new System.EventHandler(this.DrawRectangleBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"影像檔案|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;*.tiff;*.ico\"";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 276);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(412, 276);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PixelInfo,
            this.RGBInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 301);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(412, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PixelInfo
            // 
            this.PixelInfo.Name = "PixelInfo";
            this.PixelInfo.Size = new System.Drawing.Size(30, 17);
            this.PixelInfo.Text = "Pos:";
            // 
            // RGBInfo
            // 
            this.RGBInfo.Name = "RGBInfo";
            this.RGBInfo.Size = new System.Drawing.Size(34, 17);
            this.RGBInfo.Text = "RGB:";
            // 
            // ClearObjectBtn
            // 
            this.ClearObjectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearObjectBtn.Image = ((System.Drawing.Image)(resources.GetObject("ClearObjectBtn.Image")));
            this.ClearObjectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearObjectBtn.Name = "ClearObjectBtn";
            this.ClearObjectBtn.Size = new System.Drawing.Size(23, 22);
            this.ClearObjectBtn.Text = "toolStripButton1";
            this.ClearObjectBtn.Click += new System.EventHandler(this.ClearObjectBtn_Click);
            // 
            // AdvPictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "AdvPictureBox";
            this.Size = new System.Drawing.Size(412, 323);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton OpenFileBtn;
        private System.Windows.Forms.ToolStripButton DrawRectangleBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel PixelInfo;
        private System.Windows.Forms.ToolStripStatusLabel RGBInfo;
        private System.Windows.Forms.ToolStripButton ClearObjectBtn;
    }
}
