using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleMap.Controls;

namespace SimpleMapApp
{
    public partial class FrmGeoReference : Form
    {
        public FrmGeoReference()
        {
            InitializeComponent();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            registerImageMapClt1.ControlClosing();
        }

        private void registerImageMapClt1_Load(object sender, EventArgs e)
        {

        }
    }
}
