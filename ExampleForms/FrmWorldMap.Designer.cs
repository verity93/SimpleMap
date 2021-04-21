namespace ProgramMain.ExampleForms
{
    partial class FrmWorldMap
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.simpleMapDb1 = new ProgramMain.ExampleDb.SimpleMapDb();
            this.imageZoomlCtl1 = new ProgramMain.ExampleForms.Controls.RegisterImageCtl();
            this.registerImageCtl1 = new ProgramMain.ExampleForms.Controls.RegisterImageCtl();
            this.registerMapCtl1 = new ProgramMain.ExampleForms.Controls.RegisterMapCtl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.simpleMapDb1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // simpleMapDb1
            // 
            this.simpleMapDb1.DataSetName = "SimpleMapDb";
            this.simpleMapDb1.EnforceConstraints = false;
            this.simpleMapDb1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // imageZoomlCtl1
            // 
            this.imageZoomlCtl1.Location = new System.Drawing.Point(511, 2);
            this.imageZoomlCtl1.MinimumSize = new System.Drawing.Size(325, 38);
            this.imageZoomlCtl1.Name = "imageZoomlCtl1";
            this.imageZoomlCtl1.Size = new System.Drawing.Size(432, 335);
            this.imageZoomlCtl1.TabIndex = 32;
            // 
            // registerImageCtl1
            // 
            this.registerImageCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registerImageCtl1.Location = new System.Drawing.Point(4, 534);
            this.registerImageCtl1.Margin = new System.Windows.Forms.Padding(4);
            this.registerImageCtl1.MinimumSize = new System.Drawing.Size(433, 47);
            this.registerImageCtl1.Name = "registerImageCtl1";
            this.registerImageCtl1.Size = new System.Drawing.Size(1084, 630);
            this.registerImageCtl1.TabIndex = 0;
            // 
            // registerMapCtl1
            // 
            this.registerMapCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registerMapCtl1.Location = new System.Drawing.Point(4, 4);
            this.registerMapCtl1.Margin = new System.Windows.Forms.Padding(4);
            this.registerMapCtl1.MinimumSize = new System.Drawing.Size(433, 47);
            this.registerMapCtl1.Name = "registerMapCtl1";
            this.registerMapCtl1.Size = new System.Drawing.Size(1084, 522);
            this.registerMapCtl1.TabIndex = 1;
            this.registerMapCtl1.txtxsize = null;
            this.registerMapCtl1.txtysize = null;
            this.registerMapCtl1.Worldfile = null;
            this.registerMapCtl1.xsize = 0;
            this.registerMapCtl1.ysize = 0;
            this.registerMapCtl1.Load += new System.EventHandler(this.registerMapCtl1_Load);
            this.registerMapCtl1.Click += new System.EventHandler(this.registerMapCtl1_Click);
            this.registerMapCtl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.registerMapCtl1_MouseClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.registerMapCtl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.registerImageCtl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.37671F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.62329F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1092, 1168);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // FrmGeoReference
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1092, 1168);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmGeoReference";
            this.Text = "Geo Reference Image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGeoReference_FormClosing);
            this.Load += new System.EventHandler(this.FrmGeoReference_Load);
            ((System.ComponentModel.ISupportInitialize)(this.simpleMapDb1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ExampleDb.SimpleMapDb simpleMapDb1;
        private Controls.RegisterImageCtl imageZoomlCtl1;
        private Controls.RegisterImageCtl registerImageCtl1;
        private Controls.RegisterMapCtl registerMapCtl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}