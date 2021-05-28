using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleMap.Controls
{
    public partial class PointReferenceCtl : UserControl
    {
        public PointReferenceCtl()
        {
            InitializeComponent();
            
          

            //pointPairGrid1.DataSource = Model.Points;

            //mapControl1.Redraw();

            //UpdateCursor();

            //SetColumnFormats();

            //UpdateView();
        }

        private void SetColumnFormats()
        {
            //string format = _context.Map.MapUnits == LengthUnits.DecimalDegrees ? "f6" : "f2";
            //pointPairGrid1.Adapter.GetColumn(p => p.X1).Appearance.AnyCell.Format = format;
            //pointPairGrid1.Adapter.GetColumn(p => p.X2).Appearance.AnyCell.Format = format;
            //pointPairGrid1.Adapter.GetColumn(p => p.Y1).Appearance.AnyCell.Format = format;
            //pointPairGrid1.Adapter.GetColumn(p => p.Y2).Appearance.AnyCell.Format = format;
            //pointPairGrid1.ForceImmediateSaveValue();
        }

    }
}
