namespace SimpleMap.Controls
{
    partial class RegisterImageCtl
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtysize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtxsize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBR_Y = new System.Windows.Forms.TextBox();
            this.txtBR_X = new System.Windows.Forms.TextBox();
            this.txtTR_Y = new System.Windows.Forms.TextBox();
            this.txtTR_X = new System.Windows.Forms.TextBox();
            this.txtBL_Y = new System.Windows.Forms.TextBox();
            this.txtBL_X = new System.Windows.Forms.TextBox();
            this.txtTL_Y = new System.Windows.Forms.TextBox();
            this.rbBR = new System.Windows.Forms.RadioButton();
            this.rbTR = new System.Windows.Forms.RadioButton();
            this.rbBL = new System.Windows.Forms.RadioButton();
            this.rbTL = new System.Windows.Forms.RadioButton();
            this.txtTL_X = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trbZoomFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.lblZoomFactor.Size = new System.Drawing.Size(18, 13);
            this.lblZoomFactor.TabIndex = 10;
            this.lblZoomFactor.Text = "x3";
            // 
            // trbZoomFactor
            // 
            this.trbZoomFactor.LargeChange = 1;
            this.trbZoomFactor.Location = new System.Drawing.Point(46, 6);
            this.trbZoomFactor.Minimum = 2;
            this.trbZoomFactor.Name = "trbZoomFactor";
            this.trbZoomFactor.Size = new System.Drawing.Size(300, 45);
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
            this.picZoom.Size = new System.Drawing.Size(440, 234);
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
            this.picImage.Size = new System.Drawing.Size(622, 652);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 446F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.picImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1074, 658);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtysize);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtxsize);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(631, 335);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(440, 145);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Image Registration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Image Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "px";
            // 
            // txtysize
            // 
            this.txtysize.Location = new System.Drawing.Point(237, 32);
            this.txtysize.Margin = new System.Windows.Forms.Padding(4);
            this.txtysize.Name = "txtysize";
            this.txtysize.Size = new System.Drawing.Size(67, 20);
            this.txtysize.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(245, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "Height";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(211, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "px";
            // 
            // txtxsize
            // 
            this.txtxsize.Location = new System.Drawing.Point(136, 32);
            this.txtxsize.Margin = new System.Windows.Forms.Padding(4);
            this.txtxsize.Name = "txtxsize";
            this.txtxsize.Size = new System.Drawing.Size(67, 20);
            this.txtxsize.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Width";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBR_Y);
            this.groupBox1.Controls.Add(this.txtBR_X);
            this.groupBox1.Controls.Add(this.txtTR_Y);
            this.groupBox1.Controls.Add(this.txtTR_X);
            this.groupBox1.Controls.Add(this.txtBL_Y);
            this.groupBox1.Controls.Add(this.txtBL_X);
            this.groupBox1.Controls.Add(this.txtTL_Y);
            this.groupBox1.Controls.Add(this.rbBR);
            this.groupBox1.Controls.Add(this.rbTR);
            this.groupBox1.Controls.Add(this.rbBL);
            this.groupBox1.Controls.Add(this.rbTL);
            this.groupBox1.Controls.Add(this.txtTL_X);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 52);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(434, 90);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Control Points";
            // 
            // txtBR_Y
            // 
            this.txtBR_Y.Location = new System.Drawing.Point(387, 58);
            this.txtBR_Y.Margin = new System.Windows.Forms.Padding(4);
            this.txtBR_Y.Name = "txtBR_Y";
            this.txtBR_Y.Size = new System.Drawing.Size(35, 20);
            this.txtBR_Y.TabIndex = 63;
            // 
            // txtBR_X
            // 
            this.txtBR_X.Location = new System.Drawing.Point(351, 58);
            this.txtBR_X.Margin = new System.Windows.Forms.Padding(4);
            this.txtBR_X.Name = "txtBR_X";
            this.txtBR_X.Size = new System.Drawing.Size(35, 20);
            this.txtBR_X.TabIndex = 62;
            // 
            // txtTR_Y
            // 
            this.txtTR_Y.Location = new System.Drawing.Point(387, 20);
            this.txtTR_Y.Margin = new System.Windows.Forms.Padding(4);
            this.txtTR_Y.Name = "txtTR_Y";
            this.txtTR_Y.Size = new System.Drawing.Size(35, 20);
            this.txtTR_Y.TabIndex = 61;
            // 
            // txtTR_X
            // 
            this.txtTR_X.Location = new System.Drawing.Point(351, 20);
            this.txtTR_X.Margin = new System.Windows.Forms.Padding(4);
            this.txtTR_X.Name = "txtTR_X";
            this.txtTR_X.Size = new System.Drawing.Size(35, 20);
            this.txtTR_X.TabIndex = 60;
            // 
            // txtBL_Y
            // 
            this.txtBL_Y.Location = new System.Drawing.Point(164, 58);
            this.txtBL_Y.Margin = new System.Windows.Forms.Padding(4);
            this.txtBL_Y.Name = "txtBL_Y";
            this.txtBL_Y.Size = new System.Drawing.Size(35, 20);
            this.txtBL_Y.TabIndex = 59;
            // 
            // txtBL_X
            // 
            this.txtBL_X.Location = new System.Drawing.Point(128, 58);
            this.txtBL_X.Margin = new System.Windows.Forms.Padding(4);
            this.txtBL_X.Name = "txtBL_X";
            this.txtBL_X.Size = new System.Drawing.Size(35, 20);
            this.txtBL_X.TabIndex = 58;
            // 
            // txtTL_Y
            // 
            this.txtTL_Y.Location = new System.Drawing.Point(164, 20);
            this.txtTL_Y.Margin = new System.Windows.Forms.Padding(4);
            this.txtTL_Y.Name = "txtTL_Y";
            this.txtTL_Y.Size = new System.Drawing.Size(35, 20);
            this.txtTL_Y.TabIndex = 57;
            // 
            // rbBR
            // 
            this.rbBR.AutoSize = true;
            this.rbBR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbBR.Location = new System.Drawing.Point(215, 60);
            this.rbBR.Margin = new System.Windows.Forms.Padding(4);
            this.rbBR.Name = "rbBR";
            this.rbBR.Size = new System.Drawing.Size(86, 17);
            this.rbBR.TabIndex = 56;
            this.rbBR.Text = "Bottom Right";
            this.rbBR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbBR.UseVisualStyleBackColor = true;
            // 
            // rbTR
            // 
            this.rbTR.AutoSize = true;
            this.rbTR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbTR.Location = new System.Drawing.Point(240, 22);
            this.rbTR.Margin = new System.Windows.Forms.Padding(4);
            this.rbTR.Name = "rbTR";
            this.rbTR.Size = new System.Drawing.Size(72, 17);
            this.rbTR.TabIndex = 55;
            this.rbTR.Text = "Top Right";
            this.rbTR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbTR.UseVisualStyleBackColor = true;
            // 
            // rbBL
            // 
            this.rbBL.AutoSize = true;
            this.rbBL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbBL.Location = new System.Drawing.Point(-1, 63);
            this.rbBL.Margin = new System.Windows.Forms.Padding(4);
            this.rbBL.Name = "rbBL";
            this.rbBL.Size = new System.Drawing.Size(79, 17);
            this.rbBL.TabIndex = 52;
            this.rbBL.Text = "Bottom Left";
            this.rbBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbBL.UseVisualStyleBackColor = true;
            // 
            // rbTL
            // 
            this.rbTL.AutoSize = true;
            this.rbTL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbTL.Checked = true;
            this.rbTL.Location = new System.Drawing.Point(24, 22);
            this.rbTL.Margin = new System.Windows.Forms.Padding(4);
            this.rbTL.Name = "rbTL";
            this.rbTL.Size = new System.Drawing.Size(65, 17);
            this.rbTL.TabIndex = 51;
            this.rbTL.TabStop = true;
            this.rbTL.Text = "Top Left";
            this.rbTL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbTL.UseVisualStyleBackColor = true;
            // 
            // txtTL_X
            // 
            this.txtTL_X.Location = new System.Drawing.Point(128, 20);
            this.txtTL_X.Margin = new System.Windows.Forms.Padding(4);
            this.txtTL_X.Name = "txtTL_X";
            this.txtTL_X.Size = new System.Drawing.Size(35, 20);
            this.txtTL_X.TabIndex = 49;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picZoom);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(631, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 326);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLoadImage);
            this.panel2.Controls.Add(this.btnSelectColor);
            this.panel2.Controls.Add(this.trbZoomFactor);
            this.panel2.Controls.Add(this.lblZoomFactor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 92);
            this.panel2.TabIndex = 12;
            // 
            // RegisterImageCtl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(325, 38);
            this.Name = "RegisterImageCtl";
            this.Size = new System.Drawing.Size(1074, 658);
            this.Load += new System.EventHandler(this.FrmDesignPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbZoomFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtysize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtxsize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbBR;
        private System.Windows.Forms.RadioButton rbTR;
        private System.Windows.Forms.RadioButton rbBL;
        private System.Windows.Forms.RadioButton rbTL;
        private System.Windows.Forms.TextBox txtTL_X;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBR_Y;
        private System.Windows.Forms.TextBox txtBR_X;
        private System.Windows.Forms.TextBox txtTR_Y;
        private System.Windows.Forms.TextBox txtTR_X;
        private System.Windows.Forms.TextBox txtBL_Y;
        private System.Windows.Forms.TextBox txtBL_X;
        private System.Windows.Forms.TextBox txtTL_Y;
    }
}
