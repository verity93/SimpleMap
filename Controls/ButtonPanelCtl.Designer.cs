namespace SimpleMap.Controls
{ 
    partial class ButtonPanelCtl
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
            this.labelControl1 = new System.Windows.Forms.Label();
            this.btnRefreshMap = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.zoomLevel = new System.Windows.Forms.TrackBar();
            this.btnCenterMap = new System.Windows.Forms.Button();
            this.btnCacheAllMap = new System.Windows.Forms.Button();
            this.btnSaveMapAsImage = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnLoadGeoRefImage = new System.Windows.Forms.Button();
            this.btnShapeData = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.zoomLevel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(3, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 32);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Zoom:";
            this.labelControl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefreshMap
            // 
            this.btnRefreshMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefreshMap.Image = global::SimpleMap.Properties.Resources.refresh_16;
            this.btnRefreshMap.Location = new System.Drawing.Point(3, 3);
            this.btnRefreshMap.Name = "btnRefreshMap";
            this.btnRefreshMap.Size = new System.Drawing.Size(57, 32);
            this.btnRefreshMap.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnRefreshMap, "Refresh Sample Tree");
            this.btnRefreshMap.UseCompatibleTextRendering = true;
            this.btnRefreshMap.UseVisualStyleBackColor = true;
            this.btnRefreshMap.Click += new System.EventHandler(this.btnRefreshMap_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrint.Image = global::SimpleMap.Properties.Resources.print_24;
            this.btnPrint.Location = new System.Drawing.Point(66, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(57, 32);
            this.btnPrint.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnPrint, "Print Map");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // zoomLevel
            // 
            this.zoomLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoomLevel.LargeChange = 2;
            this.zoomLevel.Location = new System.Drawing.Point(53, 3);
            this.zoomLevel.Maximum = 20;
            this.zoomLevel.Minimum = 10;
            this.zoomLevel.Name = "zoomLevel";
            this.zoomLevel.Size = new System.Drawing.Size(253, 26);
            this.zoomLevel.TabIndex = 10;
            this.toolTip1.SetToolTip(this.zoomLevel, "Change map zoom level");
            this.zoomLevel.Value = 12;
            this.zoomLevel.ValueChanged += new System.EventHandler(this.zoomLevel_ValueChanged);
            // 
            // btnCenterMap
            // 
            this.btnCenterMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCenterMap.Image = global::SimpleMap.Properties.Resources.centermap_24;
            this.btnCenterMap.Location = new System.Drawing.Point(444, 3);
            this.btnCenterMap.Name = "btnCenterMap";
            this.btnCenterMap.Size = new System.Drawing.Size(57, 32);
            this.btnCenterMap.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnCenterMap, "Center map");
            this.btnCenterMap.UseVisualStyleBackColor = true;
            this.btnCenterMap.Click += new System.EventHandler(this.btnCenterMap_Click);
            // 
            // btnCacheAllMap
            // 
            this.btnCacheAllMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheAllMap.Image = global::SimpleMap.Properties.Resources.save_2_16x16;
            this.btnCacheAllMap.Location = new System.Drawing.Point(507, 3);
            this.btnCacheAllMap.Name = "btnCacheAllMap";
            this.btnCacheAllMap.Size = new System.Drawing.Size(57, 32);
            this.btnCacheAllMap.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnCacheAllMap, "Download whole map to local disk cache");
            this.btnCacheAllMap.UseVisualStyleBackColor = true;
            this.btnCacheAllMap.Click += new System.EventHandler(this.btnCacheAllMap_Click);
            // 
            // btnSaveMapAsImage
            // 
            this.btnSaveMapAsImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveMapAsImage.Image = global::SimpleMap.Properties.Resources.program_24;
            this.btnSaveMapAsImage.Location = new System.Drawing.Point(570, 3);
            this.btnSaveMapAsImage.Name = "btnSaveMapAsImage";
            this.btnSaveMapAsImage.Size = new System.Drawing.Size(57, 32);
            this.btnSaveMapAsImage.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnSaveMapAsImage, "Save map as image to file");
            this.btnSaveMapAsImage.UseVisualStyleBackColor = true;
            this.btnSaveMapAsImage.Click += new System.EventHandler(this.btnSaveMapAsImage_Click);
            // 
            // btnLoadGeoRefImage
            // 
            this.btnLoadGeoRefImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadGeoRefImage.Location = new System.Drawing.Point(633, 3);
            this.btnLoadGeoRefImage.Name = "btnLoadGeoRefImage";
            this.btnLoadGeoRefImage.Size = new System.Drawing.Size(94, 32);
            this.btnLoadGeoRefImage.TabIndex = 15;
            this.btnLoadGeoRefImage.Text = "Load GeoRef";
            this.toolTip1.SetToolTip(this.btnLoadGeoRefImage, "Load Geo Reference Image");
            this.btnLoadGeoRefImage.UseVisualStyleBackColor = true;
            this.btnLoadGeoRefImage.Click += new System.EventHandler(this.btnLoadGeoRefImage_Click);
            // 
            // btnShapeData
            // 
            this.btnShapeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShapeData.Location = new System.Drawing.Point(733, 3);
            this.btnShapeData.Name = "btnShapeData";
            this.btnShapeData.Size = new System.Drawing.Size(94, 32);
            this.btnShapeData.TabIndex = 16;
            this.btnShapeData.Text = "Shape";
            this.toolTip1.SetToolTip(this.btnShapeData, "Load Shape Data");
            this.btnShapeData.UseVisualStyleBackColor = true;
            this.btnShapeData.Click += new System.EventHandler(this.btnShapeData_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnRefreshMap, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnShapeData, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrint, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadGeoRefImage, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveMapAsImage, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCenterMap, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCacheAllMap, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(830, 38);
            this.tableLayoutPanel1.TabIndex = 17;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.50485F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.49515F));
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.zoomLevel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(129, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(309, 32);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // ButtonPanelCtl
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(20000, 38);
            this.MinimumSize = new System.Drawing.Size(325, 38);
            this.Name = "ButtonPanelCtl";
            this.Size = new System.Drawing.Size(830, 38);
            this.Load += new System.EventHandler(this.FrmDesignPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zoomLevel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelControl1;
        private System.Windows.Forms.Button btnCenterMap;
        private System.Windows.Forms.TrackBar zoomLevel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRefreshMap;
        private System.Windows.Forms.Button btnCacheAllMap;
        private System.Windows.Forms.Button btnSaveMapAsImage;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnLoadGeoRefImage;
        private System.Windows.Forms.Button btnShapeData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
