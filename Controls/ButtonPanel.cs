using System;
using System.IO;
using System.Windows.Forms;

namespace SimpleMap.Controls
{
    public partial class ButtonPanel : UserControl
    {
        public ButtonPanel()
        {
            InitializeComponent();
        }

        public int Level
        {
            get
            {
                return zoomLevel.Value;
            }
            set
            {
                zoomLevel.Value = value;
            }
        }

        public class LevelValueArgs : EventArgs
        {
            public int Level { get; private set; }

            public LevelValueArgs(int level)
            {
                Level = level;
            }
        }

        public event EventHandler<LevelValueArgs> LevelValueChanged;

        public event EventHandler CenterMapClicked;

        public event EventHandler PrintMapClicked;

        public event EventHandler RefreshMapClicked;

        public event EventHandler SaveAllMapClicked;

        public event EventHandler SaveMapAsImageClicked;

        public event EventHandler LoadGeoRefImageClicked;

        private void FrmDesignPanel_Load(object sender, EventArgs e)
        {
            zoomLevel.Maximum = Properties.Settings.Default.MaxZoomLevel;
            zoomLevel.Minimum = Properties.Settings.Default.MinZoomLevel;
            zoomLevel.Value = Properties.Settings.Default.StartZoomLevel;
        }

        private void zoomLevel_ValueChanged(object sender, EventArgs e)
        {
            if (LevelValueChanged != null && zoomLevel.Value >= Properties.Settings.Default.MinZoomLevel
                && zoomLevel.Value <= Properties.Settings.Default.MaxZoomLevel)
            {
                LevelValueChanged(this, new LevelValueArgs(zoomLevel.Value));
            }
        }

        private void btnCenterMap_Click(object sender, EventArgs e)
        {
            if (CenterMapClicked != null) CenterMapClicked(this, e);
        }

        private void btnRefreshMap_Click(object sender, EventArgs e)
        {
            if (RefreshMapClicked != null) RefreshMapClicked(this, e);   //GenerateSampleData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (PrintMapClicked != null) PrintMapClicked(this, EventArgs.Empty);
        }

        private void btnCacheAllMap_Click(object sender, EventArgs  e)
        {
            if (SaveAllMapClicked != null) SaveAllMapClicked(this, EventArgs.Empty);
        }

        private void btnSaveMapAsImage_Click(object sender, EventArgs e)
        {
            if (SaveMapAsImageClicked != null) SaveMapAsImageClicked(this, EventArgs.Empty);
        }

      

        private void btnLoadGeoRefImage_Click(object sender, EventArgs e)
        {
            if (LoadGeoRefImageClicked != null)
                LoadGeoRefImageClicked(this, EventArgs.Empty);
        }

        private void btnShapeData_Click(object sender, EventArgs e)
        {
            //GenerateSampleData();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}