namespace SimpleMap.Controls
{
    partial class ImageZoomer
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.lblZoomFactor = new System.Windows.Forms.Label();
            this.trbZoomFactor = new System.Windows.Forms.TrackBar();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.picZoom = new System.Windows.Forms.PictureBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trbZoomFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(277, 38);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(112, 34);
            this.btnSelectColor.TabIndex = 11;
            this.btnSelectColor.Text = "Background";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // lblZoomFactor
            // 
            this.lblZoomFactor.AutoSize = true;
            this.lblZoomFactor.Location = new System.Drawing.Point(386, 14);
            this.lblZoomFactor.Name = "lblZoomFactor";
            this.lblZoomFactor.Size = new System.Drawing.Size(25, 20);
            this.lblZoomFactor.TabIndex = 10;
            this.lblZoomFactor.Text = "x3";
            // 
            // trbZoomFactor
            // 
            this.trbZoomFactor.LargeChange = 1;
            this.trbZoomFactor.Location = new System.Drawing.Point(46, 6);
            this.trbZoomFactor.Minimum = 2;
            this.trbZoomFactor.Name = "trbZoomFactor";
            this.trbZoomFactor.Size = new System.Drawing.Size(300, 69);
            this.trbZoomFactor.TabIndex = 9;
            this.trbZoomFactor.Value = 3;
            this.trbZoomFactor.Scroll += new System.EventHandler(this.trbZoomFactor_ValueChanged);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(41, 38);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(125, 34);
            this.btnLoadImage.TabIndex = 8;
            this.btnLoadImage.Text = "Load image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // picZoom
            // 
            this.picZoom.BackColor = System.Drawing.Color.White;
            this.picZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picZoom.Location = new System.Drawing.Point(0, 0);
            this.picZoom.Name = "picZoom";
            this.picZoom.Size = new System.Drawing.Size(416, 340);
            this.picZoom.TabIndex = 7;
            this.picZoom.TabStop = false;
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.White;
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.Location = new System.Drawing.Point(3, 3);
            this.picImage.Name = "picImage";
            this.tableLayoutPanel1.SetRowSpan(this.picImage, 3);
            this.picImage.Size = new System.Drawing.Size(609, 629);
            this.picImage.TabIndex = 6;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            this.picImage.Paint += new System.Windows.Forms.PaintEventHandler(this.picImage_Paint);
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseMove);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 422F));
            this.tableLayoutPanel1.Controls.Add(this.picImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 438F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1037, 635);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picZoom);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(618, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 432);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLoadImage);
            this.panel2.Controls.Add(this.btnSelectColor);
            this.panel2.Controls.Add(this.trbZoomFactor);
            this.panel2.Controls.Add(this.lblZoomFactor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 340);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 92);
            this.panel2.TabIndex = 12;
            // 
            // ImageZoomCtl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(325, 38);
            this.Name = "ImageZoomCtl";
            this.Size = new System.Drawing.Size(1037, 635);
            this.Load += new System.EventHandler(this.FrmDesignPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbZoomFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Label lblZoomFactor;
        private System.Windows.Forms.TrackBar trbZoomFactor;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.PictureBox picZoom;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
